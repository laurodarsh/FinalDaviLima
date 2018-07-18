using ProjetoFinal.Classes;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ProjetoFinal.Forms
{
    public partial class UserProfileAllForm : Form
    {
        string connectionString = "workstation id=StockControlData.mssql.somee.com;packet size=4096;user id=luacademy_SQLLogin_1;pwd=msctq6gvt3;data source=StockControlData.mssql.somee.com;persist security info=False;initial catalog=StockControlData";
        string search = "";

        public UserProfileAllForm()
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

                SqlCommand cmd = new SqlCommand("SELECT * FROM USER_PROFILE", sqlConnect);
                // SqlDataReader reader = cmd.ExecuteReader();

                cmd.ExecuteNonQuery();

                DataTable dt = new DataTable();
                SqlDataAdapter sqlDtAdapter = new SqlDataAdapter(cmd);
                sqlDtAdapter.Fill(dt);

                dgvUser_Profile.DataSource = dt;

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
            dgvUser_Profile.Columns["ID"].Visible = false;
            dgvUser_Profile.Columns["NAME"].HeaderText = "Nome";
            dgvUser_Profile.Columns["ACTIVE"].HeaderText = "Ativo";


            foreach (DataGridViewColumn col in dgvUser_Profile.Columns)
            {
                col.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
                col.HeaderCell.Style.Font = new Font("Arial", 12F, FontStyle.Bold, GraphicsUnit.Pixel);
            }
        }

        private void pbxSearch_Click(object sender, EventArgs e)
        {

        }

        private void pbxDelete_Click(object sender, EventArgs e)
        {
            int idUser_Profile = Int32.Parse(dgvUser_Profile.SelectedRows[0].Cells[0].Value.ToString());

            SqlConnection sqlConnect = new SqlConnection(connectionString);

            try
            {
                sqlConnect.Open();
                string sql = "UPDATE USER_PROFILE SET ACTIVE = @active WHERE ID = @id";

                SqlCommand cmd = new SqlCommand(sql, sqlConnect);

                cmd.Parameters.Add(new SqlParameter("@id", idUser_Profile));
                cmd.Parameters.Add(new SqlParameter("@active", false));

                cmd.ExecuteNonQuery();

                MessageBox.Show("Perfil inativo!");
                Log.SalvarLog("perfil desativado", "exclusão", DateTime.Now);
            }
            catch (Exception Ex)
            {
                MessageBox.Show("Erro ao desativar o perfil!" + "\n\n" + Ex.Message);
                throw;
            }
            finally
            {
                sqlConnect.Close();
            }
        }

        private void pbxAdd_Click(object sender, EventArgs e)
        {
           UserProfileDetailsForm userprofiledetailsform = new UserProfileDetailsForm();
            userprofiledetailsform.Show();
            this.Hide();

        }

        private void pbxEdit_Click(object sender, EventArgs e)
        {
            int idUser_Profile = Int32.Parse(dgvUser_Profile.SelectedRows[0].Cells[0].Value.ToString());

            UserProfileDetailsForm userprofileDetails = new UserProfileDetailsForm(idUser_Profile);
            userprofileDetails.Show();

            this.Close();
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

        private void pbxAdd_MouseEnter(object sender, EventArgs e)
        {
            pbxAdd.BackColor = Color.Cyan;
        }

        private void pbxAdd_MouseLeave(object sender, EventArgs e)
        {
            pbxAdd.BackColor = Color.Transparent;
        }

        private void pbxEdit_MouseEnter(object sender, EventArgs e)
        {
            pbxEdit.BackColor = Color.Cyan;
        }

        private void pbxEdit_MouseLeave(object sender, EventArgs e)
        {
            pbxEdit.BackColor = Color.Transparent;
        }

        private void pbxDelete_MouseEnter(object sender, EventArgs e)
        {
            pbxDelete.BackColor = Color.Cyan;
        }

        private void pbxDelete_MouseLeave(object sender, EventArgs e)
        {
            pbxDelete.BackColor = Color.Transparent;
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
