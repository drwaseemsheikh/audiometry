using System;
using System.Globalization;

namespace Audiometry.Converter
{
    public static class SqliteDateTimeHelper
    {
        private const string SqliteDateTimeFormat = "yyyy-MM-dd HH:mm:ss.fff";

        public static string ToSqliteDateTime(DateTime datetime)
        {
            string dtStr = datetime.ToString(SqliteDateTimeFormat, CultureInfo.InvariantCulture);
            return dtStr;
        }

        public static DateTime ToDotNetDateTime(string sqliteDateTime)
        {
            DateTime dt = DateTime.ParseExact(sqliteDateTime, SqliteDateTimeFormat, CultureInfo.InvariantCulture);
            return dt;
        }
    }
}
