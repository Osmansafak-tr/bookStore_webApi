using AutoMapper;
using FluentAssertions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebApi.DB;
using WebApi.Operations.GenreOperations.Queries.GetGenreById;
using WebApi.UnitTests.TestSetup;

namespace WebApi.UnitTests.Operations.GenreOperations.Queries.GetGenreById
{
    public class GetGenreByIdQueryTests : IClassFixture<CommonTestFixture>
    {
        private readonly BookStoreDbContext _context;
        private readonly IMapper _mapper;

        public GetGenreByIdQueryTests(CommonTestFixture testFixture)
        {
            _context = testFixture.Context;
            _mapper = testFixture.Mapper;
        }

        [Fact]
        public void WhenInvalidInputsAreGiven_KeyNotFoundException_ShouldBeReturned()
        {
            // Arrange
            GetGenreByIdQuery query = new GetGenreByIdQuery(_context,_mapper);
            query.Id = int.MaxValue;
            
            // Act & Assert
            FluentActions
                .Invoking(()=>query.Handle())
                .Should().ThrowExactly<KeyNotFoundException>("Genre key not found or genre is inactive.");
        }

        [Fact]
        public void WhenValidInputsAreGiven_Genre_ShouldBeReturned()
        {
            // Arrange
            GetGenreByIdQuery query = new GetGenreByIdQuery(_context, _mapper);
            query.Id = 1;

            // Act
            var genre =  FluentActions.Invoking(() => query.Handle()).Invoke();

            // Assert
            genre.Should().NotBeNull();
        }
    }
}
