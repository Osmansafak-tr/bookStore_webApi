using AutoMapper;
using WebApi.BookOperations.Commands.Create.CreateBook;
using WebApi.BookOperations.Queries.GetBooks;
using WebApi.Entities;
using WebApi.Operations.AuthorOperations.Commands.Create;
using WebApi.Operations.AuthorOperations.Queries.GetAuthorById;
using WebApi.Operations.AuthorOperations.Queries.GetAuthors;
using WebApi.Operations.BookOperations.Queries.GetById;
using WebApi.Operations.GenreOperations.Commands.Create.CreateGenre;
using WebApi.Operations.GenreOperations.Queries.GetGenreById;
using WebApi.Operations.GenreOperations.Queries.GetGenres;
using WebApi.Operations.UserOperations.Commands.Create.CreateUser;
using WebApi.Operations.UserOperations.Queries.GetUserById;
using WebApi.Operations.UserOperations.Queries.GetUsers;

namespace WebApi.Common
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            // BOOK 
            CreateMap<CreateBookModel, Book>();
            CreateMap<Book, GetBookByIdViewModel>()
                .ForMember(dest => dest.Genre, opt => opt.MapFrom(src => src.Genre.Name))
                .ForMember(dest => dest.Author, opt => opt.MapFrom(src => (src.Author.Name + " " + src.Author.LastName)))
                .ForMember(dest => dest.PublishDate, opt => opt.MapFrom(src => src.PublishDate.Date.ToString("dd/MM/yyyy")));
            CreateMap<Book,BooksViewModel>()
                .ForMember(dest => dest.Genre, opt => opt.MapFrom(src => src.Genre.Name))
                .ForMember(dest => dest.Author, opt => opt.MapFrom(src => (src.Author.Name + " " + src.Author.LastName)))
                .ForMember(dest => dest.PublishDate, opt => opt.MapFrom(src => src.PublishDate.Date.ToString("dd/MM/yyyy")));

            // GENRE
            CreateMap<Genre, GetGenresViewModel>();
            CreateMap<Genre, GetGenreByIdViewModel>();
            CreateMap<CreateGenreModel, Genre>();

            // AUTHOR
            CreateMap<Author, GetAuthorsViewModel>()
                .ForMember(dest => dest.DateOfBirth, opt => opt.MapFrom(src => src.DateOfBirth.Date.ToString("dd/MM/yyyy")));
            CreateMap<Author, GetAuthorByIdViewModel>()
                .ForMember(dest => dest.DateOfBirth, opt => opt.MapFrom(src => src.DateOfBirth.Date.ToString("dd/MM/yyyy") ));
            CreateMap<CreateAuthorModel, Author>();

            // USER
            CreateMap<User, GetUsersViewModel>();
            CreateMap<User, GetUserByIdViewModel>();
            CreateMap<CreateUserModel, User>();
        }
    }
}
