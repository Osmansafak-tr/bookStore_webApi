using FluentAssertions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebApi.Operations.GenreOperations.Queries.GetGenreById;
using WebApi.Operations.GenreOperations.Queries.GetGenres;

namespace WebApi.UnitTests.Operations.GenreOperations.Queries.GetGenreById
{
    public class GetGenreByIdQueryValidatorTests
    {
        [Fact]
        public void WhenInvalidGenreIdGiven_Validator_ShouldBeReturnError()
        {
            // Arrange
            GetGenreByIdQuery query = new GetGenreByIdQuery(null, null);
            query.Id = -1;

            // Act
            GetGenreByIdQueryValidator validator = new GetGenreByIdQueryValidator();
            var result = validator.Validate(query);

            // Assert
            result.Errors.Count.Should().Be(1);
        }

        [Fact]
        public void WhenValidGenreIdGiven_Validator_ShouldNotBeReturnError()
        {
            // Arrange
            GetGenreByIdQuery query = new GetGenreByIdQuery(null, null);
            query.Id = 1;

            // Act
            GetGenreByIdQueryValidator validator = new GetGenreByIdQueryValidator();
            var result = validator.Validate(query);

            // Assert
            result.Errors.Count.Should().Be(0);
        }
    }
}
