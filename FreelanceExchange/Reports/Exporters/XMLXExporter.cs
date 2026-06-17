using ClosedXML.Excel;
using FreelanceExchange.Reports.Models;


namespace FreelanceExchange.Reports.Exporters
{
    public class ExcelExporter : IReportExporter
    {
        public void Export(ReportInfo report, string fileName)
        {
            using XLWorkbook workbook = new();

            var worksheet = workbook.Worksheets.Add("Report");

            worksheet.Cell(1, 1).Value = report.Title;

            for (int col = 0; col < report.Data.Columns.Count; col++)
            {
                worksheet.Cell(3, col + 1).Value = report.Data.Columns[col].ColumnName;
            }

            for (int row = 0; row < report.Data.Rows.Count; row++)
            {
                for (int col = 0; col < report.Data.Columns.Count; col++)
                {
                    worksheet.Cell(row + 4, col + 1).Value = report.Data.Rows[row][col]?.ToString();
                }
            }

            worksheet.Columns().AdjustToContents();

            workbook.SaveAs(fileName);
        }
    }
}
