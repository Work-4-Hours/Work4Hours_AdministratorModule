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
            string sql = "SELECT u.idusuario, u.nombres, u.apellidos, u.correo, case when u.fotop is null then '' else u.fotop end as fotop, u.color, count(ur.id) as cantidadReportes,e.id as idEstado, e.nombre_estado FROM usuarios u INNER JOIN estados e on u.estado = e.id LEFT JOIN usuario_reportes ur on u.idusuario = ur.idusuario group by u.idusuario order by count(ur.id) desc;" ;
            return db.ConvertDataTabletoString(sql);
        }

        public string searchUsers( int searchNumber )
        {
            string sql = $"select u.nombres, u.apellidos, u.correo, case when u.fotop is null then '' else u.fotop end as fotop, u.color, count(ur.id) as cantidadReportes, e.nombre_estado from usuarios u inner join estados e on u.estado = e.id left join usuario_reportes ur ON u.idusuario = ur.idusuario group by u.idusuario having count(ur.id) = {searchNumber}; ";
            return db.ConvertDataTabletoString(sql);
        }
        public string searchusers(string searchWord)
        {   
            string sql = $"select u.nombres, u.apellidos, u.correo, case when u.fotop is null then '' else u.fotop end as fotop, u.color, count(ur.id) as cantidadReportes, e.nombre_estado from usuarios u inner join estados e on u.estado = e.id left join usuario_reportes ur ON u.idusuario = ur.idusuario where u.nombres like '{searchWord}%' or u.apellidos like '{searchWord}%' or concat(u.nombres, ' ', u.apellidos) like '{searchWord}%' or  u.correo like '{searchWord}%' or e.nombre_estado like '{searchWord}%' group by u.idusuario; ";
            return db.ConvertDataTabletoString(sql);
        }

        public string searchUsersFilters(int option, string searchWord)
        {
            string sql = "";
            if (option == 1)
            {
                sql = $"select u.nombres, u.apellidos, u.correo, case when u.fotop is null then '' else u.fotop end as fotop, u.color, count(ur.id) as cantidadReportes, e.id,e.nombre_estado from usuarios u inner join estados e on u.estado = e.id left join usuario_reportes ur ON u.idusuario = ur.idusuario where e.nombre_estado like '{searchWord}%' group by u.idusuario";
            }
            else if (option == 2)
            {
                sql = $"select u.nombres, u.apellidos, u.correo, case when u.fotop is null then '' else u.fotop end as fotop, u.color, count(ur.id) as cantidadReportes, e.nombre_estado from usuarios u inner join estados e on u.estado = e.id left join usuario_reportes ur ON u.idusuario = ur.idusuario group by u.idusuario having count(ur.id) = {Convert.ToInt32(searchWord)};";
            }
            else if (option == 3)
            {
                sql = $"select u.nombres, u.apellidos, u.correo, case when u.fotop is null then '' else u.fotop end as fotop, u.color, count(ur.id) as cantidadReportes, e.nombre_estado from usuarios u inner join estados e on u.estado = e.id left join usuario_reportes ur ON u.idusuario = ur.idusuario where u.correo like '{searchWord}%' group by u.idusuario; ";
            }
            else if (option == 4)
            {
                sql = $"select u.idusuario,u.nombres, u.apellidos, u.correo, case when u.fotop is null then '' else u.fotop end as fotop, u.color, count(ur.id) as cantidadReportes, e.nombre_estado from usuarios u inner join estados e on u.estado = e.id left join usuario_reportes ur ON u.idusuario = ur.idusuario where concat(u.nombres, ' ', u.apellidos) like '%{searchWord}%' group by u.idusuario;";
            }
            return db.ConvertDataTabletoString(sql);
        }

        public string suspencionUsers(List<ChangeState> array)
        {
            string sql = " ";
            for (int i=0; i<array.Count;i++)
            { 
                sql = $"update usuarios set estado = {array[i].IdEstado} where idusuario = {array[i].IdUsuario};";
                db.ejecuteSQL(sql);
            }
            return db.ejecuteSQL(sql);
        }
    }
}