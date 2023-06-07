using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebApi.DB;
using WebApi.Entities;

namespace WebApi.UnitTests.TestSetup.DataGenerations
{
    public static class Books
    {
        public static void AddBooks(this BookStoreDbContext context)
        {
            context.Books.AddRange
                (
                    new Book() { Title = "Book 1", GenreId = 1, AuthorId = 1, PageCount = 20, PublishDate = new DateTime(2001, 01, 01) },
                    new Book() { Title = "Book 2", GenreId = 1, AuthorId = 1, PageCount = 60, PublishDate = new DateTime(2001, 01, 02) },
                    new Book() { Title = "Book 3", GenreId = 2, AuthorId = 2, PageCount = 50, PublishDate = new DateTime(2001, 01, 03) }
                );
        }
    }
}
