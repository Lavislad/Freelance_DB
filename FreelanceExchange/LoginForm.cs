using Npgsql;
using System;
using System.Windows.Forms;

namespace FreelanceExchange
{
    public partial class LoginForm : Form
    {
        private int currentUserId;
        private int currentUserRoleId;
        private string currentUserLogin;

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
                "Password=1";

            try
            {
                using (NpgsqlConnection connection = new NpgsqlConnection(adminConnection))
                {
                    connection.Open();

                    string sql =
                        "SELECT id, role_id, email " +
                        "FROM users " +
                        "WHERE email=@email " +
                        "AND password=@password";


                    NpgsqlCommand command = new NpgsqlCommand(sql, connection);

                    command.Parameters.AddWithValue("@email", txtLogin.Text);

                    command.Parameters.AddWithValue("@password", txtPassword.Text);

                    NpgsqlDataReader reader = command.ExecuteReader();

                    if (reader.Read())
                    {
                        currentUserId = Convert.ToInt32(reader["id"]);

                        currentUserRoleId = Convert.ToInt32(reader["role_id"].ToString());

                        currentUserLogin = Convert.ToString(reader["email"].ToString());

                        string connectionString = "";

                        // Подключение по роли PostgreSQL

                        if (currentUserRoleId == 1)
                        {
                            connectionString =
                                "Host=localhost;" +
                                "Port=5432;" +
                                "Database=freelance_db;" +
                                "Username=admin_role;" +
                                "Password=admin123;";
                        }
                        else if (currentUserRoleId == 2)
                        {
                            connectionString =
                                "Host=localhost;" +
                                "Port=5432;" +
                                "Database=freelance_db;" +
                                "Username=user_role;" +
                                "Password=user123;";
                        }
                        else
                        {
                            throw new Exception("Роль не определена");
                        }

                        MainForm form = new MainForm(connectionString, currentUserRoleId, currentUserId, currentUserLogin);
                        this.Hide();
                        form.ShowDialog();
                        this.Close();
                    }
                    else
                    {
                        MessageBox.Show("Неверный логин или пароль");
                    }
                }
            }

            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (txtPassword.PasswordChar == '*')
            {
                txtPassword.PasswordChar = '\0';
            }
            else
            {
                txtPassword.PasswordChar = '*';
            }
        }
    }
}