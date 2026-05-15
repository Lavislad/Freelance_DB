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

        public MainForm(string connStr, string role)
        {
            InitializeComponent();

            connectionString = connStr;
            currentRole = role;

            lblRole.Text = "Роль: " + currentRole;

            ConfigureAccess();

        }

        private void ConfigureAccess()
        {
            // Ограничение интерфейса

            if (currentRole == "Фрилансер")
            {
                btnAdd.Enabled = false;
                btnDelete.Enabled = false;
            }

            if (currentRole == "Заказчик")
            {
                btnDelete.Enabled = false;
            }
        }

        private void btnLoad_Click(object sender, EventArgs e)
        {
            LoadVacancies();
        }

        private void LoadVacancies()
        {
            try
            {
                using (NpgsqlConnection connection =
                       new NpgsqlConnection(connectionString))
                {
                    connection.Open();

                    string sql =
                        "SELECT id, title, budget, deadline " +
                        "FROM vacancies";

                    NpgsqlDataAdapter adapter =
                        new NpgsqlDataAdapter(sql, connection);

                    DataTable table = new DataTable();

                    adapter.Fill(table);

                    dgvVacancies.DataSource = table;
                }
            }

            catch (Exception ex)
            {
                MessageBox.Show(
                    ex.Message,
                    "Ошибка",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            try
            {
                using (NpgsqlConnection connection =
                       new NpgsqlConnection(connectionString))
                {
                    connection.Open();

                    string sql =
                        "INSERT INTO vacancies " +
                        "(title, description, budget, deadline, author_id) " +
                        "VALUES " +
                        "(@title, @description, @budget, @deadline, @author)";

                    NpgsqlCommand command =
                        new NpgsqlCommand(sql, connection);

                    command.Parameters.AddWithValue("@title",
                        "Новая вакансия");

                    command.Parameters.AddWithValue("@description",
                        "Описание вакансии");

                    command.Parameters.AddWithValue("@budget",
                        50000);

                    command.Parameters.AddWithValue("@deadline",
                        DateTime.Now.AddDays(10));

                    command.Parameters.AddWithValue("@author",
                        1);

                    command.ExecuteNonQuery();

                    MessageBox.Show("Вакансия добавлена");

                    LoadVacancies();
                }
            }

            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (dgvVacancies.CurrentRow == null)
                return;

            int id = Convert.ToInt32(
                dgvVacancies.CurrentRow.Cells["id"].Value);

            try
            {
                using (NpgsqlConnection connection =
                       new NpgsqlConnection(connectionString))
                {
                    connection.Open();

                    string sql =
                        "DELETE FROM vacancies WHERE id=@id";

                    NpgsqlCommand command =
                        new NpgsqlCommand(sql, connection);

                    command.Parameters.AddWithValue("@id", id);

                    command.ExecuteNonQuery();

                    MessageBox.Show("Удалено");

                    LoadVacancies();
                }
            }

            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void MainForm_FormClosed(object sender, FormClosedEventArgs e)
        {

        }
    }
}