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
        if (date.DayOfWeek == DayOfWeek.Saturday || date.DayOfWeek == DayOfWeek.Sunday || IsDayHoliday(date))
        {
            return true;
        }

        return false;
    }
    private static bool IsDayHoliday(DateTime date)
    {
        int month = date.Month;
        int day = date.Day;

        if (month == 1 && day == 1 ||
               month == 3 && (day == 28 || day == 29) ||
               month == 4 && (day == 1 || day == 30) ||
               month == 5 && (day == 1 || day == 8 || day == 9) ||
               month == 6 && (day == 5 || day == 6 || day == 21) ||
               month == 7 ||
               month == 11 && day == 1 ||
               month == 12 && (day == 24 || day == 25 || day == 26 || day == 31))
        {
            return true;
        }
        return false;
    }

    private static bool IsWithinTimeInterval(int hour, int minute, int startHour, int startMinute, int endHour, int endMinute)
    {
        DateTime startTime = DateTime.Today.AddHours(startHour).AddMinutes(startMinute);
        DateTime endTime = DateTime.Today.AddHours(endHour).AddMinutes(endMinute);
        DateTime currentTime = DateTime.Today.AddHours(hour).AddMinutes(minute);

        return currentTime >= startTime && currentTime <= endTime;
    }
}