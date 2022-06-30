using System;

namespace Backend_CSharp_Work4Hours_AdministratorModule.Models.Entities
{
    public class ChangeState
    {
        private int _idStatus;
        private string _email;
        private int _id;
        private string _photo;
        private string _color;
        private string _name;

        public int IdStatus
        {
            get { return _idStatus; }
            set { _idStatus = value; }
        }

        public string Email
        {
            get { return _email; }
            set { _email = value; }
        }

        public int Id
        {
            get { return _id; }
            set { _id = value; }
        }

        public string Photo
        {
            get { return _photo; }
            set { _photo = value; }
        }

        public string Color
        {
            get { return _color; }
            set { _color = value; }
        }

        public string Name
        {
            get { return _name; }
            set { _name = value; }
        }
    }
}
