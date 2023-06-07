using AutoMapper;
using FluentAssertions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebApi.DB;
using WebApi.Operations.BookOperations.Queries.GetById;
using WebApi.UnitTests.TestSetup;

namespace WebApi.UnitTests.Operations.BookOperations.Queries.GetBookById
{
    public class GetBookByIdQueryTests : IClassFixture<CommonTestFixture>
    {
        private readonly BookStoreDbContext _context;
        private readonly IMapper _mapper;

        public GetBookByIdQueryTests(CommonTestFixture testFixture)
        {
            _context = testFixture.Context;
            _mapper = testFixture.Mapper;
        }

        [Fact]
        public void WhenInvalidBookIdGiven_KeyNotFoundException_ShouldBeReturned()
        {
            // Arrange
            GetBookByIdQuery query = new GetBookByIdQuery(_context,_mapper);
            query.Id = int.MaxValue;

            // Act & Assert
            FluentActions
                .Invoking(() => query.Handle())
                .Should().Throw<KeyNotFoundException>().WithMessage("Book can not found with this id.");
        }

        [Fact]
        public void WhenValidInputsAreGiven_Book_ShouldBePulledFromDatabase()
        {
            // Arrange
            GetBookByIdQuery query = new GetBookByIdQuery(_context, _mapper);
            int bookId = 1;
            query.Id = bookId;

            // Act
            var book =  FluentActions.Invoking(() => query.Handle()).Invoke();

            // Assert
            book.Should().NotBeNull();
        }
    }
}
