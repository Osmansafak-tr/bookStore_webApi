﻿using WebApi.DB;

namespace WebApi.Operations.GenreOperations.Commands.Delete.DeleteGenre
{
    public class DeleteGenreCommand
    {
        private readonly BookStoreDbContext _context;
        public int Id { get; set; }

        public DeleteGenreCommand(BookStoreDbContext context)
        {
            _context = context;
        }

        public void Handle()
        {
            var genre = _context.Genres.SingleOrDefault(genre => genre.Id == Id);
            if (genre == null)
                throw new KeyNotFoundException("Key not found");

            _context.Genres.Remove(genre);
            _context.SaveChanges();
        }
    }
}
