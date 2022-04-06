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
        private int Id;
        private string Nombre_estado;

        public int GetId()
        {
            return Id;
        }

        public string GetNameState()
        {
            string sql = "SELECT nombrerol FROM roles";
            Nombre_estado = db.ejecuteSQL(sql);
            return Nombre_estado;
        }

        public IEnumerable<State> typeState()
        {
            string sql = "SELECT nombre_estado FROM estados";
            DataTable dt = db.getTable(sql);

            List<State> clientList = new List<State>();
            clientList = (from DataRow dr in dt.Rows
                          select new State()
                          {
                              Nombre_estado = dr["nombrE_ESTADO"].ToString(),
                          }).ToList();
            return clientList;
        }
    }        
}