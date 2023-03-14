using Application.Services.Repositories;
using Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Features.Books.Queries.GetListBook
{
    public class GetListBookQuery : IRequest<List<Book>>
    {
        public class GetListBookQueryCopyHandler : IRequestHandler<GetListBookQuery, List<Book>>
        {
            IBookRepository _bookRepository;

            public GetListBookQueryCopyHandler(IBookRepository bookRepository)
            {
                _bookRepository = bookRepository;
            }

            public async Task<List<Book>> Handle(GetListBookQuery request, CancellationToken cancellationToken)
            {
                List<Book> books = (List<Book>)await _bookRepository.GetAllListAsync();

                return  books;
            }
        }
    }
}
