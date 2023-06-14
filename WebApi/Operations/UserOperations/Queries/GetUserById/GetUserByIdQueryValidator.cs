using FluentValidation;

namespace WebApi.Operations.UserOperations.Queries.GetUserById
{
    public class GetUserByIdQueryValidator : AbstractValidator<GetUserByIdQuery>
    {
        public GetUserByIdQueryValidator()
        {
            RuleFor(query => query.Id).GreaterThan(0);
        }
    }
}
