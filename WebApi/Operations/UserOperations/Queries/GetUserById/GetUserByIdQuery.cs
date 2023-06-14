using AutoMapper;
using WebApi.DB;
using WebApi.Entities;

namespace WebApi.Operations.UserOperations.Queries.GetUserById
{
    public class GetUserByIdQuery
    {
        private readonly IBookStoreDbContext _context;
        private readonly IMapper _mapper;
        public int Id { get; set; }

        public GetUserByIdQuery(IBookStoreDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public GetUserByIdViewModel Handle()
        {
            var user = _context.Users.SingleOrDefault(x => x.Id == Id);
            if (user == null)
                throw new KeyNotFoundException("User key not found.");
            return _mapper.Map<GetUserByIdViewModel>(user);
        }
    }

    public class GetUserByIdViewModel
    {
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Email { get; set; }
    }
}
