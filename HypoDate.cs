namespace HypoDates
{
    using System;
    using System.Collections.Generic;

    public class HypoDate
    {
        private const int DaysPerYear = 365;

        private const int FirstYear = 1901;

        public HypoDate(int year, int month, int day)
        {
            ValidateDate(year, month, day);

            this.Year = year;
            this.Month = month;
            this.Day = day;

            this.AbsoluteDays = this.GetAbsoluteDays();
        }


        /// <summary>
        /// Returns the number of days elapsed since 1/1/1901.
        /// </summary>
        public int AbsoluteDays { get; private set; }

        public int Day { get; private set; }

        public int Month { get; private set; }

        public int Year { get; private set; }


        public static Dictionary<int, int> GetMaxDaysPerMonthList(int year)
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

        public static int GetElapsedDays(HypoDate from, HypoDate to)
        {
            return to.AbsoluteDays - from.AbsoluteDays - 1; // Discounts no fully elapsed day.
        }


        private int GetAbsoluteDays()
        {
            var days = ((this.Year - 1901) * DaysPerYear) + this.CountLeapYearsBetween(FirstYear, this.Year);

            var maxDaysPerMonthList = GetMaxDaysPerMonthList(this.Year);
            for (var i = 1; i < this.Month; i++)
            {
                days += maxDaysPerMonthList[i];
            }

            days += this.Day;

            return days - 1; // So it doesn't count the 1/1/1901
        }

        private int CountLeapYearsBetween(int fromYear, int toYear)
        {
            var count = 0;
            for (int i = fromYear; i < toYear; i++)
            {
                count += IsLeapYear(i) ? 1 : 0;
            }

            return count;
        }

        private static void ValidateDate(int year, int month, int day)
        {
            if (year < FirstYear || year > 2999)
            {
                throw new ArgumentOutOfRangeException("year", "Year must be between 1901 and 2999 inclusive.");
            }

            if (month < 1 || month > 12)
            {
                throw new ArgumentOutOfRangeException("month", "Month must be between 1 and 12 inclusive.");
            }

            var maxDayOfTheMonth = GetMaxDaysPerMonthList(year)[month];
            if (day < 1 || day > maxDayOfTheMonth)
            {
                throw new ArgumentOutOfRangeException(
                    "day",
                    string.Format("Day must be between 1 and {0} inclusive.", maxDayOfTheMonth));
            }
        }

        private static bool IsLeapYear(int year)
        {
            return (year % 4 == 0) || ((year % 100 == 0) && (year % 400 == 0));
        }
    }
}
