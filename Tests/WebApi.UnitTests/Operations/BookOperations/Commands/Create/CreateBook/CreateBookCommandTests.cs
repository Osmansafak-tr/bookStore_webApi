using AutoMapper;
using FluentAssertions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebApi.BookOperations.Commands.Create.CreateBook;
using WebApi.DB;
using WebApi.Entities;
using WebApi.UnitTests.TestSetup;
using Xunit;

namespace WebApi.UnitTests.Operations.BookOperations.Commands.Create.CreateBook
{
    public class CreateBookCommandTests : IClassFixture<CommonTestFixture>
    {
        private readonly BookStoreDbContext _context;
        private readonly IMapper _mapper;

        public CreateBookCommandTests(CommonTestFixture testFixture)
        {
            _context = testFixture.Context;
            _mapper = testFixture.Mapper;
        }

        [Fact]
        public void WhenAlreadyExistBookTitleGiven_InvalidOperationException_ShouldBeReturn()
        {
            // Arrange
            var book = new Book()
            {
                Title = "WhenAlreadyExistBookTitleGiven_InvalidOperationException_ShouldBeReturn",
                GenreId = 1,
                AuthorId = 1,
                PageCount = 100,
                PublishDate = new DateTime(2002, 02, 02)
            };
            _context.Books.Add(book);
            _context.SaveChanges();

            CreateBookCommand command = new CreateBookCommand(_context, _mapper);
            command.Model = new CreateBookModel() { Title = book.Title };
            // Act and Assert
            FluentActions
                .Invoking(() => command.Handle())
                .Should().Throw<InvalidOperationException>().WithMessage("Same book already created.");
        }

        [Fact]
        public void WhenValidInputsAreGiven_Book_ShouldBeCreated()
        {
            // Arrange
            CreateBookCommand command = new CreateBookCommand(_context, _mapper);
            CreateBookModel model = new CreateBookModel() { Title = "Title", GenreId = 1, AuthorId = 1, PageCount = 100, PublishDate = DateTime.Now.AddYears(-1).Date };
            command.Model = model;

            // Act
            FluentActions.Invoking(() => command.Handle()).Invoke();

            // Assert
            var book = _context.Books.SingleOrDefault(x => x.Title == model.Title);
            book.Should().NotBeNull();
            book.AuthorId.Should().Be(model.AuthorId);
            book.GenreId.Should().Be(model.GenreId);
            book.PageCount.Should().Be(model.PageCount);
            book.PublishDate.Should().Be(model.PublishDate);
        }
    }
}
