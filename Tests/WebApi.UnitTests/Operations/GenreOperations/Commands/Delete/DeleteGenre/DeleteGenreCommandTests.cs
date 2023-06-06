using AutoMapper;
using FluentAssertions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebApi.DB;
using WebApi.Operations.GenreOperations.Commands.Delete.DeleteGenre;
using WebApi.UnitTests.TestSetup;

namespace WebApi.UnitTests.Operations.GenreOperations.Commands.Delete.DeleteGenre
{
    public class DeleteGenreCommandTests : IClassFixture<CommonTestFixture>
    {
        private readonly BookStoreDbContext _context;

        public DeleteGenreCommandTests(CommonTestFixture testFixture)
        {
            _context = testFixture.Context;
        }

        [Fact]
        public void WhenInvalidGenreIdGiven_KeyNotFoundException_ShoulBeReturned()
        {
            // Arrange
            DeleteGenreCommand command = new DeleteGenreCommand(_context);
            command.Id = int.MaxValue;

            // Act & Assert
            FluentActions
                .Invoking(() => command.Handle())
                .Should().Throw<KeyNotFoundException>().WithMessage("Genre can not found with this id.");
        }

        [Fact]
        public void WhenValidGenreIdGiven_KeyNotFoundException_ShoulBeReturned()
        {
            // Arrange
            var genre = _context.Genres.FirstOrDefault();
            int genreId = genre.Id;

            DeleteGenreCommand command = new DeleteGenreCommand(_context);
            command.Id = genreId;

            // Act
            FluentActions.Invoking(() => command.Handle()).Invoke();

            // Assert
            genre = _context.Genres.SingleOrDefault(x => x.Id == genreId);
            genre.Should().BeNull();
        }
    }
}
