using FastReport;
using FastReport.Export.PdfSimple;
using FreelanceExchange.Reports.Templates;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace FreelanceExchange
{
    public partial class ExportForm : Form
    {
        Panel currentPanel;
        DBManager dbm;
        string _connectionString;

        public ExportForm(string exportType, DBManager dBManager, string connectionString)
        {
            InitializeComponent();

            _connectionString = connectionString;

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

            var repository = new ReportTemplateRepository(_connectionString);

            var templates = repository.GetAll();

            cmbTemplates.DataSource = templates;
            cmbTemplates.DisplayMember = "Name";
            cmbTemplates.ValueMember = "Id";
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

        private void btnCancel_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void btnGenerate_Click(object sender, EventArgs e)
        {
            string exportType = cmbReports.Text;

        }

        private void btnDesigner_Click(object sender, EventArgs e)
        {
            
        }
    }
}
