using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;
using CapaTransversal.Cache;
using MySql.Data.MySqlClient;

namespace Persistencia
{
    public class UserDatos:ConnectionToSql
    {
        public bool Login(String user, String pass)
        {
            using (var connection = GetConnection())
            {
                connection.Open();

                using (var command = new MySqlCommand()) {
                    command.Connection = connection;
                    command.CommandText = "SELECT * FROM users WHERE username=@user AND password=@pass";
                    command.Parameters.AddWithValue("@user", user);
                    command.Parameters.AddWithValue("@pass", pass);
                    command.CommandType = CommandType.Text;

                    MySqlDataReader reader = command.ExecuteReader();
                    if(reader.HasRows) {
                        while(reader.Read()) {
                            CacheLoginUser.IdUser = reader.GetInt32(0);
                            CacheLoginUser.FirstName = reader.GetString(2);
                            CacheLoginUser.LastName = reader.GetString(3);
                            CacheLoginUser.Role = reader.GetString(4);
                            CacheLoginUser.Email = reader.GetString(5);
                        }
                        return true;
                    } else {
                        return false;
                    }

                }
            }
        }
    }
}
