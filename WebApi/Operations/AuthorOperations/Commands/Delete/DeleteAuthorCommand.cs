using AutoMapper;
using Microsoft.EntityFrameworkCore;
using WebApi.DB;

namespace WebApi.Operations.AuthorOperations.Commands.Delete
{
    public class DeleteAuthorCommand
    {
        private readonly IBookStoreDbContext _context;
        private readonly IMapper _mapper;
        public int Id { get; set; }

        public DeleteAuthorCommand(IBookStoreDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public void Handle()
        {
            var author = _context.Authors.Include(x => x.Books).SingleOrDefault(x => x.Id == Id);
            if (author == null)
                throw new KeyNotFoundException("Author not found");
            if (author.Books.Count() > 0)
                throw new InvalidOperationException("There are this author's books in database. Please delete that books first.");

            _context.Remove(author);
            _context.SaveChanges();
        }
    }
}
