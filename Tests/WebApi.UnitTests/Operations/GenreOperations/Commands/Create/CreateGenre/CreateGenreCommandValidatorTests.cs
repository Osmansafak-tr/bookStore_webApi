using FluentAssertions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebApi.Operations.GenreOperations.Commands.Create.CreateGenre;

namespace WebApi.UnitTests.Operations.GenreOperations.Commands.Create.CreateGenre
{
    public class CreateGenreCommandValidatorTests
    {
        [Fact]
        public void WhenInvalidNameGiven_Validator_ShouldBeReturnErrors()
        {
            // Arrange
            CreateGenreCommand command = new CreateGenreCommand(null, null);
            command.Model = new CreateGenreModel() { Name = ""};

            // Act
            CreateGenreCommandValidator validator = new CreateGenreCommandValidator();
            var result = validator.Validate(command);

            // Assert
            result.Errors.Count.Should().Be(1);
        }

        [Fact]
        public void WhenValidNameGiven_Validator_ShouldBeReturnErrors()
        {
            // Arrange
            CreateGenreCommand command = new CreateGenreCommand(null, null);
            command.Model = new CreateGenreModel() { Name = "ValidName" };

            // Act
            CreateGenreCommandValidator validator = new CreateGenreCommandValidator();
            var result = validator.Validate(command);

            // Assert
            result.Errors.Count.Should().Be(0);
        }
    }
}
