using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OnlineBooks.Models
{
    public class BooksDbContext : DbContext         //Database context
    {
        public BooksDbContext(DbContextOptions<BooksDbContext> options) : base (options)
        {

        }

        public DbSet<Books> Books { get; set; }
    }
}
