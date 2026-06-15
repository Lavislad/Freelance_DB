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
            string filterString = dbm.Filter["vacancies"] ?? "";

            // 1. Формируем новое условие поиска (пробел на конце обязателен)
            string newSql = $"title LIKE '%{searchString}%' OR description LIKE '%{searchString}%' ";

            // Шаблон для поиска СТАРОГО условия (с любым текстом внутри процентов)
            string pattern = @"title\s+LIKE\s+'%.*?%'\s+OR\s+description\s+LIKE\s+'%.*?%'\s*";

            // 2. Проверяем, есть ли уже старый поиск в строке
            if (Regex.IsMatch(filterString, pattern, RegexOptions.IgnoreCase))
            {
                // Если старый поиск найден, просто заменяем его на новый на том же месте
                dbm.Filter["vacancies"] = Regex.Replace(filterString, pattern, newSql, RegexOptions.IgnoreCase);
            }
            else
            {
                // 3. Если старого поиска не было, добавляем его в конец по вашей логике
                string prefix = "";

                // Проверяем на пустую строку (с учетом пробелов)
                if (!string.IsNullOrWhiteSpace(filterString) && !isEditing)
                {
                    prefix = "AND ";
                }

                // Если строка состояла только из пробелов, очищаем её перед добавлением
                if (string.IsNullOrWhiteSpace(filterString)) filterString = "";

                dbm.Filter["vacancies"] = filterString + prefix + newSql;
            }
        }

        public void ClearSql()
        {
            string currentFilter = dbm.Filter["vacancies"];

            // 1. Удаляем саму связку title LIKE ... OR description LIKE ...
            string pattern = @"title\s+LIKE\s+'%.*?%'\s+OR\s+description\s+LIKE\s+'%.*?%'";
            string cleaned = Regex.Replace(currentFilter, pattern, "", RegexOptions.IgnoreCase);

            // 2. Очищаем лишние операторы AND/OR, которые могли остаться по бокам
            // Захватываем оператор в начале строки
            cleaned = Regex.Replace(cleaned, @"^\s*(OR|AND)\s*", "", RegexOptions.IgnoreCase);
            // Захватываем оператор в конце строки, игнорируя концевые пробелы
            cleaned = Regex.Replace(cleaned, @"\s*(OR|AND)\s*$", "", RegexOptions.IgnoreCase);

            // 3. Нормализуем пробелы: убираем лишние, но принудительно оставляем ровно один пробел в конце
            cleaned = Regex.Replace(cleaned.Trim(), @"\s+", " ");

            dbm.Filter["vacancies"] = string.IsNullOrEmpty(cleaned) ? " " : cleaned + " ";
        }
    }
}
