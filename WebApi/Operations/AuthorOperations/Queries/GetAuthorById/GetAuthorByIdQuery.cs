﻿using AutoMapper;
using WebApi.DBOperations;

namespace WebApi.Operations.AuthorOperations.Queries.GetAuthorById
{
    public class GetAuthorByIdQuery
    {
        private readonly BookStoreDbContext _context;
        private readonly IMapper _mapper;
        public int Id { get; set; }

        public GetAuthorByIdQuery(BookStoreDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public GetAuthorByIdViewModel Handle()
        {
            var author = _context.Authors.SingleOrDefault(x => x.Id == Id);
            if (author == null)
                throw new KeyNotFoundException("Author can not found");

            return _mapper.Map<GetAuthorByIdViewModel>(author);
        }
    }

    public class GetAuthorByIdViewModel
    {
        public string Name { get; set; }
        public string LastName { get; set; }
        public string DateOfBirth { get; set; }
    }
}