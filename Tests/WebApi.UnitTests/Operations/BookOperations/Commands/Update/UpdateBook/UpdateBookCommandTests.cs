using FluentAssertions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebApi.DB;
using WebApi.Operations.BookOperations.Commands.Update.UpdateBook;
using WebApi.UnitTests.TestSetup;

namespace WebApi.UnitTests.Operations.BookOperations.Commands.Update.UpdateBook
{
    public class UpdateBookCommandTests : IClassFixture<CommonTestFixture>
    {
        private readonly BookStoreDbContext _context;

        public UpdateBookCommandTests(CommonTestFixture testFixture)
        {
            _context = testFixture.Context;
        }

        [Fact]
        public void WhenInvalidBookIdGiven_KeyNotFoundException_ShoulBeReturned()
        {
            // Assert
            UpdateBookCommand command = new UpdateBookCommand(_context);
            command.Id = int.MaxValue;
            command.Model = new UpdateBookModel();

            // Act & Assert
            FluentActions
                .Invoking(() => command.Handle())
                .Should().Throw<KeyNotFoundException>().WithMessage("Book can not found with this id.");
        }

        public void WhenValidInputsGiven_Book_ShouldBeUpdated()
        {
            // Assert
            UpdateBookCommand command = new UpdateBookCommand(_context);
            int bookId = 1;
            UpdateBookModel model = new UpdateBookModel() {Title="Title",AuthorId=1,GenreId=1,PageCount=100,PublishDate=DateTime.Now.AddYears(-1)};
            command.Id = bookId;
            command.Model = model;

            // Act
            FluentActions.Invoking(() => command.Handle()).Invoke();

            // Assert
            var book = _context.Books.SingleOrDefault(x => x.Id == bookId);
            book.Should().NotBeNull();
            book.Title.Should().Be(model.Title);
            book.AuthorId.Should().Be(model.AuthorId);
            book.GenreId.Should().Be(model.GenreId);
            book.PageCount.Should().Be(model.PageCount);
            book.PublishDate.Should().Be(model.PublishDate);
        }
    }
}
