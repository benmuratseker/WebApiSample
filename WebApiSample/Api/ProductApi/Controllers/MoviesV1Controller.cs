using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using ProductApi.Models;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace ProductApi.Controllers
{
    [ApiVersion("1.0")]
    //[Route("api/movies")]/api/movies?api-version=1.0
    [Route("api/v{version:apiVersion}/movies")]//api/v1/movies
    //[Route("api/movies")]//MediaTypeApiVersionReader()
    [ApiController]
    public class MoviesV1Controller : ControllerBase
    {
        static List<MoviesV1> movies = new List<MoviesV1>()
        {
            new MoviesV1(){Id=0, Name="Movie 1"},
            new MoviesV1(){Id=1, Name="Movie 2"}
        };
        // GET: api/<MoviesV1Controller>
        [HttpGet]
        public IEnumerable<MoviesV1> Get()
        {
            return movies;
        }

        // GET api/<MoviesV1Controller>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<MoviesV1Controller>
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/<MoviesV1Controller>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<MoviesV1Controller>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
