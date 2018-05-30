using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace projetofinalPedroLima.Forms
{
    public partial class HomeForm : Form
    {
        public HomeForm()
        {
            InitializeComponent();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

            ProductAllForm productallForm = new ProductAllForm();
            productallForm.Show();
            this.Hide();

        }

        private void pbxProduto_MouseEnter(object sender, EventArgs e)
        {

            pbxProduto.BackColor = Color.Aquamarine;
            lblProduct.Visible = true;
        }

        private void pbxProduto_MouseLeave(object sender, EventArgs e)
        {
            pbxProduto.BackColor = Color.Transparent;
            lblProduct.Visible = false;
        }

        private void pbxCategory_MouseEnter(object sender, EventArgs e)
        {

        }

        private void pbxCategory_MouseLeave(object sender, EventArgs e)
        {

        }

        private void pbxUserProfile_MouseEnter(object sender, EventArgs e)
        {

        }

        private void pbxUserProfile_MouseLeave(object sender, EventArgs e)
        {

        }

        private void pbxUser_MouseEnter(object sender, EventArgs e)
        {

        }

        private void pbxUser_MouseLeave(object sender, EventArgs e)
        {

        }

        private void pbxLog_MouseEnter(object sender, EventArgs e)
        {

        }

        private void pbxLog_MouseLeave(object sender, EventArgs e)
        {

        }

        private void pbxCategory_Click(object sender, EventArgs e)
        {

            CategoryAllForm categoryallForm = new CategoryAllForm();
            categoryallForm.Show();
            this.Hide();

        }

        private void pbxUser_Click(object sender, EventArgs e)
        {

            UserAllForm userallForm = new UserAllForm();
            userallForm.Show();
            this.Hide();

        }

        private void pbxUserProfile_Click(object sender, EventArgs e)
        {

            UserProfileAllForm userprofileallForm = new UserProfileAllForm();
            userprofileallForm.Show();
            this.Hide();

        }

        private void pbxLog_Click(object sender, EventArgs e)
        {


            LogForm logForm = new LogForm();
            logForm.Show();
            this.Hide();

        }
    }
}
