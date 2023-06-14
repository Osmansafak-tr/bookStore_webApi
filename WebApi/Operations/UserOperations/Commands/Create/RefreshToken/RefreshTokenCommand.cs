using AutoMapper;
using WebApi.DB;
using WebApi.Operations.UserOperations.Commands.Create.CreateToken;
using WebApi.TokenOperations.Models;
using WebApi.TokenOperations;

namespace WebApi.Operations.UserOperations.Commands.Create.RefreshToken
{
    public class RefreshTokenCommand
    {
        private readonly IBookStoreDbContext _context;
        private readonly IMapper _mapper;
        private readonly IConfiguration _configuration;
        public string RefreshToken { get; set; }

        public RefreshTokenCommand(IBookStoreDbContext context, IMapper mapper, IConfiguration configuration)
        {
            _context = context;
            _mapper = mapper;
            _configuration = configuration;
        }

        public Token Handle()
        {
            var user = _context.Users.SingleOrDefault(x => x.RefreshToken == RefreshToken && x.RefreshTokenExpireDate > DateTime.Now);
            if (user == null)
                throw new InvalidOperationException("Valid refresh token couldn't found.");

            AppTokenHandler tokenHandler = new AppTokenHandler(_configuration);
            Token token = tokenHandler.CreateJwtToken(user);

            user.RefreshToken = token.RefreshToken;
            user.RefreshTokenExpireDate = token.Expiration.AddMinutes(5);
            _context.SaveChanges();
            return token;
        }
    }
}
