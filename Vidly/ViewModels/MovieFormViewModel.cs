using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using Vidly.Models;

namespace Vidly.ViewModels
{
    public class MovieFormViewModel
    {
        public IEnumerable<Genre> Genres { get; set; }

        public int? Id { get; set; }

        [Required]
        [StringLength(255)]
        public string Name { get; set; }

        [Required]
        [Display(Name = "Genre")]
        public int? GenreId { get; set; }

        [Required]
        [Display(Name = "Release Date")]
        public DateTime? ReleaseDate { get; set; }

        [Required]
        [Display(Name = "Number in stock")]
        [MaxAndMinNumberInStock]
        public int? NumberInStock { get; set; }

        [Required]
        [Display(Name = "Number in stock")]
        public int? NumberAvailable { get; set; }

        public string Title
        {
            get
            {
                return (Id != 0) ? "Edit Movie" : "New Movie";
            }
        }

        public MovieFormViewModel()
        {
            Id = 0;
        }

        public MovieFormViewModel(IEnumerable<Genre> Genres)
        {
            Id = 0;
            this.Genres = Genres;
        }

        public MovieFormViewModel(IEnumerable<Genre> Genres, Movie Movie)
        {
            this.Genres = Genres;
            this.Id = Movie.Id;
            this.Name = Movie.Name;
            this.GenreId = Movie.GenreId;
            this.ReleaseDate = Movie.ReleaseDate;
            this.NumberInStock = Movie.NumberInStock;
            this.NumberAvailable = Movie.NumberInStock;
        }
    }
}