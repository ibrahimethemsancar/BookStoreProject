
using FluentValidation;

namespace WebApi.BookOperations.CreateBook
{
    public class GetBookDetailQueryValidator :AbstractValidator<GetBookDetailQuery>
    {
        public GetBookDetailQueryValidator()
        {
            RuleFor(command => command.BookId).NotEmpty().NotEqual(0).GreaterThan(0);
        }
    }
}