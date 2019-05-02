using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MoviesRentalStore.Models;
using MoviesRentalStore.ViewModels;

namespace MoviesRentalStore.Controllers
{
    public class MoviesController : Controller
    {
        // GET: Movies/Random
        public ActionResult Random()
        {
            var movie = new Movie() {Name = "Die Hard 4 - A Good Day to Die Hard"};
            ViewData["Movie"] = movie;
            ViewBag.Movie = movie;

            var Customers = new List<Customer>
            {
                new Customer {Name = "Igor Masamuna"},
                new Customer {Name = "Michel Dimiroff"},
                new Customer {Name = "Georges Montana"},
                new Customer {Name = "Elisée Kitoko"},
                new Customer {Name = "Julien Kembisi"}
            };

            var viewModel = new RandomMovieViewModel
            {
                Movie = movie,
                Customers = Customers
            };

            return View(viewModel);
        }

        public ActionResult Edit(int id)
        {
            return Content("Id = " + id);
        }

        //Movies
        public ActionResult Index(int? pageIndex, string sortBy)
        {
            if (!pageIndex.HasValue)
                pageIndex = 1;
            if (String.IsNullOrWhiteSpace(sortBy))
                sortBy = "Name";

            return Content(String.Format("pageIndex={0} & sortBy={1}", pageIndex, sortBy));
        }

        [Route("movies/released/{year}/{month:regex(\\d{2}):range(1,12)}")]
        public ActionResult ByReleaseYear(int year, int month)
        {
            return Content(year + "/" + month);
        }

    }
}