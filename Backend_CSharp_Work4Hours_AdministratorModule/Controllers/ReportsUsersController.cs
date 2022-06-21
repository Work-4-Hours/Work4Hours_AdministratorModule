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
    public class ReportsUsersController : ControllerBase
    {
        ReportsUsers ru = new ReportsUsers();
        // GET: api/<ReportsUsersController>
        [HttpGet]
        public string Get([FromQuery] int id)
        {
            return ru.reportsUsers(id);
        }
    }
}