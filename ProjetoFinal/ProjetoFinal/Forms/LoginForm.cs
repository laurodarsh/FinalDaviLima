using ProjetoFinal.Classes;
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
        User aux = new User();
        string name = "";
        string pass = "";

        public LoginForm()
        {
            InitializeComponent();
        }

        private void ProfileDetailsForm_Load(object sender, EventArgs e)
        {

        }

        private void btnEntrar_Click(object sender, EventArgs e)
        {
            GetData();
            if (CheckLogin(pass, name))
            {
                HomeForm homeform = new HomeForm(aux);
                homeform.Show();
                this.Hide();
            }
            else
            {
                CleanData();
                MessageBox.Show("Usuário ou senha incorretos!");
            }

          
        }
        private bool CheckLogin(string password, string name)
        {
            User user = UserHelper.SelectByName(name);
            aux = user;
            if (user != null)
            {
                if (UserHelper.Hash(password) == user.Password)
                {
                    return true;
                }
            }
            return false;
        }
        private void btnForgot_Click(object sender, EventArgs e)
        {

        }
        void GetData()
        {
            name = tbxNome.Text;
            pass = tbxSenha.Text;
        }
        void CleanData()
        {
            tbxNome.Text = "";
            tbxSenha.Text = "";
        }

        private void lblNome_Click(object sender, EventArgs e)
        {

        }

        private void tbxSenha_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
