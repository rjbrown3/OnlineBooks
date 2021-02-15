using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OnlineBooks.Models
{
    public class EFBooksRepository : IBooksRespository
    {
        private BooksDbContext _context;

        public EFBooksRepository (BooksDbContext context)
        {
            _context = context;     //update context
        }

        public IQueryable<Books> Books => _context.Books;       //add books to IQueryable list
    }
}
