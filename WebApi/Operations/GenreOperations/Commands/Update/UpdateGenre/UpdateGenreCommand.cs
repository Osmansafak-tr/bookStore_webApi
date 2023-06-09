﻿using WebApi.DB;

namespace WebApi.Operations.GenreOperations.Commands.Update.UpdateGenre
{
    public class UpdateGenreCommand
    {
        private readonly IBookStoreDbContext _context;
        public int Id { get; set; }
        public UpdateGenreModel Model { get; set; }

        public UpdateGenreCommand(IBookStoreDbContext context)
        {
            _context = context;
        }

        public void Handle()
        {
            var genre = _context.Genres.SingleOrDefault(genre => genre.Id == Id);
            if (genre is null)
                throw new KeyNotFoundException("Genre can not found with this id.");
            // If there is a genre that already have same name.
            if (_context.Genres.Any(g => g.Name.ToLower() == Model.Name.ToLower() && g.Id != Id ))
                throw new InvalidOperationException("There is a genre that already have this name.");

            genre.Name = Model.Name.Trim() != default ? Model.Name.Trim() : genre.Name;
            genre.IsActive = Model.IsActive;
            _context.SaveChanges();
        }
    }

    public class UpdateGenreModel
    {
        public string Name { get; set; }
        public bool IsActive { get; set; }
    }
}
