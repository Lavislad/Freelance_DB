using FreelanceExchange.Reports.Models;
using FreelanceExchange.Reports.Exporters;
using iText.Kernel.Pdf;
using iText.Layout;
using iText.Layout.Element;
using System.Data;


namespace FreelanceExchange.Reports.Exporters
{
    public class PdfExporter : IReportExporter
    {
        public void Export(ReportInfo report, string fileName)
        {
            using PdfWriter writer = new(fileName);
            using PdfDocument pdf = new(writer);
            using Document document = new(pdf);

            document.Add(new Paragraph(report.Title).SetFontSize(18));

            document.Add(new Paragraph($"Создан: {report.CreatedAt:g}"));

            Table table = new Table(report.Data.Columns.Count);

            foreach (DataColumn column in report.Data.Columns)
                table.AddHeaderCell(column.ColumnName);

            foreach (DataRow row in report.Data.Rows)
                foreach (object value in row.ItemArray)
                    table.AddCell(value?.ToString());

            document.Add(table);
        }
    }
}