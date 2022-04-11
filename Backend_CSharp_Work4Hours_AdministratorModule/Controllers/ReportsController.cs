using Backend_CSharp_Work4Hours_AdministratorModule.Models;
using Backend_CSharp_Work4Hours_AdministratorModule.Models.Entities;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Backend_CSharp_Work4Hours_AdministratorModule.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ReportsController : ControllerBase
    {
        DataBase db = new DataBase();
        // GET: api/<ReportsController>
        [HttpGet]
        public IEnumerable<Reports> Get()
        {
            string sql = "SELECT idreporte,nombrereporte FROM reportes;";
            DataTable dt = db.getTable(sql);

            List<Reports> reportsList = new List<Reports>();
            reportsList = (from DataRow dr in dt.Rows
                          select new Reports()
                          {
                              Idreporte = Convert.ToInt32(dr["idreporte"]),
                              NombreReporte = dr["nombrereporte"].ToString()
                          }).ToList();
            return reportsList;
        }

    }
}
