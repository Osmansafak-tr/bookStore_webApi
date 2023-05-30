using FluentValidation;

namespace WebApi.Operations.BookOperations.GetById
{
    public class GetBookByIdQueryValidator : AbstractValidator<GetBookByIdQuery>
    {
        public GetBookByIdQueryValidator()
        {
            RuleFor(query => query.Id).GreaterThan(0);
        }
    }
}
