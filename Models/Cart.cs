using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OnlineBooks.Models
{
    public class Cart
    {
        public List<CartLine> Lines { get; set; } = new List<CartLine>(); //instatiate one

        public virtual void AddItem (Book bk, int qty)
        {
            //create a new instance of the object and set it to the Lines list where the book id already exists and compare it to the one just added
            CartLine line = Lines
                .Where(b => b.Book.BookId == bk.BookId)
                .FirstOrDefault();  //grab the first one from that group

            if (line == null)   //if it didn't find anything in that list that matched
            {
                Lines.Add(new CartLine
                {
                    Book = bk,
                    Quantity = qty
                });
            }
            else           //if it did find it, increment the quantity
            {
                line.Quantity += qty;
            }
        }

        public virtual void RemoveLine(Book bk) =>
            Lines.RemoveAll(b => b.Book.BookId == bk.BookId); //remove all lines that match up with that book

        public virtual void Clear() => Lines.Clear(); //clear everything from the cart

        public decimal ComputeTotalSum() => Lines.Sum(b => b.Book.Price * b.Quantity);

        public class CartLine
        {
            public int CartLineId { get; set; }
            public Book Book { get; set; }
            public int Quantity { get; set; }
        }
    }
}
