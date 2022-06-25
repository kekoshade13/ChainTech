using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Presentacion.BackOffice
{
    public partial class FormEditUser : Form
    {
        public FormEditUser()
        {
            InitializeComponent();
        }

        private void FormEditUser_Load(object sender, EventArgs e)
        {

        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            UserDatos user = new UserDatos();
            var datosUser = user.devolverDatos;
            var result = user.consultarUsuarios(txtUser.Text);

            /*if(result == true)
            {
                txtNewUser.Text = datosUser;
                txtNewName.Text = CacheLoginUser.FirstName;
                txtNewLastName.Text = CacheLoginUser.LastName;
                txtNewEmail.Text = CacheLoginUser.Email;
                txtNewPassword.Text = CacheLoginUser.Password;
            }*/
        }

        private void btnAddUser_Click(object sender, EventArgs e)
        {
            UserDatos user = new UserDatos();
            var editUser = user.editUser(txtUser.Text, txtNewUser.Text, txtNewName.Text, 
                txtNewLastName.Text, txtNewEmail.Text, txtNewPassword.Text);

            if(editUser == true)
            {
                MessageBox.Show("Los datos han sido modificados exitosamente.");
                txtUser.Text = "";
                txtNewUser.Text = "";
                txtNewName.Text = "";
                txtNewLastName.Text = "";
                txtNewEmail.Text = "";
                txtNewPassword.Text = "";
            } 
            else
            {
                MessageBox.Show("Ha ocurrido un error.");
            }

        }

        private void button1_Click(object sender, EventArgs e)
        {
            FormBackOffice principal = new FormBackOffice();
            principal.Show();
            this.Hide();
        }
    }
}
