using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ProjetoFinal.Forms
{
    public partial class ProductAllForm : Form
    {
        public ProductAllForm()
        {
            InitializeComponent();
        }

        private void pbxBack_Click(object sender, EventArgs e)
        {
            HomeForm homeform = new HomeForm();
            homeform.Show();
            this.Hide();

        }

        private void pbxAdd_Click(object sender, EventArgs e)
        {
            ProductDetailsForm productdetailsform = new ProductDetailsForm();
            productdetailsform.Show();
            this.Hide();
        }

        private void pbxEdit_Click(object sender, EventArgs e)
        {
            ProductDetailsForm productdetailsform = new ProductDetailsForm();
            productdetailsform.Show();
            this.Hide();
        }

        private void pbxDelete_Click(object sender, EventArgs e)
        {
            
        }
    }
}
