namespace Backend_CSharp_Work4Hours_AdministratorModule.Models.Entities
{
    public class ChangeStateService
    {
        private int _idEstado;
        private int _idServicio;
        private string _nombreServicio;
        public int IdEstado
        {
            get { return _idEstado; }
            set { _idEstado = value; }
        }

        public int IdServicio
        {
            get { return _idServicio; }
            set { _idServicio = value; }
        }
        public string NombreServicio
        {
            get { return _nombreServicio; }
            set { _nombreServicio = value; }
        }


    }
}
