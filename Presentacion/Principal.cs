using App;
using Presentacion;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Presentacion
{
    public partial class Principal : Form
    {
        public Principal()
        {
            InitializeComponent();
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {
        }

        private void btnVerMas_MouseHover(object sender, EventArgs e)
        {
            btnVerMas.BackColor = Color.Black;
            btnVerMas.ForeColor = Color.White;
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void btnVerMas_MouseLeave(object sender, EventArgs e)
        {
            btnVerMas.BackColor = Color.White;
            btnVerMas.ForeColor = Color.Black;
        }

        private void btnPerfil_Click(object sender, EventArgs e)
        {
            FormLogin login = new FormLogin();
            login.Show();
        }



        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void lblNombre_Click(object sender, EventArgs e)
        {

        }

        private void Principal_Load(object sender, EventArgs e)
        {
            userLoadData();
            btnLogout.Hide();
        }

        private void btnLogout_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void userLoadData()
        {
            UserDatos user = new UserDatos();
        }
    }
}
