using AutoMapper;
using FluentValidation;
using FluentValidation.Results;
using Microsoft.AspNetCore.Mvc;
using WebApi.BookOperations.CreateBook;
using WebApi.BookOperations.GetBooks;
using WebApi.DBOperations;
using WebApi.Operations.BookOperations.CreateBook;
using WebApi.Operations.BookOperations.DeleteBook;
using WebApi.Operations.BookOperations.GetById;
using WebApi.Operations.BookOperations.UpdateBook;

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
            try
            {
                GetBooksQuery query = new GetBooksQuery(_context,_mapper);
                var vm = query.Handle();
                return Ok(vm);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            try
            {
                GetBookByIdQuery query = new GetBookByIdQuery(_context,_mapper);
                query.Id = id;
                // Validation
                GetBookByIdQueryValidator validator = new GetBookByIdQueryValidator();
                validator.ValidateAndThrow(query);
                // Handle
                var vm = query.Handle();
                if (vm == null)
                    return NotFound("Book can not found.");

                return Ok(vm);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpPost]
        public IActionResult AddBook([FromBody] CreateBookModel newBook)
        {
            try
            {
                CreateBookCommand command = new CreateBookCommand(_context,_mapper);
                command.Model = newBook;
                // Validation
                CreateBookCommandValidator validator = new CreateBookCommandValidator();
                validator.ValidateAndThrow(command);
                // Handle
                command.Handle();
                return Ok();
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
            
        }

        [HttpPut("{id}")]
        public IActionResult UpdateBook(int id, [FromBody] UpdateBookModel updatedBook)
        {
            try
            {
                UpdateBookCommand command = new UpdateBookCommand(_context);
                command.Model = updatedBook;
                command.Id = id;
                // Validation
                UpdateBookCommandValidator validator = new UpdateBookCommandValidator();
                validator.ValidateAndThrow(command);
                // Handle
                var isSuccess =  command.Handle();
                if(!isSuccess)
                    return NotFound("Book can not found");

                return Ok();
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteBook(int id)
        {
            try
            {
                DeleteBookCommand command = new DeleteBookCommand(_context);
                command.Id = id;
                // Validation
                DeleteBookCommandValidator validator = new DeleteBookCommandValidator();
                validator.ValidateAndThrow(command);

                var isSuccess = command.Handle();
                if (!isSuccess)
                    return NotFound("Book can not found.");

                return Ok();
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }
    }
}
