using Microsoft.EntityFrameworkCore;
using WebApi.Entities;

namespace WebApi.DBOperations
{
    public class DataGenerator
    {
        public static void Initilaze(IServiceProvider serviceProvider)
        {
            using (var context = new BookStoreDbContext(serviceProvider.GetRequiredService<DbContextOptions<BookStoreDbContext>>()))
            {
                // Check is there any book
                if (context.Books.Any())
                    return;

                context.Genres.AddRange(
                    new Genre()
                    {
                        Name = "Personal Growth"
                    },
                    new Genre()
                    {
                        Name = "Science Fiction"
                    },
                    new Genre()
                    {
                        Name = "Romance"
                    }
                );

                context.Books.AddRange
                (
                    new Book()
                    {
                        Title = "Book 1",
                        GenreId = 1,
                        PageCount = 20,
                        PublishDate = new DateTime(2001, 01, 01)
                    },
                    new Book()
                    {
                        Title = "Book 2",
                        GenreId = 1,
                        PageCount = 60,
                        PublishDate = new DateTime(2001, 01, 02)
                    },
                    new Book()
                    {
                        Title = "Book 3",
                        GenreId = 2,
                        PageCount = 50,
                        PublishDate = new DateTime(2001, 01, 03)
                    }
                );

                context.Authors.AddRange(
                    new Author
                    {
                        Name = "George",
                        LastName = "Orwell",
                        DateOfBirth = new DateTime(1903,6,25)
                    },
                    new Author
                    {
                        Name = "Stefan",
                        LastName = "Zweig",
                        DateOfBirth= new DateTime(1881,11,28)
                    },
                    new Author
                    {
                        Name = "Fyodor",
                        LastName = "Dostoyevski",
                        DateOfBirth = new DateTime(1821, 11, 11)
                    }
                );

                context.SaveChanges();
            }

        }
    }
}
