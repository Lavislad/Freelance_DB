using ClosedXML.Excel;
using FreelanceExchange.Reports.Models;
using FreelanceExchange.Reports.Templates;

namespace FreelanceExchange
{
    public class ExcelExporter : IReportExporter
    {
        public void Export(
            ReportInfo report,
            ReportTemplate template,
            string fileName)
        {
            using XLWorkbook workbook = new();

            var worksheet =
                workbook.Worksheets.Add("Report");

            int currentRow = 1;

            worksheet.Cell(currentRow, 1).Value =
                template.Header;

            currentRow++;

            if (template.ShowDate)
            {
                worksheet.Cell(currentRow, 1).Value =
                    $"Дата формирования: {report.CreatedAt:dd.MM.yyyy HH:mm}";

                currentRow++;
            }

            currentRow++;

            for (int col = 0; col < report.Data.Columns.Count; col++)
            {
                worksheet.Cell(currentRow, col + 1).Value =
                    report.Data.Columns[col].ColumnName;
            }

            currentRow++;

            for (int row = 0; row < report.Data.Rows.Count; row++)
            {
                for (int col = 0; col < report.Data.Columns.Count; col++)
                {
                    worksheet.Cell(currentRow + row, col + 1).Value =
                        report.Data.Rows[row][col]?.ToString();
                }
            }

            currentRow += report.Data.Rows.Count + 2;

            if (!string.IsNullOrWhiteSpace(template.Footer))
            {
                worksheet.Cell(currentRow, 1).Value =
                    template.Footer;
            }

            worksheet.Columns().AdjustToContents();

            workbook.SaveAs(fileName);
        }
    }
}