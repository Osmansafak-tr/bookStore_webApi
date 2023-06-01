using AutoMapper;
using FluentValidation;
using Microsoft.AspNetCore.Mvc;
using WebApi.DBOperations;
using WebApi.Operations.GenreOperations.Commands.Create.CreateGenre;
using WebApi.Operations.GenreOperations.Commands.Delete.DeleteGenre;
using WebApi.Operations.GenreOperations.Commands.Update.UpdateGenre;
using WebApi.Operations.GenreOperations.Queries.GetGenreById;
using WebApi.Operations.GenreOperations.Queries.GetGenres;

namespace WebApi.Controllers
{
    [ApiController]
    [Route("[controller]s")]
    public class GenreController : Controller
    {
        private readonly BookStoreDbContext _context;
        private readonly IMapper _mapper;

        public GenreController(BookStoreDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        [HttpGet]
        public IActionResult GetGenres()
        {
            GetGenresQuery query = new GetGenresQuery(_context, _mapper);
            var genres = query.Handle();
            return Ok(genres);
        }

        [HttpGet("{id}")]
        public IActionResult GetGenreById(int id)
        {
            GetGenreByIdQuery query = new GetGenreByIdQuery(_context, _mapper);
            query.Id = id;
            // Validation
            GetGenreByIdQueryValidator validator = new GetGenreByIdQueryValidator();
            validator.ValidateAndThrow(query);
            //Handle
            var genre = query.Handle();
            return Ok(genre);
        }

        [HttpPost]
        public IActionResult CreateGenre([FromBody] CreateGenreModel genreModel)
        {
            CreateGenreCommand command = new CreateGenreCommand(_context, _mapper);
            command.Model = genreModel;
            // Validation
            CreateGenreCommandValidator validator = new CreateGenreCommandValidator();
            validator.ValidateAndThrow(command);
            // Handle
            command.Handle();
            return Ok();
        }

        [HttpPut("{id}")]
        public IActionResult UpdateGenre([FromBody] UpdateGenreModel genreModel,int id)
        {
            UpdateGenreCommand command = new UpdateGenreCommand(_context);
            command.Model = genreModel;
            command.Id = id;
            // Validation
            UpdateGenreCommadValidator validator = new UpdateGenreCommadValidator();
            validator.ValidateAndThrow(command);
            // Handle
            command.Handle();
            return Ok();
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteGenre(int id)
        {
            DeleteGenreCommand command = new DeleteGenreCommand(_context);
            command.Id = id;
            // Validation
            DeleteGenreCommandValidator validator = new DeleteGenreCommandValidator();
            validator.ValidateAndThrow(command);
            // Handle
            command.Handle();
            return Ok();
        }
    }
}
