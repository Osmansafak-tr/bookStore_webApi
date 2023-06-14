using AutoMapper;
using WebApi.DB;
using WebApi.Entities;
using WebApi.Operations.GenreOperations.Commands.Create.CreateGenre;

namespace WebApi.Operations.UserOperations.Commands.Create.CreateUser
{
    public class CreateUserCommand
    {
        private readonly IBookStoreDbContext _context;
        private readonly IMapper _mapper;

        public CreateUserModel Model;
        public CreateUserCommand(IBookStoreDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public void Handle()
        {
            var alreadyHave = _context.Users.SingleOrDefault(x => x.Email == x.Email);
            if (alreadyHave != null)
                throw new InvalidOperationException("There is an user that haves same email.");

            User user = _mapper.Map<User>(Model);
            _context.Users.Add(user);
            _context.SaveChanges();
        }
    }

    public class CreateUserModel
    {
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
    }
}
