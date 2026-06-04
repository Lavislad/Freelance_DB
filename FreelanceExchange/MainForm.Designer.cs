namespace FreelanceExchange
{
    partial class MainForm
    {
        private System.ComponentModel.IContainer components = null;

        private System.Windows.Forms.DataGridView dgvData;

        private System.Windows.Forms.ComboBox cmbTables;

        private System.Windows.Forms.Label lblRole;

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
            dgvData = new System.Windows.Forms.DataGridView();
            cmbTables = new System.Windows.Forms.ComboBox();
            lblRole = new System.Windows.Forms.Label();
            menuStrip1 = new System.Windows.Forms.MenuStrip();
            файлToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            сохранитьToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            редактироватьToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            создатьОтчетToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            выходToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            добавитьСтрокуToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            удалитьСтрокуToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            ((System.ComponentModel.ISupportInitialize)dgvData).BeginInit();
            menuStrip1.SuspendLayout();
            SuspendLayout();
            // 
            // dgvData
            // 
            dgvData.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.ColumnHeader;
            dgvData.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvData.Location = new System.Drawing.Point(23, 93);
            dgvData.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            dgvData.Name = "dgvData";
            dgvData.RowHeadersWidth = 51;
            dgvData.Size = new System.Drawing.Size(1086, 600);
            dgvData.TabIndex = 0;
            // 
            // cmbTables
            // 
            cmbTables.FormattingEnabled = true;
            cmbTables.Location = new System.Drawing.Point(301, 36);
            cmbTables.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            cmbTables.Name = "cmbTables";
            cmbTables.Size = new System.Drawing.Size(205, 28);
            cmbTables.TabIndex = 1;
            cmbTables.SelectedIndexChanged += cmbTables_SelectedIndexChanged;
            // 
            // lblRole
            // 
            lblRole.AutoSize = true;
            lblRole.Location = new System.Drawing.Point(23, 40);
            lblRole.Name = "lblRole";
            lblRole.Size = new System.Drawing.Size(42, 20);
            lblRole.TabIndex = 6;
            lblRole.Text = "Роль";
            // 
            // menuStrip1
            // 
            menuStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] { файлToolStripMenuItem, редактироватьToolStripMenuItem });
            menuStrip1.Location = new System.Drawing.Point(0, 0);
            menuStrip1.Name = "menuStrip1";
            menuStrip1.Size = new System.Drawing.Size(1143, 28);
            menuStrip1.TabIndex = 8;
            menuStrip1.Text = "menuStrip1";
            // 
            // файлToolStripMenuItem
            // 
            файлToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] { сохранитьToolStripMenuItem, создатьОтчетToolStripMenuItem, выходToolStripMenuItem });
            файлToolStripMenuItem.Name = "файлToolStripMenuItem";
            файлToolStripMenuItem.Size = new System.Drawing.Size(59, 24);
            файлToolStripMenuItem.Text = "Файл";
            // 
            // сохранитьToolStripMenuItem
            // 
            сохранитьToolStripMenuItem.Name = "сохранитьToolStripMenuItem";
            сохранитьToolStripMenuItem.Size = new System.Drawing.Size(224, 26);
            сохранитьToolStripMenuItem.Text = "Сохранить";
            сохранитьToolStripMenuItem.Click += btnSave_Click;
            // 
            // редактироватьToolStripMenuItem
            // 
            редактироватьToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] { добавитьСтрокуToolStripMenuItem, удалитьСтрокуToolStripMenuItem });
            редактироватьToolStripMenuItem.Name = "редактироватьToolStripMenuItem";
            редактироватьToolStripMenuItem.Size = new System.Drawing.Size(125, 24);
            редактироватьToolStripMenuItem.Text = "Редактировать";
            // 
            // создатьОтчетToolStripMenuItem
            // 
            создатьОтчетToolStripMenuItem.Name = "создатьОтчетToolStripMenuItem";
            создатьОтчетToolStripMenuItem.Size = new System.Drawing.Size(224, 26);
            создатьОтчетToolStripMenuItem.Text = "Создать отчет";
            // 
            // выходToolStripMenuItem
            // 
            выходToolStripMenuItem.Name = "выходToolStripMenuItem";
            выходToolStripMenuItem.Size = new System.Drawing.Size(224, 26);
            выходToolStripMenuItem.Text = "Выход";
            выходToolStripMenuItem.Click += btnLogout_Click;
            // 
            // добавитьСтрокуToolStripMenuItem
            // 
            добавитьСтрокуToolStripMenuItem.Name = "добавитьСтрокуToolStripMenuItem";
            добавитьСтрокуToolStripMenuItem.Size = new System.Drawing.Size(224, 26);
            добавитьСтрокуToolStripMenuItem.Text = "Добавить строку";
            добавитьСтрокуToolStripMenuItem.Click += btnAdd_Click;
            // 
            // удалитьСтрокуToolStripMenuItem
            // 
            удалитьСтрокуToolStripMenuItem.Name = "удалитьСтрокуToolStripMenuItem";
            удалитьСтрокуToolStripMenuItem.Size = new System.Drawing.Size(224, 26);
            удалитьСтрокуToolStripMenuItem.Text = "Удалить строку";
            удалитьСтрокуToolStripMenuItem.Click += btnDelete_Click;
            // 
            // MainForm
            // 
            AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            ClientSize = new System.Drawing.Size(1143, 733);
            Controls.Add(lblRole);
            Controls.Add(cmbTables);
            Controls.Add(dgvData);
            Controls.Add(menuStrip1);
            MainMenuStrip = menuStrip1;
            Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            Name = "MainForm";
            Text = "Информационная система";
            ((System.ComponentModel.ISupportInitialize)dgvData).EndInit();
            menuStrip1.ResumeLayout(false);
            menuStrip1.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem файлToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem сохранитьToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem редактироватьToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem создатьОтчетToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem выходToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem добавитьСтрокуToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem удалитьСтрокуToolStripMenuItem;
    }
}