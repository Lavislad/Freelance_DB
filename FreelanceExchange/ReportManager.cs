using FastReport;
using FastReport.Export.PdfSimple;
using System.Data;


public interface IReportExporter
{
    void Export(DataTable data, string filePath);
}

public class PdfExporter
{
    public void Export(DataTable table, string templatePath, string outputPath)
    {
        using Report report = new();

        report.Load(templatePath);

        report.RegisterData(table, "Report");

        report.GetDataSource("Report").Enabled = true;

        report.Prepare();

        PDFSimpleExport pdf = new();

        report.Export(pdf, outputPath);
    }
}