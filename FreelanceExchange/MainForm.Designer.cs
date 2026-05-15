namespace FreelanceExchange
{
    partial class MainForm
    {
        private System.ComponentModel.IContainer components = null;

        private System.Windows.Forms.DataGridView dgvData;

        private System.Windows.Forms.ComboBox cmbTables;

        private System.Windows.Forms.Button btnLoad;
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
            this.dgvData =
                new System.Windows.Forms.DataGridView();

            this.cmbTables =
                new System.Windows.Forms.ComboBox();

            this.btnLoad =
                new System.Windows.Forms.Button();

            this.btnAdd =
                new System.Windows.Forms.Button();

            this.btnDelete =
                new System.Windows.Forms.Button();

            this.btnSave =
                new System.Windows.Forms.Button();

            this.lblRole =
                new System.Windows.Forms.Label();

            ((System.ComponentModel.ISupportInitialize)
                (this.dgvData)).BeginInit();

            this.SuspendLayout();

            // dgvData
            this.dgvData.ColumnHeadersHeightSizeMode =
                System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;

            this.dgvData.Location =
                new System.Drawing.Point(20, 70);

            this.dgvData.Name =
                "dgvData";

            this.dgvData.Size =
                new System.Drawing.Size(950, 450);

            this.dgvData.TabIndex = 0;

            // cmbTables
            this.cmbTables.FormattingEnabled = true;

            this.cmbTables.Location =
                new System.Drawing.Point(20, 25);

            this.cmbTables.Name =
                "cmbTables";

            this.cmbTables.Size =
                new System.Drawing.Size(180, 23);

            this.cmbTables.TabIndex = 1;

            // btnLoad
            this.btnLoad.Location =
                new System.Drawing.Point(220, 20);

            this.btnLoad.Name =
                "btnLoad";

            this.btnLoad.Size =
                new System.Drawing.Size(120, 35);

            this.btnLoad.TabIndex = 2;

            this.btnLoad.Text =
                "Загрузить";

            this.btnLoad.UseVisualStyleBackColor = true;

            this.btnLoad.Click +=
                new System.EventHandler(this.btnLoad_Click);

            // btnAdd
            this.btnAdd.Location =
                new System.Drawing.Point(360, 20);

            this.btnAdd.Name =
                "btnAdd";

            this.btnAdd.Size =
                new System.Drawing.Size(120, 35);

            this.btnAdd.TabIndex = 3;

            this.btnAdd.Text =
                "Добавить";

            this.btnAdd.UseVisualStyleBackColor = true;

            this.btnAdd.Click +=
                new System.EventHandler(this.btnAdd_Click);

            // btnDelete
            this.btnDelete.Location =
                new System.Drawing.Point(500, 20);

            this.btnDelete.Name =
                "btnDelete";

            this.btnDelete.Size =
                new System.Drawing.Size(120, 35);

            this.btnDelete.TabIndex = 4;

            this.btnDelete.Text =
                "Удалить";

            this.btnDelete.UseVisualStyleBackColor = true;

            this.btnDelete.Click +=
                new System.EventHandler(this.btnDelete_Click);

            // btnSave
            this.btnSave.Location =
                new System.Drawing.Point(640, 20);

            this.btnSave.Name =
                "btnSave";

            this.btnSave.Size =
                new System.Drawing.Size(140, 35);

            this.btnSave.TabIndex = 5;

            this.btnSave.Text =
                "Сохранить";

            this.btnSave.UseVisualStyleBackColor = true;

            this.btnSave.Click +=
                new System.EventHandler(this.btnSave_Click);

            // lblRole
            this.lblRole.AutoSize = true;

            this.lblRole.Location =
                new System.Drawing.Point(810, 30);

            this.lblRole.Name =
                "lblRole";

            this.lblRole.Size =
                new System.Drawing.Size(39, 15);

            this.lblRole.TabIndex = 6;

            this.lblRole.Text =
                "Роль";

            // MainForm
            this.AutoScaleDimensions =
                new System.Drawing.SizeF(7F, 15F);

            this.AutoScaleMode =
                System.Windows.Forms.AutoScaleMode.Font;

            this.ClientSize =
                new System.Drawing.Size(1000, 550);

            this.Controls.Add(this.lblRole);

            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.btnDelete);
            this.Controls.Add(this.btnAdd);
            this.Controls.Add(this.btnLoad);

            this.Controls.Add(this.cmbTables);

            this.Controls.Add(this.dgvData);

            this.Name =
                "MainForm";

            this.Text =
                "Информационная система";

            ((System.ComponentModel.ISupportInitialize)
                (this.dgvData)).EndInit();

            this.ResumeLayout(false);

            this.PerformLayout();
        }
    }
}