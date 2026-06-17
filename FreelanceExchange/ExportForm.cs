using FreelanceExchange.Reports;
using FreelanceExchange.Reports.Exporters;
using FreelanceExchange.Reports.Models;
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
            try
            {
                IReportGenerator generator = GetGenerator();

                if (generator == null)
                {
                    MessageBox.Show(
                        "Не выбран тип отчета.",
                        "Ошибка",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Warning);

                    return;
                }

                ReportInfo report = generator.Generate();

                ReportTemplate template =
                    cmbTemplates.SelectedItem as ReportTemplate;

                if (template == null)
                {
                    MessageBox.Show(
                        "Не выбран шаблон отчета.",
                        "Ошибка",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Warning);

                    return;
                }

                IReportExporter exporter = GetExporter();

                if (exporter == null)
                {
                    MessageBox.Show(
                        "Не выбран формат экспорта.",
                        "Ошибка",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Warning);

                    return;
                }

                using SaveFileDialog dialog = new()
                {
                    Filter = GetFilter(),
                    FileName = $"{report.Title}_{DateTime.Now:yyyyMMdd_HHmmss}"
                };

                if (dialog.ShowDialog() != DialogResult.OK)
                    return;

                exporter.Export(
                    report,
                    template,
                    dialog.FileName);

                MessageBox.Show(
                    "Отчет успешно сформирован.",
                    "Успех",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    ex.Message,
                    "Ошибка",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
        }

        private IReportGenerator GetGenerator()
        {
            return cmbReportType.Text switch
            {
                "Вакансии за период" =>
                    new VacancyReportGenerator(
                        dbm,
                        dtpDateFromVacancies.Value,
                        dtpDateToVacancies.Value),

                "Статистика по тегам" =>
                    new TagReportGenerator(
                        dbm,
                        dtpDateFromTags.Value,
                        dtpDateToTags.Value),

                "Отклики на вакансии" =>
                    new ResponseReportGenerator(
                        dbm,
                        dtpDateFromResponses.Value,
                        dtpDateToResponses.Value),

                _ => null
            };
        }

        private IReportExporter GetExporter()
        {
            return cmbReports.Text switch
            {
                "PDF" => new PdfExporter(),
                "DOCX" => new DocxExporter(),
                "XLSX" => new ExcelExporter(),
                _ => null
            };
        }

        private string GetFilter()
        {
            return cmbReports.Text switch
            {
                "PDF" => "PDF (*.pdf)|*.pdf",
                "DOCX" => "Word (*.docx)|*.docx",
                "XLSX" => "Excel (*.xlsx)|*.xlsx",
                _ => "Все файлы (*.*)|*.*"
            };
        }
    }
}
