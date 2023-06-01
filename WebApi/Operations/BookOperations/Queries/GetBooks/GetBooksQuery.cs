﻿using AutoMapper;
using Microsoft.EntityFrameworkCore;
using WebApi.Common;
using WebApi.DBOperations;

namespace WebApi.BookOperations.Queries.GetBooks
{
    public class GetBooksQuery
    {
        private readonly BookStoreDbContext _context;
        private readonly IMapper _mapper;

        public GetBooksQuery(BookStoreDbContext context,IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public List<BooksViewModel> Handle()
        {
            var bookList = _context.Books.Include(x => x.Genre).OrderBy(x => x.Id).ToList();
            List<BooksViewModel> vm = _mapper.Map<List<BooksViewModel>>(bookList);

            return vm;
        }
    }

    public class BooksViewModel
    {
        public string Title { get; set; }
        public string Genre { get; set; }
        public int PageCount { get; set; }
        public string PublishDate { get; set; }
    }
}