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
    public partial class ExportForm : Form
    {
        Panel currentPanel;
        DBManager dbm;

        public ExportForm(string exportType, DBManager dBManager)
        {
            InitializeComponent();

            LoadComboBoxes(exportType);
            pnlVacancies.Visible = true;
            currentPanel = pnlVacancies;
            cmbReportType.SelectedIndexChanged += cmbReportType_SelectedIndexChanged;

            dbm = dBManager;
            LoadTags();
        }

        private void LoadComboBoxes(string exportType)
        {
            cmbReportType.SelectedItem = "Вакансии за период";
            cmbReports.SelectedItem = exportType;
        }

        private void LoadTags()
        {
            List<string> tags = dbm.LoadTags();

            foreach (string tag in tags)
            {
                listTags.Items.Add(tag);
            }
        }

        private void cmbReportType_SelectedIndexChanged(object sender, EventArgs e)
        {
            currentPanel.Visible = false;
            switch (cmbReportType.SelectedItem)
            {
                case "Вакансии за период":
                    pnlVacancies.Visible = true;
                    currentPanel = pnlVacancies;
                    break;
                case "Статистика по тегам":
                    pnlTags.Visible = true;
                    currentPanel = pnlTags;
                    break;
                case "Отклики на вакансии":
                    pnlResponses.Visible = true;
                    currentPanel = pnlResponses;
                    break;
            }
        }
    }
}
