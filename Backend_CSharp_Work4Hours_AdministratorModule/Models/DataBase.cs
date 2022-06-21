using MySql.Data.MySqlClient;
using Nancy.Json;
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
            connection = new MySqlConnection("datasource=work4hours.cw9ejgkmfeqy.us-east-1.rds.amazonaws.com; port=3306; username=w4hadmin;password=DCMMLwork4hours;database=work4hours;SSLMode=none");
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

        public string ConvertDataTabletoString(string sql)
        {
            DataTable dt = new DataTable();
            using (connection)
            {
                using (MySqlCommand cmd = new MySqlCommand(sql, connection))
                {
                    connection.Open();
                    MySqlDataAdapter adapter = new MySqlDataAdapter(cmd);
                    adapter.Fill(dt);
                    JavaScriptSerializer serializer = new JavaScriptSerializer();
                    List<Dictionary<string, object>> rows = new List<Dictionary<string, object>>();
                    Dictionary<string, object> row;
                    foreach (DataRow dr in dt.Rows)
                    {
                        row = new Dictionary<string, object>();
                        foreach (DataColumn col in dt.Columns)
                        {
                            row.Add(col.ColumnName, dr[col]);
                        }
                        rows.Add(row);
                    }
                    return serializer.Serialize(rows);
                }
            }
        }
    }
}
