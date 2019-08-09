﻿using AutoMapper;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Vidly.Dtos;
using Vidly.Models;

namespace Vidly.Controllers.Api
{
    public class CustomersController : ApiController
    {
        private ApplicationDbContext _context;

        public CustomersController()
        {
            _context = new ApplicationDbContext();
        }

        // GET /api/customers
        public IHttpActionResult GetCustomers(string query = null)
        {
            var customersQuery = _context.Customers
                .Include(c => c.MembershipType);

            if (!String.IsNullOrWhiteSpace(query))
                customersQuery = customersQuery.Where(c => c.Name.Contains(query));

            var customerDtos = customersQuery
                .ToList()
                .Select(Mapper.Map<Customer, CustomerDto>); // sem o () no método Map pois queremos apenas a referência a esse método, para passar ao parametro delegate.

            return Ok(customerDtos); 
        }

        // GET /api/customers/1
        public IHttpActionResult GetCustomer(int id)
        {
            var customer = _context.Customers.SingleOrDefault(c => c.Id == id);

            if (customer == null)
            {
                //throw new HttpResponseException(HttpStatusCode.NotFound);
                return NotFound();
            }

            return Ok(Mapper.Map<Customer, CustomerDto>(customer));
        }

        // POST /api/customers
        [HttpPost] //Método só vai ser chamado se for uma requisição POST
        [Authorize(Roles = RoleName.CanManageMovies)]
        public IHttpActionResult CreateCustomer(CustomerDto customerDto)
        {
            if (!ModelState.IsValid)
            {
                //throw new HttpResponseException(HttpStatusCode.BadRequest);
                return BadRequest();
            }                

            var customer = Mapper.Map<CustomerDto, Customer>(customerDto);
            _context.Customers.Add(customer);
            _context.SaveChanges();

            customerDto.Id = customer.Id; // Adicionando o Id gerado no banco ao Dto

            return Created(new Uri(Request.RequestUri + "/" + customer.Id), customerDto); // Passando a URI: /api/customers/1
        }

        // PUT /api/customers/1
        [HttpPut]
        [Authorize(Roles = RoleName.CanManageMovies)]
        public IHttpActionResult UpdateCustomer(int id, CustomerDto customerDto)
        {
            if (!ModelState.IsValid)
            {
                // throw new HttpResponseException(HttpStatusCode.BadRequest);
                return BadRequest();
            }                

            var customerInDb = _context.Customers.SingleOrDefault(c => c.Id == id);

            if (customerInDb == null)
            {
                // throw new HttpResponseException(HttpStatusCode.NotFound);
                return NotFound();
            }                

            Mapper.Map(customerDto, customerInDb); // O 2º parametro é o objeto a ser preenchido            
            
            _context.SaveChanges();

            return Ok();
        }

        // DELETE /api/customers/1
        [HttpDelete]
        [Authorize(Roles = RoleName.CanManageMovies)]
        public IHttpActionResult DeleteCustomer(int id)
        {
            var customerInDb = _context.Customers.SingleOrDefault(c => c.Id == id);

            if (customerInDb == null)
            {
                //throw new HttpResponseException(HttpStatusCode.NotFound);
                return NotFound();
            }

            _context.Customers.Remove(customerInDb);
            _context.SaveChanges();

            return Ok();
        }
    }
}










