using Application.Features.UserActionsOnTheBookRepository.Dtos;
using Application.Features.UserActionsOnTheBookRepository.Rules;
using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Features.UserActionsOnTheBookRepository.Commands.BookStatusUpdateCommand
{
    public class UpdateUserBookStatusCommand : IRequest<UpdatedBookStatusDto>
    {
        public int Id { get; set; }
        public BookStatus StatusOfTheBook { get; set; }
        public DateTime DeliveryDate { get; set; }

        public class UpdateUserBookStatusCommandHandler : IRequestHandler<UpdateUserBookStatusCommand, UpdatedBookStatusDto>
        {
            private readonly IUserActionsOnTheBookRepository _userActionsOnTheBookRepository;
            private readonly IBookRepository _bookRepository;
            private readonly UserBookBusinessRules _userBookBusinessRules;
            private readonly IMapper _mapper;

            public UpdateUserBookStatusCommandHandler(IUserActionsOnTheBookRepository userActionsOnTheBookRepository, IBookRepository bookRepository, UserBookBusinessRules userBookBusinessRules, IMapper mapper)
            {
                _userActionsOnTheBookRepository = userActionsOnTheBookRepository;
                _bookRepository = bookRepository;
                _userBookBusinessRules = userBookBusinessRules;
                _mapper = mapper;
            }

            public async Task<UpdatedBookStatusDto> Handle(UpdateUserBookStatusCommand request, CancellationToken cancellationToken)
            {
                await _userBookBusinessRules.UserBookShouldExistWhenRequestedAsync(request.Id);

                UserActionsOnTheBook mappedUserActionsOnTheBook = _mapper.Map<UserActionsOnTheBook>(request);

                mappedUserActionsOnTheBook.StatusOfTheBook = BookStatus.Return;
                UserActionsOnTheBook updatedUserBook = await _userActionsOnTheBookRepository.UpdateAsync(mappedUserActionsOnTheBook);
                UpdatedBookStatusDto updatedUserBookDto = _mapper.Map<UpdatedBookStatusDto>(updatedUserBook);

                Book book = await _bookRepository.GetAsync(x => x.Id == mappedUserActionsOnTheBook.BookId);
                book.Count++;
                await _bookRepository.UpdateAsync(book);

                return updatedUserBookDto;

            }
        }
    }
}

