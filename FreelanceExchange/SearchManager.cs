using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FreelanceExchange
{
    public class SearchManager
    {
        DBManager dbm;
        public SearchManager(DBManager dbm)
        {
            this.dbm = dbm;
        }

        public void Search(string searchString)
        {
            string sql = "";
            string filterString = dbm.Filter["vacancies"];

            if (filterString != "")
                sql += "AND ";
            else
                sql += "WHERE ";

            sql += $"title LIKE '%{searchString}%' OR description LIKE '%{searchString}%' ";

            dbm.Filter["vacancies"] = sql;          
        }
    }
}
