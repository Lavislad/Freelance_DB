using FreelanceExchange.Reports.Models;


namespace FreelanceExchange.Reports.Exporters
{
    public interface IReportExporter
    {
        void Export(ReportInfo report, string fileName);
    }
}
