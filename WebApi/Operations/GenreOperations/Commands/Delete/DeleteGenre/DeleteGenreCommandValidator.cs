using FluentValidation;

namespace WebApi.Operations.GenreOperations.Commands.Delete.DeleteGenre
{
    public class DeleteGenreCommandValidator : AbstractValidator<DeleteGenreCommand>
    {
        public DeleteGenreCommandValidator()
        {
            RuleFor(command => command.Id).GreaterThan(0);
        }
    }
}
