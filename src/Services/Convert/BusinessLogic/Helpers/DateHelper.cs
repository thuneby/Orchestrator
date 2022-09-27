using System.Globalization;

namespace Convert.BusinessLogic.Helpers
{
    public static class DateHelper
    {
        public static DateTime GetDate6N(string dateString)
        {
            try
            {
                return DateTime.ParseExact(dateString, "ddMMyy", CultureInfo.InvariantCulture);
            }
            catch
            {
                return DateTime.MinValue;
            }
        }

        public static DateTime GetDate8N(string dateString)
        {
            try
            {
                return DateTime.ParseExact(dateString, "yyyyMMdd", CultureInfo.InvariantCulture);
            }
            catch
            {
                return DateTime.MinValue;
            }
        }

    }
}
