using AutoMapper;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Vidly.Dtos;
using Vidly.Models;

namespace Vidly.Controllers.Api
{
    public class NewRentalsController : ApiController
    {
        private ApplicationDbContext _context;

        public NewRentalsController ()
        {
            _context = new ApplicationDbContext();
        }

        [HttpPost]
        //[Authorize(Roles = RoleName.CanManageMovies)]
        //Apenas faça verificações defensivas assim se vc estiver construindo uma API pública que será utilizada por multiplas aplicações e devs
        public IHttpActionResult CreateRent(NewRentalDto newRentalDto)
        {
            if (newRentalDto.MovieIds.Count == 0)
                return BadRequest("No movie Ids Have been given.");

            var customer = _context.Customers.Single(c => c.Id == newRentalDto.CustomerId);

            if (customer == null)
                return BadRequest("Customer Id is not valid.");

            var movies = _context.Movies.Where(m => newRentalDto.MovieIds.Contains(m.Id)).ToList();

            if (movies.Count != newRentalDto.MovieIds.Count)
                return BadRequest("One or more movie Ids are invalid.");

            foreach (var movie in movies)
            {
                if (movie.NumberAvailable == 0)
                    return BadRequest("Movie with Id " + movie.Id + " is not available.");
                
                var rental = new Rental(movie, customer, DateTime.Now);

                _context.Rentals.Add(rental);
                movie.NumberAvailable--;                
            }

            _context.SaveChanges();

            return Ok();
        }
    }
}




