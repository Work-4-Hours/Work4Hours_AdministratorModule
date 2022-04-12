using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;

namespace Backend_CSharp_Work4Hours_AdministratorModule.Models.Entities
{
    public class Reports
    {
        DataBase db = new DataBase();
        private int _idreporte;
        private string _nombrereporte;

        public int Idreporte
        {
            get { return _idreporte; }
            set { _idreporte = value; }
        }

        public string NombreReporte
        {
            get { return _nombrereporte; }
            set { _nombrereporte = value; }
        }

        public string typesReports()
        {
            string sql = "SELECT idreporte,nombrereporte FROM reportes;";
            return db.ConvertDataTabletoString(sql);
        }
    }
}