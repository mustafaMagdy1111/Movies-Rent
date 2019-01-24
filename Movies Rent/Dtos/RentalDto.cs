using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Movies_Rent.Dtos
{
    public class RentalDto
    {
        public int CutomerId { get; set; }
        public List<int> MoviesIds { get; set; }
    }
}