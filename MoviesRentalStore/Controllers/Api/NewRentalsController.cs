using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using MoviesRentalStore.Dtos;

namespace MoviesRentalStore.Controllers.Api
{
    public class NewRentalsController : ApiController
    {
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
            throw new NotImplementedException();
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
