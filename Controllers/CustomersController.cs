using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data.Entity;
using System.Web.Configuration;
using Libly.Models;
using Libly.ViewModels;
using Microsoft.Owin.Security.Provider;

namespace Libly.Controllers
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

        public ViewResult Index()
        {
            if (User.IsInRole(RoleName.CanManageBooks)) return View("Index");

            return View("ReadOnlyIndex");
        }

        public ActionResult Details(int id)
        {
            var customer = _context.Customers.Include(c => c.Membership).SingleOrDefault(c => c.Id == id);

            if (customer == null) return HttpNotFound();

            return View(customer);
        }
        [Authorize(Roles = RoleName.CanManageBooks)]
        public ActionResult NewCustomer()
        {
            var memberships = _context.Memberships.ToList();

            var viewModel = new CustomerFormViewModel
            {
                Customer = new Customer(),
                Memberships = memberships
            };


            return View("CustomerForm", viewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Save(Customer customer)
        {
            if (!ModelState.IsValid)
            {
                var viewModel = new CustomerFormViewModel
                {
                    Customer = customer,
                    Memberships = _context.Memberships.ToList()
                };
                return View("CustomerForm", viewModel);
            }
            if(customer.Id == 0) _context.Customers.Add(customer);
            else
            {
                var customerInDb = _context.Customers.Single(c => c.Id == customer.Id);

                customerInDb.Name = customer.Name;
                customerInDb.Birthday = customer.Birthday;
                customerInDb.MembershipId = customer.MembershipId;
                customerInDb.IsSubscribed = customer.IsSubscribed;
            }

            _context.SaveChanges();
            return RedirectToAction("Index", "Customers");
        }
        [Authorize(Roles = RoleName.CanManageBooks)]
        public ActionResult Edit(int id)
        {
            var customer = _context.Customers.SingleOrDefault(c => c.Id == id);
            var viewModel = new CustomerFormViewModel
            {
                Customer = customer,
                Memberships = _context.Memberships.ToList()
            };

            if (customer == null) return HttpNotFound();
            return View("CustomerForm", viewModel);
        }
    }

   
}   
