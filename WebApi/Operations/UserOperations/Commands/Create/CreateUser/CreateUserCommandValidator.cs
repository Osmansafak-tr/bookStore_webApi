using FluentValidation;

namespace WebApi.Operations.UserOperations.Commands.Create.CreateUser
{
    public class CreateUserCommandValidator : AbstractValidator<CreateUserCommand>
    {
        public CreateUserCommandValidator()
        {
            RuleFor(command => command.Model.Email).MinimumLength(10);
            RuleFor(command => command.Model.Name).MinimumLength(3);
            RuleFor(command => command.Model.Surname).MinimumLength(3);
            RuleFor(command => command.Model.Password).MinimumLength(8);
        }
    }
}
