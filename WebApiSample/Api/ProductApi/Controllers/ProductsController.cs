using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ProductApi.Models;

namespace ProductApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        static List<Product> products = new List<Product>()
        {
            new Product(){ ProductId=0, ProductName = "Laptop", Price="200"},
            new Product(){ProductId=1, ProductName ="Smartphone", Price="100"}
        };

        public IActionResult Get()
        {
            return Ok(products);
        }

        //api/products/GetLocal
        [HttpGet("GetLocal")]
        public IActionResult GetCustomMessage()
        {
            return Ok("This is a custom message...");
        }

        [HttpPost]
        public IActionResult Post([FromBody] Product product)
        {
            products.Add(product);
            return StatusCode(StatusCodes.Status201Created);
        }

        [HttpPut("{id}")]
        public void Put(int id, [FromBody] Product product)
        {
            products[id] = product;
        }

        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            products.RemoveAt(id);
        }
    }
}
