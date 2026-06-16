namespace FreelanceExchange
{
    partial class UserForm
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
            pbImage = new System.Windows.Forms.PictureBox();
            lblId = new System.Windows.Forms.Label();
            txtId = new System.Windows.Forms.TextBox();
            txtName = new System.Windows.Forms.TextBox();
            lblName = new System.Windows.Forms.Label();
            txtSurname = new System.Windows.Forms.TextBox();
            lblSurname = new System.Windows.Forms.Label();
            txtEmail = new System.Windows.Forms.TextBox();
            lblEmail = new System.Windows.Forms.Label();
            txtPassword = new System.Windows.Forms.TextBox();
            lblPassword = new System.Windows.Forms.Label();
            btnPassword = new System.Windows.Forms.Button();
            lblDescription = new System.Windows.Forms.Label();
            rtxtDescription = new System.Windows.Forms.RichTextBox();
            txtRoleId = new System.Windows.Forms.TextBox();
            lblRoleId = new System.Windows.Forms.Label();
            lblRegistrationDate = new System.Windows.Forms.Label();
            txtRegistrationDate = new System.Windows.Forms.TextBox();
            btnChange = new System.Windows.Forms.Button();
            btnDelete = new System.Windows.Forms.Button();
            openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            btnAccept = new System.Windows.Forms.Button();
            btnCancel = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)pbImage).BeginInit();
            SuspendLayout();
            // 
            // pbImage
            // 
            pbImage.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
            pbImage.Location = new System.Drawing.Point(12, 12);
            pbImage.Name = "pbImage";
            pbImage.Size = new System.Drawing.Size(250, 250);
            pbImage.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            pbImage.TabIndex = 0;
            pbImage.TabStop = false;
            // 
            // lblId
            // 
            lblId.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right;
            lblId.AutoSize = true;
            lblId.Location = new System.Drawing.Point(268, 12);
            lblId.Name = "lblId";
            lblId.Size = new System.Drawing.Size(18, 15);
            lblId.TabIndex = 1;
            lblId.Text = "ID";
            // 
            // txtId
            // 
            txtId.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right;
            txtId.Location = new System.Drawing.Point(268, 30);
            txtId.Name = "txtId";
            txtId.ReadOnly = true;
            txtId.Size = new System.Drawing.Size(250, 23);
            txtId.TabIndex = 2;
            // 
            // txtName
            // 
            txtName.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right;
            txtName.Location = new System.Drawing.Point(268, 124);
            txtName.Name = "txtName";
            txtName.Size = new System.Drawing.Size(250, 23);
            txtName.TabIndex = 4;
            // 
            // lblName
            // 
            lblName.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right;
            lblName.AutoSize = true;
            lblName.Location = new System.Drawing.Point(268, 106);
            lblName.Name = "lblName";
            lblName.Size = new System.Drawing.Size(39, 15);
            lblName.TabIndex = 3;
            lblName.Text = "Name";
            // 
            // txtSurname
            // 
            txtSurname.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right;
            txtSurname.Location = new System.Drawing.Point(268, 168);
            txtSurname.Name = "txtSurname";
            txtSurname.Size = new System.Drawing.Size(250, 23);
            txtSurname.TabIndex = 6;
            // 
            // lblSurname
            // 
            lblSurname.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right;
            lblSurname.AutoSize = true;
            lblSurname.Location = new System.Drawing.Point(268, 150);
            lblSurname.Name = "lblSurname";
            lblSurname.Size = new System.Drawing.Size(54, 15);
            lblSurname.TabIndex = 5;
            lblSurname.Text = "Surname";
            // 
            // txtEmail
            // 
            txtEmail.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right;
            txtEmail.Location = new System.Drawing.Point(268, 212);
            txtEmail.Name = "txtEmail";
            txtEmail.Size = new System.Drawing.Size(250, 23);
            txtEmail.TabIndex = 8;
            // 
            // lblEmail
            // 
            lblEmail.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right;
            lblEmail.AutoSize = true;
            lblEmail.Location = new System.Drawing.Point(268, 194);
            lblEmail.Name = "lblEmail";
            lblEmail.Size = new System.Drawing.Size(36, 15);
            lblEmail.TabIndex = 7;
            lblEmail.Text = "Email";
            // 
            // txtPassword
            // 
            txtPassword.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right;
            txtPassword.Location = new System.Drawing.Point(268, 256);
            txtPassword.Name = "txtPassword";
            txtPassword.PasswordChar = '*';
            txtPassword.Size = new System.Drawing.Size(211, 23);
            txtPassword.TabIndex = 10;
            // 
            // lblPassword
            // 
            lblPassword.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right;
            lblPassword.AutoSize = true;
            lblPassword.Location = new System.Drawing.Point(268, 238);
            lblPassword.Name = "lblPassword";
            lblPassword.Size = new System.Drawing.Size(57, 15);
            lblPassword.TabIndex = 9;
            lblPassword.Text = "Password";
            // 
            // btnPassword
            // 
            btnPassword.Location = new System.Drawing.Point(485, 256);
            btnPassword.Name = "btnPassword";
            btnPassword.Size = new System.Drawing.Size(33, 23);
            btnPassword.TabIndex = 11;
            btnPassword.Text = "👁️";
            btnPassword.UseVisualStyleBackColor = true;
            btnPassword.Click += btnPassword_Click;
            // 
            // lblDescription
            // 
            lblDescription.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right;
            lblDescription.AutoSize = true;
            lblDescription.Location = new System.Drawing.Point(268, 326);
            lblDescription.Name = "lblDescription";
            lblDescription.Size = new System.Drawing.Size(104, 15);
            lblDescription.TabIndex = 12;
            lblDescription.Text = "Profile Description";
            // 
            // rtxtDescription
            // 
            rtxtDescription.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right;
            rtxtDescription.Location = new System.Drawing.Point(265, 344);
            rtxtDescription.Name = "rtxtDescription";
            rtxtDescription.ScrollBars = System.Windows.Forms.RichTextBoxScrollBars.Vertical;
            rtxtDescription.Size = new System.Drawing.Size(250, 95);
            rtxtDescription.TabIndex = 14;
            rtxtDescription.Text = "";
            // 
            // txtRoleId
            // 
            txtRoleId.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right;
            txtRoleId.Location = new System.Drawing.Point(268, 300);
            txtRoleId.Name = "txtRoleId";
            txtRoleId.Size = new System.Drawing.Size(250, 23);
            txtRoleId.TabIndex = 16;
            // 
            // lblRoleId
            // 
            lblRoleId.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right;
            lblRoleId.AutoSize = true;
            lblRoleId.Location = new System.Drawing.Point(268, 282);
            lblRoleId.Name = "lblRoleId";
            lblRoleId.Size = new System.Drawing.Size(44, 15);
            lblRoleId.TabIndex = 15;
            lblRoleId.Text = "Role ID";
            // 
            // lblRegistrationDate
            // 
            lblRegistrationDate.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right;
            lblRegistrationDate.AutoSize = true;
            lblRegistrationDate.Location = new System.Drawing.Point(268, 62);
            lblRegistrationDate.Name = "lblRegistrationDate";
            lblRegistrationDate.Size = new System.Drawing.Size(97, 15);
            lblRegistrationDate.TabIndex = 17;
            lblRegistrationDate.Text = "Registration Date";
            // 
            // txtRegistrationDate
            // 
            txtRegistrationDate.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right;
            txtRegistrationDate.Location = new System.Drawing.Point(268, 80);
            txtRegistrationDate.Name = "txtRegistrationDate";
            txtRegistrationDate.ReadOnly = true;
            txtRegistrationDate.Size = new System.Drawing.Size(246, 23);
            txtRegistrationDate.TabIndex = 18;
            // 
            // btnChange
            // 
            btnChange.Location = new System.Drawing.Point(12, 268);
            btnChange.Name = "btnChange";
            btnChange.Size = new System.Drawing.Size(75, 23);
            btnChange.TabIndex = 19;
            btnChange.Text = "Изменить";
            btnChange.UseVisualStyleBackColor = true;
            btnChange.Click += btnChange_Click;
            // 
            // btnDelete
            // 
            btnDelete.Location = new System.Drawing.Point(93, 268);
            btnDelete.Name = "btnDelete";
            btnDelete.Size = new System.Drawing.Size(75, 23);
            btnDelete.TabIndex = 20;
            btnDelete.Text = "Удалить";
            btnDelete.UseVisualStyleBackColor = true;
            btnDelete.Click += btnDelete_Click;
            // 
            // openFileDialog1
            // 
            openFileDialog1.FileName = "openFileDialog1";
            // 
            // btnAccept
            // 
            btnAccept.Location = new System.Drawing.Point(439, 452);
            btnAccept.Name = "btnAccept";
            btnAccept.Size = new System.Drawing.Size(75, 23);
            btnAccept.TabIndex = 21;
            btnAccept.Text = "Принять";
            btnAccept.UseVisualStyleBackColor = true;
            btnAccept.Click += btnAccept_Click;
            // 
            // btnCancel
            // 
            btnCancel.Location = new System.Drawing.Point(12, 452);
            btnCancel.Name = "btnCancel";
            btnCancel.Size = new System.Drawing.Size(75, 23);
            btnCancel.TabIndex = 22;
            btnCancel.Text = "Отмена";
            btnCancel.UseVisualStyleBackColor = true;
            btnCancel.Click += btnCancel_Click;
            // 
            // UserForm
            // 
            AcceptButton = btnAccept;
            AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            CancelButton = btnCancel;
            ClientSize = new System.Drawing.Size(526, 487);
            Controls.Add(btnCancel);
            Controls.Add(btnAccept);
            Controls.Add(btnDelete);
            Controls.Add(btnChange);
            Controls.Add(txtRegistrationDate);
            Controls.Add(lblRegistrationDate);
            Controls.Add(txtRoleId);
            Controls.Add(lblRoleId);
            Controls.Add(rtxtDescription);
            Controls.Add(lblDescription);
            Controls.Add(btnPassword);
            Controls.Add(txtPassword);
            Controls.Add(lblPassword);
            Controls.Add(txtEmail);
            Controls.Add(lblEmail);
            Controls.Add(txtSurname);
            Controls.Add(lblSurname);
            Controls.Add(txtName);
            Controls.Add(lblName);
            Controls.Add(txtId);
            Controls.Add(lblId);
            Controls.Add(pbImage);
            Name = "UserForm";
            Text = "UserForm";
            ((System.ComponentModel.ISupportInitialize)pbImage).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private System.Windows.Forms.PictureBox pbImage;
        private System.Windows.Forms.Label lblId;
        private System.Windows.Forms.TextBox txtId;
        private System.Windows.Forms.TextBox txtName;
        private System.Windows.Forms.Label lblName;
        private System.Windows.Forms.TextBox txtSurname;
        private System.Windows.Forms.Label lblSurname;
        private System.Windows.Forms.TextBox txtEmail;
        private System.Windows.Forms.Label lblEmail;
        private System.Windows.Forms.TextBox txtPassword;
        private System.Windows.Forms.Label lblPassword;
        private System.Windows.Forms.Button btnPassword;
        private System.Windows.Forms.Label lblDescription;
        private System.Windows.Forms.RichTextBox rtxtDescription;
        private System.Windows.Forms.TextBox txtRoleId;
        private System.Windows.Forms.Label lblRoleId;
        private System.Windows.Forms.Label lblRegistrationDate;
        private System.Windows.Forms.TextBox txtRegistrationDate;
        private System.Windows.Forms.Button btnChange;
        private System.Windows.Forms.Button btnDelete;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.Button btnAccept;
        private System.Windows.Forms.Button btnCancel;
    }
}