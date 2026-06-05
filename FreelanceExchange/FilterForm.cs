using System;
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

        public FilterForm(int role_id, string table)
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

        }
    }
}
