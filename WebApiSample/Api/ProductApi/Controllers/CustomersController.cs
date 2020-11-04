using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.VisualBasic.CompilerServices;
using ProductApi.Models;

namespace ProductApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomersController : ControllerBase
    {
        static List<Customer> customers = new List<Customer>()
        {
            new Customer(){Id = 0, Name="Murat", Email="murat@gmail.com", Phone="1234567"},
            new Customer(){Id = 0, Name="Kylie", Email="kylie@gmail.com", Phone="2223344"},
        };

        public IEnumerable<Customer> Get()
        {
            return customers;
        }

        [HttpPost]
        public IActionResult Post([FromBody] Customer customer)
        {
            if (ModelState.IsValid)
            {
                customers.Add(customer);
                return Ok();
            }
            return BadRequest(ModelState);
        }
    }
}
