using WebApi.DBOperations;

namespace WebApi.Operations.BookOperations.DeleteBook
{
    public class DeleteBookCommand
    {
        private readonly BookStoreDbContext _context;
        public int Id { get; set; }

        public DeleteBookCommand(BookStoreDbContext context)
        {
            _context = context;
        }

        public Boolean Handle()
        {
            var book = _context.Books.SingleOrDefault(book => book.Id == Id);
            if (book == null)
                return false;

            _context.Books.Remove(book);
            _context.SaveChanges();
            return true;
        }
    }
}
