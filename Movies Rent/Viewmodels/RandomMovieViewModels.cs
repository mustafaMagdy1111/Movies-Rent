using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Movies_Rent.Models;

namespace Movies_Rent.Viewmodels
{
    public class RandomMovieViewModels
    {
        public Movie Movie { get; set; }
        public List<customer>  Customerslist { get; set; }
    }
}