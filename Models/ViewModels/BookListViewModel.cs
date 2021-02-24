using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OnlineBooks.Models.ViewModels
{
    public class BookListViewModel   //provides the view with the details of the books to display on the page
    {
        public IEnumerable<Book> Books { get; set; }    
        public PagingInfo PagingInfo { get; set; }
    }
}
