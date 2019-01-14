using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebApplicationVidly.Models;
using WebApplicationVidly.ViewModels;

namespace WebApplicationVidly.Controllers
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

        public ActionResult Save()
        {
            var membershipTypes = _context.MembershipTypes.ToList();
            var viewModel = new NewCustomerViewModel
            {
                MembershipTypes = membershipTypes
            };
            return View("CustomerForm",viewModel);
        }

        public ActionResult Edit(int Id)
        {
            var customer = _context.Customers.SingleOrDefault(c => c.Id == Id);
            if (customer==null)
            {
                return HttpNotFound();
            }

            var viewModel = new NewCustomerViewModel
            {
                Customer = customer,
                MembershipTypes=_context.MembershipTypes.ToList()
            };
            return View("CustomerForm", viewModel);
        }

        [HttpPost]
        public ActionResult CreateOrUpdate(Customer customer)
        {
            if (customer.Id == 0)
            {
                _context.Customers.Add(customer);
            }
            else
            {
                var customerInDb = _context.Customers.SingleOrDefault(c => c.Id == customer.Id);
                customerInDb.Name = customer.Name;
                customerInDb.BirthDate = customer.BirthDate;
                customerInDb.IsSubscribedToNewsletter = customer.IsSubscribedToNewsletter;
                customerInDb.MembershipType = customer.MembershipType;
            }
            
            _context.SaveChanges();
            return RedirectToAction("Index","Customers");
        }

        // GET: Customers
        public ViewResult Index()
        {
            var customers = _context.Customers.Include(c=>c.MembershipType).ToList();

            return View(customers);
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