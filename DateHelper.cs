namespace HypoDates
{
    using System.Collections.Generic;

    public static class DateHelper
    {
        public static int GetMaxDaysPerMonth(int month, int year)
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
            if (from.Year == to.Year && from.Month == to.Month)
            {
                return to.Day - from.Day - 1;
            }

            if (from.Year == to.Year && from.Month < to.Month)
            {
                int fromMonthMax = GetMaxDaysPerMonth(from.Month, from.Year);
                int fromMonthRemainingDays = fromMonthMax - from.Day;
                var inBetweenMonthsDays = 0;
                for (int i = from.Month + 1; i < to.Month; i++)
                {
                    inBetweenMonthsDays += GetMaxDaysPerMonthList(from.Year)[i];
                }

                return fromMonthRemainingDays + inBetweenMonthsDays + to.Day - 1;
            }

            var fromYearMonths = GetMaxDaysPerMonthList(from.Year);
            var toYearMonths = GetMaxDaysPerMonthList(to.Year);
            var count = fromYearMonths[from.Month] - from.Day;
            for (int i = from.Month + 1; i <= 12; i++)
            {
                count += fromYearMonths[i];
            }

            for (int i = from.Year + 1; i < to.Year; i++)
            {
                count += IsLeapYear(i) ? 366 : 365;
            }

            for (int i = 1; i < to.Month; i++)
            {
                count += toYearMonths[i];
            }

            return count + to.Day - 1;
        }

        private static bool IsLeapYear(int year)
        {
            return (year % 4 == 0) || ((year % 100 == 0) && (year % 400 == 0));
        }
    }
}
