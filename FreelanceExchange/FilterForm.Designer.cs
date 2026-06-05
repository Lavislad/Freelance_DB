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
            SuspendLayout();
            // 
            // btnAccept
            // 
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
            cmbTables.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right;
            cmbTables.FormattingEnabled = true;
            cmbTables.Location = new System.Drawing.Point(12, 27);
            cmbTables.Name = "cmbTables";
            cmbTables.Size = new System.Drawing.Size(180, 23);
            cmbTables.TabIndex = 3;
            // 
            // FilterForm
            // 
            AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            ClientSize = new System.Drawing.Size(434, 450);
            Controls.Add(cmbTables);
            Controls.Add(lblTable);
            Controls.Add(btnCancel);
            Controls.Add(btnAccept);
            Name = "FilterForm";
            Text = "Фильтры";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private System.Windows.Forms.Button btnAccept;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Label lblTable;
        private System.Windows.Forms.ComboBox cmbTables;
    }
}