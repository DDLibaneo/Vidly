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
        public ActionResult Index ()
        {
            var movies = _context.Movies.Include(m => m.Genre).ToList();

            return View(movies);
        }

        // GET: Movies/Details/<Id>
        public ActionResult Details (int Id)
        {
            var movies = _context.Movies.Include(m => m.Genre).SingleOrDefault(m => m.Id == Id);

            if (movies == null)
                return HttpNotFound();

            return View(movies);
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