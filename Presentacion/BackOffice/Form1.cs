using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Text.Json;
using System.Text.Json.Serialization;
using Presentacion.Controllers.Datos;
using Newtonsoft.Json;
using Presentacion.Controllers;

namespace Presentacion.BackOffice
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void btnVolver_Click(object sender, EventArgs e)
        {
            FormBackOffice principalBO = new FormBackOffice();
            principalBO.Show();
            this.Hide();
        }

        private void btnAddBanner_Click(object sender, EventArgs e)
        {

            List<Object> bannerObject = new List<object>();
            bannersPublicidad banners = new bannersPublicidad
            {
                url = txtAddBanner.Text,
                empresa = txtBussiness.Text,
                directorio = txtDirectory.Text,
            };
            bannerObject.Add(banners);
            createJson bannersInfo = new createJson();
            bannersInfo.serializarBanners(bannerObject);
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
