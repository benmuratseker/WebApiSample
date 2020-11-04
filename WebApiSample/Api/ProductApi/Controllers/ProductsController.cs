using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ProductApi.Data;
using ProductApi.Models;

namespace ProductApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private ProductsDbContext context;
        public ProductsController(ProductsDbContext productsDbContext)
        {
            context = productsDbContext;
        }
        //static List<Product> products = new List<Product>()
        //{
        //    new Product(){ ProductId=0, ProductName = "Laptop", Price="200"},
        //    new Product(){ProductId=1, ProductName ="Smartphone", Price="100"}
        //};
        [HttpGet]
        public IEnumerable<Product> Get(string sortPrice)
        {
            IQueryable<Product> products;
            switch (sortPrice)
            {
                case "desc":
                    products = context.Products.OrderByDescending(p => p.Price);
                    break;
                case "asc":
                    products = context.Products.OrderBy(p => p.Price);
                    break;
                default:
                    products = context.Products;
                    break;
            }
            return products;
        }

        [HttpGet("{id}", Name ="Get")]
        public IActionResult Get(int id)
        {
            var product = context.Products.SingleOrDefault(p => p.ProductId == id);
            if (product == null)
                return NotFound("No record found...");

            return Ok(product);
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
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            context.Products.Add(product);
            context.SaveChanges(true);
            return StatusCode(StatusCodes.Status201Created);
        }

        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody] Product product)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            if (id != product.ProductId)
                return BadRequest();
            try
            {
                context.Products.Update(product);
                context.SaveChanges(true);
            }
            catch (Exception e)
            {
                return NotFound("No related record for this id");
            }
           
            return Ok("Product updaated...");
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var product = context.Products.SingleOrDefault(p => p.ProductId == id);
            if (product == null)
                return NotFound("No record found...");

            context.Products.Remove(product);
            context.SaveChanges(true);
            return Ok("Product deleted...");
        }
    }
}
