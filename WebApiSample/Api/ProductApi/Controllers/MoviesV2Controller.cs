using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using ProductApi.Models;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace ProductApi.Controllers
{
    [ApiVersion("2.0")]
    //[Route("api/movies")]//api/movies?api-version=2.0
    [Route("api/v{version:apiVersion}/movies")]//api/v2/movies
    //[Route("api/movies")] with MediaTypeApiVersionReader()
    [ApiController]
    public class MoviesV2Controller : ControllerBase
    {
        static List<MoviesV2> movies = new List<MoviesV2>()
        {
            new MoviesV2(){Id=0, Name="John Wick", Description="An action by Keanu Reeves", Type="Action"},
            new MoviesV2(){Id=1, Name="Green Line", Description="A drama by Tom Hanks", Type="Dram"}
        };
        // GET: api/<MoviesV2Controller>
        [HttpGet]
        public IEnumerable<MoviesV2> Get()
        {
            return movies;
        }

        // GET api/<MoviesV2Controller>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<MoviesV2Controller>
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/<MoviesV2Controller>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<MoviesV2Controller>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
