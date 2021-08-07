using System;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using MyShop.Domain.Models;
using MyShop.Infrastructure;
using MyShop.Infrastructure.Repositories;

namespace MyShop.Web.Controllers
{
    public class CustomerController : Controller
    {
        private readonly IRepository<Customer> customerRepository;
        public CustomerController(IRepository<Customer> customerRepository)
        {
            this.customerRepository = customerRepository;
        }

        public IActionResult Index(Guid? id)
        {
            if (id == null)
            {
                var customers = customerRepository.All();

                return View(customers);
            }
            else
            {
                var customer = customerRepository.Get(id.Value);

                return View(new[] { customer });
            }
        }
    }
}
