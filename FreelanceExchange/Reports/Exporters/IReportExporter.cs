using FreelanceExchange.Reports.Models;
using FreelanceExchange.Reports.Templates;

namespace FreelanceExchange
{
    public interface IReportExporter
    {
        void Export(
            ReportInfo report,
            ReportTemplate template,
            string fileName);
    }
}