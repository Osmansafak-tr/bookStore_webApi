using AutoMapper;
using WebApi.DBOperations;

namespace WebApi.Operations.GenreOperations.Queries.GetGenreById
{
    public class GetGenreByIdQuery
    {
        private readonly BookStoreDbContext _context;
        private readonly IMapper _mapper;
        public int Id { get; set; }

        public GetGenreByIdQuery(BookStoreDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public GetGenreByIdViewModel Handle()
        {
            var genre = _context.Genres.SingleOrDefault(genre => genre.IsActive && genre.Id == Id);
            if (genre == null)
                throw new KeyNotFoundException("Genre key not found or genre is inactive");
            return _mapper.Map<GetGenreByIdViewModel>(genre);
        }
    }

    public class GetGenreByIdViewModel
    {
        public string Name { get; set; }
    }
}
