using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace Vidly.Models
{
    public class Movie
    {
        // this is apparently known as CLR object or POCO
        //It is used to represent State, and it doesn't have complicated methods, just properties
        public int Id { get; set; }
        [Required]
        [StringLength(255)]
        public string Name { get; set; }
        public Genre Genre { get; set; }
        public int GenreId { get; set; }
        [Required]
        public DateTime ReleaseDate { get; set; }
        [Required]
        public DateTime DateAdded { get; set; }
        [Required]
        public int NumberInStock { get; set; }

        public Movie() { }

        public Movie(int Id, string Name)
        {
            this.Id = Id;
            this.Name = Name;
        }
    }
}