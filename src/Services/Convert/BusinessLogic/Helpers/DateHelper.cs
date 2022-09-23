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

        public static DateTime GetDate8DK(string dateString)
        {
            try
            {
                return DateTime.ParseExact(dateString, "ddMMyyyy", CultureInfo.InvariantCulture);
            }
            catch
            {
                return DateTime.MinValue;
            }
        }

        public static DateTime GetNextBusinessDay(DateTime date)
        {
            DateTime nextDay;
            var holidays = DanishHoliday.GetHolidays(date.Year);
            do
            {
                nextDay = GetNextWeekDay(date);
                if (date.Year != nextDay.Year)
                    holidays = DanishHoliday.GetHolidays(nextDay.Year);
            } while (holidays.Where(x => x.IsBankHoliday).Select(x => x.Date).Contains(nextDay));
            return nextDay;
        }
        
        private static DateTime GetNextWeekDay(DateTime date)
        {
           return date.DayOfWeek switch
            {
                DayOfWeek.Friday => date.AddDays(3),
                DayOfWeek.Saturday => date.AddDays(2),
                _ => date.AddDays(1)
            };
        }
    }
}
