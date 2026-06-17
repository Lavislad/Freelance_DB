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
            textBox1 = new System.Windows.Forms.TextBox();
            dtpDateToVacancies = new System.Windows.Forms.DateTimePicker();
            lblDatePeriod = new System.Windows.Forms.Label();
            dtpDateFromVacancies = new System.Windows.Forms.DateTimePicker();
            comboBox1 = new System.Windows.Forms.ComboBox();
            lblBudgetVacancies = new System.Windows.Forms.Label();
            textBox2 = new System.Windows.Forms.TextBox();
            btnGenerate = new System.Windows.Forms.Button();
            pnlVacancies.SuspendLayout();
            SuspendLayout();
            // 
            // cmbReportType
            // 
            cmbReportType.FormattingEnabled = true;
            cmbReportType.Location = new System.Drawing.Point(12, 27);
            cmbReportType.Name = "cmbReportType";
            cmbReportType.Size = new System.Drawing.Size(121, 23);
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
            // comboBox1
            // 
            comboBox1.FormattingEnabled = true;
            comboBox1.Items.AddRange(new object[] { "PDF", "DOCX", "XLSX" });
            comboBox1.Location = new System.Drawing.Point(12, 271);
            comboBox1.Name = "comboBox1";
            comboBox1.Size = new System.Drawing.Size(121, 23);
            comboBox1.TabIndex = 3;
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
            // textBox2
            // 
            textBox2.Location = new System.Drawing.Point(114, 77);
            textBox2.Name = "textBox2";
            textBox2.PlaceholderText = "До";
            textBox2.Size = new System.Drawing.Size(92, 23);
            textBox2.TabIndex = 8;
            // 
            // btnGenerate
            // 
            btnGenerate.Location = new System.Drawing.Point(12, 300);
            btnGenerate.Name = "btnGenerate";
            btnGenerate.Size = new System.Drawing.Size(121, 23);
            btnGenerate.TabIndex = 4;
            btnGenerate.Text = "Сформировать";
            btnGenerate.UseVisualStyleBackColor = true;
            // 
            // ExportForm
            // 
            AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            ClientSize = new System.Drawing.Size(800, 450);
            Controls.Add(btnGenerate);
            Controls.Add(comboBox1);
            Controls.Add(pnlVacancies);
            Controls.Add(lblReportType);
            Controls.Add(cmbReportType);
            Name = "ExportForm";
            Text = "ExportForm";
            pnlVacancies.ResumeLayout(false);
            pnlVacancies.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private System.Windows.Forms.ComboBox cmbReportType;
        private System.Windows.Forms.Label lblReportType;
        private System.Windows.Forms.Panel pnlVacancies;
        private System.Windows.Forms.Label lblDatePeriod;
        private System.Windows.Forms.DateTimePicker dtpDateFromVacancies;
        private System.Windows.Forms.ComboBox comboBox1;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.DateTimePicker dtpDateToVacancies;
        private System.Windows.Forms.TextBox textBox2;
        private System.Windows.Forms.Label lblBudgetVacancies;
        private System.Windows.Forms.Button btnGenerate;
    }
}