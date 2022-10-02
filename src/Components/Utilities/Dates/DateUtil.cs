namespace Utilities.Dates
{
    public class DateUtil
    {
        public static bool IsBusinessDay(DateTime date)
        {
            if (date.DayOfWeek == DayOfWeek.Saturday || date.DayOfWeek == DayOfWeek.Sunday)
                return false;
            return !date.IsHoliday();
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
