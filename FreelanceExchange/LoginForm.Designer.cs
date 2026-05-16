namespace FreelanceExchange
{
    partial class LoginForm
    {
        private System.ComponentModel.IContainer components = null;

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;

        private System.Windows.Forms.TextBox txtLogin;
        private System.Windows.Forms.TextBox txtPassword;

        private System.Windows.Forms.ComboBox cmbRole;

        private System.Windows.Forms.Button btnLogin;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }

            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            label1 = new System.Windows.Forms.Label();
            label2 = new System.Windows.Forms.Label();
            label3 = new System.Windows.Forms.Label();
            txtLogin = new System.Windows.Forms.TextBox();
            txtPassword = new System.Windows.Forms.TextBox();
            cmbRole = new System.Windows.Forms.ComboBox();
            btnLogin = new System.Windows.Forms.Button();
            button1 = new System.Windows.Forms.Button();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new System.Drawing.Point(40, 40);
            label1.Name = "label1";
            label1.Size = new System.Drawing.Size(41, 15);
            label1.TabIndex = 0;
            label1.Text = "Логин";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new System.Drawing.Point(40, 90);
            label2.Name = "label2";
            label2.Size = new System.Drawing.Size(49, 15);
            label2.TabIndex = 1;
            label2.Text = "Пароль";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new System.Drawing.Point(40, 140);
            label3.Name = "label3";
            label3.Size = new System.Drawing.Size(34, 15);
            label3.TabIndex = 2;
            label3.Text = "Роль";
            // 
            // txtLogin
            // 
            txtLogin.Location = new System.Drawing.Point(140, 35);
            txtLogin.Name = "txtLogin";
            txtLogin.Size = new System.Drawing.Size(180, 23);
            txtLogin.TabIndex = 3;
            // 
            // txtPassword
            // 
            txtPassword.Location = new System.Drawing.Point(140, 85);
            txtPassword.Name = "txtPassword";
            txtPassword.PasswordChar = '*';
            txtPassword.Size = new System.Drawing.Size(141, 23);
            txtPassword.TabIndex = 4;
            // 
            // cmbRole
            // 
            cmbRole.FormattingEnabled = true;
            cmbRole.Items.AddRange(new object[] { "Администратор", "Заказчик", "Фрилансер" });
            cmbRole.Location = new System.Drawing.Point(140, 135);
            cmbRole.Name = "cmbRole";
            cmbRole.Size = new System.Drawing.Size(180, 23);
            cmbRole.TabIndex = 5;
            // 
            // btnLogin
            // 
            btnLogin.Location = new System.Drawing.Point(140, 190);
            btnLogin.Name = "btnLogin";
            btnLogin.Size = new System.Drawing.Size(120, 35);
            btnLogin.TabIndex = 6;
            btnLogin.Text = "Войти";
            btnLogin.UseVisualStyleBackColor = true;
            btnLogin.Click += btnLogin_Click;
            // 
            // button1
            // 
            button1.Location = new System.Drawing.Point(287, 85);
            button1.Name = "button1";
            button1.Size = new System.Drawing.Size(33, 23);
            button1.TabIndex = 7;
            button1.Text = "👁️";
            button1.UseVisualStyleBackColor = true;
            button1.Click += button1_Click;
            // 
            // LoginForm
            // 
            AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            ClientSize = new System.Drawing.Size(400, 280);
            Controls.Add(button1);
            Controls.Add(label1);
            Controls.Add(label2);
            Controls.Add(label3);
            Controls.Add(txtLogin);
            Controls.Add(txtPassword);
            Controls.Add(cmbRole);
            Controls.Add(btnLogin);
            Name = "LoginForm";
            Text = "Авторизация";
            ResumeLayout(false);
            PerformLayout();
        }
        private System.Windows.Forms.Button button1;
    }
}