using AutoMapper;
using FluentValidation;
using FluentValidation.Results;
using Microsoft.AspNetCore.Mvc;
using WebApi.BookOperations.Commands.Create.CreateBook;
using WebApi.BookOperations.Queries.GetBooks;
using WebApi.DBOperations;
using WebApi.Operations.BookOperations.Commands.Delete.DeleteBook;
using WebApi.Operations.BookOperations.Commands.Update.UpdateBook;
using WebApi.Operations.BookOperations.Queries.GetById;

namespace WebApi.Controllers
{
    [ApiController]
    [Route("[controller]s")]
    public class BookController : Controller
    {
        private readonly BookStoreDbContext _context;
        private readonly IMapper _mapper;
        public BookController(BookStoreDbContext dbContext,IMapper mapper)
        {
            _context = dbContext;
            _mapper = mapper;
        }

        [HttpGet]
        public IActionResult GetBooks()
        {
            GetBooksQuery query = new GetBooksQuery(_context,_mapper);
            var vm = query.Handle();
            return Ok(vm);
        }

        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            GetBookByIdQuery query = new GetBookByIdQuery(_context,_mapper);
            query.Id = id;
            // Validation
            GetBookByIdQueryValidator validator = new GetBookByIdQueryValidator();
            validator.ValidateAndThrow(query);
            // Handle
            var vm = query.Handle();

            return Ok(vm);
        }

        [HttpPost]
        public IActionResult AddBook([FromBody] CreateBookModel newBook)
        {
            CreateBookCommand command = new CreateBookCommand(_context, _mapper);
            command.Model = newBook;
            // Validation
            CreateBookCommandValidator validator = new CreateBookCommandValidator();
            validator.ValidateAndThrow(command);
            // Handle
            command.Handle();
            return Ok();
        }

        [HttpPut("{id}")]
        public IActionResult UpdateBook(int id, [FromBody] UpdateBookModel updatedBook)
        {
            UpdateBookCommand command = new UpdateBookCommand(_context);
            command.Model = updatedBook;
            command.Id = id;
            // Validation
            UpdateBookCommandValidator validator = new UpdateBookCommandValidator();
            validator.ValidateAndThrow(command);
            // Handle
            command.Handle();

            return Ok();
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteBook(int id)
        {
            DeleteBookCommand command = new DeleteBookCommand(_context);
            command.Id = id;
            // Validation
            DeleteBookCommandValidator validator = new DeleteBookCommandValidator();
            validator.ValidateAndThrow(command);
            // Handle
            command.Handle();

            return Ok();
        }
    }
}
