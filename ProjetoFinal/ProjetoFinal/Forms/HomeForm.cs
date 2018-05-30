using ProjetoFinal.Forms;
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
    public partial class HomeForm : Form
    {
        public HomeForm()
        {
            InitializeComponent();
        }

        private void pbxProduct_Click(object sender, EventArgs e)
        {
            ProductAllForm productallform = new ProductAllForm();
            productallform.Show();
            this.Hide();
        }

        private void pbxProduct_MouseEnter(object sender, EventArgs e)
        {
            pbxProduct.BackColor = Color.Cyan;
            lblProduto.Visible = true;
        }

        private void pbxProduct_MouseLeave(object sender, EventArgs e)
        {
            pbxProduct.BackColor = Color.Transparent;
            lblProduto.Visible = false;
        }

        private void pbxCategory_MouseEnter(object sender, EventArgs e)
        {
            pbxCategory.BackColor = Color.Cyan;
            lblCategoria.Visible = true;
        }

        private void pbxCategory_MouseLeave(object sender, EventArgs e)
        {
            pbxCategory.BackColor = Color.Transparent;
            lblCategoria.Visible = false;

        }

        private void pbxUser_MouseEnter(object sender, EventArgs e)
        {
            pbxUser.BackColor = Color.Cyan;
            lblUsuario.Visible = true;
        }

        private void pbxUser_MouseLeave(object sender, EventArgs e)
        {
            pbxUser.BackColor = Color.Transparent;
            lblUsuario.Visible = false;
        }

        private void pbxProfile_MouseEnter(object sender, EventArgs e)
        {
            pbxProfile.BackColor = Color.Cyan;
            lblPerfil.Visible = true;
        }

        private void pbxProfile_MouseLeave(object sender, EventArgs e)
        {
            pbxProfile.BackColor = Color.Transparent;
            lblPerfil.Visible = false;
        }

        private void pbxLog_MouseEnter(object sender, EventArgs e)
        {
            pbxLog.BackColor = Color.Cyan;
            lblLog.Visible = true;
        }

        private void pbxLog_MouseLeave(object sender, EventArgs e)
        {
            pbxLog.BackColor = Color.Transparent;
            lblLog.Visible = false;

        }

        private void pbxCategory_Click(object sender, EventArgs e)
        {
            CategoryAllForm categoryallform = new CategoryAllForm();
            categoryallform.Show();
            this.Hide();
        }

        private void pbxUser_Click(object sender, EventArgs e)
        {
            UserAllForm userallform = new UserAllForm();
            userallform.Show();
            this.Hide();
        }

        private void pbxProfile_Click(object sender, EventArgs e)
        {
            UserProfileAllForm userprofileallform = new UserProfileAllForm();
            userprofileallform.Show();
            this.Hide();
        }

        private void pbxLog_Click(object sender, EventArgs e)
        {
            LogForm logform = new LogForm();
            logform.Show();
            this.Hide();
        }
    }
}
