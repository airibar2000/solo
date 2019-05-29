using solo.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Data;

namespace solo.Controllers.Api
{
    public class CustomersController : ApiController
    {
        private MyDBContext _dbContext;
        public CustomersController()
            {
            _dbContext = new MyDBContext();
            }
        // GET Api/customers
        public IEnumerable<Customer> GetCustomers()
            {
            return _dbContext.Customers.ToList();
            }
        // GET API/Customers/1
        public Customer GetCustomer(int id)
            {
            var customer = _dbContext.Customers.Single(c => c.Id == id);
            if(customer == null)
                {
                throw new HttpResponseException(HttpStatusCode.NotFound);
                }else
                {
                return customer;
                };
            }
        [HttpPost]
        public Customer PostCustomer(Customer customer)
            {
            if (!ModelState.IsValid)
                {
                throw new HttpResponseException(HttpStatusCode.BadRequest);
                }else
                {
                _dbContext.Customers.Add(customer);
                _dbContext.SaveChanges();
                return (customer);
                }

            }

        // PUt API/Customers/1
        [HttpPut]
        public void UpdateCustomer(int id,Customer customer)
            {
            if (!ModelState.IsValid)
                {
                throw new HttpResponseException(HttpStatusCode.BadRequest);
                }
            var customerInDb = _dbContext.Customers.SingleOrDefault(c => c.Id == id);
            if (customerInDb == null)
                throw new HttpResponseException(HttpStatusCode.NotFound);
            customerInDb.Name = customer.Name;
            customerInDb.Birthdate = customer.Birthdate;
            customerInDb.IsSubscribedToNewsLetter = customer.IsSubscribedToNewsLetter;
            customerInDb.MembershipTypeId = customer.MembershipTypeId;
            _dbContext.SaveChanges();

            }
        // Delete /Api/customers/1
        [HttpDelete]
        public void DeleteCustomer(int id)
            {
            if (!ModelState.IsValid)
                {
                throw new HttpResponseException(HttpStatusCode.BadRequest);
                }
            var customerInDb = _dbContext.Customers.SingleOrDefault(c => c.Id == id);
            if (customerInDb == null)
                throw new HttpResponseException(HttpStatusCode.NotFound);
            _dbContext.Customers.Remove(customerInDb);
            _dbContext.SaveChanges();

            }

        }

    }
