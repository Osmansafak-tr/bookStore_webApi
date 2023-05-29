using Microsoft.AspNetCore.Mvc;
using WebApi.BookOperations.CreateBook;
using WebApi.BookOperations.GetBooks;
using WebApi.DBOperations;
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
        public BookController(BookStoreDbContext dbContext)
        {
            _context = dbContext;
        }

        [HttpGet]
        public IActionResult GetBooks()
        {
            try
            {
                GetBooksQuery query = new GetBooksQuery(_context);
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
                GetBookByIdQuery query = new GetBookByIdQuery(_context);
                var vm = query.Handle(id);
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
                CreateBookCommand command = new CreateBookCommand(_context);
                command.Model = newBook;
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
                var isSuccess =  command.Handle(id);
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
                var isSuccess = command.Handle(id);
                if (!isSuccess)
                    return NotFound("Book can not found.");

                return Ok();
            }
            catch (Exception)
            {
                return BadRequest();
            }
        }
    }
}
