﻿using FluentValidation;
using WebApi.BookOperations.Commands.Create.CreateBook;

namespace WebApi.BookOperations.Commands.Create.CreateBook
{
    public class CreateBookCommandValidator : AbstractValidator<CreateBookCommand>
    {
        public CreateBookCommandValidator()
        {
            RuleFor(command => command.Model.GenreId).GreaterThan(0);
            RuleFor(command => command.Model.AuthorId).GreaterThan(0);
            RuleFor(command => command.Model.PageCount).GreaterThan(0);
            RuleFor(command => command.Model.Title).NotNull().MinimumLength(3);
            RuleFor(command => command.Model.PublishDate).NotEmpty().NotNull().LessThan(DateTime.Now.Date);
        }
    }
}
