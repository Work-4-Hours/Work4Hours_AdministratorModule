using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;

namespace Backend_CSharp_Work4Hours_AdministratorModule.Models.Entities
{
    public class State
    {
        DataBase db = new DataBase();
        private int _id;
        private string _nombre_estado;

        public int Id
        {
            get
            {
                return _id;
            }
            set
            {
                _id = value;
            }
        }
        public string Nombre_estado
        {
            get
            {
                return _nombre_estado;
            }
            set
            {
                _nombre_estado = value;
            }
        }

        public IEnumerable<State> nameState()
        {
            string sql = "SELECT *  FROM estados";
            DataTable dt = db.getTable(sql);

            List<State> stateList = new List<State>();
            stateList = (from DataRow dr in dt.Rows
                          select new State()
                          {
                              Id = Convert.ToInt32(dr["id"]),
                              Nombre_estado = dr["nombre_estado"].ToString(),
                          }).ToList();

            /*string state = "";
            foreach(DataRow dr in dt.Rows)
            {
                state = dr["nombre_estado"].ToString();
            }*/
            return stateList;
        }
    }        
}