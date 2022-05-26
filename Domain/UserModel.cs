using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Persistencia;

namespace Domain
{
    public class UserModel
    {
        UserDatos userDatos = new UserDatos();
        public bool Login(string user, string pass) {
            return userDatos.Login(user,pass);
        }
    }
}
