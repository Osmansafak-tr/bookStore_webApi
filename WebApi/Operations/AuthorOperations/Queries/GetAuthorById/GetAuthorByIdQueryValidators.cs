using FluentValidation;

namespace WebApi.Operations.AuthorOperations.Queries.GetAuthorById
{
    public class GetAuthorByIdQueryValidators : AbstractValidator<GetAuthorByIdQuery>
    {
        public GetAuthorByIdQueryValidators()
        {
            RuleFor(query => query.Id).GreaterThan(0);
        }
    }
}
