
using FluentValidation;
using WebApi.Application.BookOperations.Queries.GetBook;

namespace WebApi.Application.BookOperations.Queries.GetBook
{
    public class GetBookDetailQueryValidator :AbstractValidator<GetBookDetailQuery>
    {
        public GetBookDetailQueryValidator()
        {
            RuleFor(command => command.BookId).NotEmpty().NotEqual(0).GreaterThan(0);
        }
    }
}