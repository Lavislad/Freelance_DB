using Npgsql;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FreelanceExchange
{
    public partial class UserForm : Form
    {
        string _id;
        string connectionString;

        public UserForm(string id, string connectionString)
        {
            InitializeComponent();
            _id = id;
            this.connectionString = connectionString;
            InitializeData();
        }

        private void InitializeData()
        {
            try
            {
                DataTable table;

                using (NpgsqlConnection connection = new NpgsqlConnection(connectionString))
                {
                    connection.Open();

                    string sql = $"SELECT * FROM users WHERE id={_id}";

                    NpgsqlCommand command = new NpgsqlCommand(sql, connection);

                    NpgsqlDataAdapter adapter = new NpgsqlDataAdapter(command);

                    table = new DataTable();

                    adapter.Fill(table);
                }   

                txtId.Text = _id;
                txtName.Text = table.Rows[0]["name"].ToString();
                txtSurname.Text = table.Rows[0]["surname"].ToString();
                txtEmail.Text = table.Rows[0]["email"].ToString();
                txtPassword.Text = table.Rows[0]["password"].ToString();
                txtRoleId.Text = table.Rows[0]["role_id"].ToString();
                rtxtDescription.Text = table.Rows[0]["profile_description"].ToString();
                txtRegistrationDate.Text = table.Rows[0]["registration_date"].ToString();
            }
            catch (Exception ex) { MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error); }
        }

        private void btnPassword_Click(object sender, EventArgs e)
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
