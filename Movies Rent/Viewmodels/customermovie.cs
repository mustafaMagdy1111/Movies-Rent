using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Movies_Rent.Models;
using Movies_Rent.Controllers;
using System.Web.Mvc;

namespace Movies_Rent.ViewModels
{
    public class customermovie
    {
        public customermovie()
        {
            CustmoerMovies = new List<int>();
        }
        public List<SelectListItem> movies { get; set; }
        public List<SelectListItem> customers { get; set; }
        public int customer { get; set; }
        public List<int> CustmoerMovies { get; set; }
    }
}