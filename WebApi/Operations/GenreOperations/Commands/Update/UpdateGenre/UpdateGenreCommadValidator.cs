using FluentValidation;

namespace WebApi.Operations.GenreOperations.Commands.Update.UpdateGenre
{
    public class UpdateGenreCommadValidator : AbstractValidator<UpdateGenreCommand>
    {
        public UpdateGenreCommadValidator()
        {
            //Model
            RuleFor(command => command.Model.Name.Trim()).MinimumLength(3);
            // Id
            RuleFor(command => command.Id).GreaterThan(0);
        }
    }
}
