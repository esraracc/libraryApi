using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.UserActionsOnTheBookRepository.Commands.CreateUserBook
{
    public class CreateUserBookCommandValidator : AbstractValidator<CreateUserBookCommand>
    {
        public CreateUserBookCommandValidator()
        {
            RuleFor(x => x.UserId).NotEmpty();
            RuleFor(x => x.BookId).NotEmpty();
            RuleFor(x => x.ReserveDate).NotEmpty();
            RuleFor(x => x.ReturnDate).NotEmpty();

            RuleFor(x => x.UserId).NotNull();
            RuleFor(x => x.BookId).NotNull();
            RuleFor(x => x.ReserveDate).NotNull();
            RuleFor(x => x.ReturnDate).NotNull();
        }
    }
}
