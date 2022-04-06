using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;

namespace Backend_CSharp_Work4Hours_AdministratorModule.Models
{
    public class DataBase
    {
        MySqlConnection connection;

        public DataBase()
        {
            connection = new MySqlConnection("datasource=bgeztpvckg0lxhnhjorg-mysql.services.clever-cloud.com; port=3306; username=urz9oici6joy6gog;password=dMxPboxqGHD4ik5Sv8mu;database=bgeztpvckg0lxhnhjorg;SSLMode=none");

        }

        public string ejecuteSQL(string sql)
        {     
            string result = "";
            try
            {
                connection.Open();

                MySqlCommand cmd = new MySqlCommand(sql, connection);
                int countRows = cmd.ExecuteNonQuery();

                if (countRows > -1)
                {
                    result = "Correcto";
                }
                else
                {
                    result = "Incorrecto";
                }
                connection.Close();

            }
            catch (Exception ex)
            {
                result = ex.Message;
            }

            return result;
        }
        
        public DataTable getTable(string sql)
        {
            DataTable dt = new DataTable();
            try
            {
                connection.Open();
                MySqlCommand cmd = new MySqlCommand(sql, connection);

                MySqlDataAdapter adapter = new MySqlDataAdapter(cmd);

                adapter.Fill(dt);
                connection.Close();
                adapter.Dispose();
            }
            catch
            {
                return null;
            }
            return dt;
        }
    }
}
