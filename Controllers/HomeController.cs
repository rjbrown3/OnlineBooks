using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using OnlineBooks.Models;
using OnlineBooks.Models.ViewModels;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace OnlineBooks.Controllers
{
    public class HomeController : Controller
    {
        private IBooksRespository _repository;      //add private repository variable that can be updated

        private readonly ILogger<HomeController> _logger;

        public int PageSize = 5;            //display a maximum of 5 items per page

        public HomeController(ILogger<HomeController> logger, IBooksRespository repository)
        {
            _logger = logger;
            _repository = repository;               //add to repository
        }

        public IActionResult Index(string category, int pageNum = 1)     //add parameter to Index method - category, page number: default is page 1
        {
            return View(new BookListViewModel          
            {
                Books = _repository.Books             //send repository to the index page
                    .Where(b => category == null || b.Category == category)     //add ability to filter by category
                    .OrderBy(b => b.BookId)
                    .Skip((pageNum - 1) * PageSize)
                    .Take(PageSize)
                ,
                PagingInfo = new PagingInfo
                {
                    CurrentPage = pageNum,
                    ItemsPerPage = PageSize,
                    TotalNumItems = category == null ? _repository.Books.Count() :
                        _repository.Books.Where(x => x.Category == category).Count()
                }
                ,
                CurrentCategory = category
            });        
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
