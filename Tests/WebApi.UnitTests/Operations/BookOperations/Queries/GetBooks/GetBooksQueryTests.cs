using AutoMapper;
using FluentAssertions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebApi.BookOperations.Queries.GetBooks;
using WebApi.DB;
using WebApi.UnitTests.TestSetup;

namespace WebApi.UnitTests.Operations.BookOperations.Queries.GetBooks
{
    public class GetBooksQueryTests : IClassFixture<CommonTestFixture>
    {
        public readonly BookStoreDbContext _context;
        public readonly IMapper _mapper;

        public GetBooksQueryTests(CommonTestFixture testFixture)
        {
            _context = testFixture.Context;
            _mapper = testFixture.Mapper;
        }

        [Fact]
        public void WhenInputsAreValid_Books_ShouldBeReturned()
        {
            // Arrange
            GetBooksQuery query = new GetBooksQuery(_context, _mapper);

            // Act
            var books = FluentActions.Invoking(() => query.Handle()).Invoke();

            // Assert
            books.Should().NotBeNull();

        }
    }
}
