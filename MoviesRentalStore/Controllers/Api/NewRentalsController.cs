using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using MoviesRentalStore.Dtos;
using MoviesRentalStore.Models;

namespace MoviesRentalStore.Controllers.Api
{
    public class NewRentalsController : ApiController
    {
        private readonly ApplicationDbContext _context;

        public NewRentalsController()
        {
            _context = new ApplicationDbContext();
        }


        // GET: api/NewRental
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET: api/NewRental/5
        public string Get(int id)
        {
            return "value";
        }

        // POST: api/NewRental
        [HttpPost]
        public IHttpActionResult CreateNewRentals(NewRentalDto newRental)
        {
            var customer = _context.Customers.Single(c => c.Id == newRental.CustomerId);

            var movies = _context.Movies.Where(m => newRental.MovieIds.Contains(m.Id)).ToList();

            foreach (var movie in movies)
            {
                if (movie.NumberAvailable == 0)
                    return BadRequest("Sorry, the movie requested is not available now.");

                movie.NumberAvailable--;

                var rental = new Rental
                {
                    Customer = customer,
                    Movie = movie,
                    DateRented = DateTime.Now
                };

                _context.Rentals.Add(rental);

            }

            _context.SaveChanges();

            return Ok();
        }

        // PUT: api/NewRental/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE: api/NewRental/5
        public void Delete(int id)
        {
        }
    }
}
