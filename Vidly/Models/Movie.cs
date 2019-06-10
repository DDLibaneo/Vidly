using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Vidly.Models
{
    public class Movie
    {
        // this is apparently known as CLR object or POCO
        //It is used to represent State, and it doesn't have complicated methods, just properties
        public int Id { get; set; }
        public string Name { get; set; }

        public Movie() { }

        public Movie(int Id, string Name)
        {
            this.Id = Id;
            this.Name = Name;
        }
    }
}