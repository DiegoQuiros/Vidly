using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Vidly.Models;
using Vidly.ViewModels;

namespace Vidly.Controllers
{
    public class MoviesController : Controller
    {
        // GET: Movies/
        public ActionResult Index()
        {
            var movies = new List<Movie> {
              new Movie { Name = "Shrek" },
              new Movie { Name = "Wall-e" }
            };

            var viewModel = new MoviesViewModel
            {
                Movies = movies
            };

            return View(viewModel);
        }
    }
}