namespace Map_Front
{
    partial class frMain
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
            this.btnCreateUser = new System.Windows.Forms.Button();
            this.btnListUser = new System.Windows.Forms.Button();
            this.btnListReport = new System.Windows.Forms.Button();
            this.btnListPartners = new System.Windows.Forms.Button();
            this.btnEditUser = new System.Windows.Forms.Button();
            this.txtEmail = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txtList = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // btnCreateUser
            // 
            this.btnCreateUser.Location = new System.Drawing.Point(23, 12);
            this.btnCreateUser.Name = "btnCreateUser";
            this.btnCreateUser.Size = new System.Drawing.Size(141, 41);
            this.btnCreateUser.TabIndex = 0;
            this.btnCreateUser.Text = "Cadastrar Usuário";
            this.btnCreateUser.UseVisualStyleBackColor = true;
            this.btnCreateUser.Click += new System.EventHandler(this.btnCreateUser_Click);
            // 
            // btnListUser
            // 
            this.btnListUser.Location = new System.Drawing.Point(23, 68);
            this.btnListUser.Name = "btnListUser";
            this.btnListUser.Size = new System.Drawing.Size(141, 41);
            this.btnListUser.TabIndex = 2;
            this.btnListUser.Text = "Listar Usuário";
            this.btnListUser.UseVisualStyleBackColor = true;
            this.btnListUser.Click += new System.EventHandler(this.btnListUser_Click);
            // 
            // btnListReport
            // 
            this.btnListReport.Location = new System.Drawing.Point(427, 68);
            this.btnListReport.Name = "btnListReport";
            this.btnListReport.Size = new System.Drawing.Size(141, 41);
            this.btnListReport.TabIndex = 3;
            this.btnListReport.Text = "Listar Reporte";
            this.btnListReport.UseVisualStyleBackColor = true;
            this.btnListReport.Click += new System.EventHandler(this.btnListReport_Click);
            // 
            // btnListPartners
            // 
            this.btnListPartners.Location = new System.Drawing.Point(209, 68);
            this.btnListPartners.Name = "btnListPartners";
            this.btnListPartners.Size = new System.Drawing.Size(167, 41);
            this.btnListPartners.TabIndex = 4;
            this.btnListPartners.Text = "Listar Instituições Parceiras";
            this.btnListPartners.UseVisualStyleBackColor = true;
            this.btnListPartners.Click += new System.EventHandler(this.btnListPartners_Click);
            // 
            // btnEditUser
            // 
            this.btnEditUser.Location = new System.Drawing.Point(363, 143);
            this.btnEditUser.Name = "btnEditUser";
            this.btnEditUser.Size = new System.Drawing.Size(141, 41);
            this.btnEditUser.TabIndex = 5;
            this.btnEditUser.Text = "Editar Usuário";
            this.btnEditUser.UseVisualStyleBackColor = true;
            this.btnEditUser.Click += new System.EventHandler(this.btnEditUser_Click);
            // 
            // txtEmail
            // 
            this.txtEmail.Location = new System.Drawing.Point(95, 153);
            this.txtEmail.Name = "txtEmail";
            this.txtEmail.Size = new System.Drawing.Size(251, 23);
            this.txtEmail.TabIndex = 6;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.label2.Location = new System.Drawing.Point(23, 151);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(53, 21);
            this.label2.TabIndex = 7;
            this.label2.Text = "Email";
            // 
            // txtList
            // 
            this.txtList.Location = new System.Drawing.Point(23, 228);
            this.txtList.Multiline = true;
            this.txtList.Name = "txtList";
            this.txtList.Size = new System.Drawing.Size(545, 203);
            this.txtList.TabIndex = 8;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.label1.Location = new System.Drawing.Point(23, 195);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(45, 21);
            this.label1.TabIndex = 9;
            this.label1.Text = "Lista";
            // 
            // frMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(598, 443);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtList);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txtEmail);
            this.Controls.Add(this.btnEditUser);
            this.Controls.Add(this.btnListPartners);
            this.Controls.Add(this.btnListReport);
            this.Controls.Add(this.btnListUser);
            this.Controls.Add(this.btnCreateUser);
            this.Name = "frMain";
            this.Text = "frMain";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnCreateUser;
        private System.Windows.Forms.Button btnListUser;
        private System.Windows.Forms.Button btnListReport;
        private System.Windows.Forms.Button btnListPartners;
        private System.Windows.Forms.Button btnEditUser;
        private System.Windows.Forms.TextBox txtEmail;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtList;
        private System.Windows.Forms.Label label1;
    }
}