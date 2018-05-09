namespace ProjetoFinal
{
    partial class ProfileDetailsForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.btnEntrar = new System.Windows.Forms.Button();
            this.lblNome = new System.Windows.Forms.Label();
            this.tbxSenha = new System.Windows.Forms.TextBox();
            this.lblSenha = new System.Windows.Forms.Label();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // btnEntrar
            // 
            this.btnEntrar.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnEntrar.Location = new System.Drawing.Point(94, 162);
            this.btnEntrar.Name = "btnEntrar";
            this.btnEntrar.Size = new System.Drawing.Size(75, 23);
            this.btnEntrar.TabIndex = 0;
            this.btnEntrar.Text = "Entrar";
            this.btnEntrar.UseVisualStyleBackColor = true;
            // 
            // lblNome
            // 
            this.lblNome.AutoSize = true;
            this.lblNome.Font = new System.Drawing.Font("Arial", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblNome.Location = new System.Drawing.Point(31, 47);
            this.lblNome.Name = "lblNome";
            this.lblNome.Size = new System.Drawing.Size(57, 18);
            this.lblNome.TabIndex = 1;
            this.lblNome.Text = "Nome :";
            // 
            // tbxSenha
            // 
            this.tbxSenha.Location = new System.Drawing.Point(94, 45);
            this.tbxSenha.Name = "tbxSenha";
            this.tbxSenha.Size = new System.Drawing.Size(100, 20);
            this.tbxSenha.TabIndex = 2;
            // 
            // lblSenha
            // 
            this.lblSenha.AutoSize = true;
            this.lblSenha.Font = new System.Drawing.Font("Arial", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSenha.Location = new System.Drawing.Point(31, 105);
            this.lblSenha.Name = "lblSenha";
            this.lblSenha.Size = new System.Drawing.Size(61, 18);
            this.lblSenha.TabIndex = 3;
            this.lblSenha.Text = "Senha :";
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(94, 105);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(100, 20);
            this.textBox1.TabIndex = 4;
            // 
            // ProfileDetailsForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(284, 261);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.lblSenha);
            this.Controls.Add(this.tbxSenha);
            this.Controls.Add(this.lblNome);
            this.Controls.Add(this.btnEntrar);
            this.Name = "ProfileDetailsForm";
            this.Text = "ProfileDetailsForm";
            this.Load += new System.EventHandler(this.ProfileDetailsForm_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnEntrar;
        private System.Windows.Forms.Label lblNome;
        private System.Windows.Forms.TextBox tbxSenha;
        private System.Windows.Forms.Label lblSenha;
        private System.Windows.Forms.TextBox textBox1;
    }
}