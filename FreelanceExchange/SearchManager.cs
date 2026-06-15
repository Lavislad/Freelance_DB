using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace FreelanceExchange
{
    public class SearchManager
    {
        DBManager dbm;
        bool isEditing = false;

        public SearchManager(DBManager dbm)
        {
            this.dbm = dbm;
        }

        public bool IsEditing
        {
            get { return isEditing; }
            set { isEditing = value; }
        }

        public void Search(string searchString)
        {
            string sql = "";
            string filterString = dbm.Filter["vacancies"];

            if (filterString != "" && !isEditing)
            {
                sql += "AND ";
            }

            sql += $"title LIKE '%{searchString}%' OR description LIKE '%{searchString}%' ";

            dbm.Filter["vacancies"] = sql;          
        }

        public void ClearSql()
        {
            string currentFilter = dbm.Filter["vacancies"];

            // Шаблон ищет "title LIKE '%...%'" и возможный последующий "OR " или "AND "
            string pattern = @"title\s+LIKE\s+'%.*?%'\s*(OR|AND)?\s*";

            // Regex.Replace возвращает новую строку, записываем её обратно в фильтр
            dbm.Filter["vacancies"] = Regex.Replace(currentFilter, pattern, "", RegexOptions.IgnoreCase);
        }
    }
}
