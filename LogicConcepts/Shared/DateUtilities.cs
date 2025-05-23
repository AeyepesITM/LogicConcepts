namespace Shared;

public class DateUtilities
{
    public static bool IsLeapYear(int year)
    {
        if (year % 4 == 0)
        {
            if (year % 100 == 0)
            {
                if (year % 400 == 0)
                {
                    return true; // Divisible by 400
                }
                return false; // Divisible by 100 but not by 400
            }
            return true; // Divisible by 4 but not by 100
        }
        return false; // Not divisible by 4
    }
}