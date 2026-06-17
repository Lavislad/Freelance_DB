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
            создатьОтчетToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            выходToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            редактироватьToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            добавитьСтрокуToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            удалитьСтрокуToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            обновитьToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            пользовательToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            btnFilter = new System.Windows.Forms.Button();
            btnClearFilters = new System.Windows.Forms.Button();
            txtSearch = new System.Windows.Forms.TextBox();
            lblSearch = new System.Windows.Forms.Label();
            pDFToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            dOCXToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            xLSXToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            ((System.ComponentModel.ISupportInitialize)dgvData).BeginInit();
            menuStrip1.SuspendLayout();
            SuspendLayout();
            // 
            // dgvData
            // 
            dgvData.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
            dgvData.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.ColumnHeader;
            dgvData.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvData.Location = new System.Drawing.Point(20, 70);
            dgvData.Name = "dgvData";
            dgvData.RowHeadersWidth = 51;
            dgvData.Size = new System.Drawing.Size(950, 450);
            dgvData.TabIndex = 0;
            // 
            // cmbTables
            // 
            cmbTables.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right;
            cmbTables.FormattingEnabled = true;
            cmbTables.Location = new System.Drawing.Point(792, 30);
            cmbTables.Name = "cmbTables";
            cmbTables.Size = new System.Drawing.Size(180, 23);
            cmbTables.TabIndex = 1;
            cmbTables.SelectedIndexChanged += cmbTables_SelectedIndexChanged;
            // 
            // lblRole
            // 
            lblRole.AutoSize = true;
            lblRole.Location = new System.Drawing.Point(20, 30);
            lblRole.Name = "lblRole";
            lblRole.Size = new System.Drawing.Size(34, 15);
            lblRole.TabIndex = 6;
            lblRole.Text = "Роль";
            // 
            // menuStrip1
            // 
            menuStrip1.BackColor = System.Drawing.Color.Transparent;
            menuStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] { файлToolStripMenuItem, редактироватьToolStripMenuItem });
            menuStrip1.Location = new System.Drawing.Point(0, 0);
            menuStrip1.Name = "menuStrip1";
            menuStrip1.Padding = new System.Windows.Forms.Padding(5, 2, 0, 2);
            menuStrip1.Size = new System.Drawing.Size(1000, 24);
            menuStrip1.TabIndex = 8;
            menuStrip1.Text = "menuStrip1";
            // 
            // файлToolStripMenuItem
            // 
            файлToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] { сохранитьToolStripMenuItem, создатьОтчетToolStripMenuItem, выходToolStripMenuItem });
            файлToolStripMenuItem.Name = "файлToolStripMenuItem";
            файлToolStripMenuItem.Size = new System.Drawing.Size(48, 20);
            файлToolStripMenuItem.Text = "Файл";
            // 
            // сохранитьToolStripMenuItem
            // 
            сохранитьToolStripMenuItem.Name = "сохранитьToolStripMenuItem";
            сохранитьToolStripMenuItem.ShortcutKeys = System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.S;
            сохранитьToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            сохранитьToolStripMenuItem.Text = "Сохранить";
            сохранитьToolStripMenuItem.Click += btnSave_Click;
            // 
            // создатьОтчетToolStripMenuItem
            // 
            создатьОтчетToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] { pDFToolStripMenuItem, dOCXToolStripMenuItem, xLSXToolStripMenuItem });
            создатьОтчетToolStripMenuItem.Name = "создатьОтчетToolStripMenuItem";
            создатьОтчетToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            создатьОтчетToolStripMenuItem.Text = "Экспортировать в";
            // 
            // выходToolStripMenuItem
            // 
            выходToolStripMenuItem.Name = "выходToolStripMenuItem";
            выходToolStripMenuItem.ShortcutKeys = System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.Q;
            выходToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            выходToolStripMenuItem.Text = "Выход";
            выходToolStripMenuItem.Click += btnLogout_Click;
            // 
            // редактироватьToolStripMenuItem
            // 
            редактироватьToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] { добавитьСтрокуToolStripMenuItem, удалитьСтрокуToolStripMenuItem, обновитьToolStripMenuItem, пользовательToolStripMenuItem });
            редактироватьToolStripMenuItem.Name = "редактироватьToolStripMenuItem";
            редактироватьToolStripMenuItem.Size = new System.Drawing.Size(99, 20);
            редактироватьToolStripMenuItem.Text = "Редактировать";
            // 
            // добавитьСтрокуToolStripMenuItem
            // 
            добавитьСтрокуToolStripMenuItem.Name = "добавитьСтрокуToolStripMenuItem";
            добавитьСтрокуToolStripMenuItem.ShortcutKeys = System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.A;
            добавитьСтрокуToolStripMenuItem.Size = new System.Drawing.Size(208, 22);
            добавитьСтрокуToolStripMenuItem.Text = "Добавить строку";
            добавитьСтрокуToolStripMenuItem.Click += btnAdd_Click;
            // 
            // удалитьСтрокуToolStripMenuItem
            // 
            удалитьСтрокуToolStripMenuItem.Name = "удалитьСтрокуToolStripMenuItem";
            удалитьСтрокуToolStripMenuItem.ShortcutKeys = System.Windows.Forms.Keys.Delete;
            удалитьСтрокуToolStripMenuItem.Size = new System.Drawing.Size(208, 22);
            удалитьСтрокуToolStripMenuItem.Text = "Удалить строку";
            удалитьСтрокуToolStripMenuItem.Click += btnDelete_Click;
            // 
            // обновитьToolStripMenuItem
            // 
            обновитьToolStripMenuItem.Name = "обновитьToolStripMenuItem";
            обновитьToolStripMenuItem.ShortcutKeys = System.Windows.Forms.Keys.F5;
            обновитьToolStripMenuItem.Size = new System.Drawing.Size(208, 22);
            обновитьToolStripMenuItem.Text = "Обновить";
            обновитьToolStripMenuItem.Click += обновитьToolStripMenuItem_Click;
            // 
            // пользовательToolStripMenuItem
            // 
            пользовательToolStripMenuItem.Name = "пользовательToolStripMenuItem";
            пользовательToolStripMenuItem.Size = new System.Drawing.Size(208, 22);
            пользовательToolStripMenuItem.Text = "Пользователь...";
            пользовательToolStripMenuItem.Click += пользовательToolStripMenuItem_Click;
            // 
            // btnFilter
            // 
            btnFilter.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right;
            btnFilter.Location = new System.Drawing.Point(704, 30);
            btnFilter.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            btnFilter.Name = "btnFilter";
            btnFilter.Size = new System.Drawing.Size(82, 24);
            btnFilter.TabIndex = 9;
            btnFilter.Text = "Фильтр";
            btnFilter.UseVisualStyleBackColor = true;
            btnFilter.Click += btnFilter_Click;
            // 
            // btnClearFilters
            // 
            btnClearFilters.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right;
            btnClearFilters.Location = new System.Drawing.Point(576, 30);
            btnClearFilters.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            btnClearFilters.Name = "btnClearFilters";
            btnClearFilters.Size = new System.Drawing.Size(122, 24);
            btnClearFilters.TabIndex = 10;
            btnClearFilters.Text = "Очистить фильтры";
            btnClearFilters.UseVisualStyleBackColor = true;
            btnClearFilters.Click += btnClearFilters_Click;
            // 
            // txtSearch
            // 
            txtSearch.Location = new System.Drawing.Point(295, 30);
            txtSearch.Name = "txtSearch";
            txtSearch.Size = new System.Drawing.Size(275, 23);
            txtSearch.TabIndex = 11;
            txtSearch.TextChanged += txtSearch_TextChanged;
            // 
            // lblSearch
            // 
            lblSearch.AutoSize = true;
            lblSearch.Location = new System.Drawing.Point(184, 33);
            lblSearch.Name = "lblSearch";
            lblSearch.Size = new System.Drawing.Size(105, 15);
            lblSearch.TabIndex = 12;
            lblSearch.Text = "Поиск в vacancies";
            // 
            // pDFToolStripMenuItem
            // 
            pDFToolStripMenuItem.Name = "pDFToolStripMenuItem";
            pDFToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            pDFToolStripMenuItem.Text = "PDF";
            // 
            // dOCXToolStripMenuItem
            // 
            dOCXToolStripMenuItem.Name = "dOCXToolStripMenuItem";
            dOCXToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            dOCXToolStripMenuItem.Text = "DOCX";
            // 
            // xLSXToolStripMenuItem
            // 
            xLSXToolStripMenuItem.Name = "xLSXToolStripMenuItem";
            xLSXToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            xLSXToolStripMenuItem.Text = "XLSX";
            // 
            // MainForm
            // 
            AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            ClientSize = new System.Drawing.Size(1000, 550);
            Controls.Add(lblSearch);
            Controls.Add(txtSearch);
            Controls.Add(btnClearFilters);
            Controls.Add(btnFilter);
            Controls.Add(lblRole);
            Controls.Add(cmbTables);
            Controls.Add(dgvData);
            Controls.Add(menuStrip1);
            MainMenuStrip = menuStrip1;
            MinimumSize = new System.Drawing.Size(527, 235);
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
        private System.Windows.Forms.ToolStripMenuItem обновитьToolStripMenuItem;
        private System.Windows.Forms.Button btnFilter;
        private System.Windows.Forms.Button btnClearFilters;
        private System.Windows.Forms.TextBox txtSearch;
        private System.Windows.Forms.Label lblSearch;
        private System.Windows.Forms.ToolStripMenuItem пользовательToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem pDFToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem dOCXToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem xLSXToolStripMenuItem;
    }
}