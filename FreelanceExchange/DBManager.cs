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
        private Dictionary<string, string> filter;

        public Dictionary<string, string> Filter
        {
            get { return filter; }  
            set { filter = value; }
        }

        public DBManager(int role_id, string connection, int user_id)
        {
            currentRoleId = role_id;
            connectionString = connection;
            currentUserId = user_id;
            filter = new Dictionary<string, string>
            {
                { "users", "" },
                { "vacancies", "" },
                { "responses", "" },
                { "feedbacks", "" },
                { "news", "" }
            };
        }

        public bool LoadData(string table, DataGridView dgvData, ref DataTable currentTable)
        {
            try
            {
                using (NpgsqlConnection connection = new NpgsqlConnection(connectionString))
                {
                    connection.Open();

                    string sql = "";
                    filter.TryGetValue(table, out string value);

                    if (currentRoleId == 1)
                    {
                        switch (table)
                        {
                            case "users":
                                sql = $"SELECT * FROM {table}";
                                if (!string.IsNullOrEmpty(value))
                                    sql += $" WHERE {value}";
                                break;
                            case "vacancies":
                                sql = $"SELECT * FROM {table}";
                                if (!string.IsNullOrEmpty(value))
                                    sql += $" WHERE {value}";
                                break;
                            case "feedbacks":
                                sql = $"SELECT * FROM {table}";
                                if (!string.IsNullOrEmpty(value))
                                    sql += $" WHERE {value}";
                                break;
                            case "responses":
                                sql = $"SELECT * FROM {table}";
                                if (!string.IsNullOrEmpty(value))
                                    sql += $" WHERE {value}";
                                break;
                            case "news":
                                sql = $"SELECT * FROM {table}";
                                if (!string.IsNullOrEmpty(value))
                                    sql += $" WHERE {value}";
                                break;
                            case "tags":
                                sql = $"SELECT * FROM {table}";
                                break;
                        }
                    }

                    else if (currentRoleId == 2)
                    {
                        switch (table)
                        {
                            case "users":
                                sql =
                                    $"SELECT * FROM {table} " +
                                    "WHERE id=@id";
                                break;
                            case "vacancies":
                                sql =
                                    $"SELECT * FROM {table} ";
                                if (!string.IsNullOrEmpty(value))
                                    sql += $"WHERE {value} ";
                                break;
                            case "feedbacks":
                                sql =
                                    $"SELECT * FROM {table} ";
                                if (!string.IsNullOrEmpty(value))
                                    sql += $"WHERE {value} ";
                                break;
                            case "responses":
                                sql =
                                    $"SELECT * FROM {table} " +
                                    "WHERE user_id=@id ";
                                if (!string.IsNullOrEmpty(value))
                                    sql += $"AND {value} ";
                                break;
                            case "news":
                                sql =
                                    $"SELECT * FROM {table} ";
                                if (!string.IsNullOrEmpty(value))
                                    sql += $"WHERE {value} ";
                                break;
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

        public List<string> LoadTags()
        {
            List<string> tags = new List<string>();
            try
            {
                using (NpgsqlConnection connection = new NpgsqlConnection(connectionString))
                {
                    connection.Open();

                    string sql = "SELECT name FROM tags";

                    NpgsqlCommand command = new NpgsqlCommand(sql, connection);

                    NpgsqlDataReader reader = command.ExecuteReader();

                    while (reader.Read())
                        tags.Add(reader.GetString(0));
                }
            }
            catch (Exception ex) { MessageBox.Show($"Ошибка при зашрузке тегов: {ex.Message}", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error); }

            return tags;
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

        public void Save(string table, DataTable currentTable)
        {
            try
            {
                using (NpgsqlConnection connection = new NpgsqlConnection(connectionString))
                {
                    connection.Open();

                    if (!UpdateRow(connection, table, currentTable.Rows[0]))
                        return;

                    currentTable.AcceptChanges();
                }
            }
            catch (Exception ex) { MessageBox.Show(ex.Message); }
        }

        private bool SaveNewRow(NpgsqlConnection connection, string table, DataRow row)
        {
            try
            {
                string sql = "";

                NpgsqlCommand command;


                switch (table)
                {
                    case "users":
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
                        break;

                    case "vacancies":
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
                        break;

                    case "responses":
                        sql =
                        "INSERT INTO responses " +
                        "(vacancy_id, user_id, message) " +
                        "VALUES " +
                        "(@vacancy_id, @user_id, @message)";

                        command = new NpgsqlCommand(sql, connection);

                        command.Parameters.AddWithValue("@vacancy_id", Convert.ToInt32(row["vacancy_id"]));

                        command.Parameters.AddWithValue("@user_id", currentUserId);

                        command.Parameters.AddWithValue("@message", row["message"]);
                        break;

                    case "feedbacks":
                        sql =
                        "INSERT INTO feedbacks " +
                        "(title, message, author_id) " +
                        "VALUES " +
                        "(@title, @message, @author_id)";

                        command = new NpgsqlCommand(sql, connection);

                        command.Parameters.AddWithValue("@title", row["title"]);

                        command.Parameters.AddWithValue("@message", row["message"]);

                        command.Parameters.AddWithValue("@author_id", currentUserId);
                        break;

                    case "tags":
                        sql =
                        "INSERT INTO tags " +
                        "(name) " +
                        "VALUES " +
                        "(@name)";

                        command = new NpgsqlCommand(sql, connection);

                        command.Parameters.AddWithValue("@name", row["name"]);
                        break;

                    case "news":
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
                        break;

                    default: return false;
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
                        "role_id=@role_id, " +
                        "avatar_path=@avatar_path " +
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

                    command.Parameters.AddWithValue("@avatar_path", row["avatar_path"]);

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

        public void ClearFilters()
        {
            filter["users"] = "";
            filter["vacancies"] = "";
            filter["responses"] = "";
            filter["feedbacks"] = "";
            filter["news"] = "";
        }

        public DataTable GetVacanciesReport(
    DateTime dateFrom,
    DateTime dateTo)
        {
            DataTable table = new();

            const string sql = @"
        SELECT
            v.id,
            v.title,
            u.name || ' ' || u.surname AS author,
            v.budget,
            v.deadline,
            v.publication_date
        FROM vacancies v
        JOIN users u
            ON u.id = v.author_id
        WHERE v.publication_date
            BETWEEN @dateFrom AND @dateTo
        ORDER BY v.publication_date DESC";

            using var connection =
                new NpgsqlConnection(connectionString);

            using var command =
                new NpgsqlCommand(sql, connection);

            command.Parameters.AddWithValue(
                "@dateFrom",
                dateFrom.Date);

            command.Parameters.AddWithValue(
                "@dateTo",
                dateTo.Date);

            connection.Open();

            using var adapter =
                new NpgsqlDataAdapter(command);

            adapter.Fill(table);

            return table;
        }

        public DataTable GetTagsReport(
    DateTime dateFrom,
    DateTime dateTo)
        {
            DataTable table = new();

            const string sql = @"
        SELECT
            t.name AS tag,
            COUNT(*) AS vacancies_count
        FROM vacancy_tags vt
        JOIN tags t
            ON t.id = vt.tag_id
        JOIN vacancies v
            ON v.id = vt.vacancy_id
        WHERE v.publication_date
            BETWEEN @dateFrom AND @dateTo
        GROUP BY t.name
        ORDER BY vacancies_count DESC";

            using var connection =
                new NpgsqlConnection(connectionString);

            using var command =
                new NpgsqlCommand(sql, connection);

            command.Parameters.AddWithValue(
                "@dateFrom",
                dateFrom.Date);

            command.Parameters.AddWithValue(
                "@dateTo",
                dateTo.Date);

            connection.Open();

            using var adapter =
                new NpgsqlDataAdapter(command);

            adapter.Fill(table);

            return table;
        }

        public DataTable GetResponsesReport(
    DateTime dateFrom,
    DateTime dateTo)
        {
            DataTable table = new();

            const string sql = @"
        SELECT
            v.title,
            COUNT(r.id) AS responses_count
        FROM vacancies v
        LEFT JOIN responses r
            ON r.vacancy_id = v.id
        WHERE r.created_at
            BETWEEN @dateFrom AND @dateTo
        GROUP BY v.title
        ORDER BY responses_count DESC";

            using var connection =
                new NpgsqlConnection(connectionString);

            using var command =
                new NpgsqlCommand(sql, connection);

            command.Parameters.AddWithValue(
                "@dateFrom",
                dateFrom);

            command.Parameters.AddWithValue(
                "@dateTo",
                dateTo);

            connection.Open();

            using var adapter =
                new NpgsqlDataAdapter(command);

            adapter.Fill(table);

            return table;
        }
    }
}
