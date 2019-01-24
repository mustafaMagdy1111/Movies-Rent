using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Movies_Rent.Models;
using Movies_Rent.Viewmodels;
using System.Data.Entity;
using Movies_Rent.ViewModels;

namespace Movies_Rent.Controllers
{
    public class CustomerController : Controller
    {
        private ApplicationDbContext _context;


        public CustomerController()
        {
            _context = new ApplicationDbContext();
        }
        protected override void Dispose(bool disposing)
        {
            _context.Dispose();
        }
        
        public ActionResult New()
        {

            var membershipTypes = _context.MemberShipType.ToList();
            var viewModel = new CustomerFormViewModel
            {
                Customer = new customer(),
                MembershipTypes = membershipTypes
            };

            return View(viewModel);
        }

        [HttpPost]
        public ActionResult Create (customer customer)
        {
            _context.Customer.Add(customer);
            _context.SaveChanges();
            return RedirectToAction("Customer", "Customer");
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Save(customer customer)
        {
            if(!ModelState.IsValid)
            {
                var viewmodel = new CustomerFormViewModel
                {
                    Customer = customer,
                    MembershipTypes = _context.MemberShipType.ToList()

                };
            return View("New", viewmodel);
            }


            if (customer.id == 0)
            {
                _context.Customer.Add(customer);
            }
            else
            {
                var customerInDb = _context.Customer.Single(c => c.id == customer.id);
                customerInDb.name = customer.name;
                customerInDb.Birthdate = customer.Birthdate;
                customerInDb.MemberShipTypeId = customer.MemberShipTypeId;
                customerInDb.IsSubscribedToNewLetter = customer.IsSubscribedToNewLetter;

            }

            _context.SaveChanges();
            return RedirectToAction("Customer", "Customer");
        }
        public ActionResult Edit(int id)
        {
            var customer = _context.Customer.SingleOrDefault(c => c.id == id);
            if (customer == null)
                return HttpNotFound();
            var viewmodel = new CustomerFormViewModel
            {
                Customer = customer,
                MembershipTypes = _context.MemberShipType.ToList()
             };

            return View("New",viewmodel);
            
        }




        // GET: Customer
        public ActionResult Customer()
        {
            //var customer = _context.Customer.Include(c => c.MemberShipType).ToList();
            return View();
        }

        public ActionResult Details(int id)
        {
            var customer = _context.Customer.Include(c => c.MemberShipType).SingleOrDefault(c => c.id == id);
            if (customer == null)
                return HttpNotFound();
            return View(customer);
        }
 




    }
}
       