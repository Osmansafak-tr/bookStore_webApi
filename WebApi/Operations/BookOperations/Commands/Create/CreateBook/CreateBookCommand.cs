using AutoMapper;
using Microsoft.AspNetCore.Server.IIS.Core;
using WebApi.DB;
using WebApi.Entities;

namespace WebApi.BookOperations.Commands.Create.CreateBook
{
    public class CreateBookCommand
    {
        public CreateBookModel Model { get; set; }

        private readonly IBookStoreDbContext _context;
        private readonly IMapper _mapper;

        public CreateBookCommand(IBookStoreDbContext context,IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public void Handle()
        {
            var alreadyHave = _context.Books.SingleOrDefault(book => book.Title == Model.Title);
            if (alreadyHave != null)
                throw new InvalidOperationException("Same book already created.");

            Book book = _mapper.Map<Book>(Model);
            _context.Books.Add(book);
            _context.SaveChanges();
        }

    }

    public class CreateBookModel
    {
        public string Title { get; set; }
        public int GenreId { get; set; }
        public int AuthorId { get; set; }
        public int PageCount { get; set; }
        public DateTime PublishDate { get; set; }
    }

}
