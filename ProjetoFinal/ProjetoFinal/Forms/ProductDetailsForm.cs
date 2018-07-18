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


    public partial class ProductDetailsForm : Form
    {
        string connectionString = "workstation id=StockControlData.mssql.somee.com;packet size=4096;user id=luacademy_SQLLogin_1;pwd=msctq6gvt3;data source=StockControlData.mssql.somee.com;persist security info=False;initial catalog=StockControlData";
        string name = "";
        float price = 0;
        string category = "";
        bool active = false;
        List<Category> categories = new List<Category>();

        public ProductDetailsForm()
        {
            InitializeComponent();
            cmbCategory.DisplayMember = "NAME";
            LoadComboBox();

        }
        public ProductDetailsForm(int idProduct)
        {

            InitializeComponent();
            cmbCategory.DisplayMember = "NAME";
            lblID.Text = idProduct.ToString(); //-------

            SqlConnection sqlConnect = new SqlConnection(connectionString);

            if (!string.IsNullOrEmpty(lblID.Text))
            {
                try
                {
                    //Conectar
                    sqlConnect.Open();

                    SqlCommand cmd = new SqlCommand("SELECT * FROM PRODUCT WHERE ID = @id", sqlConnect);
                    //SqlCommand cmd = new SqlCommand("SELECT * FROM CATEGORY WHERE ID = " + idCategory.ToString(), sqlConnect);

                    cmd.Parameters.Add(new SqlParameter("@id", idProduct));

                    Product product = new Product(); //------

                    using (SqlDataReader reader = cmd.ExecuteReader()) //-----
                    {
                        while (reader.Read())
                        {
                            product.Id = Int32.Parse(reader["ID"].ToString());
                            product.Name = reader["NAME"].ToString();
                            product.Active = bool.Parse(reader["ACTIVE"].ToString());
                            product.Price = float.Parse(reader["PRICE"].ToString());
                            int indexCombo = 0;
                            if (product.Category != null)
                            {
                                indexCombo = product.Category.Id;
                            }

                            //Inicializa o dropDown com as informações do banco
                            InitializeComboBox(cmbCategory, indexCombo);


                        }
                    }

                    tbxName.Text = product.Name;
                    cbxActive.Checked = product.Active;
                    tbxPrice.Text = product.Price.ToString();
                    

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
        private void InitializeComboBox(ComboBox cbxProduct, int indexCombo)
        {
            cmbCategory.Items.Add("Selecione.. ");
            SqlConnection sqlConnect = new SqlConnection(connectionString);

            try
            {
                //Conectar
                sqlConnect.Open();

                SqlCommand cmd = new SqlCommand("SELECT * FROM CATEGORY", sqlConnect);

                using (SqlDataReader reader = cmd.ExecuteReader()) //-----
                {
                    while (reader.Read())
                    {
                        Category c = new Category(Int32.Parse(reader["ID"].ToString()), reader["NAME"].ToString(), bool.Parse(reader["ACTIVE"].ToString()));
                        cmbCategory.Items.Add(c);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("erro de acesso ao banco de dados. " + ex.Message);
            }
            finally
            {
                sqlConnect.Close();
            }
        }

        void LoadComboBox()
        {
            SqlConnection cn = new SqlConnection(connectionString);

            try
            {
                cn.Open();
                SqlCommand sqlCommand = new SqlCommand("SELECT * FROM CATEGORY", cn);

                SqlDataReader reader = sqlCommand.ExecuteReader();
                while (reader.Read())
                {
                    Category c = new Category(Int32.Parse(reader["ID"].ToString()),reader["NAME"].ToString(), bool.Parse(reader["ACTIVE"].ToString()));
                    categories.Add(c);
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
            foreach (Category c in categories)
            {
                cmbCategory.Items.Add(c);
            }
        }
        private void pbxBack_Click(object sender, EventArgs e)
        {
            ProductAllForm productallform = new ProductAllForm();
            productallform.Show();
            this.Hide();
        }

        private void pbxSave_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(lblID.Text))
            {
                //Salvar

                SqlConnection sqlConnect = new SqlConnection(connectionString);
                try
                {
                    GetData();

                    //Conectar
                    sqlConnect.Open();
                    string sql = "INSERT INTO PRODUCT(NAME, PRICE, ACTIVE, FK_PRODUCT) VALUES (@name, @price, @active, @category)";

                    SqlCommand cmd = new SqlCommand(sql, sqlConnect);

                    cmd.Parameters.Add(new SqlParameter("@name", name));
                    cmd.Parameters.Add(new SqlParameter("@price", price));
                    cmd.Parameters.Add(new SqlParameter("@active", active));
                    cmd.Parameters.Add(new SqlParameter("@category", ((Category)cmbCategory.SelectedItem).Id));
                    cmd.ExecuteNonQuery();

                    MessageBox.Show("Adicionado com sucesso!");
                    Log.SalvarLog("produto inserido", "inserção", DateTime.Now);
                    CleanData();

                }
                catch (Exception ex)
                {
                    //Tratar exceções
                    MessageBox.Show("Erro ao adicionar produto!" + ex.Message);
                    CleanData();
                }
                finally
                {
                    //Fechar
                }
            }
            else
            {
                SqlConnection sqlConnect = new SqlConnection(connectionString);

                try
                {
                    sqlConnect.Open();
                    string sql = "UPDATE PRODUCT SET NAME = @name, ACTIVE = @active,PRICE = @price,FK_PRODUCT = @fk_product Where ID = @id";

                    SqlCommand cmd = new SqlCommand(sql, sqlConnect);

                    cmd.Parameters.Add(new SqlParameter("@name", this.tbxName.Text));
                    cmd.Parameters.Add(new SqlParameter("@active", this.cbxActive.Checked));
                    cmd.Parameters.Add(new SqlParameter("@price", this.tbxPrice.Text));
                    cmd.Parameters.Add(new SqlParameter("@fk_product", ((Category)cmbCategory.SelectedItem).Id));

                    cmd.ExecuteNonQuery();

                    MessageBox.Show("Alterações salvas com sucesso!");
                    Log.SalvarLog("produto editado", "edição", DateTime.Now);
                }
                catch (Exception Ex)
                {
                    MessageBox.Show("Erro ao editar este produto!" + "\n\n" + Ex.Message);
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
;
        }

        private void pbxDelete_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(lblID.Text)) //-----
            {
                SqlConnection sqlConnect = new SqlConnection(connectionString);


                try
                {
                    sqlConnect.Open();
                    string sql = "UPDATE PRODUCT SET ACTIVE = @active WHERE ID = @id";

                    SqlCommand cmd = new SqlCommand(sql, sqlConnect);

                    cmd.Parameters.Add(new SqlParameter("@id", Int32.Parse(lblID.Text)));
                    cmd.Parameters.Add(new SqlParameter("@active", false));

                    cmd.ExecuteNonQuery();

                    MessageBox.Show("produto inativo!");
                    Log.SalvarLog("produto desativado", "exclusão", DateTime.Now);
                }
                catch (Exception Ex)
                {
                    MessageBox.Show("Erro ao desativar esta produto!" + "\n\n" + Ex.Message);
                    throw;
                }
                finally
                {
                    sqlConnect.Close();
                }
            }
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
