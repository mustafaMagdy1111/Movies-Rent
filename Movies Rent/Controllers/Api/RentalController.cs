 using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Movies_Rent.Models;
using Movies_Rent.Dtos;

namespace Movies_Rent.Controllers.Api
{
    public class RentalController : ApiController
    {
        private ApplicationDbContext _context;
        public RentalController()
        {
            _context = new ApplicationDbContext();
        }

        [HttpPost]
        
        public IHttpActionResult CreateNewRentals(RentalDto newRental)
        {
            var customer = _context.Customer.Single(
                c => c.id == newRental.CutomerId);

            var movies = _context.movies.Where(
                m => newRental.MoviesIds.Contains(m.ID)).ToList();

            foreach (var movie in movies)
            {
                if (movie.NumberAvaible == 0)
                    return BadRequest("Movie is not available.");

                movie.NumberAvaible--;

                var rental = new Rental
                {
                    customer = customer,
                    movie = movie,
                    DateRented = DateTime.Now
                };

                _context.rentals.Add(rental);
            }

            _context.SaveChanges();

            return Ok();
        }






    }
}
