using Application.Features.Books.Dtos;
using Application.Features.Books.Rules;
using Application.Services.Repositories;
using AutoMapper;
using MediatR;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Features.Books.Queries.GetByIdBook
{
    public class GetByIdBookQuery : IRequest<BookGetByIdDto>
    {
        public int Id { get; set; }
        public class GetByIdBookQueryHandler : IRequestHandler<GetByIdBookQuery, BookGetByIdDto>
        {
            private readonly IBookRepository _bookRepository;
            private readonly IMapper _mapper;
            private readonly BookBusinessRules _bookBusinessRules;

            public GetByIdBookQueryHandler(IBookRepository bookRepository, IMapper mapper, BookBusinessRules bookBusinessRules)
            {
                _bookRepository = bookRepository;
                _mapper = mapper;
                _bookBusinessRules = bookBusinessRules;
            }

            public async Task<BookGetByIdDto> Handle(GetByIdBookQuery request, CancellationToken cancellationToken)
            {
                Book Book = await _bookRepository.GetAsync(x => x.Id == request.Id);

                _bookBusinessRules.BookShouldExistWhenRequested(Book);

                BookGetByIdDto bookGetByIdDto = _mapper.Map<BookGetByIdDto>(Book);
                return bookGetByIdDto;
            }
        }
    }
}
