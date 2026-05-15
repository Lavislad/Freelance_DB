using Npgsql;
using System;
using System.Windows.Forms;

namespace FreelanceExchange
{
    public partial class LoginForm : Form
    {
        public LoginForm()
        {
            InitializeComponent();
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            string connectionString = "";

            if (cmbRole.Text == "Администратор")
            {
                connectionString =
                    "Host=localhost;" +
                    "Port=5432;" +
                    "Database=freelance_db;" +
                    "Username=admin_role;" +
                    "Password=admin123;";
            }

            else if (cmbRole.Text == "Заказчик")
            {
                connectionString =
                    "Host=localhost;" +
                    "Port=5432;" +
                    "Database=freelance_db;" +
                    "Username=customer_role;" +
                    "Password=customer123;";
            }

            else if (cmbRole.Text == "Фрилансер")
            {
                connectionString =
                    "Host=localhost;" +
                    "Port=5432;" +
                    "Database=freelance_db;" +
                    "Username=freelancer_role;" +
                    "Password=free123;";
            }

            try
            {
                using (NpgsqlConnection connection =
                       new NpgsqlConnection(connectionString))
                {
                    connection.Open();

                    MainForm form = new MainForm(connectionString, cmbRole.Text);
                    this.Hide();
                    form.ShowDialog();
                    this.Close();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}