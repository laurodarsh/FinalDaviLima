﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ProjetoFinal
{
    public partial class LogForm : Form
    {
        string connectionString = "workstation id=StockControlData.mssql.somee.com;packet size=4096;user id=luacademy_SQLLogin_1;pwd=msctq6gvt3;data source=StockControlData.mssql.somee.com;persist security info=False;initial catalog=StockControlData";
        string search = "";
        public LogForm()
        {
            InitializeComponent();
            ShowData();
            ResizeDataGridView();
        }
        private void ShowData()
        {
            SqlConnection sqlConnect = new SqlConnection(connectionString);

            try
            {
                sqlConnect.Open();

                SqlCommand cmd = new SqlCommand("SELECT * FROM LOG", sqlConnect);
                // SqlDataReader reader = cmd.ExecuteReader();

                cmd.ExecuteNonQuery();

                DataTable dt = new DataTable();
                SqlDataAdapter sqlDtAdapter = new SqlDataAdapter(cmd);
                sqlDtAdapter.Fill(dt);

                dgvLog.DataSource = dt;

            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro ao conectar. " + ex.Message);
            }
            finally
            {
                sqlConnect.Close();
            }
        }
        private void ResizeDataGridView()
        {
            dgvLog.Columns["ID"].Visible = false;
            dgvLog.Columns["DESCRIPTION"].HeaderText = "Descrição";
            dgvLog.Columns["TYPE"].HeaderText = "Tipo";
            dgvLog.Columns["DATE"].HeaderText = "Data";

            foreach (DataGridViewColumn col in dgvLog.Columns)
            {
                col.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
                col.HeaderCell.Style.Font = new Font("Arial", 12F, FontStyle.Bold, GraphicsUnit.Pixel);
            }
        }

        private void pbxSearch_Click(object sender, EventArgs e)
        {

        }

        private void pbxBack_Click(object sender, EventArgs e)
        {
            HomeForm homeForm = new HomeForm();
            homeForm.Show();
            this.Hide();
        }

        private void pbxBack_MouseEnter(object sender, EventArgs e)
        {
            pbxBack.BackColor = Color.Cyan;
        }

        private void pbxBack_MouseLeave(object sender, EventArgs e)
        {
            pbxBack.BackColor = Color.Transparent;
        }

        private void pbxSearch_MouseEnter(object sender, EventArgs e)
        {
            pbxSearch.BackColor = Color.Cyan;
        }

        private void pbxSearch_MouseLeave(object sender, EventArgs e)
        {
            pbxSearch.BackColor = Color.Transparent;
        }
        void GetData()
        {
            search = tbxSearch.Text;

        }
        void CleanData()
        {
            tbxSearch.Text = "";
        }
    }
}
