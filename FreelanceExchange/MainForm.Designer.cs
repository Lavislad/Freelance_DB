namespace FreelanceExchange
{
    partial class MainForm
    {
        private System.ComponentModel.IContainer components = null;

        private System.Windows.Forms.DataGridView dgvVacancies;

        private System.Windows.Forms.Button btnLoad;
        private System.Windows.Forms.Button btnAdd;
        private System.Windows.Forms.Button btnDelete;

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
            dgvVacancies = new System.Windows.Forms.DataGridView();
            btnLoad = new System.Windows.Forms.Button();
            btnAdd = new System.Windows.Forms.Button();
            btnDelete = new System.Windows.Forms.Button();
            lblRole = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)dgvVacancies).BeginInit();
            SuspendLayout();
            // 
            // dgvVacancies
            // 
            dgvVacancies.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvVacancies.Location = new System.Drawing.Point(20, 60);
            dgvVacancies.Name = "dgvVacancies";
            dgvVacancies.Size = new System.Drawing.Size(740, 320);
            dgvVacancies.TabIndex = 0;
            // 
            // btnLoad
            // 
            btnLoad.Location = new System.Drawing.Point(20, 400);
            btnLoad.Name = "btnLoad";
            btnLoad.Size = new System.Drawing.Size(120, 40);
            btnLoad.TabIndex = 1;
            btnLoad.Text = "Загрузить";
            btnLoad.UseVisualStyleBackColor = true;
            btnLoad.Click += btnLoad_Click;
            // 
            // btnAdd
            // 
            btnAdd.Location = new System.Drawing.Point(170, 400);
            btnAdd.Name = "btnAdd";
            btnAdd.Size = new System.Drawing.Size(120, 40);
            btnAdd.TabIndex = 2;
            btnAdd.Text = "Добавить";
            btnAdd.UseVisualStyleBackColor = true;
            btnAdd.Click += btnAdd_Click;
            // 
            // btnDelete
            // 
            btnDelete.Location = new System.Drawing.Point(320, 400);
            btnDelete.Name = "btnDelete";
            btnDelete.Size = new System.Drawing.Size(120, 40);
            btnDelete.TabIndex = 3;
            btnDelete.Text = "Удалить";
            btnDelete.UseVisualStyleBackColor = true;
            btnDelete.Click += btnDelete_Click;
            // 
            // lblRole
            // 
            lblRole.AutoSize = true;
            lblRole.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            lblRole.Location = new System.Drawing.Point(20, 20);
            lblRole.Name = "lblRole";
            lblRole.Size = new System.Drawing.Size(47, 19);
            lblRole.TabIndex = 4;
            lblRole.Text = "Роль:";
            // 
            // MainForm
            // 
            AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            ClientSize = new System.Drawing.Size(880, 453);
            Controls.Add(lblRole);
            Controls.Add(btnDelete);
            Controls.Add(btnAdd);
            Controls.Add(btnLoad);
            Controls.Add(dgvVacancies);
            Name = "MainForm";
            Text = "Главная форма";
            ((System.ComponentModel.ISupportInitialize)dgvVacancies).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }
    }
}