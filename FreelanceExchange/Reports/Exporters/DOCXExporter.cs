using DocumentFormat.OpenXml.Packaging;
using DocumentFormat.OpenXml.Wordprocessing;
using FreelanceExchange.Reports.Models;
using FreelanceExchange.Reports.Templates;
using System.Data;

namespace FreelanceExchange.Reports.Exporters
{
    public class DocxExporter : IReportExporter
    {
        public void Export(
            ReportInfo report,
            ReportTemplate template,
            string fileName)
        {
            using WordprocessingDocument doc =
                WordprocessingDocument.Create(
                    fileName,
                    DocumentFormat.OpenXml.WordprocessingDocumentType.Document);

            MainDocumentPart mainPart =
                doc.AddMainDocumentPart();

            mainPart.Document = new Document();

            Body body = new();

            body.Append(
                new Paragraph(
                    new Run(
                        new Text(template.Header))));

            if (template.ShowDate)
            {
                body.Append(
                    new Paragraph(
                        new Run(
                            new Text(
                                $"Дата формирования: {report.CreatedAt:dd.MM.yyyy HH:mm}"))));
            }

            Table table = new();

            TableRow header = new();

            foreach (DataColumn column in report.Data.Columns)
            {
                header.Append(
                    new TableCell(
                        new Paragraph(
                            new Run(
                                new Text(column.ColumnName)))));
            }

            table.Append(header);

            foreach (DataRow row in report.Data.Rows)
            {
                TableRow tr = new();

                foreach (var value in row.ItemArray)
                {
                    tr.Append(
                        new TableCell(
                            new Paragraph(
                                new Run(
                                    new Text(value?.ToString() ?? "")))));
                }

                table.Append(tr);
            }

            body.Append(table);

            if (!string.IsNullOrWhiteSpace(template.Footer))
            {
                body.Append(
                    new Paragraph(
                        new Run(
                            new Text(template.Footer))));
            }

            mainPart.Document.Append(body);
            mainPart.Document.Save();
        }
    }
}