using Application.Features.Books.Dtos;
using Application.Features.Books.Rules;
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

namespace Application.Features.Books.Commands.CreateBook
{
    public partial class CreateBookCommand : IRequest<CreatedBookDto>
    {
        public string Name { get; set; }
        public int PageCount { get; set; }
        public int Count { get; set; }
        public string AuthorName { get; set; }

        public class CreateBookCommandHandler : IRequestHandler<CreateBookCommand, CreatedBookDto>
        {
            private readonly IBookRepository _bookRepository;
            private readonly IMapper _mapper;
            private readonly BookBusinessRules _bookBusinessRules;

            public CreateBookCommandHandler(IBookRepository bookRepository, IMapper mapper, BookBusinessRules bookBusinessRules)
            {
                _bookRepository = bookRepository;
                _mapper = mapper;
                _bookBusinessRules = bookBusinessRules;
            }

            public async Task<CreatedBookDto> Handle(CreateBookCommand request, CancellationToken cancellationToken)
            {
                //await _bookBusinessRules.BookNameCanNotBeDuplicatedWhenInserted(request.Name);

                Book mappedBook = _mapper.Map<Book>(request);
                Book createdBook = await _bookRepository.AddAsync(mappedBook);
                CreatedBookDto createdBookDto = _mapper.Map<CreatedBookDto>(createdBook);

                return createdBookDto;

            }
        }
    }
}
