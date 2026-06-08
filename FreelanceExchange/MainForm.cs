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
            dbm = new DBManager(currentRoleId, connectionString);

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

                    dbm.LoadData(cmbTables.Text, dgvData);
                }
            }

            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void Save()
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

                    dbm.LoadData(cmbTables.Text, dgvData);
                }
            }

            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            Save();
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
                        "(name, surname, email, password, profile_description, role_id) " +
                        "VALUES " +
                        "(@name, @surname, @email, @password, @profile_description, @role_id)";

                    command = new NpgsqlCommand(sql, connection);

                    command.Parameters.AddWithValue("@name", row["name"]);

                    command.Parameters.AddWithValue("@surname", row["surname"]);

                    command.Parameters.AddWithValue("@email", row["email"]);

                    command.Parameters.AddWithValue("@password", row["password"]);

                    command.Parameters.AddWithValue("@profile_description", row["profile_description"]);

                    int.TryParse(row["role_id"].ToString(), out int roleID);
                    if (roleID != 1 && roleID != 2)
                    {
                        MessageBox.Show("Недопустимое значение для role.\nДопустимые значенния:\n1 (Администратор).\n2 (Пользователь).", "Предупреждение", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        return false;
                    }

                    command.Parameters.AddWithValue("@role_id", row["role_id"]);
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

                // RESPONSES
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
                MessageBox.Show($"Ошибка при добавлении записи\n{ex.Message}", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
                        "role_id=@role_id " +
                        "WHERE id=@id";

                    command = new NpgsqlCommand(sql, connection);

                    command.Parameters.AddWithValue("@name", row["name"]);

                    command.Parameters.AddWithValue("@surname", row["surname"]);

                    command.Parameters.AddWithValue("@email", row["email"]);

                    command.Parameters.AddWithValue("@password", row["password"]);

                    command.Parameters.AddWithValue("@profile_description", row["profile_description"]);

                    int.TryParse(row["role_id"].ToString(), out int roleID);
                    if (roleID != 1 && roleID != 2)
                    {
                        MessageBox.Show("Недопустимое значение для role.\nДопустимые значенния:\n1 (Администратор).\n2 (Пользователь).", "Предупреждение", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        return false;
                    }

                    command.Parameters.AddWithValue("@role_id", row["role_id"]);

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

                    if (currentRoleId == 2)
                    {
                        sql += " AND author_id=@userId";
                    }

                    command = new NpgsqlCommand(sql, connection);

                    command.Parameters.AddWithValue("@title", row["title"]);

                    command.Parameters.AddWithValue("@description", row["description"]);

                    command.Parameters.AddWithValue("@budget", Convert.ToDecimal(row["budget"]));

                    command.Parameters.AddWithValue("@deadline", DateTime.Parse(row["deadline"].ToString()));

                    command.Parameters.AddWithValue("@id", id);

                    if (currentRoleId == 2)
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

                    if (currentRoleId != 1)
                    {
                        sql += " AND user_id=@userId";
                    }

                    command = new NpgsqlCommand(sql, connection);

                    command.Parameters.AddWithValue("@title", row["title"]);

                    command.Parameters.AddWithValue("@message", row["message"]);

                    command.Parameters.AddWithValue("@id", id);

                    if (currentRoleId != 1)
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

                    if (currentRoleId == 2)
                    {
                        sql += " AND user_id=@userId";
                    }

                    command = new NpgsqlCommand(sql, connection);

                    command.Parameters.AddWithValue("@vacancy_id", row["vacancy_id"]);

                    command.Parameters.AddWithValue("@message", row["message"]);

                    command.Parameters.AddWithValue("@id", id);

                    if (currentRoleId == 2)
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
                    if (!dbm.LoadData(cmbTables.Text, dgvData)) return;
                    dgvData.Columns["id"].ReadOnly = true;
                    dgvData.Columns["registration_date"].ReadOnly = true;
                    break;
                case "vacancies":
                    if (!dbm.LoadData(cmbTables.Text, dgvData)) return;
                    dgvData.Columns["id"].ReadOnly = true;
                    dgvData.Columns["publication_date"].ReadOnly = true;
                    dgvData.Columns["author_id"].ReadOnly = true;
                    break;
                case "feedbacks":
                    if (!dbm.LoadData(cmbTables.Text, dgvData)) return;
                    dgvData.Columns["id"].ReadOnly = true;
                    dgvData.Columns["send_date"].ReadOnly = true;
                    dgvData.Columns["author_id"].ReadOnly = true;
                    break;
                case "responses":
                    if (!dbm.LoadData(cmbTables.Text, dgvData)) return;
                    dgvData.Columns["id"].ReadOnly = true;
                    dgvData.Columns["user_id"].ReadOnly = true;
                    dgvData.Columns["created_at"].ReadOnly = true;
                    break;
                case "news":
                    if (!dbm.LoadData(cmbTables.Text, dgvData)) return;
                    dgvData.Columns["id"].ReadOnly = true;
                    dgvData.Columns["creation_date"].ReadOnly = true;
                    dgvData.Columns["author_id"].ReadOnly = true;
                    break;
                case "tags":
                    if (!dbm.LoadData(cmbTables.Text, dgvData)) return;
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
            dbm.LoadData(cmbTables.Text, dgvData);
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