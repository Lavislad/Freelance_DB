namespace FreelanceExchange
{
    partial class FilterForm
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
            btnAccept = new System.Windows.Forms.Button();
            btnCancel = new System.Windows.Forms.Button();
            lblTable = new System.Windows.Forms.Label();
            cmbTables = new System.Windows.Forms.ComboBox();
            pnlUsers = new System.Windows.Forms.Panel();
            lblRole = new System.Windows.Forms.Label();
            txtRole = new System.Windows.Forms.TextBox();
            txtRegDate = new System.Windows.Forms.TextBox();
            lblRegDate = new System.Windows.Forms.Label();
            pnlUsers.SuspendLayout();
            SuspendLayout();
            // 
            // btnAccept
            // 
            btnAccept.Anchor = System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right;
            btnAccept.AutoSize = true;
            btnAccept.Location = new System.Drawing.Point(347, 415);
            btnAccept.Name = "btnAccept";
            btnAccept.Size = new System.Drawing.Size(80, 25);
            btnAccept.TabIndex = 0;
            btnAccept.Text = "Применить";
            btnAccept.UseVisualStyleBackColor = true;
            // 
            // btnCancel
            // 
            btnCancel.Anchor = System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right;
            btnCancel.AutoSize = true;
            btnCancel.Location = new System.Drawing.Point(261, 413);
            btnCancel.Name = "btnCancel";
            btnCancel.Size = new System.Drawing.Size(80, 25);
            btnCancel.TabIndex = 1;
            btnCancel.Text = "Отмена";
            btnCancel.UseVisualStyleBackColor = true;
            // 
            // lblTable
            // 
            lblTable.AutoSize = true;
            lblTable.Location = new System.Drawing.Point(12, 9);
            lblTable.Name = "lblTable";
            lblTable.Size = new System.Drawing.Size(54, 15);
            lblTable.TabIndex = 2;
            lblTable.Text = "Таблица";
            // 
            // cmbTables
            // 
            cmbTables.FormattingEnabled = true;
            cmbTables.Location = new System.Drawing.Point(12, 27);
            cmbTables.Name = "cmbTables";
            cmbTables.Size = new System.Drawing.Size(180, 23);
            cmbTables.TabIndex = 3;
            cmbTables.SelectedIndexChanged += cmbTables_SelectedIndexChanged;
            // 
            // pnlUsers
            // 
            pnlUsers.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
            pnlUsers.Controls.Add(lblRole);
            pnlUsers.Controls.Add(txtRole);
            pnlUsers.Controls.Add(txtRegDate);
            pnlUsers.Controls.Add(lblRegDate);
            pnlUsers.Location = new System.Drawing.Point(12, 56);
            pnlUsers.Name = "pnlUsers";
            pnlUsers.Size = new System.Drawing.Size(410, 351);
            pnlUsers.TabIndex = 4;
            pnlUsers.Visible = false;
            // 
            // lblRole
            // 
            lblRole.AutoSize = true;
            lblRole.Location = new System.Drawing.Point(0, 35);
            lblRole.Name = "lblRole";
            lblRole.Size = new System.Drawing.Size(49, 15);
            lblRole.TabIndex = 3;
            lblRole.Text = "ID роли";
            // 
            // txtRole
            // 
            txtRole.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
            txtRole.Location = new System.Drawing.Point(307, 32);
            txtRole.Name = "txtRole";
            txtRole.Size = new System.Drawing.Size(100, 23);
            txtRole.TabIndex = 2;
            // 
            // txtRegDate
            // 
            txtRegDate.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
            txtRegDate.Location = new System.Drawing.Point(307, 3);
            txtRegDate.Name = "txtRegDate";
            txtRegDate.Size = new System.Drawing.Size(100, 23);
            txtRegDate.TabIndex = 1;
            // 
            // lblRegDate
            // 
            lblRegDate.AutoSize = true;
            lblRegDate.Location = new System.Drawing.Point(0, 6);
            lblRegDate.Name = "lblRegDate";
            lblRegDate.Size = new System.Drawing.Size(105, 15);
            lblRegDate.TabIndex = 0;
            lblRegDate.Text = "Дата регистрации";
            // 
            // FilterForm
            // 
            AcceptButton = btnAccept;
            AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            CancelButton = btnCancel;
            ClientSize = new System.Drawing.Size(434, 450);
            Controls.Add(pnlUsers);
            Controls.Add(cmbTables);
            Controls.Add(lblTable);
            Controls.Add(btnCancel);
            Controls.Add(btnAccept);
            Name = "FilterForm";
            Text = "Фильтры";
            pnlUsers.ResumeLayout(false);
            pnlUsers.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private System.Windows.Forms.Button btnAccept;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Label lblTable;
        private System.Windows.Forms.ComboBox cmbTables;
        private System.Windows.Forms.Panel pnlUsers;
        private System.Windows.Forms.TextBox txtRegDate;
        private System.Windows.Forms.Label lblRegDate;
        private System.Windows.Forms.Label lblRole;
        private System.Windows.Forms.TextBox txtRole;
    }
}