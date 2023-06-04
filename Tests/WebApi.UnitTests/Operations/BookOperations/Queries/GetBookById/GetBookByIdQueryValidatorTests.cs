using FluentAssertions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebApi.Operations.BookOperations.Queries.GetById;

namespace WebApi.UnitTests.Operations.BookOperations.Queries.GetBookById
{
    public class GetBookByIdQueryValidatorTests
    {
        [Fact]
        public void WhenBookIdInvalidGiven_Validator_ShouldBeReturnAnError()
        {
            // Arrange
            GetBookByIdQuery query = new GetBookByIdQuery(null, null);
            query.Id = -1;

            // Act
            GetBookByIdQueryValidator validator = new GetBookByIdQueryValidator();
            var result = validator.Validate(query);

            // Arrange
            result.Errors.Count.Should().Be(1);
        }

        [Fact]
        public void WhenValidInputsGiven_Validator_ShouldNotReturnError()
        {
            // Arrange
            GetBookByIdQuery query = new GetBookByIdQuery(null, null);
            query.Id = 1;

            // Act
            GetBookByIdQueryValidator validator = new GetBookByIdQueryValidator();
            var result = validator.Validate(query);

            // Arrange
            result.Errors.Count.Should().Be(0);
        }
    }
}
