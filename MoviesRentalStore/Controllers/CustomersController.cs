using MoviesRentalStore.Models;
using System.Data.Entity;
using MoviesRentalStore.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MoviesRentalStore.Controllers
{
    public class CustomersController : Controller
    {
        private ApplicationDbContext _context;

        public CustomersController()
        {
            _context = new ApplicationDbContext();
        }

        protected override void Dispose(bool disposing)
        {
            _context.Dispose();
        }
        // GET: Customers
        public ActionResult Index()
        {
            var customers = _context.Customers.Include(x => x.MembershipType).ToList();

            //ViewBag.Customers = customers;


            var movie = new Movie() { Name = "Romance à Kinshsa" };
            ViewBag.Movie = movie;

            var movies = new List<Movie>
            {
                new Movie{ Name = "Trois morts à zéro"},
                new Movie{ Name = "Mission suicide à Singapour"},
                new Movie{ Name = "Inferno"}
            };

            ViewBag.Movies = movies;
            return View(customers);
        }        

        public ActionResult Edit(int id)
        {
            var customer = _context.Customers.SingleOrDefault(x => x.Id == id);
          
            return View(customer);
        }

        public ActionResult Details(int id)
        {
            var customer = _context.Customers.SingleOrDefault(c => c.Id == id);

            if (customer == null)
                return HttpNotFound();

            return View(customer);
        }
    }
}