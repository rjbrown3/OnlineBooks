using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using OnlineBooks.Models;

namespace OnlineBooks.Components
{
    public class NavigationMenuViewComponent : ViewComponent
    {
        private IBooksRespository repository;

        public NavigationMenuViewComponent(IBooksRespository repo)
        {
            repository = repo;
        }

        public IViewComponentResult Invoke()
        {
            ViewBag.SelectedType = RouteData?.Values["category"];

            return View(repository.Books
                .Select(b => b.Category)
                .Distinct()
                .OrderBy(b => b));
        }
    }
}
