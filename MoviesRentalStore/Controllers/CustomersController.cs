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

        public ActionResult New()
        {
            var membershipTypes = _context.MembershipTypes.ToList();
            var viewModel = new CustomerFormViewModel
            {
                MembershipTypes = membershipTypes
            };

            return View("CustomerForm", viewModel);
        }

        [HttpPost]
        public ActionResult Create(CustomerFormViewModel viewModel)//(Customer customer)
        {
            Customer customer = viewModel.Customer;
            _context.Customers.Add(customer);
            _context.SaveChanges();

            return RedirectToAction("Index", "Customers");
        }
        // GET: Customers
        public ActionResult Index()
        {
            var customers = _context.Customers.Include(x => x.MembershipType).ToList();
            
            return View(customers);
        }        

        public ActionResult Edit(int id)
        {
            var customer = _context.Customers.SingleOrDefault(x => x.Id == id);

            if (customer == null)
                return HttpNotFound();

            var viewModel = new CustomerFormViewModel
            {
                Customer = customer,
                MembershipTypes = _context.MembershipTypes.ToList()
            };
            return View("CustomerForm", viewModel);
        }

        public ActionResult Details(int id)
        {
            var customer = _context.Customers.Include(c => c.MembershipType).SingleOrDefault(c => c.Id == id);

            if (customer == null)
                return HttpNotFound();

            return View(customer);
        }
    }
}