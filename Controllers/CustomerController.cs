using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data.Entity;
using solo.ViewModels;
using solo.Models;

namespace solo.Controllers
{
    public class CustomerController : Controller
    {
        // Connect the controller with database
        private readonly MyDBContext _myDb;
        public CustomerController()
            {
            _myDb = new MyDBContext();

            }
        protected override void Dispose(bool disposing)
            {
            _myDb.Dispose();
            }
        // end conect controler with database 
        // GET: Customer
       
        [Route("Customer/Detail/{id}")]
        public ActionResult Detail(int id) {
            //public ViewDetail CustomerDetail = new ViewDetail();

            //var CustomerDetail = _myDb.Customers.SingleOrDefault(c => c.Id == id);
            var CustomerDetail = _myDb.Customers.Include(c => c.MembershipType).SingleOrDefault(c => c.Id == id);
            if (CustomerDetail == null)
                {
                return HttpNotFound();
                }
            
            return View(CustomerDetail);
            }
        [Route("listofCustomer")]
        public ViewResult Index()
            {
            var customer = _myDb.Customers.Include(c => c.MembershipType).ToList();
            return View(customer);
            }

        [Route("Customer/NewCustomer/{id}")]
        public ActionResult NewCustomer() {

            var membershiptype = _myDb.MembershipTypes.ToList();
            var newCustomer = new CustomerExtras
                {
                MembershipTypes = membershiptype
                };
            return View(newCustomer);
            }
            [HttpPost]
            public ActionResult Save(Customer customer)
            {
            if (!ModelState.IsValid)
                {
                var viewModel = new CustomerExtras
                    {
                    Customer = customer,
                    MembershipTypes = _myDb.MembershipTypes.ToList()
                    };
                return View("NewCustomer",viewModel);
                }
            if (customer.Id == 0)
                {
                _myDb.Customers.Add(customer);
               
                }else
                {
                var customerInDb = _myDb.Customers.Single(c => c.Id == customer.Id);
                customerInDb.Name = customer.Name;
                customer.Birthdate = customer.Birthdate;
                customerInDb.MembershipTypeId = customer.MembershipTypeId;
                customerInDb.IsSubscribedToNewsLetter = customer.IsSubscribedToNewsLetter;


                }
            _myDb.SaveChanges();
            return RedirectToAction("Index", "Customer");
            }
        [Route("Customer/Edit/{id}")]
        public ActionResult Edit(int id)
            {
            var customer = _myDb.Customers.SingleOrDefault(c => c.Id == id);
            if (customer == null)
                return HttpNotFound();
            var viewModel = new CustomerExtras
                {
                Customer = customer,
                MembershipTypes = _myDb.MembershipTypes.ToList()
                };
            return View("NewCustomer", viewModel);


            }
        }
}