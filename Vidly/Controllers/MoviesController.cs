using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Vidly.Models;
using Vidly.ViewModels;
using System.Data.Entity;
using System.Data.Entity.Validation;

namespace Vidly.Controllers
{
    public class MoviesController : Controller
    {
        public ApplicationDbContext _context;

        public MoviesController()
        {
            _context = new ApplicationDbContext();
        }

        protected override void Dispose(bool disposing)
        {
            _context.Dispose();
        }

        // GET: Movies/
        public ActionResult Index()
        {
            return View();
        }

        [Route("Movies/Details/{id}")]
        public ActionResult Details(int id)
        {
            Movie movie = _context.Movies.Include(x => x.Genre).FirstOrDefault(x => x.Id == id);

            if (movie == null)
                return HttpNotFound();

            return View(movie);

        }

        public ActionResult New()
        {
            MovieFormViewModel viewModel = new MovieFormViewModel()
            {
                Genres = _context.Genres.ToList()
            };

            return View("MovieForm", viewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Save(Movie movie)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    MovieFormViewModel viewModel = new MovieFormViewModel(movie) 
                    {
                        Genres = _context.Genres.ToList()
                    };

                    return View("MovieForm", viewModel);
                }

                if (movie.Id == 0)
                {
                    movie.DateAdded = DateTime.Now;
                    _context.Movies.Add(movie);
                }
                else
                {
                    var movieInDB = _context.Movies.Single(m => m.Id == movie.Id);

                    movieInDB.Name = movie.Name;
                    movieInDB.GenreId = movie.GenreId;
                    movieInDB.ReleaseDate = movie.ReleaseDate;
                    movieInDB.NumberInStock = movie.NumberInStock;
                }
                _context.SaveChanges();
            }
            catch (DbEntityValidationException e)
            {
                Console.WriteLine(e);
            }
            return RedirectToAction("Index", "Movies");
        }

        public ActionResult Edit(int Id)
        {
            var movieInDb = _context.Movies.SingleOrDefault(m => m.Id == Id);
            if (movieInDb == null)
                return HttpNotFound();

            MovieFormViewModel viewModel = new MovieFormViewModel(movieInDb)
            {
                Genres = _context.Genres.ToList()
            };

            return View("MovieForm", viewModel);
        }
    }
}