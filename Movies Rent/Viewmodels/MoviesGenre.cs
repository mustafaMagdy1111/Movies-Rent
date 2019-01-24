using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Movies_Rent.Models;

using Movies_Rent.Controllers;


namespace Movies_Rent.Viewmodels
{
    public class MoviesGenre
    {
        public IEnumerable<Genre> genreTypes { get; set; }
        public Movie movie { get; set; }

    }
}