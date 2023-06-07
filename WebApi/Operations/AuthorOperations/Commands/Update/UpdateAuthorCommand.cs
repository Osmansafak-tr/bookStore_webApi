using AutoMapper;
using WebApi.DB;

namespace WebApi.Operations.AuthorOperations.Commands.Update
{
    public class UpdateAuthorCommand
    {
        private readonly IBookStoreDbContext _context;
        public UpdateAuthorModel Model { get; set; }
        public int Id { get; set; }

        public UpdateAuthorCommand(IBookStoreDbContext context)
        {
            _context = context;
        }

        public void Handle()
        {
            var author = _context.Authors.SingleOrDefault(x => x.Id == Id);
            if (author == null)
                throw new InvalidOperationException("Author not found.");

            author.Name = Model.Name != default ? Model.Name : author.Name;
            author.LastName = Model.LastName != default ? Model.LastName : author.LastName;
            author.DateOfBirth = Model.DateOfBirth != default ? Model.DateOfBirth : author.DateOfBirth;

            _context.SaveChanges();
        }
    }

    public class UpdateAuthorModel
    {
        public string Name { get; set; }
        public string LastName { get; set; }
        public DateTime DateOfBirth { get; set; }
    }
}
