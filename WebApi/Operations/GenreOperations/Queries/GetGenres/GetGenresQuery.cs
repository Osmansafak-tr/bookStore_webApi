using AutoMapper;
using WebApi.DBOperations;

namespace WebApi.Operations.GenreOperations.Queries.GetGenres
{
    public class GetGenresQuery
    {
        private readonly BookStoreDbContext _context;
        private readonly IMapper _mapper;

        public GetGenresQuery(BookStoreDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public List<GetGenresViewModel> Handle()
        {
            var genres = _context.Genres.Where(genre => genre.IsActive == true).OrderBy(genre => genre.Id);
            List<GetGenresViewModel> viewModel = _mapper.Map<List<GetGenresViewModel>>(genres);
            return viewModel;
        }
    }

    public class GetGenresViewModel
    {
        public string Name { get; set; }
    }
}
