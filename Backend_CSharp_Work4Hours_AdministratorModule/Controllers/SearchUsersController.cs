using Backend_CSharp_Work4Hours_AdministratorModule.Models.Entities;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Backend_CSharp_Work4Hours_AdministratorModule.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SearchUsersController : ControllerBase
    {
        Users user = new Users();
        // GET: api/<SearchUsersController>
        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET api/<SearchUsersController>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<SearchUsersController>
        [HttpPost]
        public string Post([FromQuery] string value)
        {
            return user.searchusers(value);
        }

        [HttpPost("/generalSearchReports")]
        public string PostReports([FromQuery] int value)
        {
            return user.searchUsers(value);
        }

        [HttpPost("/busqueda/filter")]
        public string PostFilter([FromQuery] int value, string word)
        {
            return user.searchUsersFilters(value, word);
        }

        // PUT api/<SearchUsersController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<SearchUsersController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
