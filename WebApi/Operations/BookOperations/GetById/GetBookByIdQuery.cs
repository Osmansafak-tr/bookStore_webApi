using AutoMapper;
using WebApi.Common;
using WebApi.DBOperations;

namespace WebApi.Operations.BookOperations.GetById
{
    public class GetBookByIdQuery
    {
        private readonly BookStoreDbContext _context;
        private readonly IMapper _mapper;

        public GetBookByIdQuery(BookStoreDbContext context,IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public GetBookByIdViewModel Handle(int id)
        {
            var book = _context.Books.Where(book => book.Id.Equals(id)).SingleOrDefault();
            if (book == null)
                return null;

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
