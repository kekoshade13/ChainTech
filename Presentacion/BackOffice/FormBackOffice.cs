using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
using MySql.Data.MySqlClient;
using Presentacion.BackOffice;

namespace Presentacion
{
    public partial class FormBackOffice : Form
    {

        MySqlConnection conn = new MySqlConnection("server=localhost;user=root;database=ChainTechnology;port=3306;password=");
        public DataTable tabla = new DataTable();
        private String celda;
        public FormBackOffice()
        {
            InitializeComponent();
            dataUsuarios.AutoResizeColumns(DataGridViewAutoSizeColumnsMo‌​de.Fill);
        }

        private void dataUsuarios_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            
        }

        public void consultarUsuarios(DataGridView grid)
        {
            string query = "select * from users";
            MySqlCommand cmd = new MySqlCommand(query, conn);
            MySqlDataAdapter adaptador = new MySqlDataAdapter();
            adaptador.SelectCommand = cmd;
           
            adaptador.Fill(tabla);
            grid.DataSource = tabla;
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            consultarUsuarios(dataUsuarios);
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            FormAddUser addUser = new FormAddUser();
            addUser.Show();
            this.Hide();
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            UserDatos user = new UserDatos();
            var eliminarUser = user.eliminarUsuario(celda);
            if(eliminarUser == true)
            {
                dataUsuarios.Refresh();
                dataUsuarios.Update();
                MessageBox.Show("El usuario ha sido eliminado correctamente.");
            } else
            {
                MessageBox.Show("Ha ocurrido un error");
            }
        }

        private void dataUsuarios_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            celda = dataUsuarios.CurrentCell.Value.ToString();
            textBox1.Text = celda;
        }

        private void btnEditar_Click(object sender, EventArgs e)
        {
            FormEditUser userEdit = new FormEditUser();
            userEdit.Show();
            this.Hide();
        }

        private void btnAddbanner_Click(object sender, EventArgs e)
        {
            Form1 addBanner = new Form1();
            addBanner.Show();
            this.Hide();
        }
    }
}
