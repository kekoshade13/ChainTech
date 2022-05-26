using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace Persistencia
{
    public abstract class ConnectionToSql
    {

        private readonly String connString;
        public ConnectionToSql() {
            connString = "Server=localhost;DataBase=ChainTechnology;integrated security= true";
        }
        protected SqlConnection GetConnection() {
            return new SqlConnection(connString);
        }


    }
}
