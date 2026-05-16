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
                using (NpgsqlConnection connection = new NpgsqlConnection(connectionString))
                {
                    connection.Open();

                    string table = cmbTables.Text;

                    foreach (DataRow row in currentTable.Rows)
                    {
                        // ДОБАВЛЕНИЕ
                        if (row.RowState == DataRowState.Added)
                        {
                            if (!SaveNewRow(connection, table, row))
                                return;
                        }

                        // ИЗМЕНЕНИЕ
                        else if (row.RowState == DataRowState.Modified)
                        {
                            if (!UpdateRow(connection, table, row))
                                return;
                        }
                    }

                    currentTable.AcceptChanges();

                    LoadData();
                }
            }

            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private bool SaveNewRow(NpgsqlConnection connection, string table, DataRow row)
        {
            try
            {
                string sql = "";

                NpgsqlCommand command;

                // USERS
                if (table == "users")
                {
                    sql =
                        "INSERT INTO users " +
                        "(name, surname, email, password, profile_description, role, role_id) " +
                        "VALUES " +
                        "(@name, @surname, @email, @password, @profile_description, @role, @role_id)";

                    command = new NpgsqlCommand(sql, connection);

                    command.Parameters.AddWithValue("@name", row["name"]);

                    command.Parameters.AddWithValue("@surname", row["surname"]);

                    command.Parameters.AddWithValue("@email", row["email"]);

                    command.Parameters.AddWithValue("@password", row["password"]);

                    command.Parameters.AddWithValue("@profile_description", row["profile_description"]);

                    string role = row["role"].ToString();
                    if (role != "Администратор" && role != "Заказчик" && role != "Фрилансер")
                    {
                        MessageBox.Show("Недопустимое значение для role. Допустимые значения:\nАдминистратор,\nЗаказчик,\nФрилансер.", "Предупреждение", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        return false;
                    }

                    command.Parameters.AddWithValue("@role", row["role"]);

                    int role_id = int.Parse(row["role_id"].ToString());
                    if (role_id < 1 || role_id > 3)
                    {
                        MessageBox.Show("Недопустимое значение для role_id. Допустимые значения:\n1 (Администратор),\n2 (Заказчик),\n3 (Фрилансер).", "Предупреждение", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        return false;
                    }

                    command.Parameters.AddWithValue("@role_id", role_id);
                }

                // VACANCIES
                else if (table == "vacancies")
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

                else if (table == "responses")
                {
                    sql =
                        "INSERT INTO responses " +
                        "(vacancy_id, user_id, message) " +
                        "VALUES " +
                        "(@vacancy_id, @user_id, @message)";

                    command = new NpgsqlCommand(sql, connection);

                    command.Parameters.AddWithValue("@vacancy_id", Convert.ToInt32(row["vacancy_id"]));

                    command.Parameters.AddWithValue("@user_id", currentUserId);

                    command.Parameters.AddWithValue("@message", row["message"]);
                }

                // FEEDBACKS
                else if (table == "feedbacks")
                {
                    sql =
                        "INSERT INTO feedbacks " +
                        "(title, message, author_id) " +
                        "VALUES " +
                        "(@title, @message, @author_id)";

                    command = new NpgsqlCommand(sql, connection);

                    command.Parameters.AddWithValue("@title", row["title"]);

                    command.Parameters.AddWithValue("@message", row["message"]);

                    command.Parameters.AddWithValue("@author_id", currentUserId);
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

                // TAGS
                else if (table == "tags")
                {
                    sql =
                        "INSERT INTO tags " +
                        "(name) " +
                        "VALUES " +
                        "(@name)";

                    command = new NpgsqlCommand(sql, connection);

                    command.Parameters.AddWithValue("@name", row["name"]);
                }

                // NEWS
                else if (table == "news")
                {
                    sql =
                        "INSERT INTO news " +
                        "(title, anons, content, author_id) " +
                        "VALUES " +
                        "(@title, @anons, @content, @author_id)";

                    command = new NpgsqlCommand(sql, connection);

                    command.Parameters.AddWithValue("@title", row["title"]);

                    command.Parameters.AddWithValue("@anons", row["anons"]);

                    command.Parameters.AddWithValue("@content", row["content"]);

                    command.Parameters.AddWithValue("@author_id", currentUserId);
                }

                else
                {
                    return false;
                }

                command.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка при добавлении записи: {ex.Message}");
                return false;
            }

            return true;
        }

        private bool UpdateRow(NpgsqlConnection connection, string table, DataRow row)
        {
            try
            {
                string sql = "";

                NpgsqlCommand command;

                int id = Convert.ToInt32(row["id"]);

                // USERS
                if (table == "users")
                {
                    sql =
                        "UPDATE users " +
                        "SET name=@name, " +
                        "surname=@surname, " +
                        "email=@email, " +
                        "password=@password, " +
                        "profile_description=@profile_description, " +
                        "role=@role, " +
                        "role_id=@role_id " +
                        "WHERE id=@id";

                    command = new NpgsqlCommand(sql, connection);

                    command.Parameters.AddWithValue("@name", row["name"]);

                    command.Parameters.AddWithValue("@surname", row["surname"]);

                    command.Parameters.AddWithValue("@email", row["email"]);

                    command.Parameters.AddWithValue("@password", row["password"]);

                    command.Parameters.AddWithValue("@profile_description", row["profile_description"]);

                    string role = row["role"].ToString();
                    if (role != "Администратор" && role != "Заказчик" && role != "Фрилансер")
                    {
                        MessageBox.Show("Недопустимое значение для role. Допустимые значения:\nАдминистратор,\nЗаказчик,\nФрилансер.", "Предупреждение", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        return false;
                    }

                    command.Parameters.AddWithValue("@role", row["role"]);

                    int role_id = int.Parse(row["role_id"].ToString());
                    if (role_id < 1 || role_id > 3)
                    {
                        MessageBox.Show("Недопустимое значение для role_id. Допустимые значения:\n1 (Администратор),\n2 (Заказчик),\n3 (Фрилансер).", "Предупреждение", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        return false;
                    }

                    command.Parameters.AddWithValue("@role_id", role_id);

                    command.Parameters.AddWithValue("@id", id);
                }

                // VACANCIES
                else if (table == "vacancies")
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
                        sql += " AND author_id=@userId";
                    }

                    command = new NpgsqlCommand(sql, connection);

                    command.Parameters.AddWithValue("@title", row["title"]);

                    command.Parameters.AddWithValue("@description", row["description"]);

                    command.Parameters.AddWithValue("@budget", Convert.ToDecimal(row["budget"]));

                    command.Parameters.AddWithValue("@deadline", DateTime.Parse(row["deadline"].ToString()));

                    command.Parameters.AddWithValue("@id", id);

                    if (currentRole == "Заказчик")
                    {
                        command.Parameters.AddWithValue("@userId", currentUserId);
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
                        sql += " AND user_id=@userId";
                    }

                    command = new NpgsqlCommand(sql, connection);

                    command.Parameters.AddWithValue("@title", row["title"]);

                    command.Parameters.AddWithValue("@message", row["message"]);

                    command.Parameters.AddWithValue("@id", id);

                    if (currentRole != "Администратор")
                    {
                        command.Parameters.AddWithValue("@userId", currentUserId);
                    }
                }

                // RESPONSES
                else if (table == "responses")
                {
                    sql =
                        "UPDATE responses " +
                        "SET vacancy_id=@vacancy_id, " +
                        "message=@message " +
                        "WHERE id=@id";

                    if (currentRole == "Фрилансер")
                    {
                        sql += " AND user_id=@userId";
                    }

                    command = new NpgsqlCommand(sql, connection);

                    command.Parameters.AddWithValue("@vacancy_id", row["vacancy_id"]);

                    command.Parameters.AddWithValue("@message", row["message"]);

                    command.Parameters.AddWithValue("@id", id);

                    if (currentRole == "Фрилансер")
                    {
                        command.Parameters.AddWithValue("@userId", currentUserId);
                    }
                }

                // NEWS
                else if (table == "news")
                {
                    sql =
                        "UPDATE news " +
                        "SET title=@title, " +
                        "anons=@anons, " +
                        "content=@content " +
                        "WHERE id=@id";

                    command = new NpgsqlCommand(sql, connection);

                    command.Parameters.AddWithValue("@title", row["title"]);

                    command.Parameters.AddWithValue("@anons", row["anons"]);

                    command.Parameters.AddWithValue("@content", row["content"]);

                    command.Parameters.AddWithValue("@id", id);
                }

                // TAGS
                else if (table == "tags")
                {
                    sql =
                        "UPDATE tags " +
                        "SET name=@name " +
                        "WHERE id=@id";

                    command = new NpgsqlCommand(sql, connection);

                    command.Parameters.AddWithValue("@name", row["name"]);

                    command.Parameters.AddWithValue("@id", id);
                }

                else
                {
                    return false;
                }

                command.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка при обновлении записи: {ex.Message}");
                return false;
            }

            return true;
        }

        private void cmbTables_SelectedIndexChanged(object sender, EventArgs e)
        {
            string table = cmbTables.Text;
            switch (table)
            {
                case "users":
                    LoadData();
                    dgvData.Columns["id"].ReadOnly = true;
                    dgvData.Columns["registration_date"].ReadOnly = true;
                    break;
                case "vacancies":
                    LoadData();
                    dgvData.Columns["id"].ReadOnly = true;
                    dgvData.Columns["publication_date"].ReadOnly = true;
                    dgvData.Columns["author_id"].ReadOnly = true;
                    break;
                case "feedbacks":
                    LoadData();
                    dgvData.Columns["id"].ReadOnly = true;
                    dgvData.Columns["send_date"].ReadOnly = true;
                    dgvData.Columns["author_id"].ReadOnly = true;
                    break;
                case "responses":
                    LoadData();
                    dgvData.Columns["id"].ReadOnly = true;
                    dgvData.Columns["user_id"].ReadOnly = true;
                    dgvData.Columns["created_at"].ReadOnly = true;
                    break;
                case "news":
                    LoadData();
                    dgvData.Columns["id"].ReadOnly = true;
                    dgvData.Columns["creation_date"].ReadOnly = true;
                    dgvData.Columns["author_id"].ReadOnly = true;
                    break;
                case "tags":
                    LoadData();
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
    }
}