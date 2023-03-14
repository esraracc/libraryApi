using Application.Services.Repositories;
using Core.CrossCuttingConcers.Exceptions;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.UserActionsOnTheBookRepository.Rules
{
    public class UserBookBusinessRules
    {
        private readonly IUserActionsOnTheBookRepository _userActionsOnTheBookRepository;
        private readonly IBookRepository _bookRepository;

        public UserBookBusinessRules(IUserActionsOnTheBookRepository userActionsOnTheBookRepository, IBookRepository bookRepository)
        {
            _userActionsOnTheBookRepository = userActionsOnTheBookRepository;
            _bookRepository = bookRepository;
        }

        public async Task NoMoreThanThreeBooksShouldBeSaved(string userId)
        {
            var result = await _userActionsOnTheBookRepository.GetAllListAsync(x => x.UserId == userId && x.StatusOfTheBook == BookStatus.Reservation);
            if (result.Count() == 3) throw new BusinessException("You can have up to 3 undelivered books");
        }

        public async Task UserBookShouldExistWhenRequestedAsync(int userBookId)
        {
            UserActionsOnTheBook book = await _userActionsOnTheBookRepository.GetAsync(x => x.Id == userBookId);
            if (book == null) throw new BusinessException("Requested user book does not exist");
        }

    }
}
