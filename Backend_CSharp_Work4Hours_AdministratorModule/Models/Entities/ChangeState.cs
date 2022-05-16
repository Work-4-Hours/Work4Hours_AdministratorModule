using System;

namespace Backend_CSharp_Work4Hours_AdministratorModule.Models.Entities
{
    public class ChangeState
    {
        private int _idEstado;
        private string _email;
        private int _idUsuario;
        private string _fotoUser;
        private string _color;
        private string _nombres;

        public int IdEstado
        {
            get { return _idEstado; }
            set { _idEstado = value; }
        }

        public string Email
        {
            get { return _email; }
            set { _email = value; }
        }

        public int IdUsuario
        {
            get { return _idUsuario; }
            set { _idUsuario = value; }
        }

        public string fotoUser
        {
            get { return _fotoUser; }
            set { _fotoUser = value; }
        }

        public string Color
        {
            get { return _color; }
            set { _color = value; }
        }

        public string Nombres
        {
            get { return _nombres; }
            set { _nombres = value; }
        }
    }
}
