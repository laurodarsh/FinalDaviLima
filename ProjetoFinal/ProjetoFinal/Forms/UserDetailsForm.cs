using ProjetoFinal.Classes;
using ProjetoFinal.Forms;
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

namespace ProjetoFinal
{
    public partial class UserDetailsForm : Form
    {
        string connectionString = "workstation id=StockControlData.mssql.somee.com;packet size=4096;user id=luacademy_SQLLogin_1;pwd=msctq6gvt3;data source=StockControlData.mssql.somee.com;persist security info=False;initial catalog=StockControlData";
        string name = "";
        string email = "";
        string pass = "";
        string cpass = "";
        string profile = "";
        bool active = false;
        List<UserProfile> profiles = new List<UserProfile>();



        public UserDetailsForm()
        {
            InitializeComponent();
            cmbProfile.DisplayMember = "NAME";
            LoadComboBox();

        }
        void LoadComboBox()
        {
            SqlConnection cn = new SqlConnection(connectionString);

            try
            {
                cn.Open();
                SqlCommand sqlCommand = new SqlCommand("SELECT * FROM USER_PROFILE", cn);

                SqlDataReader reader = sqlCommand.ExecuteReader();
                while (reader.Read())
                {
                    UserProfile p = new UserProfile(Int32.Parse(reader["ID"].ToString()), reader["NAME"].ToString(), bool.Parse(reader["ACTIVE"].ToString()));
                    profiles.Add(p);
                }
            }
            catch (Exception ex)
            {
                //Erro ao carregar banco
            }
            finally
            {
                cn.Close();
            }
            foreach (UserProfile p in profiles)
            {
                cmbProfile.Items.Add(p);
            }
        }

        private void lbl_Load(object sender, EventArgs e)
        {

        }

        private void pbxBack_Click(object sender, EventArgs e)
        {
            UserAllForm userAllForm = new UserAllForm();
            userAllForm.Show();
            this.Hide();
        }

        private void pbxSave_Click(object sender, EventArgs e)
        {
            SqlConnection sqlConnect = new SqlConnection(connectionString);
            try
            {
                GetData();

                //Conectar
                sqlConnect.Open();
                string sql = "INSERT INTO [USER](NAME, PASSWORD, EMAIL,ACTIVE, FK_USERPROFILE) VALUES (@name, @password, @email, @active,@userprofile)";

                SqlCommand cmd = new SqlCommand(sql, sqlConnect);

                cmd.Parameters.Add(new SqlParameter("@name", name));
                cmd.Parameters.Add(new SqlParameter("@password", pass));
                cmd.Parameters.Add(new SqlParameter("@email", email));
                cmd.Parameters.Add(new SqlParameter("@active", active));
                cmd.Parameters.Add(new SqlParameter("@userprofile", ((UserProfile)cmbProfile.SelectedItem).Id));
                cmd.ExecuteNonQuery();

                MessageBox.Show("Adicionado com sucesso!");
                CleanData();

            }
            catch (Exception ex)
            {
                //Tratar exceções
                MessageBox.Show("Erro ao adicionar categoria!" + ex.Message);
                CleanData();
            }
            finally
            {
                //Fechar
            }
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
            email = tbxEmail.Text;
            pass = tbxPass.Text;
            cpass = tbxCPass.Text;
            profile = cmbProfile.Text;
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
            tbxName.Text = "";
            tbxEmail.Text = "";
            tbxPass.Text = "";
            tbxCPass.Text = "";
            cmbProfile.SelectedIndex = 0;
            cbxActive.Checked = false;

        }
    }
}
