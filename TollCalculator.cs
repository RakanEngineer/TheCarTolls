using System;
using System.Globalization;
using TollFeeCalculator;

public class TollCalculator
{

    /**
     * Calculate the total toll fee for one day
     *
     * @param vehicle - the vehicle
     * @param dates   - date and time of all passes on one day
     * @return - the total toll fee for that day
     */
    private static readonly int[] TollRates = { 8, 13, 18 };
    private const int MaxTotalFee = 60;
    private static readonly string[] TollFreeVehicleTypes = { "Motorbike", "Tractor", "Emergency", "Diplomat", "Foreign", "Military" };

    public int GetTollFee(IVehicle vehicle, DateTime[] dates)
    {
        DateTime intervalStart = dates[0];
        int totalFee = 0;
        foreach (DateTime date in dates)
        {
            int nextFee = GetTollFee(date, vehicle);
            int tempFee = GetTollFee(intervalStart, vehicle);

            long diffInMillies = date.Millisecond - intervalStart.Millisecond;
            long minutes = diffInMillies / 1000 / 60;

            if (minutes <= 60)
            {
                if (totalFee > 0) totalFee -= tempFee;
                if (nextFee >= tempFee) tempFee = nextFee;
                totalFee += tempFee;
            }
            else
            {
                totalFee += nextFee;
            }
        }
        return totalFee > MaxTotalFee ? MaxTotalFee : totalFee;
    }

    private bool IsTollFreeVehicle(IVehicle vehicle)
    {
        if (vehicle == null) return false;
        string vehicleType = vehicle.GetVehicleType();
        return TollFreeVehicleTypes.Contains(vehicleType);
    }
    public int GetTollFee(DateTime date, IVehicle vehicle)
    {
        if (IsTollFreeDate(date) || IsTollFreeVehicle(vehicle)) return 0;

        int hour = date.Hour;
        int minute = date.Minute;

        if (IsWithinTimeInterval(hour, minute, 6, 0, 6, 29)) return TollRates[0];
        else if (IsWithinTimeInterval(hour, minute, 6, 30, 6, 59)) return TollRates[1];
        else if (IsWithinTimeInterval(hour, minute, 7, 0, 7, 59)) return TollRates[2];
        else if (IsWithinTimeInterval(hour, minute, 8, 0, 8, 29)) return TollRates[1];
        else if (IsWithinTimeInterval(hour, minute, 8, 30, 14, 59)) return TollRates[0];
        else if (IsWithinTimeInterval(hour, minute, 15, 0, 15, 29)) return TollRates[1];
        else if (IsWithinTimeInterval(hour, minute, 15, 30, 16, 59)) return TollRates[2];
        else if (IsWithinTimeInterval(hour, minute, 17, 0, 17, 59)) return TollRates[1];
        else if (IsWithinTimeInterval(hour, minute, 18, 0, 18, 29)) return TollRates[0];
        else return 0;
    }
    private static Boolean IsTollFreeDate(DateTime date)
    {
        List<DateTime> holidays = GetHolidays(date.Year);

        if (date.DayOfWeek == DayOfWeek.Saturday || date.DayOfWeek == DayOfWeek.Sunday || IsTodayHoliday(holidays, date))
        {
            return true;
        }

        return false;
    }
    private static bool IsTodayHoliday(List<DateTime> holidays, DateTime date)
    {
        return holidays.Contains(date.Date);
    }
    private static List<DateTime> GetHolidays(int year)
    {
        List<DateTime> holidays = new List<DateTime>
            {
                new DateTime(year, 1, 1),                   // Nyårsdagen
                new DateTime(year, 1, 5),                   // Dagen före Trettondedag jul
                new DateTime(year, 1, 6),                   // Trettondedag jul
                CalculateEasterSunday(year).AddDays(-3),    // Dagen före Långfredagen
                CalculateEasterSunday(year).AddDays(-2),    // Långfredagen
                CalculateEasterSunday(year),                // Påskdagen
                CalculateEasterSunday(year).AddDays(1),     // Annandag påsk
                new DateTime(year, 4, 30),                  // Dagen före Första maj
                new DateTime(year, 5, 1),                   // Första maj
                CalculateAscensionDay(year).AddDays(-1),    // Dagen före Kristi himmelsfärds dag
                CalculateAscensionDay(year),                // Kristi himmelsfärds dag
                CalculatePentecost(year),                   // Pingstdagen
                new DateTime (year, 6, 5),                  // Dagen före Sveriges nationaldag
                new DateTime (year, 6, 6),                  // Sveriges nationaldag
                CalculateMidsummerEve(year),                // Midsommarafton,Dagen före Midsommardagen
                CalculateMidsummerEve(year).AddDays(1),     // Midsommardagen
                new DateTime(year, 7, 1),
                CalculateAllSaintsDay(year),                // Alla helgons dag
                new DateTime(year, 12, 24),                 // Julafton,Dagen före Juldagen
                new DateTime(year, 12, 25),                 // Juldagen
                new DateTime(year, 12, 26),                 // Annandag jul
                new DateTime(year, 12, 31)                  // Dagen före Nyårsdagen
        };

        return holidays;
    }

