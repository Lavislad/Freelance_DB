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
        private DataTable currentTable;

        public DBManager(int role_id, string connection)
        {
            currentRoleId = role_id;
            connectionString = connection;
        }

        public bool LoadData(string table, DataGridView dgvData)
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
                return false;
            }

            return true;
        }
    }
}
