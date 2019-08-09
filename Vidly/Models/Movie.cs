using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Vidly.Models
{
    public class Movie
    {
        //This type of class is known as CLR object or POCO
        //It is used to represent State, and it doesn't have complicated methods, just properties
        public int Id { get; set; }

        [Required]
        [StringLength(255)]
        public string Name { get; set; }

        public Genre Genre { get; set; }

        [Required]
        [Display(Name = "Genre")]
        public int GenreId { get; set; }

        [Required]
        [Display(Name = "Release Date")]
        public DateTime ReleaseDate { get; set; }

        [Required]
        [Display(Name = "Date Added")]
        public DateTime DateAdded { get; set; }

        [Required]
        [Range(1, 20)]
        [Display(Name = "Number in stock")]        
        public int NumberInStock { get; set; }

        [Range(0, 20)]
        public int NumberAvailable { get; set; }

        public Movie()
        {
            NumberInStock = 0;
            NumberAvailable = NumberInStock;
        }

        public Movie(int Id, string Name, DateTime ReleaseDate, DateTime DateAdded)
        {
            this.Id = Id;
            this.Name = Name;
            this.ReleaseDate = ReleaseDate;
            this.DateAdded = DateAdded;
            NumberInStock = 0;
            NumberAvailable = NumberInStock;
        }

        public Movie(int Id, string Name, DateTime ReleaseDate, DateTime DateAdded, int NumberInStock)
        {
            this.Id = Id;
            this.Name = Name;
            this.ReleaseDate = ReleaseDate;
            this.DateAdded = DateAdded;
            this.NumberInStock = NumberInStock;
            NumberAvailable = NumberInStock;
        }
    }
}