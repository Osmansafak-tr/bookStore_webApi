using AutoMapper;
using FluentAssertions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebApi.DB;
using WebApi.Operations.GenreOperations.Queries.GetGenres;
using WebApi.UnitTests.TestSetup;

namespace WebApi.UnitTests.Operations.GenreOperations.Queries.GetGenres
{
    public class GetGenresQueryTests : IClassFixture<CommonTestFixture>
    {
        private readonly BookStoreDbContext _context;
        private readonly IMapper _mapper;

        public GetGenresQueryTests(CommonTestFixture testFixture)
        {
            _context = testFixture.Context;
            _mapper = testFixture.Mapper;
        }

        [Fact]
        public void WhenValidInputsAreGiven_Genres_ShouldBeReturned()
        {
            // Arrange
            GetGenresQuery query = new GetGenresQuery(_context,_mapper);

            // Act
            var model = FluentActions.Invoking(() => query.Handle()).Invoke();

            // Assert
            model.Should().NotBeNull();
        }

    }
}
