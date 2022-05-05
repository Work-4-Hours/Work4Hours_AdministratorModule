using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;

namespace Backend_CSharp_Work4Hours_AdministratorModule.Models.Entities
{
    public class Users
    {
        DataBase db = new DataBase();
        private int _idusuario;
        private string _nombres;
        private string _apellidos;
        private string _correo;
        private string _fotop;

        private State _estado;
        /*private Roles _rol;*/

        public int Idusuario
        {
            get { return _idusuario; }
            set { _idusuario = value; }
        }

        public string Nombres
        {
            get { return _nombres; }
            set { _nombres = value; }
        }

        public string Apellidos
        {
            get { return _apellidos; }
            set { _apellidos = value; }
        }

        public string Correo
        {
            get { return _correo; }
            set { _correo = value; }
        }

        public string Fotop
        {
            get { return _fotop; }
            set { _fotop = value; }
        }

        public State Estado
        {
            get { return _estado; }
            set { _estado = value; }
        }

        public string listUsers()
        {
            string sql = "SELECT u.idusuario, u.nombres, u.apellidos, u.correo, u.fotop, count(ur.id) as cantidadReportes,e.id as idEstado, e.nombre_estado FROM usuarios u INNER JOIN estados e on u.estado = e.id LEFT JOIN usuario_reportes ur on u.idusuario = ur.idusuario group by u.idusuario;";
            return db.ConvertDataTabletoString(sql);
        }

        public string searchUsers( int searchNumber )
        {
            string sql = $"select u.idusuario,u.nombres, u.apellidos, u.correo, case when count(ur.id)= 0 then 0 else count(ur.id) end as cantidadReportes, e.nombre_estado from usuarios u inner join estados e on u.estado = e.id left join usuario_reportes ur ON u.idusuario = ur.idusuario where u.nombres like '{searchNumber}%' or u.apellidos like '{searchNumber}%' or u.correo like '{searchNumber}%' or e.nombre_estado like '{searchNumber}%' or 1 like '{searchNumber}%' group by u.idusuario;";
            return db.ConvertDataTabletoString(sql);
        }
    }
}