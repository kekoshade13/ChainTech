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

namespace Presentacion
{
    public partial class Form1 : Form
    {

        SqlConnection conn = new SqlConnection("Server=localhost;DataBase=ChainTechnology;integrated security= true");
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
            string query = "select * from Users";
            SqlCommand cmd = new SqlCommand(query, conn);
            SqlDataAdapter adaptador = new SqlDataAdapter();
            adaptador.SelectCommand = cmd;
            DataTable tabla = new DataTable();
            adaptador.Fill(tabla);
            dataUsuarios.DataSource = tabla;

            return tabla;
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            consultarUsuarios();
        }
    }
}
