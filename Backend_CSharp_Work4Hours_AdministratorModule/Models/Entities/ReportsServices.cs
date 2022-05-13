using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Backend_CSharp_Work4Hours_AdministratorModule.Models.Entities
{
    public class ReportsServices
    {
        DataBase db = new DataBase();
        private int _id;
        private Reports _idreporte;
        private Services _idservicio;

        public int Id
        {
            get { return _id; }
            set { _id = value; }
        }

        public Reports Idreporte
        {
            get { return _idreporte; }
            set { _idreporte = value; }
        }

        public Services Idservicio
        {
            get { return _idservicio; }
            set { _idservicio = value; }
        }

        public string reportsServices(int idservicio)
        {
            string sql = $"select r.idreporte,r.nombrereporte, count(sr.idreporte) as cantidadReportes from reportes r left join servicio_reportes sr on r.idreporte=sr.idreporte where sr.idservicio={idservicio} group by r.nombrereporte";
            return db.ConvertDataTabletoString(sql);
        }
    }
}