using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Backend_CSharp_Work4Hours_AdministratorModule.Models.Entities
{
    public class Services
    {
        DataBase db = new DataBase();
        private int _idservicio;
        private string _nombre;
        private string _descripcion;

        private State _estado;
        private Users _usuario;

        public int Idservicio
        {
            get { return _idservicio; }
            set { _idservicio = value; }
        }

        public string Nombre
        {
            get { return _nombre; }
            set { _nombre = value; }
        }

        public string Descripcion
        {
            get { return _descripcion; }
            set { _descripcion = value; }
        }

        public State Estado
        {
            get { return _estado; }
            set { _estado = value; }
        }

        public Users Usuario
        {
            get { return _usuario; }
            set { _usuario = value; }
        }

        public string listServices()
        {
            string sql = "SELECT s.idservicio as id, s.nombre as nombreServicio, s.descripcion as descripcionServicio, u.idusuario, SUBSTRING_INDEX(u.nombres, ' ', 1) as nombreUsuario, u.fotop, u.color, e.id as idEstado, e.nombre_estado as estado, case when a.descripcion is null then 'Aun no hay mensaje de apelación' else a.descripcion end as apelacion, count(sr.id) as cantidadReportes  FROM servicios s INNER JOIN estados e on s.estado = e.id  LEFT JOIN usuarios u on s.usuario = u.idusuario LEFT JOIN apelaciones a on s.apelacion = a.idapelacion LEFT JOIN servicio_reportes sr on sr.idservicio = s.idservicio group by s.idservicio; ";
            return db.ConvertDataTabletoString(sql);
        }
        public string searchServices(string wordSearch)
        {
            string sql = $"select s.idservicio as id, s.nombre as nombreServicio, s.descripcion as descripcionServicio, u.idusuario, SUBSTRING_INDEX(u.nombres, ' ', 1) as nombreUsuario, u.fotop, u.color, e.id as idEstado, e.nombre_estado as estado, case when a.descripcion is null then 'Aun no hay mensaje de apelación' else a.descripcion end as apelacion, count(sr.id) as cantidadReportes FROM servicios s INNER JOIN estados e on s.estado = e.id  LEFT JOIN usuarios u on s.usuario = u.idusuario LEFT JOIN apelaciones a on s.apelacion = a.idapelacion LEFT JOIN servicio_reportes sr on sr.idservicio = s.idservicio where s.nombre like '{wordSearch}%' or s.descripcion like '{wordSearch}%'  or u.nombres like '{wordSearch}%' or e.nombre_estado like '{wordSearch}%' or a.descripcion like '{wordSearch}%' group by s.idservicio; ";
            return db.ConvertDataTabletoString(sql);
        }

        public string searchservices(int numberSearch)
        {
            string sql = $"select s.idservicio as id, s.nombre as nombreServicio, s.descripcion as descripcionServicio, u.idusuario, SUBSTRING_INDEX(u.nombres, ' ', 1) as nombreUsuario, u.fotop, u.color, e.id as idEstado, e.nombre_estado as estado, case when a.descripcion is null then 'Aun no hay mensaje de apelación' else a.descripcion end as apelacion, count(sr.id) as cantidadReportes FROM servicios s INNER JOIN estados e on s.estado = e.id  LEFT JOIN usuarios u on s.usuario = u.idusuario LEFT JOIN apelaciones a on s.apelacion = a.idapelacion LEFT JOIN servicio_reportes sr on sr.idservicio = s.idservicio  group by s.idservicio having count(sr.id) = {numberSearch}; ";
            return db.ConvertDataTabletoString(sql);
        }

        public string searchServicesFilter (int option, string searchWord)
        {
            string sql = "";
            if (option == 1)
            {
                sql = $"select s.idservicio as id, s.nombre as nombreServicio, s.descripcion as descripcionServicio, u.idusuario, SUBSTRING_INDEX(u.nombres, ' ', 1) as nombreUsuario, u.fotop, u.color, e.id as idEstado, e.nombre_estado as estado, case when a.descripcion is null then 'Aun no hay mensaje de apelación' else a.descripcion end as apelacion, count(sr.id) as cantidadReportes FROM servicios s INNER JOIN estados e on s.estado = e.id  LEFT JOIN usuarios u on s.usuario = u.idusuario LEFT JOIN apelaciones a on s.apelacion = a.idapelacion LEFT JOIN servicio_reportes sr on sr.idservicio = s.idservicio  group by s.idservicio having count(sr.id) = {Convert.ToInt32(searchWord)}; ";
            }
            else if (option == 2)
            {
                sql = $"select s.idservicio as id, s.nombre as nombreServicio, s.descripcion as descripcionServicio, u.idusuario, SUBSTRING_INDEX(u.nombres, ' ', 1) as nombreUsuario, u.fotop, u.color, e.id as idEstado, e.nombre_estado as estado, case when a.descripcion is null then 'Aun no hay mensaje de apelación' else a.descripcion end as apelacion, count(sr.id) as cantidadReportes FROM servicios s INNER JOIN estados e on s.estado = e.id  LEFT JOIN usuarios u on s.usuario = u.idusuario LEFT JOIN apelaciones a on s.apelacion = a.idapelacion LEFT JOIN servicio_reportes sr on sr.idservicio = s.idservicio  where s.nombre like '{searchWord}%'group by s.idservicio";
            }
            else if (option == 3)
            {
                sql = $"select s.idservicio as id, s.nombre as nombreServicio, s.descripcion as descripcionServicio, u.idusuario, SUBSTRING_INDEX(u.nombres, ' ', 1) as nombreUsuario, u.fotop, u.color, e.id as idEstado, e.nombre_estado as estado, case when a.descripcion is null then 'Aun no hay mensaje de apelación' else a.descripcion end as apelacion, count(sr.id) as cantidadReportes FROM servicios s INNER JOIN estados e on s.estado = e.id  LEFT JOIN usuarios u on s.usuario = u.idusuario LEFT JOIN apelaciones a on s.apelacion = a.idapelacion LEFT JOIN servicio_reportes sr on sr.idservicio = s.idservicio  where s.tipo like '{searchWord}%'group by s.idservicio; ";
            }

            return db.ConvertDataTabletoString (sql);
        }

        public string suspensionServices(List<ChangeState> array)
        {
            string sql = " ";
            for (int i = 0; i < array.Count; i++)
            {
                sql = $"update servicios set estado = {array[i].IdStatus} where idservicio = {array[i].Id};";
                db.ejecuteSQL(sql);
            }
            return db.ejecuteSQL(sql);
        }
    }
}