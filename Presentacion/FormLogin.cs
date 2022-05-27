using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Runtime.InteropServices;
using System.Data.SqlClient;
using Domain;
using Presentacion;
using VentanaPrincipal;

namespace App
{
    public partial class FormLogin : Form
    {
        public FormLogin()
        {
            InitializeComponent();
        }

        [DllImport("user32.DLL", EntryPoint = "ReleaseCapture")]
            private extern static void ReleaseCapture();
        [DllImport("user32.DLL", EntryPoint = "SendMessage")]
        private extern static void SendMessage(System.IntPtr hwnd, int wmsg,
            int wparam, int Iparam);
        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void Form1_Enter(object sender, EventArgs e)
        {

        }

        private void txtUser_Enter(object sender, EventArgs e)
        {
            if(txtUser.Text == "USUARIO")
            {
                txtUser.Text = "";
                txtUser.ForeColor = Color.LightGray;
            }

        }

        private void txtUser_Leave(object sender, EventArgs e)
        {
            if(txtUser.Text == "")
            {
                txtUser.Text = "USUARIO";
                txtUser.ForeColor = Color.DimGray;
            }
        }

        private void txtPass_Enter(object sender, EventArgs e)
        {
            if(txtPass.Text == "CONTRASEÑA")
            {
                txtPass.Text = "";
                txtPass.ForeColor = Color.LightGray;
                txtPass.UseSystemPasswordChar = true;
            }
        }

        private void txtPass_Leave(object sender, EventArgs e)
        {
            if(txtPass.Text == "")
            {
                txtPass.Text = "CONTRASEÑA";
                txtPass.ForeColor = Color.DimGray;
                txtPass.UseSystemPasswordChar = false;
            }
        }

        private void btnMinimizar_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void Form1_MouseDown(object sender, MouseEventArgs e)
        {
            ReleaseCapture();
            SendMessage(this.Handle, 0x112, 0xf012, 0);
        }

        private void panel1_MouseDown(object sender, MouseEventArgs e)
        {
            ReleaseCapture();
            SendMessage(this.Handle, 0x112, 0xf012, 0);
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            if(txtUser.Text != "USUARIO") {
                if(txtPass.Text != "CONTRASEÑA"){
                    UserModel user = new UserModel();
                    var validLogin = user.Login(txtUser.Text, txtPass.Text);

                    if(validLogin == true)
                    {
                        Principal principal = new Principal();
                        principal.Show();
                    } else {
                        msgError("El usuario o la contraseña ingresada no son correctos. \nIntenta nuevamente");
                        txtPass.Clear();
                        txtUser.Focus();
                    }
                } else {
                    msgError("No puedes dejar campos vacios. \nPor favor, ingresa tu contraseña");
                }
            } else {
                msgError("No puedes dejar campos vacios. \nPor favor, ingresa tu contraseña");
            }
        }
        private void msgError(string msg)
        {
            lblErrorMessage.Text = msg;
            lblErrorMessage.Visible = true;
        }

        private void lblErrorMessage_Click(object sender, EventArgs e)
        {

        }
    }
}