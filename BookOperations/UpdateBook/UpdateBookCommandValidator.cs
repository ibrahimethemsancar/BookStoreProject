 using System;
using System.Linq;
using FluentValidation;
using webApi.DBOperations;

namespace WebApi.BookOperations.UpdateBook
{
    public class UpdateBookCommandValidator : AbstractValidator<UpdateBookCommand>
    {
        public UpdateBookCommandValidator()
        {
            RuleFor(command => command.Model.Title).NotEmpty().MinimumLength(2);
            RuleFor(command => command.Model.GenreId).NotEmpty().NotEqual(0);

        }
    }
}