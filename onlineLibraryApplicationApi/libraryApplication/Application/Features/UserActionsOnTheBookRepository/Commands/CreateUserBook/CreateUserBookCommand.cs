using Application.Features.Books.Rules;
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

namespace Application.Features.UserActionsOnTheBookRepository.Commands.CreateUserBook
{
    public class CreateUserBookCommand : IRequest<CreatedUserBookDto>
    {
        public string UserId { get; set; }
        public int BookId { get; set; }
        public BookStatus StatusOfTheBook { get; set; }
        public DateTime ReserveDate { get; set; }
        public DateTime ReturnDate { get; set; }
        public class CreateUserBookCommandHandler : IRequestHandler<CreateUserBookCommand, CreatedUserBookDto>
        {
            private readonly IUserActionsOnTheBookRepository _userActionsOnTheBookRepository;
            private readonly IBookRepository _bookRepository;
            private readonly IMapper _mapper;
            private readonly UserBookBusinessRules _userBookBusinessRules;
            private readonly BookBusinessRules _bookBusinessRules;

            public CreateUserBookCommandHandler(IUserActionsOnTheBookRepository userActionsOnTheBookRepository, IBookRepository bookRepository, IMapper mapper, UserBookBusinessRules userBookBusinessRules,
                 BookBusinessRules bookBusinessRules)
            {
                _userActionsOnTheBookRepository = userActionsOnTheBookRepository;
                _bookRepository = bookRepository;
                _mapper = mapper;
                _userBookBusinessRules = userBookBusinessRules;
                _bookBusinessRules = bookBusinessRules;
            }

            public async Task<CreatedUserBookDto> Handle(CreateUserBookCommand request, CancellationToken cancellationToken)
            {
                await _userBookBusinessRules.NoMoreThanThreeBooksShouldBeSaved(request.UserId);
                await _bookBusinessRules.BookShouldExistWhenRequestedAsync(request.BookId);

                UserActionsOnTheBook mappedUserBook = _mapper.Map<UserActionsOnTheBook>(request);
                UserActionsOnTheBook createdUserBook = await _userActionsOnTheBookRepository.AddAsync(mappedUserBook);
                CreatedUserBookDto createdUserBookDto = _mapper.Map<CreatedUserBookDto>(createdUserBook);

                Book book = await _bookRepository.GetAsync(x => x.Id == request.BookId);
                book.Count--;
                await _bookRepository.UpdateAsync(book);

                return createdUserBookDto;

            }
        }
    }
}
