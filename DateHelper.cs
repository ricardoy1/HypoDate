namespace HypoDates
{
    using System.Collections.Generic;

    public static class DateHelper
    {
        public static int GetMonthDays(int month, int year)
        {
            var maxDaysPerMonth = GetMaxDaysPerMonthList(year);

            return maxDaysPerMonth[month];
        }

        private static Dictionary<int, int> GetMaxDaysPerMonthList(int year)
        {
            var maxDaysPerMonth = new Dictionary<int, int>
                                      {
                                          { 1, 31 },
                                          { 2, IsLeapYear(year) ? 29 : 28 },
                                          { 3, 31 },
                                          { 4, 30 },
                                          { 5, 31 },
                                          { 6, 30 },
                                          { 7, 31 },
                                          { 8, 31 },
                                          { 9, 30 },
                                          { 10, 31 },
                                          { 11, 30 },
                                          { 12, 31 }
                                      };
            return maxDaysPerMonth;
        }

        public static bool IsValidRange(HypoDate from, HypoDate to)
        {
            return from.GetAbsolute() <= to.GetAbsolute();
        }

        public static int GetElapsedDays(HypoDate from, HypoDate to)
        {

            // Same date.
            if (from.Year == to.Year && 
                from.Month == to.Month && 
                from.Day == to.Day)
            {
                return 0;
            }

            // Same year, same month, Different day.
            if (from.Year == to.Year && from.Month == to.Month)
            {
                return to.Day - from.Day - 1;
            }

            // Same year, different month
            if (from.Year == to.Year && from.Month < to.Month)
            {
                int fromMonthDays = GetMonthDays(from.Month, from.Year);
                int fromMonthRemainingDays = fromMonthDays - from.Day;
                
                var fromYearMonthDays = GetMaxDaysPerMonthList(from.Year);
                var inBetweenMonthsDays = GetTotalDaysBetweenMonths(from.Month, to.Month, fromYearMonthDays);

                return fromMonthRemainingDays + inBetweenMonthsDays + to.Day - 1;
            }

            // Different year.
            var fromYearMonths = GetMaxDaysPerMonthList(from.Year);
            var toYearMonths = GetMaxDaysPerMonthList(to.Year);
            var count = fromYearMonths[from.Month] - from.Day; // Remaining days of the current month.
            // Days between from.Month + 1 and 31/12/(from.Year)
            for (int i = from.Month + 1; i <= 12; i++) 
            {
                count += fromYearMonths[i];
            }

            // Total of days of the years in between the two years FROM and TO.
            for (int i = from.Year + 1; i < to.Year; i++)
            {
                count += IsLeapYear(i) ? 366 : 365;
            }

            // Total of days since January until the month previous to the TO month.
            for (int i = 1; i < to.Month; i++)
            {
                count += toYearMonths[i];
            }

            return count + to.Day - 1;
        }

        private static int GetTotalDaysBetweenMonths(int from, int to, Dictionary<int, int> fromYearMonthDays)
        {
            var inBetweenMonthsDays = 0;
            for (int i = from + 1; i < to; i++)
            {
                inBetweenMonthsDays += fromYearMonthDays[i];
            }
            return inBetweenMonthsDays;
        }

        private static bool IsLeapYear(int year)
        {
            return (year % 4 == 0) || ((year % 100 == 0) && (year % 400 == 0));
        }
    }
}
