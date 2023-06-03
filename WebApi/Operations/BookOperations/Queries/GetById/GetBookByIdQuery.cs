using AutoMapper;
using Microsoft.EntityFrameworkCore;
using WebApi.DB;

namespace WebApi.Operations.BookOperations.Queries.GetById
{
    public class GetBookByIdQuery
    {
        private readonly IBookStoreDbContext _context;
        private readonly IMapper _mapper;
        public int Id { get; set; }

        public GetBookByIdQuery(IBookStoreDbContext context,IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public GetBookByIdViewModel Handle()
        {
            var book = _context.Books.Include(x => x.Genre).Include(x => x.Author).Where(book => book.Id.Equals(Id)).SingleOrDefault();
            if (book == null)
                throw new KeyNotFoundException("Key not found.");

            GetBookByIdViewModel viewModel = new GetBookByIdViewModel();
            viewModel = _mapper.Map<GetBookByIdViewModel>(book);
            return viewModel;
        }
    }

    public class GetBookByIdViewModel
    {
        public string Title { get; set; }
        public string Genre { get; set; }
        public string Author { get; set; }
        public int PageCount { get; set; }
        public string PublishDate { get; set; }
    }
}
