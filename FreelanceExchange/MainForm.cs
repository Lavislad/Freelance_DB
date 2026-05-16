using Npgsql;
using System;
using System.Data;
using System.Windows.Forms;

namespace FreelanceExchange
{
    public partial class MainForm : Form
    {
        private string connectionString;
        private string currentRole;
        private int currentUserId;

        private DataTable currentTable;

        public MainForm(string connStr, string role, int userId)
        {
            InitializeComponent();

            connectionString = connStr;
            currentRole = role;
            currentUserId = userId;

            lblRole.Text = $"Роль: {role} | ID: {userId}";

            LoadTables();

            ConfigureAccess();
        }

        // Загрузка списка таблиц
        private void LoadTables()
        {
            cmbTables.Items.Clear();

            if (currentRole == "Администратор")
            {
                cmbTables.Items.Add("users");
                cmbTables.Items.Add("vacancies");
                cmbTables.Items.Add("responses");
                cmbTables.Items.Add("feedbacks");
                cmbTables.Items.Add("news");
                cmbTables.Items.Add("tags");
            }

            else if (currentRole == "Заказчик")
            {
                cmbTables.Items.Add("vacancies");
                cmbTables.Items.Add("feedbacks");
            }

            else if (currentRole == "Фрилансер")
            {
                cmbTables.Items.Add("responses");
                cmbTables.Items.Add("feedbacks");
            }

            cmbTables.SelectedIndex = 0;
        }

        // Ограничение кнопок
        private void ConfigureAccess()
        {
            if (currentRole == "Фрилансер")
            {
                btnAdd.Text = "Добавить отклик";
            }

            if (currentRole == "Заказчик")
            {
                btnAdd.Text = "Добавить";
            }
        }

        // Загрузка данных
        private void btnLoad_Click(object sender, EventArgs e)
        {
            LoadData();
        }

