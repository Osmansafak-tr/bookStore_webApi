using FluentValidation;

namespace WebApi.Operations.AuthorOperations.Commands.Delete
{
    public class DeleteAuthorCommandValidator : AbstractValidator<DeleteAuthorCommand>
    {
        public DeleteAuthorCommandValidator()
        {
            RuleFor(command => command.Id).GreaterThan(0);
        }
    }
}
