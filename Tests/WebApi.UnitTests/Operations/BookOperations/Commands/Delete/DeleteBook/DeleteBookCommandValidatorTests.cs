using FluentAssertions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebApi.Operations.BookOperations.Commands.Delete.DeleteBook;

namespace WebApi.UnitTests.Operations.BookOperations.Commands.Delete.DeleteBook
{
    public class DeleteBookCommandValidatorTests
    {
        [Fact]
        public void WhenBookIdLessThanZero_Validator_ShouldBeReturnAnError()
        {
            // Arrange
            DeleteBookCommand command = new DeleteBookCommand(null);
            command.Id = -1;

            // Act
            DeleteBookCommandValidator validator = new DeleteBookCommandValidator();
            var result = validator.Validate(command);

            // Assert
            result.Errors.Count.Should().Be(1);
        }
    }
}
