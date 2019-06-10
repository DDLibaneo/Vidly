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
        // GET 
        public ActionResult Index ()
        {
            var movies = GetMovies();

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
        
        public IEnumerable<Movie> GetMovies()
        {
            return new List<Movie>
            {
                new Movie() { Id = 1, Name = "Diários de motocicleta" },
                new Movie() { Id = 2, Name = "Sorry to bother you" }
            };
        }
    }
}