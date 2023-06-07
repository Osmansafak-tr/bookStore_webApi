using FluentAssertions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebApi.BookOperations.Commands.Create.CreateBook;
using WebApi.Operations.BookOperations.Commands.Update.UpdateBook;
using Xunit;

namespace WebApi.UnitTests.Operations.BookOperations.Commands.Update.UpdateBook
{
    public class UpdateBookCommandValidatorTests
    {

        private static IEnumerable<object[]> GetData()
        {
            
            var allData = new List<object[]>
            {
                new object[] { 0, "",0,0,0,DateTime.Now.AddYears(1) },
                new object[] { 0, "",0,0,0,DateTime.Now.AddYears(-1) },
                new object[] { 0, "",0,0,1,DateTime.Now.AddYears(1) },
                new object[] { 0, "",0,0,1,DateTime.Now.AddYears(-1) },
                new object[] { 0, "",0,1,0,DateTime.Now.AddYears(1) },
                new object[] { 0, "",0,1,0,DateTime.Now.AddYears(-1) },
                new object[] { 0, "",0,1,1,DateTime.Now.AddYears(1) },
                new object[] { 0, "",0,1,1,DateTime.Now.AddYears(-1) },
                new object[] { 0, "",1,0,0,DateTime.Now.AddYears(1) },
                new object[] { 0, "",1,0,0,DateTime.Now.AddYears(-1) },
                new object[] { 0, "",1,0,1,DateTime.Now.AddYears(1) },
                new object[] { 0, "",1,0,1,DateTime.Now.AddYears(-1) },
                new object[] { 0, "",1,1,0,DateTime.Now.AddYears(1) },
                new object[] { 0, "",1,1,0,DateTime.Now.AddYears(-1) },
                new object[] { 0, "",1,1,1,DateTime.Now.AddYears(1) },
                new object[] { 0, "",1,1,1,DateTime.Now.AddYears(-1) },
                new object[] { 0, "string",1,1,1,DateTime.Now.AddYears(-1) },
                new object[] { 1, "",1,1,1,DateTime.Now.AddYears(-1) },
            };

            return allData;
        }

        [Theory]
        [MemberData(nameof(GetData))]
        public void WhenInvalidInputsAreGiven_Validator_ShouldBeReturnErrors(int id, string title, int genreId, int authorId, int pageCount, DateTime publishDate)
        {
            // Arrange
            UpdateBookCommand command = new UpdateBookCommand(null);
            command.Id = id;
            command.Model = new UpdateBookModel() { Title = title, GenreId = genreId, AuthorId = authorId, PageCount = pageCount, PublishDate = publishDate };

            // Act 
            UpdateBookCommandValidator validator = new UpdateBookCommandValidator();
            var result = validator.Validate(command);

            // Assert
            result.Errors.Count.Should().BeGreaterThan(0);
        }

        [Fact]
        public void WhenValidInputsAreGiven_Validator_ShouldNotReturnError()
        {
            // Arrange
            UpdateBookCommand command = new UpdateBookCommand(null);
            command.Id = 1;
            command.Model = new UpdateBookModel() { Title = "Title", GenreId = 1, AuthorId = 1, PageCount = 100, PublishDate = DateTime.Now.AddYears(-1) };

            // Act 
            UpdateBookCommandValidator validator = new UpdateBookCommandValidator();
            var result = validator.Validate(command);

            // Assert
            result.Errors.Count.Should().Be(0);
        }
    }
}
