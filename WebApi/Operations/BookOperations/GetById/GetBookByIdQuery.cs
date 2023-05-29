using WebApi.Common;
using WebApi.DBOperations;

namespace WebApi.Operations.BookOperations.GetById
{
    public class GetBookByIdQuery
    {
        private readonly BookStoreDbContext _context;

        public GetBookByIdQuery(BookStoreDbContext context)
        {
            _context = context;
        }

        public GetBookByIdViewModel Handle(int id)
        {
            var book = _context.Books.Where(book => book.Id.Equals(id)).SingleOrDefault();
            GetBookByIdViewModel viewModel = new GetBookByIdViewModel();
            if (book == null)
                return null;
            viewModel.Title = book.Title;
            viewModel.Genre = ((GenreEnum)book.GenreId).ToString();
            viewModel.PageCount = book.PageCount;
            viewModel.PublishDate = book.PublishDate.Date.ToString("dd/MM/yyyy");
            return viewModel;
        }
    }

    public class GetBookByIdViewModel
    {
        public string Title { get; set; }
        public string Genre { get; set; }
        public int PageCount { get; set; }
        public string PublishDate { get; set; }
    }
}
