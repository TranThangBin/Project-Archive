using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Runtime.Remoting.Contexts;
using System.Text;
using System.Threading.Tasks;

namespace VLU222_CSLTN02_2274801030_137_118_042_101_073.Classes
{
    internal static class Database
    {
        private static SqlConnection connection = null;

        public static void Connect(string connectionString)
        {
            if (connection == null) connection = new SqlConnection(connectionString);
            if (connection.State == ConnectionState.Closed) connection.Open();
        }

        public static void Disconnect()
        {
            if (connection != null)
            {
                if (connection.State == ConnectionState.Open)
                    connection.Close();
                connection = null;
            }
        }

        public static SqlDataReader ExecuteQuery(string query)
        {
            SqlCommand command = new SqlCommand(query, connection);
            return command.ExecuteReader();
        }

        public static int ExecuteNonQuery(string query,List<string> parameters,List<SqlDbType> dbTypes)
        {
            if (parameters.Count != dbTypes.Count) 
                throw new Exception("Không đủ tham số!");
            SqlCommand command = new SqlCommand(query, connection);
            for(int i = 0; i < parameters.Count; i++)
            {
                SqlParameter parameter = new SqlParameter(parameters[i], dbTypes[i]);
                command.Parameters.Add(parameter);
            }
            return command.ExecuteNonQuery();
        }
    }
}
