using AutoMapper;
using WebApi.DB;
using WebApi.TokenOperations;
using WebApi.TokenOperations.Models;

namespace WebApi.Operations.UserOperations.Commands.Create.CreateToken
{
    public class CreateTokenCommand
    {
        private readonly IBookStoreDbContext _context;
        private readonly IMapper _mapper;
        private readonly IConfiguration _configuration;
        public CreateTokenModel Model { get; set; }

        public CreateTokenCommand(IBookStoreDbContext context, IMapper mapper, IConfiguration configuration)
        {
            _context = context;
            _mapper = mapper;
            _configuration = configuration;
        }

        public Token Handle()
        {
            var user = _context.Users.SingleOrDefault(x => x.Email == Model.Email && x.Password == Model.Password);
            if (user == null)
                throw new InvalidOperationException("Invalid email or password.");

            AppTokenHandler tokenHandler = new AppTokenHandler(_configuration);
            Token token = tokenHandler.CreateJwtToken(user);

            user.RefreshToken = token.RefreshToken;
            user.RefreshTokenExpireDate = token.Expiration.AddMinutes(5);
            _context.SaveChanges();
            return token;
        }
    }

    public class CreateTokenModel
    {
        public string Email { get; set; }
        public string Password { get; set; }
    }
}
