using AutoMapper;
using FluentAssertions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebApi.DB;
using WebApi.Operations.BookOperations.Commands.Delete.DeleteBook;
using WebApi.UnitTests.TestSetup;

namespace WebApi.UnitTests.Operations.BookOperations.Commands.Delete.DeleteBook
{
    public class DeleteBookCommandTests : IClassFixture<CommonTestFixture>
    {
        private readonly BookStoreDbContext _context;
        private readonly IMapper _mapper;

        public DeleteBookCommandTests(CommonTestFixture testFixture)
        {
            _context = testFixture.Context;
            _mapper = testFixture.Mapper;
        }

        [Fact]
        public void WhenInvalidBookIdGiven_KeyNotFoundException_ShouldBeReturned()
        {
            // Arrange
            DeleteBookCommand command = new DeleteBookCommand(_context);
            command.Id = int.MaxValue;

            // Act & Assert
            FluentActions
                .Invoking(() => command.Handle())
                .Should().Throw<KeyNotFoundException>().WithMessage("Book can not found with this id.");
        }

        public void WhenValidInputsGiven_Book_ShouldBeDeleted()
        {
            // Arrange
            DeleteBookCommand command = new DeleteBookCommand(_context);
            int bookId = 1;
            command.Id = bookId;

            // Act
            FluentActions.Invoking(() => command.Handle()).Invoke();

            // Assert
            var book = _context.Books.SingleOrDefault(x => x.Id == bookId);
            book.Should().BeNull();
        }
    }
}
