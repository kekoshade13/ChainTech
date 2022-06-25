using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.Json;
using System.Text.Json.Serialization;
using Newtonsoft.Json;

namespace Presentacion.Controllers
{

    public class createJson
    {
        public string serializarBanners(object info)
        {
            string jsonCreado = JsonConvert.SerializeObject(info, Formatting.Indented);
            return jsonCreado;
        }

        public void serializarUserInfo(object info)
        {
            string jsonCreado = JsonConvert.SerializeObject(info);
            string path = @"C:\Users\jpazg\source\repos\userInfo.json";
            System.IO.File.WriteAllText(path, jsonCreado);
        }
    }
}
