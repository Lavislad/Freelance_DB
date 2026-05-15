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

        public MainForm(string connStr, string role, int userId)
        {
            InitializeComponent();

            connectionString = connStr;

            currentRole = role;

            currentUserId = userId;

            lblRole.Text = $"Роль: {role} | ID: {userId}";
        }

        // Загрузка таблиц БД
        private void LoadTables()
        {
            cmbTables.Items.Clear();

            cmbTables.Items.Add("users");
            cmbTables.Items.Add("vacancies");
            cmbTables.Items.Add("responses");
            cmbTables.Items.Add("news");
            cmbTables.Items.Add("feedback");
            cmbTables.Items.Add("tags");

            cmbTables.SelectedIndex = 0;
        }

        // Разграничение доступа
        private void ConfigureAccess()
        {
            if (currentRole == "Фрилансер")
            {
                btnAdd.Enabled = false;
                btnEdit.Enabled = false;
                btnDelete.Enabled = false;
            }

            if (currentRole == "Заказчик")
            {
                btnDelete.Enabled = false;
            }
        }

        // Загрузка данных
        private void btnLoadData_Click(object sender, EventArgs e)
        {
            try
            {
                using (NpgsqlConnection connection =
                       new NpgsqlConnection(connectionString))
                {
                    connection.Open();

                    string table = cmbTables.Text;

                    string sql = $"SELECT * FROM {table}";

                    NpgsqlDataAdapter adapter =
                        new NpgsqlDataAdapter(sql, connection);

                    DataTable dataTable = new DataTable();

                    adapter.Fill(dataTable);

                    dgvData.DataSource = dataTable;
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
                using (NpgsqlConnection connection =
                       new NpgsqlConnection(connectionString))
                {
                    connection.Open();

                    string sql = "";

                    if (table == "vacancies")
                    {
                        sql =
                            "INSERT INTO vacancies " +
                            "(title, description, budget, deadline, author_id) " +
                            "VALUES " +
                            "('Новая вакансия', 'Описание', 10000, NOW(), 1)";
                    }

                    else if (table == "tags")
                    {
                        sql =
                            "INSERT INTO tags(name) VALUES('Новый тег')";
                    }

                    else
                    {
                        MessageBox.Show(
                            "Добавление для таблицы не реализовано");
                        return;
                    }

                    NpgsqlCommand command =
                        new NpgsqlCommand(sql, connection);

                    command.ExecuteNonQuery();

                    MessageBox.Show("Запись добавлена");

                    btnLoadData.PerformClick();
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

            int id = Convert.ToInt32(
                dgvData.CurrentRow.Cells["id"].Value);

            try
            {
                using (NpgsqlConnection connection =
                       new NpgsqlConnection(connectionString))
                {
                    connection.Open();

                    string sql =
                        $"DELETE FROM {table} WHERE id=@id";

                    NpgsqlCommand command =
                        new NpgsqlCommand(sql, connection);

                    command.Parameters.AddWithValue("@id", id);

                    command.ExecuteNonQuery();

                    MessageBox.Show("Удалено");

                    btnLoadData.PerformClick();
                }
            }

            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        // Изменение записи
        private void btnEdit_Click(object sender, EventArgs e)
        {
            if (dgvData.CurrentRow == null)
                return;

            string table = cmbTables.Text;

            int id = Convert.ToInt32(
                dgvData.CurrentRow.Cells["id"].Value);

            try
            {
                using (NpgsqlConnection connection =
                       new NpgsqlConnection(connectionString))
                {
                    connection.Open();

                    string sql = "";

                    if (table == "vacancies")
                    {
                        sql =
                            "UPDATE vacancies " +
                            "SET title='Изменено' " +
                            "WHERE id=@id";
                    }

                    else if (table == "tags")
                    {
                        sql =
                            "UPDATE tags " +
                            "SET name='Изменённый тег' " +
                            "WHERE id=@id";
                    }

                    else
                    {
                        MessageBox.Show(
                            "Изменение для таблицы не реализовано");
                        return;
                    }

                    NpgsqlCommand command =
                        new NpgsqlCommand(sql, connection);

                    command.Parameters.AddWithValue("@id", id);

                    command.ExecuteNonQuery();

                    MessageBox.Show("Изменено");

                    btnLoadData.PerformClick();
                }
            }

            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}