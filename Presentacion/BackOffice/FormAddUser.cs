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
    public partial class FormAddUser : Form
    {
        public FormAddUser()
        {
            InitializeComponent();
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void btnAddUser_Click(object sender, EventArgs e)
        {
            UserDatos user = new UserDatos();
            string selected = "";
            if(checkedListBox1.CheckedItems.Count != 0)
            {
                for (int x = 0; x < checkedListBox1.CheckedItems.Count; x++)
                {
                    selected = selected + checkedListBox1.CheckedItems[x];
                }
            }
            user.addUser(txtUser.Text, txtName.Text, txtLastName.Text, selected, txtEmail.Text, txtPassword.Text);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            FormBackOffice principal = new FormBackOffice();
            principal.Show();
            this.Hide();
        }
    }
}
