using AutoMapper;
using FluentAssertions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebApi.DB;
using WebApi.Entities;
using WebApi.Operations.GenreOperations.Commands.Create.CreateGenre;
using WebApi.UnitTests.TestSetup;

namespace WebApi.UnitTests.Operations.GenreOperations.Commands.Create.CreateGenre
{
    public class CreateGenreCommandTests : IClassFixture<CommonTestFixture>
    {
        private readonly BookStoreDbContext _context;
        private readonly IMapper _mapper;

        public CreateGenreCommandTests(CommonTestFixture testFixture)
        {
            _context = testFixture.Context;
            _mapper = testFixture.Mapper;
        }

        [Fact]
        public void WhenSameGenreAlreadyBeenCreated_InvalidOperationException_ShouldBeReturned()
        {

            // Arrange
            var genre = new Genre() { Name = "ForTestPurposes" };
            _context.Genres.Add(genre);
            _context.SaveChanges();

            CreateGenreCommand command = new CreateGenreCommand(_context, _mapper);
            command.Model = new CreateGenreModel() { Name = genre.Name };

            // Assert & Act
            FluentActions
                .Invoking( () => command.Handle() )
                .Should().Throw<InvalidOperationException>().WithMessage("Same genre already created");
        }

        [Fact]
        public void WhenValidInputsGiven_Genre_ShouldBeCreated()
        {
            // Arrange
            CreateGenreCommand command = new CreateGenreCommand(_context, _mapper);
            string genreName = "TestGenre";
            command.Model = new CreateGenreModel() { Name = genreName };

            // Act
            FluentActions.Invoking(() => command.Handle()).Invoke();
            
            // Assert
            var genre = _context.Genres.SingleOrDefault(x => x.Name == genreName);
            genre.Should().NotBeNull();
            genre.IsActive.Should().Be(true);
        }
    }
}
