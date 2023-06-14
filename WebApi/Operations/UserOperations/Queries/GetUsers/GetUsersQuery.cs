using AutoMapper;
using WebApi.DB;
using WebApi.Entities;

namespace WebApi.Operations.UserOperations.Queries.GetUsers
{
    public class GetUsersQuery
    {
        private readonly IBookStoreDbContext _context;
        private readonly IMapper _mapper;

        public GetUsersQuery(IBookStoreDbContext context,IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public List<GetUsersViewModel> Handle()
        {
            var users = _context.Users.OrderBy(x => x.Id);
            List<GetUsersViewModel> usersVm = _mapper.Map<List<GetUsersViewModel>>(users);
            return usersVm;
        }
    }

    public class GetUsersViewModel
    {
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Email { get; set; }
    }
}
