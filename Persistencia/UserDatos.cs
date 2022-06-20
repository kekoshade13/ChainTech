using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;
using CapaTransversal.Cache;
using MySql.Data.MySqlClient;
using System.Windows.Controls;
using Org.BouncyCastle.Asn1.Crmf;

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
                        return true;
                    } else {
                        return false;
                    }

                }
            }
        }

        public bool addUser(String user, String firstName, String lastName, String email, String password)
        {


            if(consultarUsuarios(user) == false)
            {
                using (var connection = GetConnection())
                {
                    connection.Open();

                    using (var command = new MySqlCommand())
                    {
                        command.Connection = connection;
                        command.CommandText = "INSERT INTO users (username, first_name, last_name, email, password) VALUES (@username, @firstname, @lastname, @email, @password)";
                        command.Parameters.AddWithValue("@username", user);
                        command.Parameters.AddWithValue("@firstname", firstName);
                        command.Parameters.AddWithValue("@lastname", lastName);
                        command.Parameters.AddWithValue("@email", email);
                        command.Parameters.AddWithValue("@password", password);

                        command.CommandType = CommandType.Text;
                        command.ExecuteReader();
                        return true;
                    }
                }
            } 
            else
            {
                return false;
            }
        }

        public bool editUser(String oldUser, String user, String firstName, String lastName, String email, String password)
        {
            if (consultarUsuarios(oldUser) == true)
            {
                using (var connection = GetConnection())
                {
                    connection.Open();

                    using (var command = new MySqlCommand())
                    {
                        command.Connection = connection;

                        command.CommandText = "UPDATE users SET username=@user, first_name=@firstname, " +
                            "last_name=@lastname, email=@email, password=@password WHERE username=@oldUser";
                        command.Parameters.AddWithValue("@user", user);
                        command.Parameters.AddWithValue("@firstname", firstName);
                        command.Parameters.AddWithValue("@lastname", lastName);
                        command.Parameters.AddWithValue("@email", email);
                        command.Parameters.AddWithValue("@password", password);
                        command.Parameters.AddWithValue("@oldUser", oldUser);

                        command.CommandType = CommandType.Text;

                        command.ExecuteReader();

                        return true;

                    }
                }
            } else
            {
                return false;
            }
        }

        public bool eliminarUsuario(String username)
        {
            if(consultarUsuarios(username) == true)
            {
                using (var connection = GetConnection())
                {
                    connection.Open();

                    using (var command = new MySqlCommand())
                    {
                        command.Connection = connection;

                        command.CommandText = "DELETE FROM users WHERE username=@username";
                        command.Parameters.AddWithValue("@username", username);
                        command.CommandType = CommandType.Text;
                        command.ExecuteReader();

                        return true;
                    }
                }
            }
            else
            {
                return false;
            }
        }

        public bool consultarUsuarios(String username)
        {
            using (var connection = GetConnection())
            {
                connection.Open();

                using (var command = new MySqlCommand())
                {
                    command.Connection = connection;

                    command.CommandText = "SELECT * FROM users WHERE username=@username";
                    command.Parameters.AddWithValue("@username", username);
                    command.CommandType = CommandType.Text;

                    MySqlDataReader reader = command.ExecuteReader();
                    if (reader.HasRows)
                    {
                        while (reader.Read())
                        {
                            CacheLoginUser.IdUser = reader.GetInt32(0);
                            CacheLoginUser.UserName = reader.GetString(1);
                            CacheLoginUser.FirstName = reader.GetString(2);
                            CacheLoginUser.LastName = reader.GetString(3);
                            CacheLoginUser.Role = reader.GetString(4);
                            CacheLoginUser.Email = reader.GetString(5);
                            CacheLoginUser.Password = reader.GetString(6);
                        }
                        return true;
                    } 
                    else
                    {
                        return false;
                    }
                }
            }
        }
    }
}