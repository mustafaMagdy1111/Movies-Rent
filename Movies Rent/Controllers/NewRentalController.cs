using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Movies_Rent.Models;
using Movies_Rent.ViewModels;

namespace Movies_Rent.Controllers
{
    public class NewRentalController : Controller
    {
        private ApplicationDbContext _context;
        public NewRentalController()
        {
            _context = new ApplicationDbContext();
        }
        protected override void Dispose(bool disposing)
        {
            _context.Dispose();
        }


        public ActionResult New()
        {
            var customernames = _context.Customer.Select(m => new SelectListItem() { Text = m.name, Value = m.id.ToString() }).ToList();
            var moviesnames = _context.movies.Select(m => new SelectListItem() { Text = m.Name, Value = m.ID.ToString() }).ToList();
            var viewModel = new customermovie
            {
                movies = moviesnames,
                customers = customernames
            };

            return View(viewModel);
        }

        [HttpPost]
        public ActionResult Save(customermovie model)
        {

            var customer = _context.Customer.Single(
               c => c.id == model.customer);

            var movies = _context.movies.Where(
                m => model.CustmoerMovies.Contains(m.ID)).ToList();

            foreach (var movie in movies)
            {


           

                var rental = new Rental
                {
                    customer = customer,
                    movie = movie,
                    DateRented = DateTime.Now,
                    Name=customer.name
                };

                _context.rentals.Add(rental);
                _context.SaveChanges();

              
            }


            return RedirectToAction("Customer", "Customer");


        }
    }
}
