using AutoMapper;
using WebApi.BookOperations.Commands.Create.CreateBook;
using WebApi.BookOperations.Queries.GetBooks;
using WebApi.Entities;
using WebApi.Operations.AuthorOperations.Queries.GetAuthorById;
using WebApi.Operations.AuthorOperations.Queries.GetAuthors;
using WebApi.Operations.BookOperations.Commands.Update.UpdateBook;
using WebApi.Operations.BookOperations.Queries.GetById;
using WebApi.Operations.GenreOperations.Commands.Create.CreateGenre;
using WebApi.Operations.GenreOperations.Queries.GetGenreById;
using WebApi.Operations.GenreOperations.Queries.GetGenres;

namespace WebApi.Common
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            // Book 
            CreateMap<CreateBookModel, Book>();
            CreateMap<Book, GetBookByIdViewModel>()
                .ForMember(dest => dest.Genre, opt => opt.MapFrom(src => src.Genre.Name))
                .ForMember(dest => dest.PublishDate, opt => opt.MapFrom(src => src.PublishDate.Date.ToString("dd/MM/yyyy")));
            CreateMap<Book,BooksViewModel>()
                .ForMember(dest => dest.Genre, opt => opt.MapFrom(src => src.Genre.Name))
                .ForMember(dest => dest.PublishDate, opt => opt.MapFrom(src => src.PublishDate.Date.ToString("dd/MM/yyyy")));

            // Genre
            CreateMap<Genre, GetGenresViewModel>();
            CreateMap<Genre, GetGenreByIdViewModel>();
            CreateMap<CreateGenreModel, Genre>();

            // Author
            CreateMap<Author, GetAuthorsViewModel>()
                .ForMember(dest => dest.DateOfBirth, opt => opt.MapFrom(src => src.DateOfBirth.Date.ToString("dd/MM/yyyy")));
            CreateMap<Author, GetAuthorByIdViewModel>()
                .ForMember(dest => dest.DateOfBirth, opt => opt.MapFrom(src => src.DateOfBirth.Date.ToString("dd/MM/yyyy") ));
        }
    }
}
