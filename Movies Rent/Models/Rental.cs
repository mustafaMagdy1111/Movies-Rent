using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using Movies_Rent.Models;

namespace Movies_Rent.Models
{
    public class Rental
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public DateTime DateRented { get; set; }
        public DateTime? DateReturned { get; set; }
        [Required]
        public customer customer { get; set; }
        [Required]
        public Movie movie { get; set; }
    }
}