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
        private Appeal _apelacion;
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

        public Appeal Apelacion
        {
            get { return _apelacion; }
            set { _apelacion = value; }
        }

        public Users Usuario
        {
            get { return _usuario; }
            set { _usuario = value; }
        }

        public string listServices()
        {
            string sql = "SELECT s.idservicio, s.nombre as nombreServicio, s.descripcion as descripcionServicio, u.idusuario, SUBSTRING_INDEX(u.nombres, ' ', 1) as nombreUsuario, u.fotop, e.nombre_estado as estado, a.descripcion as apelacion, count(sr.id) as cantidadReportes  FROM servicios s INNER JOIN estados e on s.estado=e.id  LEFT JOIN usuarios u on s.usuario=u.idusuario LEFT JOIN apelaciones a on s.apelacion=a.idapelacion LEFT JOIN servicio_reportes sr on sr.idservicio=s.idservicio group by s.idservicio ;";
            return db.ConvertDataTabletoString(sql);
        }
    }
}