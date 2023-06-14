using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using WebApi.Entities;

namespace WebApi.DB
{
    public class BookStoreDbContext : DbContext,IBookStoreDbContext
    {
        public BookStoreDbContext(DbContextOptions options) : base(options) { }

        public DbSet<Book> Books { get; set; }
        public DbSet<Genre> Genres { get; set; }
        public DbSet<Author> Authors { get; set; }
        public DbSet<User> Users { get; set; }

        public override EntityEntry Remove(object entity)
        {
            return base.Remove(entity);
        }

        public override int SaveChanges()
        {
            return base.SaveChanges();
        }

        public override EntityEntry Remove(object entity)
        {
            return base.Remove(entity);
        }

        public override int SaveChanges()
        {
            return base.SaveChanges();
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Author - Books | Many to one
            modelBuilder.Entity<Author>()
                .HasMany(x => x.Books)
                .WithOne(x => x.Author)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
