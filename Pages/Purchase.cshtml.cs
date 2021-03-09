using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using OnlineBooks.Models;
using OnlineBooks.Infrastructure;

namespace OnlineBooks.Pages
{
    public class PurchaseModel : PageModel  //inherits from the page model (razor page)
    {
        private IBooksRespository repository;

        //constructor
        public PurchaseModel (IBooksRespository repo, Cart cartService)  
        {
            repository = repo;
            Cart = cartService;
        }

        //properties
        public Cart Cart { get; set; }
        public string ReturnUrl { get; set; }

        //methods
        public void OnGet(string returnUrl)
        {
            ReturnUrl = returnUrl ?? "/";
            //Cart = HttpContext.Session.GetJson<Cart>("cart") ?? new Cart();
        }

        public IActionResult OnPost(long bookId, string returnUrl)
        {
            Book book = repository.Books.FirstOrDefault(b => b.BookId == bookId);
            //Cart = HttpContext.Session.GetJson<Cart>("cart") ?? new Cart();  //add a new cart if one doesn't exist
            Cart.AddItem(book, 1);
            //HttpContext.Session.SetJson("cart", Cart);  //set the json with the updated cart

            return RedirectToPage(new { returnUrl = returnUrl }); //redirect to new page with the new url with whatever has been passed in
        }

        public IActionResult OnPostRemove(long bookId, string returnUrl)
        {
            Cart.RemoveLine(Cart.Lines.First(b =>
                b.Book.BookId == bookId).Book);
            return RedirectToPage(new { returnUrl = returnUrl });
        }
    }
}
