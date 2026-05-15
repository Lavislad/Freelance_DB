using Npgsql;
using System;
using System.Windows.Forms;

namespace FreelanceExchange
{
    public partial class LoginForm : Form
    {
        private int currentUserId;
        private string currentUserRole;

        public LoginForm()
        {
            InitializeComponent();
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            string adminConnection =
                "Host=localhost;" +
                "Port=5432;" +
                "Database=freelance_db;" +
                "Username=postgres;" +
                "Password=12345";

            try
            {
                using (NpgsqlConnection connection =
                       new NpgsqlConnection(adminConnection))
                {
                    connection.Open();

                    string sql =
                        "SELECT id, role " +
                        "FROM users " +
                        "WHERE email=@email " +
                        "AND password=@password";

                    NpgsqlCommand command =
                        new NpgsqlCommand(sql, connection);

                    command.Parameters.AddWithValue(
                        "@email",
                        txtLogin.Text);

                    command.Parameters.AddWithValue(
                        "@password",
                        txtPassword.Text);

                    NpgsqlDataReader reader =
                        command.ExecuteReader();

                    if (reader.Read())
                    {
                        currentUserId =
                            Convert.ToInt32(reader["id"]);

                        currentUserRole =
                            reader["role"].ToString();

                        string connectionString = "";

                        // Подключение по роли PostgreSQL

                        if (currentUserRole == "Администратор")
                        {
                            connectionString =
                                "Host=localhost;" +
                                "Port=5432;" +
                                "Database=freelance_db;" +
                                "Username=admin_role;" +
                                "Password=admin123;";
                        }

                        else if (currentUserRole == "Заказчик")
                        {
                            connectionString =
                                "Host=localhost;" +
                                "Port=5432;" +
                                "Database=freelance_db;" +
                                "Username=customer_role;" +
                                "Password=customer123;";
                        }

                        else
                        {
                            connectionString =
                                "Host=localhost;" +
                                "Port=5432;" +
                                "Database=freelance_db;" +
                                "Username=freelancer_role;" +
                                "Password=free123;";
                        }

                        MainForm form = new MainForm(connectionString, currentUserRole, currentUserId);

                        this.Hide();

                        form.ShowDialog();

                        this.Close();
                    }

                    else
                    {
                        MessageBox.Show(
                            "Неверный логин или пароль");
                    }
                }
            }

            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}