    //private static bool IsDayHoliday(DateTime date)
    //{
    //    int year = date.Year;
    //    int month = date.Month;
    //    int day = date.Day;

    //    if (month == 1 && (day == 1 || day == 6) ||
    //           month == 3 && (day == 28 || day == 29) ||
    //           month == 4 && (day == 1 || day == 30) ||
    //           month == 5 && (day == 1 || day == 8 || day == 9) ||
    //           month == 6 && (day == 5 || day == 6 || day == 21) ||
    //           month == 7 ||
    //           month == 11 && day == 1 ||
    //           month == 12 && (day == 24 || day == 25 || day == 26 || day == 31))
    //    {
    //        return true;
    //    }
    //    return false;
    //}

    private static bool IsWithinTimeInterval(int hour, int minute, int startHour, int startMinute, int endHour, int endMinute)
    {
        DateTime startTime = DateTime.Today.AddHours(startHour).AddMinutes(startMinute);
        DateTime endTime = DateTime.Today.AddHours(endHour).AddMinutes(endMinute);
        DateTime currentTime = DateTime.Today.AddHours(hour).AddMinutes(minute);

        return currentTime >= startTime && currentTime <= endTime;
    }
    private static List<DateTime> GetSwedishHolidays(int year)
    {
        List<DateTime> holidays = new List<DateTime>
            {
                new DateTime(year, 1, 1),                   // Nyårsdagen
                new DateTime(year, 1, 5),                   // Dagen före Trettondedag jul
                new DateTime(year, 1, 6),                   // Trettondedag jul
                CalculateEasterSunday(year).AddDays(-3),    // Dagen före Långfredagen
                CalculateEasterSunday(year).AddDays(-2),    // Långfredagen
                CalculateEasterSunday(year),                // Påskdagen
                CalculateEasterSunday(year).AddDays(1),     // Annandag påsk
                new DateTime(year, 4, 30),                  // Dagen före Första maj
                new DateTime(year, 5, 1),                   // Första maj
                CalculateAscensionDay(year).AddDays(-1),    // Dagen före Kristi himmelsfärds dag
                CalculateAscensionDay(year),                // Kristi himmelsfärds dag
                CalculatePentecost(year),                   // Pingstdagen
                new DateTime (year, 6, 5),                  // Dagen före Sveriges nationaldag
                new DateTime (year, 6, 6),                  // Sveriges nationaldag
                CalculateMidsummerEve(year),                // Midsommarafton,Dagen före Midsommardagen
                CalculateMidsummerEve(year).AddDays(1),     // Midsommardagen
                new DateTime(year, 7, 1),
                CalculateAllSaintsDay(year),                // Alla helgons dag
                new DateTime(year, 12, 24),                 // Julafton,Dagen före Juldagen
                new DateTime(year, 12, 25),                 // Juldagen
                new DateTime(year, 12, 26),                 // Annandag jul
                new DateTime(year, 12, 31)                  // Dagen före Nyårsdagen
        };

        return holidays;
    }
    private static DateTime CalculateEasterSunday(int year)
    {
        int a = year % 19;
        int b = year / 100;
        int c = year % 100;
        int d = b / 4;
        int e = b % 4;
        int f = (b + 8) / 25;
        int g = (b - f + 1) / 3;
        int h = (19 * a + b - d - g + 15) % 30;
        int i = c / 4;
        int k = c % 4;
        int l = (32 + 2 * e + 2 * i - h - k) % 7;
        int m = (a + 11 * h + 22 * l) / 451;
        int month = (h + l - 7 * m + 114) / 31;
        int day = ((h + l - 7 * m + 114) % 31) + 1;

        return new DateTime(year, month, day);
    }

    private static DateTime CalculateMidsummerEve(int year)
    {
        // Midsommarafton infaller alltid på en fredag mellan den 19 och 25 juni
        DateTime midsummerEve = new DateTime(year, 6, 19);
        while (midsummerEve.DayOfWeek != DayOfWeek.Friday)
        {
            midsummerEve = midsummerEve.AddDays(1);
        }

        return midsummerEve;
    }
    private static DateTime CalculateAscensionDay(int year)
    {
        // Kristi himmelsfärdsdag infaller alltid 39 dagar efter påsk
        DateTime easterSunday = CalculateEasterSunday(year);
        DateTime ascensionDay = easterSunday.AddDays(39);
        return ascensionDay;
    }

    private static DateTime CalculatePentecost(int year)
    {
        // Pingstdagen infaller alltid 49 dagar efter påsk
        DateTime easterSunday = CalculateEasterSunday(year);
        DateTime pentecost = easterSunday.AddDays(49);
        return pentecost;
    }
    private static DateTime CalculateAllSaintsDay(int year)
    {
        DateTime firstNovember = new DateTime(year, 11, 1);
        int daysUntilFirstSaturday = ((int)DayOfWeek.Saturday - (int)firstNovember.DayOfWeek + 7) % 7;
        DateTime allSaintsDay = firstNovember.AddDays(daysUntilFirstSaturday);

        return allSaintsDay;
    }
}