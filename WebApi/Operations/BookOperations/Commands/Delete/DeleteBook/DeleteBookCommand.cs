using WebApi.DB;

namespace WebApi.Operations.BookOperations.Commands.Delete.DeleteBook
{
    public class DeleteBookCommand
    {
        private readonly IBookStoreDbContext _context;
        public int Id { get; set; }

        public DeleteBookCommand(IBookStoreDbContext context)
        {
            _context = context;
        }

        public void Handle()
        {
            var book = _context.Books.SingleOrDefault(book => book.Id == Id);
            if (book == null)
                throw new KeyNotFoundException("Key not found.");

            _context.Books.Remove(book);
            _context.SaveChanges();
        }
    }
}
