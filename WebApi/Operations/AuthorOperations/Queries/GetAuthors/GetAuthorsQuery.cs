using AutoMapper;
using WebApi.DB;

namespace WebApi.Operations.AuthorOperations.Queries.GetAuthors
{
    public class GetAuthorsQuery
    {
        private readonly IBookStoreDbContext _context;
        private readonly IMapper _mapper;

        public GetAuthorsQuery(IBookStoreDbContext context,IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public List<GetAuthorsViewModel> Handle()
        {
            var queries = _context.Authors.OrderBy(x => x.Id);
            return _mapper.Map<List<GetAuthorsViewModel>>(queries);
        }
    }

    public class GetAuthorsViewModel
    {
        public string Name { get; set; }
        public string LastName { get; set; }
        public string DateOfBirth { get; set; }
    }
}
