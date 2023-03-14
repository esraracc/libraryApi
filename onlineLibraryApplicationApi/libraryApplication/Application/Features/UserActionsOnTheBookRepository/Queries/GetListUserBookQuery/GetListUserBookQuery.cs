using Application.Services.Repositories;
using Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Features.UserActionsOnTheBookRepository.Queries.GetListUserBookQuery
{
    public class GetListUserBookQuery : IRequest<List<UserActionsOnTheBook>>
    {
        public class GetListBookQueryCopyHandler : IRequestHandler<GetListUserBookQuery, List<UserActionsOnTheBook>>
        {
            IUserActionsOnTheBookRepository _userActionsOnTheBookRepository;

            public GetListBookQueryCopyHandler(IUserActionsOnTheBookRepository userActionsOnTheBookRepository)
            {
                _userActionsOnTheBookRepository = userActionsOnTheBookRepository;
            }

            public async Task<List<UserActionsOnTheBook>> Handle(GetListUserBookQuery request, CancellationToken cancellationToken)
            {
                List<UserActionsOnTheBook> books = (List<UserActionsOnTheBook>)await _userActionsOnTheBookRepository.GetAllListAsync();

                return books;
            }
        }
    }
}
