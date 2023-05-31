using AutoMapper;
using WebApi.Common;
using WebApi.DBOperations;

namespace WebApi.Operations.BookOperations.GetById
{
    public class GetBookByIdQuery
    {
        private readonly BookStoreDbContext _context;
        private readonly IMapper _mapper;
        public int Id { get; set; }

        public GetBookByIdQuery(BookStoreDbContext context,IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public GetBookByIdViewModel Handle()
        {
            var book = _context.Books.Where(book => book.Id.Equals(Id)).SingleOrDefault();
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
        public int PageCount { get; set; }
        public string PublishDate { get; set; }
    }
}
