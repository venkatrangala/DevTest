using DeveloperTest.Business.Interfaces;
using DeveloperTest.Models;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace DeveloperTest.Controllers
{
    [ApiController, Route("[controller]")]
    public class CustomerController : Controller
    {
        private readonly ICustomerService _customerService;
        private static readonly string[] customerType = { "Small", "Large" };

        public CustomerController(ICustomerService customerService)
        {
            _customerService = customerService;
        }

        [HttpGet]
        public IList<CustomerModel> Get()
        {
            return _customerService.GetCustomers();
        }

        [Route("CustomerType"), HttpGet]
        public IEnumerable<string> CustomerType()
        {
            return customerType;
        }

        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            var customer = _customerService.GetCustomerById(id);

            if (customer == null)
            {
                return NotFound();
            }

            return Ok(customer);
        }

        [HttpPost]
        public CustomerModel Create(BaseCustomerModel model)
        {
            return _customerService.CreateCustomer(model);
        }
    }
}