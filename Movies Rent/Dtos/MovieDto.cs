using System;
using System.ComponentModel.DataAnnotations;
using Movies_Rent.Models;

namespace Movies_Rent.Dtos
{
    public class MovieDto
    {
       
        public int ID { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        [Display(Name = "Release Date")]
        public DateTime ReleaseDate { get; set; }
        public DateTime? DateAdded { get; set; }
        [Required]
        [Range(0, 20)]
        [MinNumber]
        public GenreDto Genre { get; set; }
        public int NumberInStocks { get; set; }
       
        [Display(Name = "Genre")]
        public byte GenreID { get; set; }

    }
}