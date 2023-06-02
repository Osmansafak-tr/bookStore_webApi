using FluentValidation;
using WebApi.Common;

namespace WebApi.Operations.BookOperations.Commands.Update.UpdateBook
{
    public class UpdateBookCommandValidator : AbstractValidator<UpdateBookCommand>
    {
        public UpdateBookCommandValidator()
        {
            // Model
            RuleFor(command => command.Model.Title).NotNull().MinimumLength(3);
            RuleFor(command => command.Model.GenreId).GreaterThan(0);
            RuleFor(command => command.Model.AuthorId).GreaterThan(0);
            RuleFor(command => command.Model.PageCount).GreaterThan(0);
            RuleFor(command => command.Model.PublishDate).LessThan(DateTime.Now);
            // Id
            RuleFor(command => command.Id).GreaterThan(0);
        }
    }
}
