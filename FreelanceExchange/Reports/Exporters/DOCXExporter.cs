using DocumentFormat.OpenXml.Packaging;
using DocumentFormat.OpenXml.Wordprocessing;
using FreelanceExchange.Reports.Models;
using System.Data;


namespace FreelanceExchange.Reports.Exporters
{
    public class DocxExporter : IReportExporter
    {
        public void Export(ReportInfo report, string fileName)
        {
            using WordprocessingDocument doc = WordprocessingDocument.Create(fileName, DocumentFormat.OpenXml.WordprocessingDocumentType.Document);

            MainDocumentPart mainPart = doc.AddMainDocumentPart();

            mainPart.Document = new Document();
            Body body = new Body();

            body.Append(new Paragraph(new Run(new Text(report.Title))));

            Table table = new();

            TableRow header = new();

            foreach (DataColumn column in report.Data.Columns)
            {
                header.Append(new TableCell(new Paragraph(new Run(new Text(column.ColumnName)))));
            }

            table.Append(header);

            foreach (DataRow row in report.Data.Rows)
            {
                TableRow tr = new();

                foreach (var value in row.ItemArray)
                {
                    tr.Append(new TableCell(new Paragraph(new Run(new Text(value?.ToString() ?? "")))));
                }

                table.Append(tr);
            }

            body.Append(table);

            mainPart.Document.Append(body);
            mainPart.Document.Save();
        }
    }
}
