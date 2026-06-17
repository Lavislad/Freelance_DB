namespace FreelanceExchange
{
    partial class ExportForm
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
            cmbReportType = new System.Windows.Forms.ComboBox();
            lblReportType = new System.Windows.Forms.Label();
            pnlVacancies = new System.Windows.Forms.Panel();
            textBox2 = new System.Windows.Forms.TextBox();
            lblBudgetVacancies = new System.Windows.Forms.Label();
            textBox1 = new System.Windows.Forms.TextBox();
            dtpDateToVacancies = new System.Windows.Forms.DateTimePicker();
            lblDatePeriod = new System.Windows.Forms.Label();
            dtpDateFromVacancies = new System.Windows.Forms.DateTimePicker();
            cmbReports = new System.Windows.Forms.ComboBox();
            btnGenerate = new System.Windows.Forms.Button();
            pnlTags = new System.Windows.Forms.Panel();
            listTags = new System.Windows.Forms.ListBox();
            lblTags = new System.Windows.Forms.Label();
            dtpDateToTags = new System.Windows.Forms.DateTimePicker();
            lblPeriod = new System.Windows.Forms.Label();
            dtpDateFromTags = new System.Windows.Forms.DateTimePicker();
            pnlResponses = new System.Windows.Forms.Panel();
            textBox3 = new System.Windows.Forms.TextBox();
            lblAuthor = new System.Windows.Forms.Label();
            dtpDateToResponses = new System.Windows.Forms.DateTimePicker();
            lblPeriodResponses = new System.Windows.Forms.Label();
            dtpDateFromResponses = new System.Windows.Forms.DateTimePicker();
            btnCancel = new System.Windows.Forms.Button();
            pnlVacancies.SuspendLayout();
            pnlTags.SuspendLayout();
            pnlResponses.SuspendLayout();
            SuspendLayout();
            // 
            // cmbReportType
            // 
            cmbReportType.FormattingEnabled = true;
            cmbReportType.Items.AddRange(new object[] { "Вакансии за период", "Статистика по тегам", "Отклики на вакансии" });
            cmbReportType.Location = new System.Drawing.Point(12, 27);
            cmbReportType.Name = "cmbReportType";
            cmbReportType.Size = new System.Drawing.Size(312, 23);
            cmbReportType.TabIndex = 0;
            // 
            // lblReportType
            // 
            lblReportType.AutoSize = true;
            lblReportType.Location = new System.Drawing.Point(12, 9);
            lblReportType.Name = "lblReportType";
            lblReportType.Size = new System.Drawing.Size(67, 15);
            lblReportType.TabIndex = 1;
            lblReportType.Text = "Тип отчета";
            // 
            // pnlVacancies
            // 
            pnlVacancies.Controls.Add(textBox2);
            pnlVacancies.Controls.Add(lblBudgetVacancies);
            pnlVacancies.Controls.Add(textBox1);
            pnlVacancies.Controls.Add(dtpDateToVacancies);
            pnlVacancies.Controls.Add(lblDatePeriod);
            pnlVacancies.Controls.Add(dtpDateFromVacancies);
            pnlVacancies.Location = new System.Drawing.Point(12, 56);
            pnlVacancies.Name = "pnlVacancies";
            pnlVacancies.Size = new System.Drawing.Size(307, 209);
            pnlVacancies.TabIndex = 2;
            pnlVacancies.Visible = false;
            // 
            // textBox2
            // 
            textBox2.Location = new System.Drawing.Point(114, 77);
            textBox2.Name = "textBox2";
            textBox2.PlaceholderText = "До";
            textBox2.Size = new System.Drawing.Size(92, 23);
            textBox2.TabIndex = 8;
            // 
            // lblBudgetVacancies
            // 
            lblBudgetVacancies.AutoSize = true;
            lblBudgetVacancies.Location = new System.Drawing.Point(3, 55);
            lblBudgetVacancies.Name = "lblBudgetVacancies";
            lblBudgetVacancies.Size = new System.Drawing.Size(50, 15);
            lblBudgetVacancies.TabIndex = 7;
            lblBudgetVacancies.Text = "Бюджет";
            // 
            // textBox1
            // 
            textBox1.Location = new System.Drawing.Point(3, 77);
            textBox1.Name = "textBox1";
            textBox1.PlaceholderText = "От";
            textBox1.Size = new System.Drawing.Size(92, 23);
            textBox1.TabIndex = 6;
            // 
            // dtpDateToVacancies
            // 
            dtpDateToVacancies.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            dtpDateToVacancies.Location = new System.Drawing.Point(114, 18);
            dtpDateToVacancies.Name = "dtpDateToVacancies";
            dtpDateToVacancies.Size = new System.Drawing.Size(92, 23);
            dtpDateToVacancies.TabIndex = 5;
            // 
            // lblDatePeriod
            // 
            lblDatePeriod.AutoSize = true;
            lblDatePeriod.Location = new System.Drawing.Point(3, 0);
            lblDatePeriod.Name = "lblDatePeriod";
            lblDatePeriod.Size = new System.Drawing.Size(49, 15);
            lblDatePeriod.TabIndex = 4;
            lblDatePeriod.Text = "Период";
            // 
            // dtpDateFromVacancies
            // 
            dtpDateFromVacancies.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            dtpDateFromVacancies.Location = new System.Drawing.Point(3, 18);
            dtpDateFromVacancies.Name = "dtpDateFromVacancies";
            dtpDateFromVacancies.Size = new System.Drawing.Size(92, 23);
            dtpDateFromVacancies.TabIndex = 0;
            // 
            // cmbReports
            // 
            cmbReports.FormattingEnabled = true;
            cmbReports.Items.AddRange(new object[] { "PDF", "DOCX", "XLSX" });
            cmbReports.Location = new System.Drawing.Point(12, 274);
            cmbReports.Name = "cmbReports";
            cmbReports.Size = new System.Drawing.Size(95, 23);
            cmbReports.TabIndex = 3;
            // 
            // btnGenerate
            // 
            btnGenerate.Location = new System.Drawing.Point(203, 336);
            btnGenerate.Name = "btnGenerate";
            btnGenerate.Size = new System.Drawing.Size(121, 23);
            btnGenerate.TabIndex = 4;
            btnGenerate.Text = "Сформировать";
            btnGenerate.UseVisualStyleBackColor = true;
            // 
            // pnlTags
            // 
            pnlTags.Controls.Add(listTags);
            pnlTags.Controls.Add(lblTags);
            pnlTags.Controls.Add(dtpDateToTags);
            pnlTags.Controls.Add(lblPeriod);
            pnlTags.Controls.Add(dtpDateFromTags);
            pnlTags.Location = new System.Drawing.Point(12, 56);
            pnlTags.Name = "pnlTags";
            pnlTags.Size = new System.Drawing.Size(307, 209);
            pnlTags.TabIndex = 9;
            pnlTags.Visible = false;
            // 
            // listTags
            // 
            listTags.FormattingEnabled = true;
            listTags.ItemHeight = 15;
            listTags.Location = new System.Drawing.Point(3, 73);
            listTags.Name = "listTags";
            listTags.SelectionMode = System.Windows.Forms.SelectionMode.MultiSimple;
            listTags.Size = new System.Drawing.Size(301, 139);
            listTags.TabIndex = 10;
            // 
            // lblTags
            // 
            lblTags.AutoSize = true;
            lblTags.Location = new System.Drawing.Point(3, 55);
            lblTags.Name = "lblTags";
            lblTags.Size = new System.Drawing.Size(25, 15);
            lblTags.TabIndex = 7;
            lblTags.Text = "Тег";
            // 
            // dtpDateToTags
            // 
            dtpDateToTags.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            dtpDateToTags.Location = new System.Drawing.Point(114, 18);
            dtpDateToTags.Name = "dtpDateToTags";
            dtpDateToTags.Size = new System.Drawing.Size(92, 23);
            dtpDateToTags.TabIndex = 5;
            // 
            // lblPeriod
            // 
            lblPeriod.AutoSize = true;
            lblPeriod.Location = new System.Drawing.Point(3, 0);
            lblPeriod.Name = "lblPeriod";
            lblPeriod.Size = new System.Drawing.Size(49, 15);
            lblPeriod.TabIndex = 4;
            lblPeriod.Text = "Период";
            // 
            // dtpDateFromTags
            // 
            dtpDateFromTags.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            dtpDateFromTags.Location = new System.Drawing.Point(3, 18);
            dtpDateFromTags.Name = "dtpDateFromTags";
            dtpDateFromTags.Size = new System.Drawing.Size(92, 23);
            dtpDateFromTags.TabIndex = 0;
            // 
            // pnlResponses
            // 
            pnlResponses.Controls.Add(textBox3);
            pnlResponses.Controls.Add(lblAuthor);
            pnlResponses.Controls.Add(dtpDateToResponses);
            pnlResponses.Controls.Add(lblPeriodResponses);
            pnlResponses.Controls.Add(dtpDateFromResponses);
            pnlResponses.Location = new System.Drawing.Point(12, 56);
            pnlResponses.Name = "pnlResponses";
            pnlResponses.Size = new System.Drawing.Size(307, 209);
            pnlResponses.TabIndex = 11;
            pnlResponses.Visible = false;
            // 
            // textBox3
            // 
            textBox3.Location = new System.Drawing.Point(3, 73);
            textBox3.Name = "textBox3";
            textBox3.Size = new System.Drawing.Size(100, 23);
            textBox3.TabIndex = 8;
            // 
            // lblAuthor
            // 
            lblAuthor.AutoSize = true;
            lblAuthor.Location = new System.Drawing.Point(3, 55);
            lblAuthor.Name = "lblAuthor";
            lblAuthor.Size = new System.Drawing.Size(112, 15);
            lblAuthor.TabIndex = 7;
            lblAuthor.Text = "ID автора вакансии";
            // 
            // dtpDateToResponses
            // 
            dtpDateToResponses.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            dtpDateToResponses.Location = new System.Drawing.Point(114, 18);
            dtpDateToResponses.Name = "dtpDateToResponses";
            dtpDateToResponses.Size = new System.Drawing.Size(92, 23);
            dtpDateToResponses.TabIndex = 5;
            // 
            // lblPeriodResponses
            // 
            lblPeriodResponses.AutoSize = true;
            lblPeriodResponses.Location = new System.Drawing.Point(3, 0);
            lblPeriodResponses.Name = "lblPeriodResponses";
            lblPeriodResponses.Size = new System.Drawing.Size(49, 15);
            lblPeriodResponses.TabIndex = 4;
            lblPeriodResponses.Text = "Период";
            // 
            // dtpDateFromResponses
            // 
            dtpDateFromResponses.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            dtpDateFromResponses.Location = new System.Drawing.Point(3, 18);
            dtpDateFromResponses.Name = "dtpDateFromResponses";
            dtpDateFromResponses.Size = new System.Drawing.Size(92, 23);
            dtpDateFromResponses.TabIndex = 0;
            // 
            // btnCancel
            // 
            btnCancel.Location = new System.Drawing.Point(12, 336);
            btnCancel.Name = "btnCancel";
            btnCancel.Size = new System.Drawing.Size(121, 23);
            btnCancel.TabIndex = 12;
            btnCancel.Text = "Отмена";
            btnCancel.UseVisualStyleBackColor = true;
            // 
            // ExportForm
            // 
            AcceptButton = btnGenerate;
            AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            CancelButton = btnCancel;
            ClientSize = new System.Drawing.Size(336, 371);
            Controls.Add(btnCancel);
            Controls.Add(pnlTags);
            Controls.Add(pnlResponses);
            Controls.Add(pnlVacancies);
            Controls.Add(btnGenerate);
            Controls.Add(cmbReports);
            Controls.Add(lblReportType);
            Controls.Add(cmbReportType);
            Name = "ExportForm";
            Text = "ExportForm";
            pnlVacancies.ResumeLayout(false);
            pnlVacancies.PerformLayout();
            pnlTags.ResumeLayout(false);
            pnlTags.PerformLayout();
            pnlResponses.ResumeLayout(false);
            pnlResponses.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private System.Windows.Forms.ComboBox cmbReportType;
        private System.Windows.Forms.Label lblReportType;
        private System.Windows.Forms.Panel pnlVacancies;
        private System.Windows.Forms.Label lblDatePeriod;
        private System.Windows.Forms.DateTimePicker dtpDateFromVacancies;
        private System.Windows.Forms.ComboBox cmbReports;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.DateTimePicker dtpDateToVacancies;
        private System.Windows.Forms.TextBox textBox2;
        private System.Windows.Forms.Label lblBudgetVacancies;
        private System.Windows.Forms.Button btnGenerate;
        private System.Windows.Forms.Panel pnlTags;
        private System.Windows.Forms.Label lblTags;
        private System.Windows.Forms.DateTimePicker dtpDateToTags;
        private System.Windows.Forms.Label lblPeriod;
        private System.Windows.Forms.DateTimePicker dtpDateFromTags;
        private System.Windows.Forms.ListBox listTags;
        private System.Windows.Forms.Panel pnlResponses;
        private System.Windows.Forms.ListBox listBox1;
        private System.Windows.Forms.Label lblAuthor;
        private System.Windows.Forms.DateTimePicker dtpDateToResponses;
        private System.Windows.Forms.Label lblPeriodResponses;
        private System.Windows.Forms.DateTimePicker dtpDateFromResponses;
        private System.Windows.Forms.TextBox textBox3;
        private System.Windows.Forms.Button btnCancel;
    }
}