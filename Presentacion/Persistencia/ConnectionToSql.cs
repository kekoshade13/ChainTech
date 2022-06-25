using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;
using MySql.Data.MySqlClient;

namespace Presentacion
{
    public abstract class ConnectionToSql
    {

        private readonly String connString;
        public ConnectionToSql() {
            connString = "server=localhost;user=root;database=ChainTechnology;port=3306;password=";
        }
        protected MySqlConnection GetConnection()
        {
            return new MySqlConnection(connString);
        }
    }
}
