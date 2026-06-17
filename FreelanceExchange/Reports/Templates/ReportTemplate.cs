namespace FreelanceExchange.Reports.Templates
{
    public class ReportTemplate
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string Header { get; set; }

        public string Footer { get; set; }

        public bool ShowDate { get; set; }

        public bool ShowLogo { get; set; }
    }
}