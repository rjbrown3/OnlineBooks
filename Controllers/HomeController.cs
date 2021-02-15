using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using OnlineBooks.Models;
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

        public HomeController(ILogger<HomeController> logger, IBooksRespository repository)
        {
            _logger = logger;
            _repository = repository;               //add to repository
        }

        public IActionResult Index()
        {
            return View(_repository.Books);         //send repository to the index page
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
