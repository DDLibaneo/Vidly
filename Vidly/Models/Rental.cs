using System;
using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Vidly.Models
{
    public class Rental
    {
        public int Id { get; set; }

        [Required]
        public Movie Movie { get; set; }

        [Required]
        public Customer Customer  { get; set; }
        
        public DateTime DateRented { get; set; }
        
        public DateTime? DateReturned { get; set; }

        public Rental() { }

        public Rental(Movie Movie, Customer Customer, DateTime DateRented)
        {
            this.Movie = Movie;
            this.Customer = Customer;
            this.DateRented = DateRented;
            this.DateReturned = null;
        }
    }
}