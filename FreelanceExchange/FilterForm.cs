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
    public partial class FilterForm : Form
    {
        string table;
        int currentRoleId;
        Panel currentPanel;

        public FilterForm(int role_id, int tableIndex)
        {
            InitializeComponent();

            currentRoleId = role_id;
            this.table = cmbTables.Text;

            LoadTables();
            cmbTables.SelectedIndex = tableIndex;
            LoadPanel();
        }

        private void LoadTables()
        {
            cmbTables.Items.Clear();

            if (currentRoleId == 1)
            {
                cmbTables.Items.Add("users");
                cmbTables.Items.Add("vacancies");
                cmbTables.Items.Add("responses");
                cmbTables.Items.Add("feedbacks");
                cmbTables.Items.Add("news");
                cmbTables.Items.Add("tags");
            }

            else if (currentRoleId == 2)
            {
                cmbTables.Items.Add("users");
                cmbTables.Items.Add("vacancies");
                cmbTables.Items.Add("feedbacks");
                cmbTables.Items.Add("news");
                cmbTables.Items.Add("responses");
            }
        }

        private void LoadPanel()
        {
            switch (table)
            {
                case "users":
                    pnlUsers.Visible = true;
                    currentPanel = pnlUsers;
                    break;
            }
        }

        private void cmbTables_SelectedIndexChanged(object sender, EventArgs e)
        {
            currentPanel.Visible = false;
            LoadPanel();
        }
    }
}
