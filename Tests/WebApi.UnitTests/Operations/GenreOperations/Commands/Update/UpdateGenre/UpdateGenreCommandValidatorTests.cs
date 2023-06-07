using FluentAssertions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebApi.Operations.GenreOperations.Commands.Update.UpdateGenre;

namespace WebApi.UnitTests.Operations.GenreOperations.Commands.Update.UpdateGenre
{
    public class UpdateGenreCommandValidatorTests
    {
        [Theory]
        [InlineData(-1," ")]
        [InlineData(-1, "string")]
        [InlineData(1, " ")]
        public void WhenInvalidInputsAreGiven_Validator_ShouldBeReturnError(int id,string name)
        {
            // Arrange
            UpdateGenreCommand command = new UpdateGenreCommand(null);
            command.Id = id;
            command.Model = new UpdateGenreModel() { Name = name, IsActive = true };

            // Act
            UpdateGenreCommadValidator validator = new UpdateGenreCommadValidator();
            var result =  validator.Validate(command);

            // Assert
            result.Errors.Count.Should().BeGreaterThan(0);
        }

        public void WhenValidInputsAreGiven_Validator_ShouldNotBeReturnError()
        {
            // Arrange
            UpdateGenreCommand command = new UpdateGenreCommand(null);
            command.Id = 1;
            command.Model = new UpdateGenreModel() { Name = "ValidName", IsActive = true };

            // Act
            UpdateGenreCommadValidator validator = new UpdateGenreCommadValidator();
            var result = validator.Validate(command);

            // Assert
            result.Errors.Count.Should().Be(0);
        }
    }
}
