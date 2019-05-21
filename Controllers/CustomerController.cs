using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using solo.ViewModels;
using solo.Models;

namespace solo.Controllers
{
    public class CustomerController : Controller
    {
        // GET: Customer
        [Route("listofCustomer")]
        public ActionResult Index()
        {
            var listofcustomer = new ListViewModel();
            List<Customer> ListofCustomers = new List<Customer>()
                {
                new Customer
                    {
                    Id = 1,
                    Name = "Customer 1"
                    },
                new Customer
                    {
                    Id = 2,
                    Name = "Customer 2"
                    },
                new Customer
                    {
                    Id = 3,
                    Name = "Customer 3"
                    }
                };

            listofcustomer.Listofcustomers = ListofCustomers;
            ViewBag.LT = listofcustomer;
            return View(listofcustomer);
            //return Content("llege");
        }
        [Route("Customer/Detail/{id}")]
        public ActionResult Detail(Customer x) {
            //public ViewDetail CustomerDetail = new ViewDetail();


            var CustomerDetail = new ViewDetail() {
                ID = x.Id,
                NAME = x.Name
                };
            
            //return Content("ID = "+id);
            return View(CustomerDetail);
            }
        }
}