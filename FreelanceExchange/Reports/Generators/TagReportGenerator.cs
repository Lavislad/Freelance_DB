using FreelanceExchange.Reports.Models;
using System;

namespace FreelanceExchange.Reports
{
    public class TagReportGenerator : IReportGenerator
    {
        private readonly DBManager _dbm;
        private readonly DateTime _from;
        private readonly DateTime _to;

        public TagReportGenerator(DBManager db, DateTime from, DateTime to)
        {
            _dbm = db;
            _from = from;
            _to = to;
        }

        public ReportInfo Generate()
        {
            return new ReportInfo
            {
                Title = "Статистика по тегам",
                CreatedAt = DateTime.Now,
                Data = _dbm.GetTagsReport(_from, _to)
            };
        }
    }
}