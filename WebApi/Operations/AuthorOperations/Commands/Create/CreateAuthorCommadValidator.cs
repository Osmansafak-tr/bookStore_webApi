using FluentValidation;

namespace WebApi.Operations.AuthorOperations.Commands.Create
{
    public class CreateAuthorCommadValidator : AbstractValidator<CreateAuthorCommand>
    {
        public CreateAuthorCommadValidator()
        {
            RuleFor(comand => comand.Model.Name).MinimumLength(3);
            RuleFor(comand => comand.Model.LastName).MinimumLength(3);
            RuleFor(comand => comand.Model.DateOfBirth).LessThan(DateTime.Now);
        }
    }
}
