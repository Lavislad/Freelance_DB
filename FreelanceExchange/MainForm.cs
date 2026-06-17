using Npgsql;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Diagnostics;
using System.Windows.Forms;

namespace FreelanceExchange
{
    public partial class MainForm : Form
    {
        private string connectionString;
        private int currentRoleId;
        private int currentUserId;
        private string currentUserLogin;
        private DBManager dbm;
        private SearchManager sm;
        private DataTable currentTable;

        public MainForm(string connStr, int role_id, int userId, string login)
        {
            InitializeComponent();

            connectionString = connStr;
            currentRoleId = role_id;
            currentUserId = userId;
            currentUserLogin = login;
            dbm = new DBManager(currentRoleId, connectionString, currentUserId);
            sm = new SearchManager(dbm);

            lblRole.Text = $"{currentUserLogin} | ID: {userId}";

            LoadTables();

            cmbTables.SelectedIndex = 0;
        }

        private void LoadTables()
        {
            cmbTables.Items.Clear();

            if (currentRoleId == 1)
            {
                cmbTables.Items.Add("users");
                cmbTables.Items.Add("vacancies");
                cmbTables.Items.Add("responses");
                cmbTables.Items.Add("feedbacks");
                cmbTables.Items.Add("news");
                cmbTables.Items.Add("tags");
            }

            else if (currentRoleId == 2)
            {
                cmbTables.Items.Add("users");
                cmbTables.Items.Add("vacancies");
                cmbTables.Items.Add("responses");
                cmbTables.Items.Add("feedbacks");
                cmbTables.Items.Add("news");
            }
        }



        // Добавление записи
        private void btnAdd_Click(object sender, EventArgs e)
        {
            currentTable.Rows.Add();
        }

        // Удаление записи
        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (dgvData.CurrentRow == null)
                return;

            if (string.IsNullOrEmpty(dgvData.CurrentRow.Cells["id"].Value.ToString()))
            {
                dgvData.Rows.Remove(dgvData.CurrentRow);
                return;
            }

            if (MessageBox.Show("Вы уверены, что хотите удалить эту запись?", "Подтверждение удаления", MessageBoxButtons.YesNo, MessageBoxIcon.Information) == DialogResult.No)
            {
                return;
            }


            string table = cmbTables.Text;

            int id = Convert.ToInt32(dgvData.CurrentRow.Cells["id"].Value);

            try
            {
                using (NpgsqlConnection connection = new NpgsqlConnection(connectionString))
                {
                    connection.Open();

                    string sql = $"DELETE FROM {table} WHERE id=@id";

                    NpgsqlCommand command = new NpgsqlCommand(sql, connection);

                    command.Parameters.AddWithValue("@id", id);

                    command.ExecuteNonQuery();

                    dbm.LoadData(cmbTables.Text, dgvData, ref currentTable);
                }
            }

            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            Validate();
            dbm.Save(cmbTables.Text, dgvData, currentTable);
            dbm.LoadData(cmbTables.Text, dgvData, ref currentTable);

        }

        private void cmbTables_SelectedIndexChanged(object sender, EventArgs e)
        {
            string table = cmbTables.Text;
            switch (table)
            {
                case "users":
                    if (!dbm.LoadData(cmbTables.Text, dgvData, ref currentTable)) return;
                    dgvData.Columns["id"].ReadOnly = true;
                    dgvData.Columns["registration_date"].ReadOnly = true;
                    break;
                case "vacancies":
                    if (!dbm.LoadData(cmbTables.Text, dgvData, ref currentTable)) return;
                    dgvData.Columns["id"].ReadOnly = true;
                    dgvData.Columns["publication_date"].ReadOnly = true;
                    dgvData.Columns["author_id"].ReadOnly = true;
                    break;
                case "feedbacks":
                    if (!dbm.LoadData(cmbTables.Text, dgvData, ref currentTable)) return;
                    dgvData.Columns["id"].ReadOnly = true;
                    dgvData.Columns["send_date"].ReadOnly = true;
                    dgvData.Columns["author_id"].ReadOnly = true;
                    break;
                case "responses":
                    if (!dbm.LoadData(cmbTables.Text, dgvData, ref currentTable)) return;
                    dgvData.Columns["id"].ReadOnly = true;
                    dgvData.Columns["user_id"].ReadOnly = true;
                    dgvData.Columns["created_at"].ReadOnly = true;
                    break;
                case "news":
                    if (!dbm.LoadData(cmbTables.Text, dgvData, ref currentTable)) return;
                    dgvData.Columns["id"].ReadOnly = true;
                    dgvData.Columns["creation_date"].ReadOnly = true;
                    dgvData.Columns["author_id"].ReadOnly = true;
                    break;
                case "tags":
                    if (!dbm.LoadData(cmbTables.Text, dgvData, ref currentTable)) return;
                    dgvData.Columns["id"].ReadOnly = true;
                    break;
            }
        }

