using AutoMapper;
using WebApi.DBOperations;

namespace WebApi.Operations.AuthorOperations.Commands.Delete
{
    public class DeleteAuthorCommand
    {
        private readonly BookStoreDbContext _context;
        private readonly IMapper _mapper;
        public int Id { get; set; }

        public DeleteAuthorCommand(BookStoreDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public void Handle()
        {
            var author = _context.Authors.SingleOrDefault(x => x.Id == Id);
            if (author == null)
                throw new KeyNotFoundException("Author not found");

            _context.Remove(author);
            _context.SaveChanges();
        }
    }
}
