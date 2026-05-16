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
            string table = cmbTables.Text;

            try
            {
                using (NpgsqlConnection connection = new NpgsqlConnection(connectionString))
                {
                    connection.Open();

                    string sql = "";

                    // Заказчик
                    if (currentRole == "Заказчик")
                    {
                        if (table == "vacancies")
                        {
                            sql =
                                "INSERT INTO vacancies " +
                                "(title, description, budget, deadline, author_id) " +
                                "VALUES " +
                                "('Новая вакансия', 'Описание', 10000, NOW(), @userId)";
                        }

                        else if (table == "feedbacks")
                        {
                            sql =
                                "INSERT INTO feedbacks " +
                                "(title, message, user_id) " +
                                "VALUES " +
                                "('Новый отзыв', 'Текст', @userId)";
                        }
                    }

                    // Фрилансер
                    else if (currentRole == "Фрилансер")
                    {
                        if (table == "responses")
                        {
                            sql =
                                "INSERT INTO responses " +
                                "(message, user_id, vacancy_id) " +
                                "VALUES " +
                                "('Новый отклик', @userId, 1)";
                        }

                        else if (table == "feedbacks")
                        {
                            sql =
                                "INSERT INTO feedbacks " +
                                "(title, message, user_id) " +
                                "VALUES " +
                                "('Новый отзыв', 'Текст', @userId)";
                        }
                    }

                    // Админ
                    else
                    {
                        MessageBox.Show("Добавление для администратора лучше делать напрямую через таблицу");

                        return;
                    }

                    NpgsqlCommand command = new NpgsqlCommand(sql, connection);

                    command.Parameters.AddWithValue("@userId", currentUserId);

                    command.ExecuteNonQuery();

                    MessageBox.Show("Добавлено");

                    LoadData();
                }
            }

            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        // Удаление записи
        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (dgvData.CurrentRow == null)
                return;

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

                    MessageBox.Show("Удалено");

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

                    foreach (DataGridViewRow row in dgvData.Rows)
                    {
                        if (row.IsNewRow)
                            continue;

                        int id =
                            Convert.ToInt32(row.Cells["id"].Value);

                        // vacancies
                        if (table == "vacancies")
                        {
                            string sql =
                                "UPDATE vacancies " +
                                "SET title=@title, " +
                                "description=@description, " +
                                "budget=@budget " +
                                "WHERE id=@id";

                            if (currentRole == "Заказчик")
                            {
                                sql +=
                                    " AND author_id=@userId";
                            }

                            NpgsqlCommand command = new NpgsqlCommand(sql, connection);

                            command.Parameters.AddWithValue("@title", row.Cells["title"].Value);

                            command.Parameters.AddWithValue("@description", row.Cells["description"].Value);

                            command.Parameters.AddWithValue("@budget", Convert.ToDecimal(row.Cells["budget"].Value));

                            command.Parameters.AddWithValue("@id", id);

                            if (currentRole == "Заказчик")
                            {
                                command.Parameters.AddWithValue("@userId", currentUserId);
                            }

                            command.ExecuteNonQuery();
                        }

                        // feedbacks
                        else if (table == "feedbacks")
                        {
                            string sql =
                                "UPDATE feedbacks " +
                                "SET title=@title, " +
                                "message=@message " +
                                "WHERE id=@id";

                            if (currentRole != "Администратор")
                            {
                                sql +=
                                    " AND user_id=@userId";
                            }

                            NpgsqlCommand command = new NpgsqlCommand(sql, connection);

                            command.Parameters.AddWithValue("@title", row.Cells["title"].Value);

                            command.Parameters.AddWithValue("@message", row.Cells["message"].Value);

                            command.Parameters.AddWithValue("@id", id);

                            if (currentRole != "Администратор")
                            {
                                command.Parameters.AddWithValue("@userId", currentUserId);
                            }

                            command.ExecuteNonQuery();
                        }

                        // responses
                        else if (table == "responses")
                        {
                            string sql =
                                "UPDATE responses " +
                                "SET message=@message " +
                                "WHERE id=@id";

                            if (currentRole == "Фрилансер")
                            {
                                sql +=
                                    " AND user_id=@userId";
                            }

                            NpgsqlCommand command = new NpgsqlCommand(sql, connection);

                            command.Parameters.AddWithValue("@message", row.Cells["message"].Value);

                            command.Parameters.AddWithValue("@id", id);

                            if (currentRole == "Фрилансер")
                            {
                                command.Parameters.AddWithValue("@userId", currentUserId);
                            }

                            command.ExecuteNonQuery();
                        }
                    }

                    MessageBox.Show("Изменения сохранены");

                    LoadData();
                }
            }

            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
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