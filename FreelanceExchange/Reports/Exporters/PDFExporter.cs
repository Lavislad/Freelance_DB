using FreelanceExchange.Reports.Models;
using FreelanceExchange.Reports.Templates;
using iText.Kernel.Pdf;
using iText.Layout;
using iText.Layout.Element;
using System.Data;

namespace FreelanceExchange
{
    public class PdfExporter : IReportExporter
    {
        public void Export(
            ReportInfo report,
            ReportTemplate template,
            string fileName)
        {
            using PdfWriter writer = new(fileName);
            using PdfDocument pdf = new(writer);
            using Document document = new(pdf);

            document.Add(
                new Paragraph(template.Header)
                .SetFontSize(18));

            if (template.ShowDate)
            {
                document.Add(
                    new Paragraph(
                        $"Дата формирования: {report.CreatedAt:dd.MM.yyyy HH:mm}"));
            }

            Table table = new(report.Data.Columns.Count);

            foreach (DataColumn column in report.Data.Columns)
            {
                table.AddHeaderCell(column.ColumnName);
            }

            foreach (DataRow row in report.Data.Rows)
            {
                foreach (object value in row.ItemArray)
                {
                    table.AddCell(value?.ToString() ?? "");
                }
            }

            document.Add(table);

            if (!string.IsNullOrWhiteSpace(template.Footer))
            {
                document.Add(
                    new Paragraph(template.Footer));
            }
        }
    }
}