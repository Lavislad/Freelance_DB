using Npgsql;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
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
        DBManager dbm;
        DataTable _currentTable;

        public event Action OnApplied;

        public UserForm(string id, string connectionString, DBManager dbManager)
        {
            InitializeComponent();
            _id = id;
            this.connectionString = connectionString;
            dbm = dbManager;
            _currentTable = new DataTable();
            InitializeData();
        }

        private void InitializeData()
        {
            try
            {
                using (NpgsqlConnection connection = new NpgsqlConnection(connectionString))
                {
                    connection.Open();

                    string sql = $"SELECT * FROM users WHERE id={_id}";

                    NpgsqlCommand command = new NpgsqlCommand(sql, connection);

                    NpgsqlDataAdapter adapter = new NpgsqlDataAdapter(command);

                    adapter.Fill(_currentTable);
                }

                txtId.Text = _id;
                txtName.Text = _currentTable.Rows[0]["name"].ToString();
                txtSurname.Text = _currentTable.Rows[0]["surname"].ToString();
                txtEmail.Text = _currentTable.Rows[0]["email"].ToString();
                txtPassword.Text = _currentTable.Rows[0]["password"].ToString();
                txtRoleId.Text = _currentTable.Rows[0]["role_id"].ToString();
                rtxtDescription.Text = _currentTable.Rows[0]["profile_description"].ToString();
                txtRegistrationDate.Text = _currentTable.Rows[0]["registration_date"].ToString();

                string avatarPath = _currentTable.Rows[0]["avatar_path"].ToString();
                if (avatarPath != "")
                {
                    pbImage.Image = Image.FromFile(avatarPath);
                    pbImage.ImageLocation = avatarPath;
                }
                else
                {
                    pbImage.Image = null;
                    pbImage.ImageLocation = null;
                }
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

        private void btnAccept_Click(object sender, EventArgs e)
        {
            Validate();

            _currentTable.Rows[0]["name"] = txtName.Text;
            _currentTable.Rows[0]["surname"] = txtSurname.Text;
            _currentTable.Rows[0]["surname"] = txtSurname.Text;
            _currentTable.Rows[0]["email"] = txtEmail.Text;
            _currentTable.Rows[0]["password"] = txtPassword.Text;
            _currentTable.Rows[0]["role_id"] = txtRoleId.Text;
            _currentTable.Rows[0]["profile_description"] = rtxtDescription.Text;
            _currentTable.Rows[0]["avatar_path"] = pbImage.ImageLocation ?? null;

            dbm.Save("users", _currentTable);

            OnApplied?.Invoke();
            Close();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void btnChange_Click(object sender, EventArgs e)
        {
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                string filePath = openFileDialog1.FileName;
                string savePath = SaveImageToAppDirectory(filePath);

                _currentTable.Rows[0]["avatar_path"] = savePath;
                pbImage.Image = Image.FromFile(savePath);
                pbImage.ImageLocation = savePath;
            }
        }

        private string SaveImageToAppDirectory(string sourcePath)
        {
            string imageDirectory = Path.Combine(Application.StartupPath, "images", "users");
            
            if (!Directory.Exists(imageDirectory))
                Directory.CreateDirectory(imageDirectory);

            string fileName = $"avatar_{_id}_{DateTime.Now.Ticks}.jpg";

            string destinationPath = Path.Combine(imageDirectory, fileName);

            File.Copy(sourcePath, destinationPath, true);

            return destinationPath;
        }
    }
}
