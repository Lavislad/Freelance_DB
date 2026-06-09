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
            lblRegDate = new System.Windows.Forms.Label();
            pnlVacancies = new System.Windows.Forms.Panel();
            dtpFromDate = new System.Windows.Forms.DateTimePicker();
            lblToDate = new System.Windows.Forms.Label();
            lblFromDate = new System.Windows.Forms.Label();
            dtpToDate = new System.Windows.Forms.DateTimePicker();
            lblDate = new System.Windows.Forms.Label();
            dtpFromDeadline = new System.Windows.Forms.DateTimePicker();
            lblToDeadline = new System.Windows.Forms.Label();
            lblFromDeadline = new System.Windows.Forms.Label();
            dtpToDeadline = new System.Windows.Forms.DateTimePicker();
            lblToBudget = new System.Windows.Forms.Label();
            lblFromBudget = new System.Windows.Forms.Label();
            txtToBudget = new System.Windows.Forms.TextBox();
            lblDeadline = new System.Windows.Forms.Label();
            txtFromBudget = new System.Windows.Forms.TextBox();
            lblBudget = new System.Windows.Forms.Label();
            dateTimePicker1 = new System.Windows.Forms.DateTimePicker();
            label1 = new System.Windows.Forms.Label();
            label2 = new System.Windows.Forms.Label();
            dateTimePicker2 = new System.Windows.Forms.DateTimePicker();
            pnlUsers.SuspendLayout();
            pnlVacancies.SuspendLayout();
            SuspendLayout();
            // 
            // btnAccept
            // 
            btnAccept.Anchor = System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right;
            btnAccept.AutoSize = true;
            btnAccept.Location = new System.Drawing.Point(347, 223);
            btnAccept.Name = "btnAccept";
            btnAccept.Size = new System.Drawing.Size(80, 25);
            btnAccept.TabIndex = 0;
            btnAccept.Text = "Применить";
            btnAccept.UseVisualStyleBackColor = true;
            btnAccept.Click += btnAccept_Click;
            // 
            // btnCancel
            // 
            btnCancel.Anchor = System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right;
            btnCancel.AutoSize = true;
            btnCancel.Location = new System.Drawing.Point(261, 221);
            btnCancel.Name = "btnCancel";
            btnCancel.Size = new System.Drawing.Size(80, 25);
            btnCancel.TabIndex = 1;
            btnCancel.Text = "Отмена";
            btnCancel.UseVisualStyleBackColor = true;
            btnCancel.Click += btnCancel_Click;
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
            pnlUsers.BackColor = System.Drawing.Color.Transparent;
            pnlUsers.Controls.Add(dateTimePicker1);
            pnlUsers.Controls.Add(label1);
            pnlUsers.Controls.Add(label2);
            pnlUsers.Controls.Add(dateTimePicker2);
            pnlUsers.Controls.Add(lblRole);
            pnlUsers.Controls.Add(txtRole);
            pnlUsers.Controls.Add(lblRegDate);
            pnlUsers.Location = new System.Drawing.Point(12, 56);
            pnlUsers.Name = "pnlUsers";
            pnlUsers.Size = new System.Drawing.Size(410, 159);
            pnlUsers.TabIndex = 4;
            pnlUsers.Visible = false;
            // 
            // lblRole
            // 
            lblRole.AutoSize = true;
            lblRole.Location = new System.Drawing.Point(0, 67);
            lblRole.Name = "lblRole";
            lblRole.Size = new System.Drawing.Size(49, 15);
            lblRole.TabIndex = 3;
            lblRole.Text = "ID роли";
            // 
            // txtRole
            // 
            txtRole.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
            txtRole.Location = new System.Drawing.Point(111, 64);
            txtRole.Name = "txtRole";
            txtRole.Size = new System.Drawing.Size(296, 23);
            txtRole.TabIndex = 2;
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
            // pnlVacancies
            // 
            pnlVacancies.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
            pnlVacancies.BackColor = System.Drawing.Color.Transparent;
            pnlVacancies.Controls.Add(dtpFromDate);
            pnlVacancies.Controls.Add(lblToDate);
            pnlVacancies.Controls.Add(lblFromDate);
            pnlVacancies.Controls.Add(dtpToDate);
            pnlVacancies.Controls.Add(lblDate);
            pnlVacancies.Controls.Add(dtpFromDeadline);
            pnlVacancies.Controls.Add(lblToDeadline);
            pnlVacancies.Controls.Add(lblFromDeadline);
            pnlVacancies.Controls.Add(dtpToDeadline);
            pnlVacancies.Controls.Add(lblToBudget);
            pnlVacancies.Controls.Add(lblFromBudget);
            pnlVacancies.Controls.Add(txtToBudget);
            pnlVacancies.Controls.Add(lblDeadline);
            pnlVacancies.Controls.Add(txtFromBudget);
            pnlVacancies.Controls.Add(lblBudget);
            pnlVacancies.Location = new System.Drawing.Point(12, 56);
            pnlVacancies.Name = "pnlVacancies";
            pnlVacancies.Size = new System.Drawing.Size(410, 159);
            pnlVacancies.TabIndex = 5;
            pnlVacancies.Visible = false;
            // 
            // dtpFromDate
            // 
            dtpFromDate.Location = new System.Drawing.Point(265, 90);
            dtpFromDate.Name = "dtpFromDate";
            dtpFromDate.Size = new System.Drawing.Size(145, 23);
            dtpFromDate.TabIndex = 15;
            // 
            // lblToDate
            // 
            lblToDate.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right;
            lblToDate.AutoSize = true;
            lblToDate.Location = new System.Drawing.Point(237, 122);
            lblToDate.Name = "lblToDate";
            lblToDate.Size = new System.Drawing.Size(22, 15);
            lblToDate.TabIndex = 14;
            lblToDate.Text = "До";
            // 
            // lblFromDate
            // 
            lblFromDate.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right;
            lblFromDate.AutoSize = true;
            lblFromDate.Location = new System.Drawing.Point(239, 93);
            lblFromDate.Name = "lblFromDate";
            lblFromDate.Size = new System.Drawing.Size(21, 15);
            lblFromDate.TabIndex = 13;
            lblFromDate.Text = "От";
            // 
            // dtpToDate
            // 
            dtpToDate.Location = new System.Drawing.Point(265, 119);
            dtpToDate.Name = "dtpToDate";
            dtpToDate.Size = new System.Drawing.Size(145, 23);
            dtpToDate.TabIndex = 12;
            // 
            // lblDate
            // 
            lblDate.AutoSize = true;
            lblDate.Location = new System.Drawing.Point(0, 93);
            lblDate.Name = "lblDate";
            lblDate.Size = new System.Drawing.Size(102, 15);
            lblDate.TabIndex = 11;
            lblDate.Text = "Дата публикации";
            // 
            // dtpFromDeadline
            // 
            dtpFromDeadline.Location = new System.Drawing.Point(265, 32);
            dtpFromDeadline.Name = "dtpFromDeadline";
            dtpFromDeadline.Size = new System.Drawing.Size(145, 23);
            dtpFromDeadline.TabIndex = 10;
            // 
            // lblToDeadline
            // 
            lblToDeadline.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right;
            lblToDeadline.AutoSize = true;
            lblToDeadline.Location = new System.Drawing.Point(237, 64);
            lblToDeadline.Name = "lblToDeadline";
            lblToDeadline.Size = new System.Drawing.Size(22, 15);
            lblToDeadline.TabIndex = 9;
            lblToDeadline.Text = "До";
            // 
            // lblFromDeadline
            // 
            lblFromDeadline.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right;
            lblFromDeadline.AutoSize = true;
            lblFromDeadline.Location = new System.Drawing.Point(239, 35);
            lblFromDeadline.Name = "lblFromDeadline";
            lblFromDeadline.Size = new System.Drawing.Size(21, 15);
            lblFromDeadline.TabIndex = 8;
            lblFromDeadline.Text = "От";
            // 
            // dtpToDeadline
            // 
            dtpToDeadline.Location = new System.Drawing.Point(265, 61);
            dtpToDeadline.Name = "dtpToDeadline";
            dtpToDeadline.Size = new System.Drawing.Size(145, 23);
            dtpToDeadline.TabIndex = 7;
            // 
            // lblToBudget
            // 
            lblToBudget.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right;
            lblToBudget.AutoSize = true;
            lblToBudget.Location = new System.Drawing.Point(279, 6);
            lblToBudget.Name = "lblToBudget";
            lblToBudget.Size = new System.Drawing.Size(22, 15);
            lblToBudget.TabIndex = 6;
            lblToBudget.Text = "До";
            // 
            // lblFromBudget
            // 
            lblFromBudget.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right;
            lblFromBudget.AutoSize = true;
            lblFromBudget.Location = new System.Drawing.Point(138, 6);
            lblFromBudget.Name = "lblFromBudget";
            lblFromBudget.Size = new System.Drawing.Size(21, 15);
            lblFromBudget.TabIndex = 5;
            lblFromBudget.Text = "От";
            // 
            // txtToBudget
            // 
            txtToBudget.Location = new System.Drawing.Point(307, 0);
            txtToBudget.Name = "txtToBudget";
            txtToBudget.Size = new System.Drawing.Size(103, 23);
            txtToBudget.TabIndex = 4;
            // 
            // lblDeadline
            // 
            lblDeadline.AutoSize = true;
            lblDeadline.Location = new System.Drawing.Point(0, 35);
            lblDeadline.Name = "lblDeadline";
            lblDeadline.Size = new System.Drawing.Size(54, 15);
            lblDeadline.TabIndex = 3;
            lblDeadline.Text = "Дедлайн";
            // 
            // txtFromBudget
            // 
            txtFromBudget.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right;
            txtFromBudget.Location = new System.Drawing.Point(165, 0);
            txtFromBudget.Name = "txtFromBudget";
            txtFromBudget.Size = new System.Drawing.Size(103, 23);
            txtFromBudget.TabIndex = 1;
            // 
            // lblBudget
            // 
            lblBudget.AutoSize = true;
            lblBudget.Location = new System.Drawing.Point(0, 6);
            lblBudget.Name = "lblBudget";
            lblBudget.Size = new System.Drawing.Size(50, 15);
            lblBudget.TabIndex = 0;
            lblBudget.Text = "Бюджет";
            // 
            // dateTimePicker1
            // 
            dateTimePicker1.Location = new System.Drawing.Point(262, 6);
            dateTimePicker1.Name = "dateTimePicker1";
            dateTimePicker1.Size = new System.Drawing.Size(145, 23);
            dateTimePicker1.TabIndex = 19;
            // 
            // label1
            // 
            label1.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right;
            label1.AutoSize = true;
            label1.Location = new System.Drawing.Point(234, 38);
            label1.Name = "label1";
            label1.Size = new System.Drawing.Size(22, 15);
            label1.TabIndex = 18;
            label1.Text = "До";
            // 
            // label2
            // 
            label2.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right;
            label2.AutoSize = true;
            label2.Location = new System.Drawing.Point(236, 9);
            label2.Name = "label2";
            label2.Size = new System.Drawing.Size(21, 15);
            label2.TabIndex = 17;
            label2.Text = "От";
            // 
            // dateTimePicker2
            // 
            dateTimePicker2.Location = new System.Drawing.Point(262, 35);
            dateTimePicker2.Name = "dateTimePicker2";
            dateTimePicker2.Size = new System.Drawing.Size(145, 23);
            dateTimePicker2.TabIndex = 16;
            // 
            // FilterForm
            // 
            AcceptButton = btnAccept;
            AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            CancelButton = btnCancel;
            ClientSize = new System.Drawing.Size(434, 258);
            Controls.Add(pnlUsers);
            Controls.Add(pnlVacancies);
            Controls.Add(cmbTables);
            Controls.Add(lblTable);
            Controls.Add(btnCancel);
            Controls.Add(btnAccept);
            Name = "FilterForm";
            Text = "Фильтры";
            pnlUsers.ResumeLayout(false);
            pnlUsers.PerformLayout();
            pnlVacancies.ResumeLayout(false);
            pnlVacancies.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private System.Windows.Forms.Button btnAccept;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Label lblTable;
        private System.Windows.Forms.ComboBox cmbTables;
        private System.Windows.Forms.Panel pnlUsers;
        private System.Windows.Forms.Label lblRegDate;
        private System.Windows.Forms.Label lblRole;
        private System.Windows.Forms.TextBox txtRole;
        private System.Windows.Forms.Panel pnlVacancies;
        private System.Windows.Forms.Label lblDeadline;
        private System.Windows.Forms.TextBox txtFromBudget;
        private System.Windows.Forms.Label lblBudget;
        private System.Windows.Forms.Label lblToBudget;
        private System.Windows.Forms.Label lblFromBudget;
        private System.Windows.Forms.TextBox txtToBudget;
        private System.Windows.Forms.DateTimePicker dtpFromDeadline;
        private System.Windows.Forms.Label lblToDeadline;
        private System.Windows.Forms.Label lblFromDeadline;
        private System.Windows.Forms.DateTimePicker dtpToDeadline;
        private System.Windows.Forms.DateTimePicker dtpFromDate;
        private System.Windows.Forms.Label lblToDate;
        private System.Windows.Forms.Label lblFromDate;
        private System.Windows.Forms.DateTimePicker dtpToDate;
        private System.Windows.Forms.Label lblDate;
        private System.Windows.Forms.DateTimePicker dateTimePicker1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.DateTimePicker dateTimePicker2;
    }
}