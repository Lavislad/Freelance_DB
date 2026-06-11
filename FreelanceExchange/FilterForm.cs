using System;
using System.CodeDom;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics.Eventing.Reader;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FreelanceExchange
{
    public partial class FilterForm : Form
    {
        int currentRoleId;
        Panel currentPanel;
        DBManager dbm;

        public event Action<string> FiltersApplied;

        public FilterForm(int role_id, string table, DBManager dbManager)
        {
            InitializeComponent();

            currentRoleId = role_id;
            LoadTables();
            if (currentRoleId == 1)
            {
                if (table == "users" || table == "vacancies")
                {
                    cmbTables.SelectedItem = table;
                }
                else
                {
                    cmbTables.SelectedItem = "users";
                }
            }
            else if (currentRoleId == 2)
            {
                if (table == "vacancies")
                {
                    cmbTables.SelectedItem = table;
                }
                else
                {
                    cmbTables.SelectedItem = "users";
                }
            }

            dbm = dbManager;
        }

        private void LoadTables()
        {
            cmbTables.Items.Clear();

            if (currentRoleId == 1)
            {
                cmbTables.Items.Add("users");
                cmbTables.Items.Add("vacancies");
                // Добавить фильтры на id
            }

            else if (currentRoleId == 2)
            {
                cmbTables.Items.Add("vacancies");
            }
        }

        private void LoadPanel()
        {
            if (currentPanel != null)
                currentPanel.Visible = false;

            switch (cmbTables.Text)
            {
                case "users":
                    pnlUsers.Visible = true;
                    currentPanel = pnlUsers;
                    break;
                case "vacancies":
                    pnlVacancies.Visible = true;
                    currentPanel = pnlVacancies;
                    break;
            }
        }

        private void cmbTables_SelectedIndexChanged(object sender, EventArgs e)
        {
            LoadPanel();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnAccept_Click(object sender, EventArgs e)
        {
            try
            {
                string sql = "";

                if (currentPanel.Name == "pnlUsers")
                {
                    if (cbRoleId.Checked)
                    {
                        string expectedRoleId = txtRole.Text;

                        if (string.IsNullOrEmpty(expectedRoleId))
                            throw new Exception("Пустое поле Role ID");
                        if (!int.TryParse(expectedRoleId, out int roleId))
                            throw new Exception("Ошибка обработки Role ID");

                        sql += $"role_id={roleId}";

                        dbm.Filter["users"] = sql;

                        FiltersApplied?.Invoke("users");
                    }
                }
            }
            catch (Exception ex) { MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error); }

            this.Close();
        }

        private void cbRegDate_CheckedChanged(object sender, EventArgs e)
        {
            if (cbRegDate.Checked)
            {
                lblRegDate.ForeColor = Color.Black;
                lblFromRegDate.ForeColor = Color.Black;
                lblToRegDate.ForeColor = Color.Black;

                dtpFromRegDate.Enabled = true;
                dtpToRegDate.Enabled = true;
            }
            else
            {
                lblRegDate.ForeColor = Color.DarkGray;
                lblFromRegDate.ForeColor = Color.DarkGray;
                lblToRegDate.ForeColor = Color.DarkGray;

                dtpFromRegDate.Enabled = false;
                dtpToRegDate.Enabled = false;
            }
        }

        private void cbRoleId_CheckedChanged(object sender, EventArgs e)
        {
            if (cbRoleId.Checked)
            {
                lblRole.ForeColor = Color.Black;
                txtRole.Enabled = true;
            }
            else
            {
                lblRole.ForeColor = Color.DarkGray;
                txtRole.Enabled = false;
            }
        }
    }
}
