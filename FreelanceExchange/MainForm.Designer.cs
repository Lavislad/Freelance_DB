namespace FreelanceExchange
{
    partial class MainForm
    {
        private System.ComponentModel.IContainer components = null;

        private System.Windows.Forms.DataGridView dgvData;

        private System.Windows.Forms.ComboBox cmbTables;
        private System.Windows.Forms.Button btnAdd;
        private System.Windows.Forms.Button btnDelete;
        private System.Windows.Forms.Button btnSave;

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
            btnAdd = new System.Windows.Forms.Button();
            btnDelete = new System.Windows.Forms.Button();
            btnSave = new System.Windows.Forms.Button();
            lblRole = new System.Windows.Forms.Label();
            btnLogout = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)dgvData).BeginInit();
            SuspendLayout();
            // 
            // dgvData
            // 
            dgvData.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvData.Location = new System.Drawing.Point(20, 70);
            dgvData.Name = "dgvData";
            dgvData.Size = new System.Drawing.Size(950, 450);
            dgvData.TabIndex = 0;
            // 
            // cmbTables
            // 
            cmbTables.FormattingEnabled = true;
            cmbTables.Location = new System.Drawing.Point(263, 27);
            cmbTables.Name = "cmbTables";
            cmbTables.Size = new System.Drawing.Size(180, 23);
            cmbTables.TabIndex = 1;
            cmbTables.SelectedIndexChanged += cmbTables_SelectedIndexChanged;
            // 
            // btnAdd
            // 
            btnAdd.Location = new System.Drawing.Point(449, 20);
            btnAdd.Name = "btnAdd";
            btnAdd.Size = new System.Drawing.Size(120, 35);
            btnAdd.TabIndex = 3;
            btnAdd.Text = "Добавить";
            btnAdd.UseVisualStyleBackColor = true;
            btnAdd.Click += btnAdd_Click;
            // 
            // btnDelete
            // 
            btnDelete.Location = new System.Drawing.Point(575, 20);
            btnDelete.Name = "btnDelete";
            btnDelete.Size = new System.Drawing.Size(120, 35);
            btnDelete.TabIndex = 4;
            btnDelete.Text = "Удалить";
            btnDelete.UseVisualStyleBackColor = true;
            btnDelete.Click += btnDelete_Click;
            // 
            // btnSave
            // 
            btnSave.Location = new System.Drawing.Point(701, 20);
            btnSave.Name = "btnSave";
            btnSave.Size = new System.Drawing.Size(140, 35);
            btnSave.TabIndex = 5;
            btnSave.Text = "Сохранить";
            btnSave.UseVisualStyleBackColor = true;
            btnSave.Click += btnSave_Click;
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
            // btnLogout
            // 
            btnLogout.Location = new System.Drawing.Point(847, 20);
            btnLogout.Name = "btnLogout";
            btnLogout.Size = new System.Drawing.Size(123, 35);
            btnLogout.TabIndex = 7;
            btnLogout.Text = "Выход";
            btnLogout.UseVisualStyleBackColor = true;
            // 
            // MainForm
            // 
            AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            ClientSize = new System.Drawing.Size(1000, 550);
            Controls.Add(btnLogout);
            Controls.Add(lblRole);
            Controls.Add(btnSave);
            Controls.Add(btnDelete);
            Controls.Add(btnAdd);
            Controls.Add(cmbTables);
            Controls.Add(dgvData);
            Name = "MainForm";
            Text = "Информационная система";
            ((System.ComponentModel.ISupportInitialize)dgvData).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }
        private System.Windows.Forms.Button btnLogout;
    }
}