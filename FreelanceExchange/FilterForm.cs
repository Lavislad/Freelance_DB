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

            dbm = dbManager;

            currentRoleId = role_id;
            LoadTables();
            if (currentRoleId == 1)
            {
                if (table == "users" || table == "vacancies")
                {
                    if (dbm.Filter["users"].Contains("role_id"))
                        cbRoleId.Checked = true;
                    if (dbm.Filter["users"].Contains("registration_date"))
                        cbRegDate.Checked = true;

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
            try
            {
                string sql;

                // USERS TABLE

                sql = "";

                if (cbRoleId.Checked)
                {
                    string expectedRoleId = txtRole.Text;

                    if (string.IsNullOrEmpty(expectedRoleId))
                        throw new Exception("Пустое поле Role ID");
                    if (!int.TryParse(expectedRoleId, out int roleId))
                        throw new Exception("Ошибка обработки Role ID");

                    if (sql != "")
                        sql += "AND ";
                    sql += $"role_id={roleId} ";
                }
                if (cbRegDate.Checked)
                {
                    if (!DateTime.TryParse(dtpFromDate.Value.ToString(), out DateTime expectedFromRegDate))
                        throw new Exception("Ошибка обрабтки начальной даты регистрации");
                    if (!DateTime.TryParse(dtpToDate.Value.ToString(), out DateTime expectedToRegDate))
                        throw new Exception("Ошибка обрабтки конечной даты регистрации");

                    if (sql != "")
                        sql += "AND ";
                    sql += $"registration_date BETWEEN '{expectedFromRegDate}' AND '{expectedToRegDate}' ";
                }

                dbm.Filter["users"] = sql;
                FiltersApplied?.Invoke("users");


                //VACANCIES TABLE

                sql = "";

                if (cbBudget.Checked)
                {
                    if (!decimal.TryParse(txtFromBudget.Text, out decimal fromBudget))
                        throw new Exception("Ошибка обрабтки начального значения бюджета");
                    if (!decimal.TryParse(txtToBudget.Text, out decimal toBudget))
                        throw new Exception("Ошибка обрабтки конечного значения бюджета");

                    if (sql != "")
                        sql += "AND ";
                    sql += $"budget BETWEEN {fromBudget} AND {toBudget} ";
                }
                if (cbDeadline.Checked)
                {
                    if (!DateTime.TryParse(dtpFromDate.Value.ToString(), out DateTime fromDeadline))
                        throw new Exception("Ошибка обрабтки начальной даты крайнего срока");
                    if (!DateTime.TryParse(dtpToDate.Value.ToString(), out DateTime toDeadline))
                        throw new Exception("Ошибка обрабтки конечной даты крайнего срока");

                    if (sql != "")
                        sql += "AND ";
                    sql += $"deadline BETWEEN {fromDeadline} AND {toDeadline}";
                }
                if (cbDate.Checked)
                {
                    if (!DateTime.TryParse(dtpFromDate.Value.ToString(), out DateTime fromDate))
                        throw new Exception("Ошибка обрабтки начальной даты регистрации");
                    if (!DateTime.TryParse(dtpToDate.Value.ToString(), out DateTime toDate))
                        throw new Exception("Ошибка обрабтки конечной даты регистрации");

                    if (sql != "")
                        sql += "AND ";
                    sql += $"publication_date BETWEEN {fromDate} AND {toDate} ";
                }

                dbm.Filter["vacancies"] = sql;
                FiltersApplied?.Invoke("vacancies");
            }
            catch (Exception ex) { MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error); return; }

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

        private void pnlVacancies_CheckedChanged(object sender, EventArgs e)
        {
            CheckBox cb = sender as CheckBox;
            switch (cb.Name)
            {
                case "cbBudget":
                    if (cb.Checked)
                    {
                        lblBudget.ForeColor = Color.Black;
                        lblFromBudget.ForeColor = Color.Black;
                        lblToBudget.ForeColor = Color.Black;

                        txtFromBudget.Enabled = true;
                        txtToBudget.Enabled = true;
                    }
                    else
                    {
                        lblBudget.ForeColor = Color.DarkGray;
                        lblFromBudget.ForeColor = Color.DarkGray;
                        lblToBudget.ForeColor = Color.DarkGray;

                        txtFromBudget.Enabled = false;
                        txtToBudget.Enabled = false;
                    }
                    break;
                case "cbDeadline":
                    if (cb.Checked)
                    {
                        lblDeadline.ForeColor = Color.Black;
                        lblFromDeadline.ForeColor = Color.Black;
                        lblToDeadline.ForeColor = Color.Black;

                        dtpFromDeadline.Enabled = true;
                        dtpToDeadline.Enabled = true;
                    }
                    else
                    {
                        lblDeadline.ForeColor = Color.DarkGray;
                        lblFromDeadline.ForeColor = Color.DarkGray;
                        lblToDeadline.ForeColor = Color.DarkGray;

                        dtpFromDeadline.Enabled = false;
                        dtpToDeadline.Enabled = false;
                    }
                    break;
                case "cbDate":
                    if (cb.Checked)
                    {
                        lblDate.ForeColor = Color.Black;
                        lblFromDate.ForeColor = Color.Black;
                        lblToDate.ForeColor = Color.Black;

                        dtpFromDate.Enabled = true;
                        dtpToDate.Enabled = true;
                    }
                    else
                    {
                        lblDate.ForeColor = Color.DarkGray;
                        lblFromDate.ForeColor = Color.DarkGray;
                        lblToDate.ForeColor = Color.DarkGray;

                        dtpFromDate.Enabled = false;
                        dtpToDate.Enabled = false;
                    }
                    break;
            }
        }
    }
}
