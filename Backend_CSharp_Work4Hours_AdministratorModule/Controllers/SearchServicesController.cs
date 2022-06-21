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
    public class SearchServicesController : ControllerBase
    {
        Services service = new Services();

        // POST api/<SearchServicesController>
        [HttpPost]
        public string Post([FromQuery] string value)
        {
            return service.searchServices(value);
        }

        [HttpPost("/generalSearchReportsServices")]
        public string PostReports([FromQuery] int value)
        {
            return service.searchservices(value);
        }

        [HttpPost("/searchServices/filter")]
        public string PostFilter([FromQuery] int value, string word)
        {
            return service.searchServicesFilter(value, word);
        }
    }
}