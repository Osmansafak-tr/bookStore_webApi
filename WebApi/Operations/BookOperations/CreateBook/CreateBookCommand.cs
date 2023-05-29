using Microsoft.AspNetCore.Server.IIS.Core;
using WebApi.DBOperations;

namespace WebApi.BookOperations.CreateBook
{
    public class CreateBookCommand
    {
        public CreateBookModel Model { get; set; }

        private readonly BookStoreDbContext _context;

        public CreateBookCommand(BookStoreDbContext context)
        {
            _context = context;
        }

        public void Handle()
        {
            var alreadyHave = _context.Books.SingleOrDefault(book => book.Title == Model.Title);
            if (alreadyHave != null)
                throw new InvalidOperationException("Same book already created");

            Book newBook = new Book();
            newBook.Title = Model.Title;
            newBook.PublishDate = Model.PublishDate;
            newBook.GenreId = Model.GenreId;
            newBook.PageCount = Model.PageCount;
            _context.Books.Add(newBook);
            _context.SaveChanges();
        }

    }

    public class CreateBookModel
    {
        public string Title { get; set; }
        public int GenreId { get; set; }
        public int PageCount { get; set; }
        public DateTime PublishDate { get; set; }
    }

}