        private void btnLogout_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Вы уверены, что хотите выйти из системы?", "Выйти из системы?", MessageBoxButtons.YesNo);
            if (result == DialogResult.Yes)
            {
                LoginForm form = new LoginForm();
                this.Hide();
                form.ShowDialog();
                this.Close();
            }
        }

        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {
            switch (keyData)
            {
                case Keys.Control | Keys.Shift | Keys.F:
                    OpenFilterForm();
                    return true;
            }

            return base.ProcessCmdKey(ref msg, keyData);
        }

        private void обновитьToolStripMenuItem_Click(object sender, EventArgs e)
        {
            dbm.LoadData(cmbTables.Text, dgvData, ref currentTable);
        }

        private void btnFilter_Click(object sender, EventArgs e)
        {
            OpenFilterForm();
        }

        private void OpenFilterForm()
        {
            FilterForm filterForm = new FilterForm(currentRoleId, cmbTables.Text, dbm);
            filterForm.FiltersApplied += FilterForm_FiltersApplied;
            filterForm.Show();
        }

        private void FilterForm_FiltersApplied(string table)
        {
            if (cmbTables.SelectedItem.ToString() == table)
                dbm.LoadData(table, dgvData, ref currentTable);
            else
                cmbTables.SelectedItem = table;
        }

        private void btnClearFilters_Click(object sender, EventArgs e)
        {
            dbm.ClearFilters();
            dbm.LoadData(cmbTables.Text, dgvData, ref currentTable);
        }

        private void txtSearch_TextChanged(object sender, EventArgs e)
        {
            if (txtSearch.Text != "")
            {
                sm.Search(txtSearch.Text);
                sm.IsEditing = true;
            }
            else
            {
                sm.ClearSql();
                sm.IsEditing = false;
            }

            dbm.LoadData("vacancies", dgvData, ref currentTable);
        }

        void UpdateTable() => dbm.LoadData(cmbTables.Text, dgvData, ref currentTable);

        private void пользовательToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                if (cmbTables.Text != "users")
                    throw new Exception("Не выбрана таблица users");
                if (dgvData.SelectedRows.Count > 1)
                    throw new Exception("Выбрано более одной записи");
                if (dgvData.CurrentRow == null)
                    throw new Exception("Не выбрано ни одной записи");

                string id = dgvData.CurrentRow.Cells[0].Value.ToString();

                UserForm userForm = new UserForm(id, connectionString, dbm);
                userForm.OnApplied += UpdateTable;
                userForm.Show();
            }
            catch (Exception ex) { MessageBox.Show(ex.Message, "Предупреждение", MessageBoxButtons.OK, MessageBoxIcon.Information); }
        }

        private void pDFToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ExportForm exportForm;
            switch ((sender as ToolStripMenuItem).Name)
            {
                case "pDFToolStripMenuItem":
                    exportForm = new ExportForm("PDF", dbm, connectionString);
                    break;
                case "dOCXToolStripMenuItem":
                    exportForm = new ExportForm("DOCX", dbm, connectionString);
                    break;
                case "xLSXToolStripMenuItem":
                    exportForm = new ExportForm("XLSX", dbm, connectionString);
                    break;
                default:
                    exportForm = new ExportForm("PDF", dbm, connectionString);
                    break;
            }

            exportForm.Show();
        }
    }
}