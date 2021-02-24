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

        public IActionResult Index(int page = 1)     //add parameter to Index method - default is page 1
        {
            return View(new BookListViewModel          
            {
                Books = _repository.Books             //send repository to the index page
                    .OrderBy(p => p.BookId)
                    .Skip((page - 1) * PageSize)
                    .Take(PageSize)
                ,
                PagingInfo = new PagingInfo
                {
                    CurrentPage = page,
                    ItemsPerPage = PageSize,
                    TotalNumItems = _repository.Books.Count()
                }
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
