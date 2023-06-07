using FluentAssertions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebApi.Operations.GenreOperations.Commands.Delete.DeleteGenre;

namespace WebApi.UnitTests.Operations.GenreOperations.Commands.Delete.DeleteGenre
{
    public class DeleteGenreCommandValidatorTests
    {
        [Fact]
        public void WhenInvalidGenreIdGiven_Validator_ShouldReturnAnError()
        {
            // Arrange
            DeleteGenreCommand command = new DeleteGenreCommand(null);
            command.Id = -1;

            // Act
            DeleteGenreCommandValidator validator = new DeleteGenreCommandValidator();
            var result = validator.Validate(command);

            // Assert
            result.Errors.Count.Should().Be(1);
        }

        [Fact]
        public void WhenValidGenreIdGiven_Validator_ShouldNotReturnError()
        {
            // Arrange
            DeleteGenreCommand command = new DeleteGenreCommand(null);
            command.Id = 1;

            // Act
            DeleteGenreCommandValidator validator = new DeleteGenreCommandValidator();
            var result = validator.Validate(command);

            // Assert
            result.Errors.Count.Should().Be(0);
        }
    }
}
