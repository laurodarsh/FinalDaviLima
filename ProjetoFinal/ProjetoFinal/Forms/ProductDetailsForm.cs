﻿using ProjetoFinal.Forms;
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


    public partial class ProductDetailsForm : Form
    {
        string name = "";
        float price = 0;
        string category = "";
        bool active = false;


        public ProductDetailsForm()
        {
            InitializeComponent();
        }

        private void pbxBack_Click(object sender, EventArgs e)
        {
            ProductAllForm productallform = new ProductAllForm();
            productallform.Show();
            this.Hide();
        }

        private void pbxSave_Click(object sender, EventArgs e)
        {

        }

        private void pbxDelete_Click(object sender, EventArgs e)
        {

        }

        private void pbxBack_MouseEnter(object sender, EventArgs e)
        {
            pbxBack.BackColor = Color.Cyan;
        }

        private void pbxBack_MouseLeave(object sender, EventArgs e)
        {
            pbxBack.BackColor = Color.Transparent;
        }

        private void pbxSave_MouseEnter(object sender, EventArgs e)
        {
            pbxSave.BackColor = Color.Cyan;
        }

        private void pbxSave_MouseLeave(object sender, EventArgs e)
        {
            pbxSave.BackColor = Color.Transparent;
        }

        private void pbxDelete_MouseEnter(object sender, EventArgs e)
        {
            pbxDelete.BackColor = Color.Cyan;
        }

        private void pbxDelete_MouseLeave(object sender, EventArgs e)
        {
            pbxDelete.BackColor = Color.Transparent;
        }
        void GetData()
        {
            name = tbxName.Text;
            price = float.Parse(tbxPrice.Text);
            category = cmbCategory.Text;

            if (cbxActive.Checked)
            {
                active = true;
            }
            else
            {
                active = false;
            }
        }
        void CleanData()
        {
            cmbCategory.SelectedIndex = 0;
            tbxName.Text = "";
            tbxPrice.Text = "";
            cbxActive.Checked = false;
        }
    }
}
