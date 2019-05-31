using solo.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Data;
using solo.Dtos;
using AutoMapper;

namespace solo.Controllers.Api
{
    public class CustomersController : ApiController
    {
        private readonly MyDBContext _dbContext;
        public CustomersController()
            {
            _dbContext = new MyDBContext();
            }
        // GET Api/customers
        public IEnumerable<CustomerDto> GetCustomers()
            {
            return _dbContext.Customers.ToList().Select(Mapper.Map<Customer, CustomerDto>);
            }
        // GET API/Customers/1
        public IHttpActionResult GetCustomer(int id)
            {
            var customer = _dbContext.Customers.Single(c => c.Id == id);
            if(customer == null)
                {
                return NotFound();
                }else
                {
                return Ok(Mapper.Map<Customer,CustomerDto>(customer));
                };
            }
        [HttpPost]
        public IHttpActionResult PostCustomer(CustomerDto customerDto)
            {
            if (!ModelState.IsValid)
                {
                return BadRequest();
                }else
                {
                var customer = Mapper.Map<CustomerDto, Customer>(customerDto);
                _dbContext.Customers.Add(customer);
                _dbContext.SaveChanges();
                customerDto.Id = customer.Id;
                return Created(new Uri(Request.RequestUri + "/" + customer.Id),customerDto);
                }

            }

        // PUt API/Customers/1
        [HttpPut]
        public IHttpActionResult UpdateCustomer(int id,CustomerDto customerDto)
            {
            if (!ModelState.IsValid)
                {
                return BadRequest();
                }

            var customerInDb = _dbContext.Customers.SingleOrDefault(c => c.Id == id);
            if (customerInDb == null)
                throw new HttpResponseException(HttpStatusCode.NotFound);
            Mapper.Map(customerDto, customerInDb);
            _dbContext.SaveChanges();
            return Ok();
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
