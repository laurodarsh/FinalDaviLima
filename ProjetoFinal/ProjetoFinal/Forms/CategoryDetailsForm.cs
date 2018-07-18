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
    public partial class CategoryDetailsForm : Form
    {
        string connectionString = "workstation id=StockControlData.mssql.somee.com;packet size=4096;user id=luacademy_SQLLogin_1;pwd=msctq6gvt3;data source=StockControlData.mssql.somee.com;persist security info=False;initial catalog=StockControlData";
        string name = "";
        bool active = false;
        public CategoryDetailsForm()
        {
            InitializeComponent();


        }
        public CategoryDetailsForm(int idCategory)
        {

            InitializeComponent();

            lblID.Text = idCategory.ToString(); //-------

            SqlConnection sqlConnect = new SqlConnection(connectionString);

            if (!string.IsNullOrEmpty(lblID.Text))
            {
                try
                {
                    //Conectar
                    sqlConnect.Open();

                    SqlCommand cmd = new SqlCommand("SELECT * FROM CATEGORY WHERE ID = @id", sqlConnect);
                    //SqlCommand cmd = new SqlCommand("SELECT * FROM CATEGORY WHERE ID = " + idCategory.ToString(), sqlConnect);

                    cmd.Parameters.Add(new SqlParameter("@id", idCategory));

                    Category category = new Category(); //------

                    using (SqlDataReader reader = cmd.ExecuteReader()) //-----
                    {
                        while (reader.Read())
                        {
                            category.Id = Int32.Parse(reader["ID"].ToString());
                            category.Name = reader["NAME"].ToString();
                            category.Active = bool.Parse(reader["ACTIVE"].ToString());





                        }
                    }

                    tbxName.Text = category.Name;
                    cbxActive.Checked = category.Active;


                }
                catch (Exception EX)
                {
                    //Tratar exce??es
                    throw;
                }
                finally
                {
                    //Fechar
                    sqlConnect.Close();
                }
            }
        }

        private void pbxBack_Click(object sender, EventArgs e)
        {
            CategoryAllForm categoryAllForm = new CategoryAllForm();
            categoryAllForm.Show();
            this.Hide();
        }

        private void pbxSave_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(lblID.Text))
            {
                SqlConnection sqlConnect = new SqlConnection(connectionString);
                try
                {
                    GetData();
                    sqlConnect.Open();
                    string sql = "INSERT INTO CATEGORY(NAME, ACTIVE) VALUES (@name, @active)";
                    SqlCommand cmd = new SqlCommand(sql, sqlConnect);

                    cmd.Parameters.Add(new SqlParameter("@name", name));
                    cmd.Parameters.Add(new SqlParameter("@active", active));

                    cmd.ExecuteNonQuery();

                    MessageBox.Show("Adicionado com sucesso!");
                    Log.SalvarLog("categoria inserida", "inserção", DateTime.Now);
                    CleanData();

                }
                catch (Exception ex)
                {
                    MessageBox.Show("Erro ao adicionar categoria!" + ex.Message);
                    CleanData();
                }
                finally
                {
                    sqlConnect.Close();
                }

            }
            else
            {
                SqlConnection sqlConnect = new SqlConnection(connectionString);

                try
                {
                    sqlConnect.Open();
                    string sql = "UPDATE CATEGORY SET NAME = @name, ACTIVE = @active Where ID = @id";

                    SqlCommand cmd = new SqlCommand(sql, sqlConnect);

                    cmd.Parameters.Add(new SqlParameter("@name", this.tbxName.Text));
                    cmd.Parameters.Add(new SqlParameter("@active", this.cbxActive.Checked));

                    cmd.ExecuteNonQuery();

                    MessageBox.Show("Alterações salvas com sucesso!");
                    Log.SalvarLog("categoria editada", "edição", DateTime.Now);
                    CleanData();
                }
                catch (Exception Ex)
                {
                    MessageBox.Show("Erro ao editar esta categoria!" + "\n\n" + Ex.Message);
                    throw;
                }
                finally
                {
                    sqlConnect.Close();

                    HomeForm homeForm = new HomeForm();
                    homeForm.Show();
                    this.Hide();
                }
            }

        }

        private void pbxDelete_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(lblID.Text)) //-----
            {
                SqlConnection sqlConnect = new SqlConnection(connectionString);


                try
                {
                    sqlConnect.Open();
                    string sql = "UPDATE CATEGORY SET ACTIVE = @active WHERE ID = @id";

                    SqlCommand cmd = new SqlCommand(sql, sqlConnect);

                    cmd.Parameters.Add(new SqlParameter("@id", Int32.Parse(lblID.Text)));
                    cmd.Parameters.Add(new SqlParameter("@active", false));

                    cmd.ExecuteNonQuery();

                    MessageBox.Show("categoria inativa!");
                    Log.SalvarLog("categoria desativada", "exclusão", DateTime.Now);
                }
                catch (Exception Ex)
                {
                    MessageBox.Show("Erro ao desativar esta categoria!" + "\n\n" + Ex.Message);
                    throw;
                }
                finally
                {
                    sqlConnect.Close();
                }

            }
        }

        private void pbxDelete_MouseEnter(object sender, EventArgs e)
        {
            pbxDelete.BackColor = Color.Cyan;
        }

        private void pbxDelete_MouseLeave(object sender, EventArgs e)
        {
            pbxDelete.BackColor = Color.Transparent;
        }

        private void pbxSave_MouseEnter(object sender, EventArgs e)
        {
            pbxSave.BackColor = Color.Cyan;
        }

        private void pbxSave_MouseLeave(object sender, EventArgs e)
        {
            pbxSave.BackColor = Color.Transparent;
        }

        private void pbxBack_MouseEnter(object sender, EventArgs e)
        {
            pbxBack.BackColor = Color.Cyan;
        }

        private void pbxBack_MouseLeave(object sender, EventArgs e)
        {
            pbxBack.BackColor = Color.Transparent;
        }
        void GetData()
        {
            name = tbxName.Text;
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
            cbxActive.Checked = false;
        }

        private void CategoryDetailsForm_Load(object sender, EventArgs e)
        {

        }
    }
}
