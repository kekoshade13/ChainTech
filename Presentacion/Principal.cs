using App;

namespace VentanaPrincipal
{
    public partial class Principal : Form
    {
        public Principal()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            FormLogin login = new FormLogin();
            login.Show();
            this.Hide();
        }

        private void Principal_Load(object sender, EventArgs e)
        {

        }

        private void btnPerfil_MouseHover(object sender, EventArgs e)
        {
            btnPerfil.BackColor = Color.White;
            btnPerfil.ForeColor = Color.Black;
        }

        private void btnPerfil_MouseLeave(object sender, EventArgs e)
        {
            btnPerfil.BackColor = Color.White;
            btnPerfil.ForeColor = Color.Black;
        }
    }
}