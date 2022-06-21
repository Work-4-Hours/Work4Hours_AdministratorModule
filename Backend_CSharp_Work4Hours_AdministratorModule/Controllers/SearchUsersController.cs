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

        [HttpPost("/searchUsers/filter")]
        public string PostFilter([FromQuery] int value, string word)
        {
            return user.searchUsersFilters(value, word);
        }
    }
}