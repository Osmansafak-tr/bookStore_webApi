using AutoMapper;
using FluentValidation;
using Microsoft.AspNetCore.Mvc;
using WebApi.DB;
using WebApi.Operations.AuthorOperations.Commands.Create;
using WebApi.Operations.AuthorOperations.Commands.Delete;
using WebApi.Operations.AuthorOperations.Commands.Update;
using WebApi.Operations.AuthorOperations.Queries.GetAuthorById;
using WebApi.Operations.AuthorOperations.Queries.GetAuthors;

namespace WebApi.Controllers
{
    [ApiController]
    [Route("[controller]s")]
    public class AuthorController : Controller
    {
        private readonly IBookStoreDbContext _context;
        private readonly IMapper _mapper;

        public AuthorController(IBookStoreDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        [HttpGet]
        public IActionResult GetAuthors()
        {
            GetAuthorsQuery query = new GetAuthorsQuery(_context,_mapper);
            var authors =  query.Handle();
            return Ok(authors);
        }

        [HttpGet("{id}")]
        public IActionResult GetAuthorsById(int id)
        {
            GetAuthorByIdQuery query = new GetAuthorByIdQuery(_context,_mapper);
            query.Id = id;
            // Validation
            GetAuthorByIdQueryValidators validator = new GetAuthorByIdQueryValidators();
            validator.ValidateAndThrow(query);
            //Handle
            var author = query.Handle();
            return Ok(author);
        }

        [HttpPost]
        public IActionResult CreateAuthor([FromBody] CreateAuthorModel authorModel)
        {
            CreateAuthorCommand command = new CreateAuthorCommand(_context,_mapper);
            command.Model = authorModel;
            // Validation
            CreateAuthorCommadValidator validator = new CreateAuthorCommadValidator();
            validator.ValidateAndThrow(command);
            // Handle
            command.Handle();
            return Ok();
        }

        [HttpPut("{id}")]
        public IActionResult UpdateAuthor([FromBody] UpdateAuthorModel authorModel, int id)
        {
            UpdateAuthorCommand command = new UpdateAuthorCommand(_context);
            command.Id = id;
            command.Model = authorModel;
            // Validation
            UpdateAuthorCommandValidator validator = new UpdateAuthorCommandValidator();
            validator.ValidateAndThrow(command);
            // Handle
            command.Handle();
            return Ok();
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteAuthor(int id)
        {
            DeleteAuthorCommand command = new DeleteAuthorCommand(_context,_mapper);
            command.Id = id;
            // Validation
            DeleteAuthorCommandValidator validator = new DeleteAuthorCommandValidator();
            validator.ValidateAndThrow(command);
            // Handle
            command.Handle();
            return Ok();
        }
    }
}
