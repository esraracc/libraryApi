using Application.Services.Repositories;
using Core.CrossCuttingConcers.Exceptions;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Books.Rules
{
    public class BookBusinessRules
    {
        private readonly IBookRepository _bookRepository;

        public BookBusinessRules(IBookRepository bookRepository)
        {
            _bookRepository = bookRepository;
        }

        //public async Task BookNameCanNotBeDuplicatedWhenInserted(string name)
        //{
        //    Book result = await _bookRepository.GetAsync(b => b.Name == name);
        //    if (result.Name.Any()) throw new BusinessException("Book name exists.");
        //}

        public void BookShouldExistWhenRequested(Book book)
        {
            if (book == null) throw new BusinessException("Requested book does not exist");
        }

        public async Task BookShouldExistWhenRequestedAsync(int bookId)
        {
            Book book = await _bookRepository.GetAsync(x => x.Id == bookId);
            if (book.Count == 0) throw new BusinessException("Requested book does not exist");
        }

    }
}
