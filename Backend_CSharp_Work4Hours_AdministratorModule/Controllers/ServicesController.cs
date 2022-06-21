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
    public class ServicesController : ControllerBase
    {
        Services service = new Services();
        // GET: api/<ServicesController>
        [HttpGet]
        public string Get()
        {
            return service.listServices();
        }

        // PUT api/<ServicesController>/5
        [HttpPut]
        public string Put([FromBody] List<ChangeState> array)
        {
            return service.suspensionServices(array);
        }
    }
}