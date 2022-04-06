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
    public class StateController : ControllerBase
    {
        State st = new State();
        // GET: api/<StateController>
        [HttpGet]
        public IEnumerable<State> Get()
        {
            //string sql = "SELECT nombre_estado FROM estados";
            return st.nameState();
        }

        // GET api/<StateController>/5
        [HttpGet("{id}")]

        public string Get(int id)
        {
            return "value";
        }

        // POST api/<StateController>
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/<StateController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<StateController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
