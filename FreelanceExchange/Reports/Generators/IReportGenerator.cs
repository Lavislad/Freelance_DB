using FreelanceExchange.Reports.Models;
using System.Data;

namespace FreelanceExchange.Reports
{
    public interface IReportGenerator
    {
        ReportInfo Generate();
    }
}
