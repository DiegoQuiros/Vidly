using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Vidly.Models;
using Vidly.ViewModels;

namespace Vidly.Controllers
{
    public class CustomersController : Controller
    {
        // GET: Customers/Index
        public ActionResult Index()
        {
            var customers = new List<Customer>
            {
                new Customer { Id = 1, Name = "John Smith"},
                new Customer { Id = 2, Name = "Mary Wiliams"}
            };

            var viewModel = new ViewModels.CustomersViewModel
            {
                Customers = customers
            };
            return View(viewModel);
        }

        [Route("Customers/Details/{id}")]
        public ActionResult Details(int id)
        {
            if (id > 2)
                return HttpNotFound();

            var customer = new Customer { Id = id, Name = "" };
            if (id == 1)
                customer.Name = "John Smith";
            else
                customer.Name = "Mary Williams";
            return View(customer);
        }
}
}