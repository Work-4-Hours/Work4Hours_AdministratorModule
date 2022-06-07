using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Backend_CSharp_Work4Hours_AdministratorModule.Models.Entities
{
    public class Reports
    {
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
    }
}