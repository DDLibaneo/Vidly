using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Vidly.Models;

namespace Vidly.ViewModels
{
    public class MovieFormViewModel
    {
        public IEnumerable<Genre> Genres { get; set; }
        public Movie Movie { get; set; }
        public string Title
        {
            get
            {
                return Movie != null && Movie.Id != 0 ? "Edit Movie" : "New Movie";
            }
        }

        public MovieFormViewModel() { }

        public MovieFormViewModel(IEnumerable<Genre> Genres)
        {
            this.Genres = Genres;
        }

        public MovieFormViewModel(IEnumerable<Genre> Genres, Movie Movie)
        {
            this.Genres = Genres;
            this.Movie = Movie;
        }
    }
}