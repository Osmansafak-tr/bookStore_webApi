using WebApi.DBOperations;

namespace WebApi.Operations.BookOperations.UpdateBook
{
    public class UpdateBookCommand
    {
        private readonly BookStoreDbContext _context;
        public UpdateBookModel Model;

        public UpdateBookCommand(BookStoreDbContext context)
        {
            _context = context;
        }

        public Boolean Handle(int id)
        {
            var book = _context.Books.SingleOrDefault(book => book.Id == id);
            if (book == null)
                return false;

            book.Title = Model.Title != default ? Model.Title : book.Title;
            book.GenreId = Model.GenreId != default ? Model.GenreId : book.GenreId;
            book.PublishDate = Model.PublishDate != default ? Model.PublishDate : book.PublishDate;
            book.PageCount = Model.PageCount != default ? Model.PageCount : book.PageCount;
            _context.SaveChanges();
            return true;
        }
    }

    public class UpdateBookModel
    {
        public string Title { get; set; }
        public int GenreId { get; set; }
        public int PageCount { get; set; }
        public DateTime PublishDate { get; set; }
    }
}
