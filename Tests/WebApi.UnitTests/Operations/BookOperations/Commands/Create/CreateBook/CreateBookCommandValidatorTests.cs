using FluentAssertions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebApi.BookOperations.Commands.Create.CreateBook;

namespace WebApi.UnitTests.Operations.BookOperations.Commands.Create.CreateBook
{
    public class CreateBookCommandValidatorTests
    {
        [Theory]
        [InlineData("", 0, 0, 0)]
        [InlineData("", 0, 0, 1)]
        [InlineData("", 0, 1, 0)]
        [InlineData("", 0, 1, 1)]
        [InlineData("", 1, 0, 0)]
        [InlineData("", 1, 0, 1)]
        [InlineData("", 1, 1, 0)]
        [InlineData("", 1, 1, 1)]
        [InlineData("string", 0, 0, 0)]
        [InlineData("string", 0, 0, 1)]
        [InlineData("string", 0, 1, 0)]
        [InlineData("string", 0, 1, 1)]
        [InlineData("string", 1, 0, 0)]
        [InlineData("string", 1, 0, 1)]
        [InlineData("string", 1, 1, 0)]
        public void WhenInvalidInputsGiven_Validator_ShouldBeReturnErrors(string title, int genreId, int authorId, int pageCount)
        {
            // Arrange
            CreateBookCommand command = new CreateBookCommand(null, null);
            command.Model = new CreateBookModel() { Title = title, GenreId = genreId, AuthorId = authorId, PageCount = pageCount, PublishDate = DateTime.Now.AddYears(-1) };

            // Act
            CreateBookCommandValidator validator = new CreateBookCommandValidator();
            var result = validator.Validate(command);

            // Assert
            result.Errors.Count().Should().BeGreaterThan(0);
        }

        [Fact]
        public void WhenDateTimeEqualNowGiven_Validator_ShouldBeReturnError()
        {
            // Arrange
            CreateBookCommand command = new CreateBookCommand(null, null);
            command.Model = new CreateBookModel() { Title = "string", GenreId = 1, AuthorId = 1, PageCount = 100, PublishDate = DateTime.Now.Date };

            // Act
            CreateBookCommandValidator validator = new CreateBookCommandValidator();
            var result = validator.Validate(command);

            // Assert
            result.Errors.Count().Should().Be(1);
        }

        [Fact]
        public void WhenValidInputsAreGiven_Validator_ShouldNotBeReturnAnError()
        {
            // Arrange
            CreateBookCommand command = new CreateBookCommand(null, null);
            command.Model = new CreateBookModel() { Title = "string", GenreId = 1, AuthorId = 1, PageCount = 100, PublishDate = DateTime.Now.AddYears(-1).Date };

            // Act
            CreateBookCommandValidator validator = new CreateBookCommandValidator();
            var result = validator.Validate(command);

            // Assert
            result.Errors.Count().Should().Be(0);
        }
    }
}
