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
        State st = new State();
        private int _idusuario;
        private string _nombres;
        private string _apellidos;
        private string _correo;
        private string _fotop;

        private State _estado;
        private Roles _rol;

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

        public string Estado
        {
            get { return st.Nombre_estado.ToString();}
            set { st.Nombre_estado = value; }
        }

        public string listUsers()
        {
            string sql = "SELECT u.idusuario, u.nombres, u.apellidos, u.correo, u.fotop, e.nombre_estado FROM usuarios u INNER JOIN estados e on u.estado=e.id";
            return db.ConvertDataTabletoString(sql);
        }
    }
}