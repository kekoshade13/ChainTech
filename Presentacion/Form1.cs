using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Persistencia;
using System.Data.SqlClient;
using MySql.Data.MySqlClient;

namespace Presentacion
{
    public partial class Form1 : Form
    {

        MySqlConnection conn = new MySqlConnection("server=localhost;user=root;database=ChainTechnology;port=3306;password=");
        public DataTable tabla = new DataTable();
        public Form1()
        {
            InitializeComponent();
            dataUsuarios.AutoResizeColumns(DataGridViewAutoSizeColumnsMo‌​de.Fill);
        }

        private void dataUsuarios_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            
        }

        public DataTable consultarUsuarios()
        {
            string query = "select * from users";
            MySqlCommand cmd = new MySqlCommand(query, conn);
            MySqlDataAdapter adaptador = new MySqlDataAdapter();
            adaptador.SelectCommand = cmd;
           
            adaptador.Fill(tabla);
            dataUsuarios.DataSource = tabla;

            return tabla;
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            consultarUsuarios();
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            Console.WriteLine("Usuario Agregado");
        }
    }
}
