using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebApi.DB;
using WebApi.Entities;

namespace WebApi.UnitTests.TestSetup.DataGenerations
{
    public static class Authors
    {
        public static void AddAuthors(this BookStoreDbContext context)
        {
            context.Authors.AddRange(
                new Author { Name = "George", LastName = "Orwell", DateOfBirth = new DateTime(1903, 6, 25), },
                new Author { Name = "Stefan", LastName = "Zweig", DateOfBirth = new DateTime(1881, 11, 28), },
                new Author { Name = "Fyodor", LastName = "Dostoyevski", DateOfBirth = new DateTime(1821, 11, 11), }
            );
        }
    }
}
