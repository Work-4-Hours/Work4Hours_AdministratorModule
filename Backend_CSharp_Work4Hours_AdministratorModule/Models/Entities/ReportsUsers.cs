using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Backend_CSharp_Work4Hours_AdministratorModule.Models.Entities
{
    public class ReportsUsers
    {
        DataBase db = new DataBase();
        private int _id;
        private Reports _idreporte;
        private Users _idusuario;

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
        public Users Idusuario
        {
            get { return _idusuario; }
            set { _idusuario = value; }
        }

        public string reportsUsers(int idusuario)
        {
            string sql = $"select r.idreporte,r.nombrereporte, count(ur.id) as cantidadReportes from reportes r inner join usuario_reportes ur on r.idreporte=ur.idreporte inner join usuarios u on ur.idusuario=u.idusuario where u.idusuario={idusuario} group by r.nombrereporte;";
            return db.ConvertDataTabletoString(sql);
        }
    }
}