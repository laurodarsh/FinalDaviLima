using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ProjetoFinal
{
    public partial class LoginForm : Form
    {
        string nome = "";
        string senha = "";

        public LoginForm()
        {
            InitializeComponent();
        }

        private void ProfileDetailsForm_Load(object sender, EventArgs e)
        {

        }

        private void btnEntrar_Click(object sender, EventArgs e)
        {
            HomeForm homeform = new HomeForm();
            homeform.Show();
            this.Hide();
        }

        private void btnForgot_Click(object sender, EventArgs e)
        {

        }
        void GetData()
        {
            nome = tbxNome.Text;
            senha = tbxSenha.Text;
        }
        void CleanData()
        {
            tbxNome.Text = "";
            tbxSenha.Text = "";
        }

        private void lblNome_Click(object sender, EventArgs e)
        {

        }
    }
}
