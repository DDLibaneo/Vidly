using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Vidly.Models;
using Vidly.ViewModels;
using System.Data.Entity;

namespace Vidly.Controllers
{
    public class MoviesController : Controller
    {
        ApplicationDbContext _context;

        public MoviesController ()
        {
            _context = new ApplicationDbContext();
        }

        protected override void Dispose (bool disposing)
        {
            _context.Dispose();
        }

        // GET: Movies
        public ViewResult Index()
        {
            if (User.IsInRole(RoleName.CanManageMovies))
                return View("List");    
            
            return View("ReadOnlyList");
        }

        // GET: Movies/Details/<Id>
        [Authorize(Roles = RoleName.CanManageMovies)]
        public ActionResult Details(int Id)
        {
            var movies = _context.Movies.Include(m => m.Genre).SingleOrDefault(m => m.Id == Id);

            if (movies == null)
                return HttpNotFound();

            return View(movies);
        }

        [Authorize(Roles = RoleName.CanManageMovies)]
        public ViewResult New()
        {
            var genres = _context.Genres.ToList();
            var viewModel = new MovieFormViewModel(genres);

            return View("MovieForm", viewModel);
        }

        [Authorize(Roles = RoleName.CanManageMovies)]
        public ActionResult Edit(int Id)
        {
            var movie = _context.Movies.Include(m => m.Genre).SingleOrDefault(m => m.Id == Id);

            if (movie == null)
                return HttpNotFound();

            var viewModel = new MovieFormViewModel(_context.Genres.ToList(), movie);

            return View("MovieForm", viewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = RoleName.CanManageMovies)]
        public ActionResult Save(Movie movie)
        {
            if (!ModelState.IsValid)
            {
                var viewModel = new MovieFormViewModel(_context.Genres.ToList(), movie);
                return View("MovieForm", viewModel);
            }
            if (movie.Id == 0)
            {
                movie.DateAdded = DateTime.Now;
                _context.Movies.Add(movie);
            }
            else
            {
                var movieInDb = _context.Movies.Single(m => m.Id == movie.Id);

                movieInDb.Name = movie.Name;
                movieInDb.ReleaseDate = movie.ReleaseDate;                
                movieInDb.GenreId = movie.GenreId;
                movieInDb.NumberInStock = movie.NumberInStock;
            }
            
            _context.SaveChanges();

            return RedirectToAction("Index", "Movies");
        }

        // GET: Movies/Random
        public ActionResult Random () // Métodos de uma controller são chamados de Action
        {
            var movie = new Movie() { Name = "Shrek" };
            var customers2 = new List<Customer>
            {
                new Customer (1, "Customer 1"),
                new Customer (2, "Customer 2")
            };

            var viewModel = new RandomMovieViewModel
            {
                Movie = movie,
                Customers = customers2
            };

            return View(viewModel);
        }      
    }
}