        private void LoadData()
        {
            try
            {
                using (NpgsqlConnection connection = new NpgsqlConnection(connectionString))
                {
                    connection.Open();

                    string table = cmbTables.Text;

                    string sql = "";

                    if (currentRole == "Администратор")
                    {
                        sql = $"SELECT * FROM {table}";
                    }

                    // Заказчик
                    else if (currentRole == "Заказчик")
                    {
                        if (table == "vacancies")
                        {
                            sql =
                                "SELECT * FROM vacancies " +
                                "WHERE author_id=@id";
                        }

                        else if (table == "feedbacks")
                        {
                            sql =
                                "SELECT * FROM feedbacks " +
                                "WHERE user_id=@id";
                        }
                    }

                    // Фрилансер
                    else if (currentRole == "Фрилансер")
                    {
                        if (table == "responses")
                        {
                            sql =
                                "SELECT * FROM responses " +
                                "WHERE user_id=@id";
                        }

                        else if (table == "feedbacks")
                        {
                            sql =
                                "SELECT * FROM feedbacks " +
                                "WHERE user_id=@id";
                        }
                    }

                    NpgsqlCommand command = new NpgsqlCommand(sql, connection);

                    if (currentRole != "Администратор")
                    {
                        command.Parameters.AddWithValue("@id", currentUserId);
                    }

                    NpgsqlDataAdapter adapter = new NpgsqlDataAdapter(command);

                    currentTable = new DataTable();

                    adapter.Fill(currentTable);

                    dgvData.DataSource = currentTable;
                    dgvData.AllowUserToAddRows = true;
                    dgvData.AllowUserToDeleteRows = false;
                    dgvData.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
                }
            }

            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
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

            bool rowIsEmpty = false;
            for (int i = 0; i < dgvData.ColumnCount; i++)
            {
                if (string.IsNullOrEmpty(dgvData.CurrentRow.Cells[i].Value?.ToString()))
                {
                    rowIsEmpty = true;
                    break;
                }
            }
            if (rowIsEmpty)
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

                    string sql = "";

                    // Админ
                    if (currentRole == "Администратор")
                    {
                        sql =
                            $"DELETE FROM {table} WHERE id=@id";
                    }

                    // Заказчик
                    else if (currentRole == "Заказчик")
                    {
                        if (table == "vacancies")
                        {
                            sql =
                                "DELETE FROM vacancies " +
                                "WHERE id=@id " +
                                "AND author_id=@userId";
                        }

                        else if (table == "feedbacks")
                        {
                            sql =
                                "DELETE FROM feedbacks " +
                                "WHERE id=@id " +
                                "AND user_id=@userId";
                        }
                    }

                    // Фрилансер
                    else if (currentRole == "Фрилансер")
                    {
                        if (table == "responses")
                        {
                            sql =
                                "DELETE FROM responses " +
                                "WHERE id=@id " +
                                "AND user_id=@userId";
                        }

                        else if (table == "feedbacks")
                        {
                            sql =
                                "DELETE FROM feedbacks " +
                                "WHERE id=@id " +
                                "AND user_id=@userId";
                        }
                    }

                    NpgsqlCommand command = new NpgsqlCommand(sql, connection);

                    command.Parameters.AddWithValue("@id", id);

                    if (currentRole != "Администратор")
                    {
                        command.Parameters.AddWithValue("@userId", currentUserId);
                    }

                    command.ExecuteNonQuery();

                    LoadData();
                }
            }

            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        // Сохранение изменений прямо из DataGridView
        private void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                using (NpgsqlConnection connection =
                       new NpgsqlConnection(connectionString))
                {
                    connection.Open();

                    string table = cmbTables.Text;

                    foreach (DataRow row in currentTable.Rows)
                    {
                        // ДОБАВЛЕНИЕ
                        if (row.RowState == DataRowState.Added)
                        {
                            SaveNewRow(connection, table, row);
                        }

                        // ИЗМЕНЕНИЕ
                        else if (row.RowState == DataRowState.Modified)
                        {
                            UpdateRow(connection, table, row);
                        }
                    }

                    currentTable.AcceptChanges();

                    MessageBox.Show("Изменения сохранены");

                    LoadData();
                }
            }

            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void SaveNewRow(NpgsqlConnection connection, string table, DataRow row)
        {
            string sql = "";

            NpgsqlCommand command;

            // VACANCIES
            if (table == "vacancies")
            {
                sql =
                    "INSERT INTO vacancies " +
                    "(title, description, budget, deadline, author_id) " +
                    "VALUES " +
                    "(@title, @description, @budget, @deadline, @userId)";

                command = new NpgsqlCommand(sql, connection);

                command.Parameters.AddWithValue("@title", row["title"]);

                command.Parameters.AddWithValue("@description", row["description"]);

                command.Parameters.AddWithValue("@budget", Convert.ToDecimal(row["budget"]));

                command.Parameters.AddWithValue("@deadline", DateTime.Parse(row["deadline"].ToString()));

                command.Parameters.AddWithValue("@userId", currentUserId);
            }

            // FEEDBACKS
            else if (table == "feedbacks")
            {
                sql =
                    "INSERT INTO feedbacks " +
                    "(title, message, user_id) " +
                    "VALUES " +
                    "(@title, @message, @userId)";

                command = new NpgsqlCommand(sql, connection);

                command.Parameters.AddWithValue("@title", row["title"]);

                command.Parameters.AddWithValue("@message", row["message"]);

                command.Parameters.AddWithValue("@userId", currentUserId);
            }

            // RESPONSES
            else if (table == "responses")
            {
                sql =
                    "INSERT INTO responses " +
                    "(message, vacancy_id, user_id) " +
                    "VALUES " +
                    "(@message, @vacancyId, @userId)";

                command = new NpgsqlCommand(sql, connection);

                command.Parameters.AddWithValue("@message", row["message"]);

                command.Parameters.AddWithValue("@vacancyId", Convert.ToInt32(row["vacancy_id"]));

                command.Parameters.AddWithValue("@userId", currentUserId);
            }

            else
            {
                return;
            }

            command.ExecuteNonQuery();
        }

        private void UpdateRow(NpgsqlConnection connection, string table, DataRow row)
        {
            string sql = "";

            NpgsqlCommand command;

            int id = Convert.ToInt32(row["id"]);

            // VACANCIES
            if (table == "vacancies")
            {
                sql =
                    "UPDATE vacancies " +
                    "SET title=@title, " +
                    "description=@description, " +
                    "budget=@budget, " +
                    "deadline=@deadline " +
                    "WHERE id=@id";

                if (currentRole == "Заказчик")
                {
                    sql +=
                        " AND author_id=@userId";
                }

                command = new NpgsqlCommand(sql, connection);

                command.Parameters.AddWithValue(
                    "@title",
                    row["title"]);

                command.Parameters.AddWithValue(
                    "@description",
                    row["description"]);

                command.Parameters.AddWithValue(
                    "@budget",
                    Convert.ToDecimal(row["budget"]));

                command.Parameters.AddWithValue(
                    "@deadline",
                    Convert.ToDateTime(row["deadline"]));

                command.Parameters.AddWithValue(
                    "@id",
                    id);

                if (currentRole == "Заказчик")
                {
                    command.Parameters.AddWithValue(
                        "@userId",
                        currentUserId);
                }
            }

            // FEEDBACKS
            else if (table == "feedbacks")
            {
                sql =
                    "UPDATE feedbacks " +
                    "SET title=@title, " +
                    "message=@message " +
                    "WHERE id=@id";

                if (currentRole != "Администратор")
                {
                    sql +=
                        " AND user_id=@userId";
                }

                command = new NpgsqlCommand(sql, connection);

                command.Parameters.AddWithValue(
                    "@title",
                    row["title"]);

                command.Parameters.AddWithValue(
                    "@message",
                    row["message"]);

                command.Parameters.AddWithValue(
                    "@id",
                    id);

                if (currentRole != "Администратор")
                {
                    command.Parameters.AddWithValue(
                        "@userId",
                        currentUserId);
                }
            }

            // RESPONSES
            else if (table == "responses")
            {
                sql =
                    "UPDATE responses " +
                    "SET message=@message " +
                    "WHERE id=@id";

                if (currentRole == "Фрилансер")
                {
                    sql +=
                        " AND user_id=@userId";
                }

                command = new NpgsqlCommand(sql, connection);

                command.Parameters.AddWithValue(
                    "@message",
                    row["message"]);

                command.Parameters.AddWithValue(
                    "@id",
                    id);

                if (currentRole == "Фрилансер")
                {
                    command.Parameters.AddWithValue(
                        "@userId",
                        currentUserId);
                }
            }

            else
            {
                return;
            }

            command.ExecuteNonQuery();
        }

        private void cmbTables_SelectedIndexChanged(object sender, EventArgs e)
        {
            string table = cmbTables.Text;
            switch (table)
            {
                case "users":
                    LoadData();
                    break;
                case "vacancies":
                    LoadData();
                    break;
                case "feedbacks":
                    LoadData();
                    break;
                case "responses":
                    LoadData();
                    break;
                case "news":
                    LoadData();
                    break;
                case "tags":
                    LoadData();
                    break;
            }
            if (dgvData.Columns.Contains("id"))
            {
                dgvData.Columns["id"].ReadOnly = true;
            }
            if (dgvData.Columns.Contains("publication_date"))
            {
                dgvData.Columns["publication_date"].ReadOnly = true;
            }
            if (dgvData.Columns.Contains("registration_date"))
            {
                dgvData.Columns["registration_date"].ReadOnly = true;
            }
            if (dgvData.Columns.Contains("created_at"))
            {
                dgvData.Columns["created_at"].ReadOnly = true;
            }
            if (dgvData.Columns.Contains("send_date"))
            {
                dgvData.Columns["send_date"].ReadOnly = true;
            }
            if (dgvData.Columns.Contains("creation_date"))
            {
                dgvData.Columns["creation_date"].ReadOnly = true;
            }
            if (dgvData.Columns.Contains("author_id"))
            {
                dgvData.Columns["author_id"].ReadOnly = true;
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
    }
}