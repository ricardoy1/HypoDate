using System;

namespace HypoDates
{
    using System.Collections.Generic;

    struct HypoDate
    {
        public int Day;

        public int Month;

        public int Year;
    }

    class Program
    {
        static void Main(string[] args)
        {
            DisplayMainMenu();
            var work = true;
            while (work)
            {
                var dateFrom = ReadDateFrom();
                var dateTo = ReadDateTo();

                if (ValidateRange(dateFrom, dateTo))
                {
                    PrintReport(dateFrom, dateTo);
                }
                
                work = DoYouWantToContinue();
            }
        }

        private static bool ValidateRange(HypoDate from, HypoDate to)
        {
            return true;
        }

        private static HypoDate ReadDateFrom()
        {
            Console.WriteLine("Please, enter the date FROM:");
            var date = ReadDate();

            return date;
        }

        private static HypoDate ReadDateTo()
        {
            Console.WriteLine("Please, enter the date TO:");
            var date = ReadDate();

            return date;
        }

        private static HypoDate ReadDate()
        {
            var date = new HypoDate();
            date.Year = ReadYear();
            date.Month = ReadMonth();
            date.Day = ReadDay(date.Year, date.Month);

            return date;
        }

        private static int ReadYear()
        {
            var year = 0;

            do
            {
                Console.WriteLine("Please, enter a year between 1901 and 2999");
                year = ReadInteger();
            }
            while (year < 1901 || year > 2999);

            return year;
        }

        private static int ReadMonth()
        {
            var month = 0;

            do
            {
                Console.WriteLine("Please, enter a month between 1 and 12");
                month = ReadInteger();
            }
            while (month < 1 || month > 12);

            return month;
        }

        private static bool IsLeapYear(int year)
        {
            return (year % 4 == 0) || ((year % 100 == 0) && (year % 400 == 0));
        }

        private static int ReadDay(int year, int month)
        {
            var daysPerMonth = new Dictionary<int, int>
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

            var maxDay = daysPerMonth[month];
            var day = 0;

            do
            {
                Console.WriteLine(string.Format("Please, enter a day for the month {0} of the year {1}. A day between 1 and {2}.", month, year, maxDay));
                day = ReadInteger();
            }
            while (day < 1 || day > maxDay);

            return day;
        }


        private static void DisplayMainMenu()
        {
            Console.WriteLine("Welcome.");
        }

        private static void PrintReport(HypoDate from, HypoDate to)
        {
            Console.WriteLine("Report.");
        }

        private static bool DoYouWantToContinue()
        {
            Console.WriteLine("Do you want to continue with another test? y/n.");
            var answer = ReadYorN();

            return answer == UIConstants.Yes;
        }



        /// <summary>
        /// Reads an integer value
        /// </summary>
        /// <returns></returns>
        private static int ReadInteger()
        {
            Console.Write(UIConstants.Arrow);
            string value = Console.ReadLine();
            int valueInt;
            while (!int.TryParse(value, out valueInt))
            {
                Console.WriteLine(UIConstants.PleaseEnterAnIntegerValue);
                Console.Write(UIConstants.Arrow);
                value = Console.ReadLine();
            }
            return valueInt;
        }

        /// <summary>
        /// Reads only Y or N for Yes or Not
        /// </summary>
        /// <returns>Result</returns>
        private static string ReadYorN()
        {
            string value = Console.ReadLine();
            while (String.IsNullOrEmpty(value) || (value.ToUpper() != UIConstants.Yes && value.ToUpper() != UIConstants.No))
            {
                Console.WriteLine(UIConstants.PleaseEnterYorN);
                value = Console.ReadLine();
            }
            return value.ToUpper();
        }
    }
}
