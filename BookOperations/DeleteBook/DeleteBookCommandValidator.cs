 using System;
using System.Linq;
using System.Reflection.Metadata;
using FluentValidation;
using webApi.DBOperations;

namespace WebApi.BookOperations.DeleteBook
{
    public class DeleteBookCommandValidator : AbstractValidator<DeleteBookCommand>
    {
        public DeleteBookCommandValidator()
        {
            RuleFor(command => command.BookId).GreaterThan(0);
            
        }
    }
}