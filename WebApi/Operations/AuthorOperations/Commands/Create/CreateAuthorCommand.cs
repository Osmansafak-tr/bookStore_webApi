using AutoMapper;
using WebApi.DB;
using WebApi.Entities;

namespace WebApi.Operations.AuthorOperations.Commands.Create
{
    public class CreateAuthorCommand
    {
        private readonly BookStoreDbContext _context;
        private readonly IMapper _mapper;

        public CreateAuthorModel Model;
        public CreateAuthorCommand(BookStoreDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public void Handle()
        {
            var alreadyHave = _context.Authors.SingleOrDefault(x => x.Name == Model.Name && x.LastName == Model.LastName);
            if (alreadyHave != null)
                throw new InvalidOperationException("This author already in database.");

            var author = _mapper.Map<Author>(Model);
            _context.Authors.Add(author);
            _context.SaveChanges();
        }
    }

    public class CreateAuthorModel
    {
        public string Name { get; set; }
        public string LastName { get; set; }
        public DateTime DateOfBirth { get; set; }
    }
}
