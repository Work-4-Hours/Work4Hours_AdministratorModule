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
    public class UsersController : ControllerBase
    {
        Users user = new Users();
        // GET: api/<UsersController>
        [HttpGet]
        public string Get()
        {
            return user.listUsers();
        }

        // PUT api/<UsersController>/5
        [HttpPut]
        public string Put([FromBody] List<ChangeState> array)
        {
            return user.suspensionUsers(array);
        }
    }
}