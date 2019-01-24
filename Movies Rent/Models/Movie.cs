using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Movies_Rent.Models
{
    public class Movie
    {
        public int ID {get; set; }
       [Required]
        public string Name { get; set; }
       [Required]
        [Display(Name = "Release Date")]
        public DateTime ReleaseDate { get; set; }
        public DateTime? DateAdded { get; set; }
        [Required]
        [Range(0,20)]
        [MinNumber]
        [Display(Name = "Number In stock")]
        public int NumberInStocks { get; set; }
        public Genre Genre { get; set; }
        [Display(Name = "Genre")]
        public byte GenreID { get; set; }

        public byte NumberAvaible { get; set; }
    }
}