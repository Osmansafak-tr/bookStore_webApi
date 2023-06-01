using FluentValidation;

namespace WebApi.Operations.GenreOperations.Commands.Create.CreateGenre
{
    public class CreateGenreCommandValidator : AbstractValidator<CreateGenreCommand>
    {
        public CreateGenreCommandValidator()
        {
            RuleFor(command => command.Model.Name).MinimumLength(3);
        }
    }
}
