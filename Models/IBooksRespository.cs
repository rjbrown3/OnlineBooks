using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OnlineBooks.Models
{
    public interface IBooksRespository
    {
        IQueryable<Books> Books { get; }        //Can get an IQueryable list of books from the repository
    }
}
