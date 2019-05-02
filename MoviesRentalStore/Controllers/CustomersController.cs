using MoviesRentalStore.Models;
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
        // GET: Customers
        public ActionResult Index()
        {
            var customers = new List<Customer>
            {
                new Customer{ Id = 1, Name = "Igor Masamuna"},
                new Customer{ Id = 2, Name = "Mike Gregory"},
                new Customer{ Id = 3, Name = "Anny Kizola"}
            };

            ViewBag.Customers = customers;


            var movie = new Movie() { Name = "Romance à Kinshsa" };
            ViewBag.Movie = movie;

            var movies = new List<Movie>
            {
                new Movie{ Name = "Trois morts à zéro"},
                new Movie{ Name = "Mission suicide à Singapour"},
                new Movie{ Name = "Inferno"}
            };

            ViewBag.Movies = movies;
            return View();
        }

        public ActionResult Edit(int id)
        {
            var customers = new List<Customer>
            {
                new Customer{ Id = 1, Name = "Igor Masamuna"},
                new Customer{ Id = 2, Name = "Mike Gregory"},
                new Customer{ Id = 3, Name = "Anny Kizola"}
            };

            var customer = customers.Find(x => x.Id == id);

            ViewBag.Name = customer.Name;
          
            return View();
        }
    }
}