using FluentAssertions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebApi.DB;
using WebApi.Entities;
using WebApi.Operations.GenreOperations.Commands.Update.UpdateGenre;
using WebApi.UnitTests.TestSetup;

namespace WebApi.UnitTests.Operations.GenreOperations.Commands.Update.UpdateGenre
{
    public class UpdateGenreCommandTests : IClassFixture<CommonTestFixture>
    {
        private readonly BookStoreDbContext _context;

        public UpdateGenreCommandTests(CommonTestFixture testFixture)
        {
            _context = testFixture.Context;
        }

        [Fact]
        public void WhenGenreNotFound_KeyNotFoundException_ShouldBeReturned()
        {
            // Arrange
            UpdateGenreCommand command = new UpdateGenreCommand(_context);
            command.Id = int.MaxValue;
            command.Model = new UpdateGenreModel() { Name = "Name", IsActive = true };

            // Act & Assert
            FluentActions
                .Invoking(() => command.Handle())
                .Should().ThrowExactly<KeyNotFoundException>("Genre can not found with this id.");
        }

        [Fact]
        public void WhenThereIsAGenreWithSameName_InvalidOperationException_ShouldBeReturned()
        {
            // Arrange
            Genre newGenre = new Genre() { Name = "ForTestSameGenreNameInUpdate" };
            _context.Genres.Add(newGenre);
            _context.SaveChanges();

            UpdateGenreCommand command = new UpdateGenreCommand(_context);
            command.Id = 1;
            command.Model = new UpdateGenreModel() { Name = newGenre.Name, IsActive = true };

            // Act & Assert
            FluentActions
                .Invoking(() => command.Handle())
                .Should().ThrowExactly<InvalidOperationException>("There is a genre that already have this name.");
        }

        [Fact]
        public void WhenValidInputsAreGiven_Genre_ShouldBeUpdated()
        {
            // Arrange
            UpdateGenreCommand command = new UpdateGenreCommand(_context);
            int genreId = 1;
            UpdateGenreModel model = new UpdateGenreModel() { Name = "UpdateGenreValidInputsTest", IsActive = false };
            command.Id = genreId;
            command.Model = model;

            // Act
            FluentActions.Invoking(() => command.Handle()).Invoke();

            // Assert
            var genre = _context.Genres.SingleOrDefault(x => x.Id == genreId);
            genre.Should().NotBeNull();
            genre.Name.Should().Be(model.Name);
            genre.IsActive.Should().Be(model.IsActive);
        }
    }
}
