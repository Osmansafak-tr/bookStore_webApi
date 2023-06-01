using FluentValidation;

namespace WebApi.Operations.AuthorOperations.Commands.Update
{
    public class UpdateAuthorCommandValidator : AbstractValidator<UpdateAuthorCommand>
    {
        public UpdateAuthorCommandValidator()
        {
            // Model
            RuleFor(comand => comand.Model.Name).MinimumLength(3);
            RuleFor(comand => comand.Model.LastName).MinimumLength(3);
            RuleFor(comand => comand.Model.DateOfBirth).LessThan(DateTime.Now);
            // Id
            RuleFor(command => command.Id).GreaterThan(0);
        }
    }
}
