using FluentValidation;
using WebApi.BookOperations.CreateBook;

namespace WebApi.Operations.BookOperations.CreateBook
{
    public class CreateBookCommandValidator : AbstractValidator<CreateBookCommand>
    {
        public CreateBookCommandValidator()
        {
            RuleFor(command => command.Model.GenreId).GreaterThan(0);
            RuleFor(command => command.Model.PageCount).GreaterThan(0);
            RuleFor(command => command.Model.Title).NotNull().MinimumLength(3);
            RuleFor(command => command.Model.PublishDate).NotEmpty().NotNull().LessThan(DateTime.Now);
        }
    }
}
