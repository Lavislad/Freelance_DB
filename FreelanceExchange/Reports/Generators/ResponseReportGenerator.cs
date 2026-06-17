using FreelanceExchange.Reports.Models;
using System;

namespace FreelanceExchange.Reports
{
    public class ResponseReportGenerator : IReportGenerator
    {
        private readonly DBManager _dbm;
        private readonly DateTime _from;
        private readonly DateTime _to;

        public ResponseReportGenerator(DBManager db, DateTime from, DateTime to)
        {
            _dbm = db;
            _from = from;
            _to = to;
        }

        public ReportInfo Generate()
        {
            return new ReportInfo
            {
                Title = "Отклики на вакансии",
                CreatedAt = DateTime.Now,
                Data = _dbm.GetResponsesReport(_from, _to)
            };
        }
    }
}