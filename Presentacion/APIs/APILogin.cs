using App;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Presentacion.APIs
{
    public class APILogin
    {
        public void consultarUsuario(String user, String pass)
        {
            UserDatos usuario = new UserDatos();
            var login = usuario.Login(user, pass);
        }

        /*public String devolverUsuario(String role, String idioma, String nombre)
        {
            FormLogin usuario = new FormLogin
            {
                username =
            }
             = JsonConvert.SerializeObject();
        }*/
    }
}
