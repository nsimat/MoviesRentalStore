using AutoMapper;
using MoviesRentalStore.Dtos;
using MoviesRentalStore.Models;
using System;
using System.Data.Entity;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace MoviesRentalStore.Controllers.Api
{
    public class CustomersController : ApiController
    {
        private readonly ApplicationDbContext _context;
        private readonly Mapper _mapper;

        public CustomersController()
        {
            _context = new ApplicationDbContext();
            _mapper = new Mapper(MvcApplication._config);
        }

        // GET: /api/Customers
        public IHttpActionResult GetAllCustomers(string query = null)
        {
            var customersQuery = _context.Customers
                .Include(c => c.MembershipType);

            if (!String.IsNullOrWhiteSpace(query))
                customersQuery = customersQuery.Where(c => c.Name.Contains(query));

            //var mapper = MvcApplication._config
            var customerDtos = customersQuery
                .ToList()
                .Select(_mapper.Map<Customer, CustomerDto>);

            return Ok(customerDtos);
        }

        // GET: /api/Customers/id
        public IHttpActionResult GetCustomer(int id)
        {
            var customer =  _context.Customers.SingleOrDefault(c => c.Id == id);

            if (customer == null)
                return NotFound();

            return Ok(_mapper.Map<Customer, CustomerDto>(customer));
        }

        // POST: /api/Customers/
        [HttpPost]
        public IHttpActionResult CreateCustomer(CustomerDto customerDto)
        {
            if (!ModelState.IsValid)
                return BadRequest();

            var customer = _mapper.Map<CustomerDto, Customer>(customerDto);
            _context.Customers.Add(customer);
            _context.SaveChanges();

            customerDto.Id = customer.Id;

            return Created(new Uri(Request.RequestUri + "/" + customer.Id), customerDto);
        }

        // PUT: /api/Customers/id
        [HttpPut]
        public void UpdateCustomer(int id, CustomerDto customerDto)
        {
            if (!ModelState.IsValid)
                throw new HttpResponseException(HttpStatusCode.BadRequest);

            var customerInDB = _context.Customers.SingleOrDefault(c => c.Id == id);

            if (customerInDB == null)
                throw new HttpResponseException(HttpStatusCode.NotFound);

            _mapper.Map<CustomerDto, Customer>(customerDto, customerInDB);// ou aussi Mapper.Map(customerDto, customerInDB)

            //customerInDB.Name = customerDto.Name;
            //customerInDB.BirthDate = customerDto.BirthDate;
            //customerInDB.MembershipTypeId = customerDto.MembershipTypeId;
            //customerInDB.IsSubscribedToNewsletter = customerDto.IsSubscribedToNewsletter;

            _context.SaveChanges();
        }

        // DELETE: /api/Customers/id
        [HttpDelete]
        public void DeleteCustomer(int id)
        {
            var customerInDB = _context.Customers.SingleOrDefault(c => c.Id == id);

            if (customerInDB == null)
                throw new HttpResponseException(HttpStatusCode.NotFound);

            _context.Customers.Remove(customerInDB);
            _context.SaveChanges();
        }
    }
}
