using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Backend_CSharp_Work4Hours_AdministratorModule.Models.Entities
{
    public class Users
    {
        private int Idusuario;
        private string Nombres;
        private string Apellidos;
        private string Correo;
        private string Fotop;

        private Roles Rol;
        private State Estado;

        public int GetIdUsuario()
        {
            return Idusuario;
        }

        public string GetName()
        {
            return Nombres;
        }

        public string GetLastName()
        {
            return Apellidos;
        }

        public string GetEmail()
        {
            return Correo;
        }

        public string GetPhoto()
        {
            return Fotop;
        }

        public string SetName(string name)
        {
            return Nombres=name;
        }

        public string SetLastName(string lastName)
        {
            return Apellidos = lastName;
        }

        public string SetEmail( string email)
        {
            return Correo = email;
        }

        public State GetState()
        {
            return Estado;
        }
    }
}