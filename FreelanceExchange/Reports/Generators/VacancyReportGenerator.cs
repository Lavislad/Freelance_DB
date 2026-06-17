using FreelanceExchange.Reports.Models;
using System;

namespace FreelanceExchange.Reports
{
    public class VacancyReportGenerator : IReportGenerator
    {
        private readonly DBManager _dbm;
        private readonly DateTime _from;
        private readonly DateTime _to;

        public VacancyReportGenerator(DBManager db, DateTime from, DateTime to)
        {
            _dbm = db;
            _from = from;
            _to = to;
        }

        public ReportInfo Generate()
        {
            return new ReportInfo
            {
                Title = "Отчет по вакансиям",
                CreatedAt = DateTime.Now,
                Data = _dbm.GetVacanciesReport(_from, _to)
            };
        }
    }
}