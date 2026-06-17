using System.Collections.Generic;
using Npgsql;
using FreelanceExchange.Reports.Templates;


namespace FreelanceExchange.Reports.Templates
{    
    public class ReportTemplateRepository
    {
        private readonly string _connectionString;

        public ReportTemplateRepository(string connectionString)
        {
            _connectionString = connectionString;
        }

        public List<ReportTemplate> GetAll()
        {
            List<ReportTemplate> templates = new();

            const string sql = """
            SELECT
                id,
                name,
                header,
                footer,
                show_logo,
                show_date
            FROM report_templates
            ORDER BY name
            """;

            using var connection = new NpgsqlConnection(_connectionString);

            using var command = new NpgsqlCommand(sql, connection);

            connection.Open();

            using var reader = command.ExecuteReader();

            while (reader.Read())
            {
                templates.Add(new ReportTemplate
                {
                    Id = reader.GetInt32(0),
                    Name = reader.GetString(1),
                    Header = reader.GetString(2),
                    Footer = reader.GetString(3),
                    ShowLogo = reader.GetBoolean(4),
                    ShowDate = reader.GetBoolean(5)
                });
            }

            return templates;
        }

        public ReportTemplate GetById(int id)
        {
            const string sql = """
            SELECT
                id,
                name,
                header,
                footer,
                show_logo,
                show_date
            FROM report_templates
            WHERE id = @id
            """;

            using var connection = new NpgsqlConnection(_connectionString);

            using var command = new NpgsqlCommand(sql, connection);

            command.Parameters.AddWithValue("id", id);

            connection.Open();

            using var reader = command.ExecuteReader();

            if (!reader.Read())
                return null;

            return new ReportTemplate
            {
                Id = reader.GetInt32(0),
                Name = reader.GetString(1),
                Header = reader.GetString(2),
                Footer = reader.GetString(3),
                ShowLogo = reader.GetBoolean(4),
                ShowDate = reader.GetBoolean(5)
            };
        }
    }
}
