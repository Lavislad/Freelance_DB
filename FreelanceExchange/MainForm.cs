using Npgsql;
using System;
using System.Configuration;
using System.Data;
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
        private DataTable currentTable;

        public MainForm(string connStr, int role_id, int userId, string login)
        {
            InitializeComponent();

            connectionString = connStr;
            currentRoleId = role_id;
            currentUserId = userId;
            currentUserLogin = login;
            dbm = new DBManager(currentRoleId, connectionString, currentUserId);

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

            if (MessageBox.Show("Вы уверены, что хотите удалить эту запись?", "Подтверждение удаления", MessageBoxButtons.YesNo) == DialogResult.No)
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
            dbm.Save(cmbTables.Text, dgvData, currentTable);
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
            dbm.LoadData(cmbTables.Text, dgvData, ref currentTable);;
        }

        private void btnFilter_Click(object sender, EventArgs e)
        {
            OpenFilterForm();
        }

        private void OpenFilterForm()
        {
            FilterForm filterForm = new FilterForm(currentRoleId, cmbTables.Text);
            filterForm.Show();
        }
    }
}