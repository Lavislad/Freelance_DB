using Npgsql;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FreelanceExchange
{
    public class DBManager
    {
        private string connectionString;
        private int currentRoleId;
        private int currentUserId;

        public DBManager(int role_id, string connection, int user_id)
        {
            currentRoleId = role_id;
            connectionString = connection;
            currentUserId = user_id;
        }

        public bool LoadData(string table, DataGridView dgvData, ref DataTable currentTable)
        {
            try
            {
                using (NpgsqlConnection connection = new NpgsqlConnection(connectionString))
                {
                    connection.Open();

                    string sql = "";

                    if (currentRoleId == 1)
                    {
                        sql = $"SELECT * FROM {table}";
                    }

                    else if (currentRoleId == 2)
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
                                "WHERE author_id=@id";
                        }

                        else if (table == "users")
                        {
                            sql =
                                "SELECT * FROM users " +
                                "WHERE id=@id";
                        }

                        else if (table == "responses")
                        {
                            sql =
                                "SELECT * FROM responses " +
                                "WHERE user_id=@id";
                        }

                        else if (table == "news")
                        {
                            sql =
                                "SELECT * FROM news ";
                        }
                    }

                    NpgsqlCommand command = new NpgsqlCommand(sql, connection);

                    if (currentRoleId != 1)
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
                MessageBox.Show("Ошибка загрузки таблицы: " + ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                currentTable = null;
                return false;
            }

            return true;
        }

        public void Save(string table, DataGridView dgvData, DataTable currentTable)
        {
            try
            {
                using (NpgsqlConnection connection = new NpgsqlConnection(connectionString))
                {
                    connection.Open();

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
                        "(name, surname, email, password, profile_description, role_id) " +
                        "VALUES " +
                        "(@name, @surname, @email, @password, @profile_description, @role_id)";

                    command = new NpgsqlCommand(sql, connection);

                    command.Parameters.AddWithValue("@name", row["name"]);

                    command.Parameters.AddWithValue("@surname", row["surname"]);

                    command.Parameters.AddWithValue("@email", row["email"]);

                    command.Parameters.AddWithValue("@password", row["password"]);

                    command.Parameters.AddWithValue("@profile_description", row["profile_description"]);

                    if (!int.TryParse(row["role_id"].ToString(), out int roleID))
                        throw new Exception("Ошибка чтения поля role_id");

                    if (roleID < 1 || roleID > 2)
                        throw new Exception("Недопустимое значение для role_id.\nДопустимые значенния:\n1 (Администратор).\n2 (Пользователь).");

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

                    if (!int.TryParse(row["role_id"].ToString(), out int roleID))
                        throw new Exception("Ошибка чтения поля role_id");
                    
                    if (roleID < 1 || roleID > 2)
                        throw new Exception("Недопустимое значение для role.\nДопустимые значенния:\n1 (Администратор).\n2 (Пользователь).");

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
    }
}
