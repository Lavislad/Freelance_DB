using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FreelanceExchange.Reports.Models
{
    public class ReportInfo
    {
        public string Title { get; set; }

        public DateTime CreatedAt { get; set; }

        public DataTable Data { get; set; }
    }


    public class VacancyReportParameters
    {
        public DateTime DateFrom { get; set; }
        public DateTime DateTo { get; set; }

        public decimal? MinBudget { get; set; }
        public decimal? MaxBudget { get; set; }
    }

    public class TagReportParameters
    {
        public DateTime DateFrom { get; set; }
        public DateTime DateTo { get; set; }
    }

    public class ResponseReportParameters
    {
        public DateTime DateFrom { get; set; }
        public DateTime DateTo { get; set; }
    }
}
