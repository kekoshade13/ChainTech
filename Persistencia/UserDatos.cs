using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;

namespace Persistencia
{
    public class UserDatos:ConnectionToSql
    {
        public bool Login(String user, String pass)
        {
            using (var connection = GetConnection())
            {
                connection.Open();

                using (var command = new SqlCommand()) {
                    command.Connection = connection;
                    command.CommandText = "SELECT * FROM Users WHERE LoginName=@user AND Password=@pass";
                    command.Parameters.AddWithValue("@user", user);
                    command.Parameters.AddWithValue("@pass", pass);
                    command.CommandType = CommandType.Text;

                    SqlDataReader reader = command.ExecuteReader();
                    if(reader.HasRows) {
                        return true;
                    } else {
                        return false;
                    }

                }
            }
        }
    }
}
