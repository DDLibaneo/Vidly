﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Vidly.Models;
using Vidly.ViewModels;
using System.Data.Entity;
using System.Runtime.Caching;

namespace Vidly.Controllers
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

        // GET: Customers
        public ViewResult Index()
        {
            /* Since we are now using ajax in the view to request the list of customers we don't need to return the list of customers anymore. */
            // var customers = _context.Customers.Include(c => c.MembershipType).ToList(); //A query só é executada na tabela do banco quando é feita uma iteração
            // return View(customers);

            //if (MemoryCache.Default["Genres"] == null) //Coloca os Genres no Cache
            //{
            //    MemoryCache.Default["Genres"] = _context.Genres.ToList();
            //}
            //var genres = MemoryCache.Default["Genres"] as IEnumerable<Genre>;

            return View();
        }

        //GET: Customers/Details/<Id>
        [Authorize(Roles = RoleName.CanManageMovies)]
        public ActionResult Details(int Id)
        {
            var customer = _context.Customers.Include(c => c.MembershipType).SingleOrDefault(c => c.Id == Id);

            if (customer == null)
                return HttpNotFound();

            return View(customer);
        }

        [Authorize(Roles = RoleName.CanManageMovies)]
        public ActionResult New()
        {
            var membershipTypes = _context.MembershipTypes.ToList();
            var viewModel = new CustomerFormViewModel(membershipTypes, new Customer());

            return View("CustomerForm", viewModel);
        }

        [HttpPost] //Esse método só pode ser chamado usando HttpPost, e não HttpGet
        [ValidateAntiForgeryToken]
        [Authorize(Roles = RoleName.CanManageMovies)]
        public ActionResult Save(Customer customer)
        {
            if (!ModelState.IsValid)
            {
                var viewModel = new CustomerFormViewModel(_context.MembershipTypes.ToList(), customer);
                return View("CustomerForm", viewModel);
            }
            if (customer.Id == 0)
            {
                _context.Customers.Add(customer); //does not interfere in database, only memory
            }
            else
            {
                var customerInDb = _context.Customers.Single(c => c.Id == customer.Id);
                //TryUpdateModel(customerInDb); Não recomendado pq faz update em todas propriedades da model
                customerInDb.Name = customer.Name;
                customerInDb.Birthdate = customer.Birthdate;
                customerInDb.MembershipTypeId = customer.MembershipTypeId;
                customerInDb.IsSubscribedNewsLatter = customer.IsSubscribedNewsLatter;                
            }
            
            _context.SaveChanges(); //Generates Runs the SQL on the Database

            return RedirectToAction("Index", "Customers");
        }

        [Authorize(Roles = RoleName.CanManageMovies)]
        public ActionResult Edit(int Id)
        {
            var customer = _context.Customers.SingleOrDefault(c => c.Id == Id);

            if (customer == null)
                return HttpNotFound();

            var viewModel = new CustomerFormViewModel(_context.MembershipTypes.ToList(), customer);

            return View("CustomerForm", viewModel); //Buscando a View "New" ao invés de "Edit"
        }
    }
}