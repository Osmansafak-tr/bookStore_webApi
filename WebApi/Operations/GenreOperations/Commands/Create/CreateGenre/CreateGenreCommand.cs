﻿using AutoMapper;
using WebApi.DB;
using WebApi.Entities;

namespace WebApi.Operations.GenreOperations.Commands.Create.CreateGenre
{
    public class CreateGenreCommand
    {
        private readonly IBookStoreDbContext _context;
        private readonly IMapper _mapper;

        public CreateGenreModel Model;
        public CreateGenreCommand(IBookStoreDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public void Handle()
        {
            var alreadyHave = _context.Genres.SingleOrDefault(genre => genre.Name == Model.Name && genre.IsActive);
            if (alreadyHave != null)
                throw new InvalidOperationException("Same genre already created");

            Genre genre = _mapper.Map<Genre>(Model);
            _context.Genres.Add(genre);
            _context.SaveChanges();
        }
    }

    public class CreateGenreModel
    {
        public string Name { get; set; }
    }
}
