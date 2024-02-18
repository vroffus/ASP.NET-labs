using System;

public class TimeOfDayService
{
    public string GetTimeOfDay()
    {
        var currentTime = DateTime.Now;
        var hour = currentTime.Hour;

        if (hour >= 6 && hour < 12)
        {
            return "зараз ранок";
        }
        else if (hour >= 12 && hour < 18)
        {
            return "зараз день";
        }
        else if (hour >= 18 && hour < 24)
        {
            return "зараз вечір";
        }
        else
        {
            return "зараз ніч";
        }
    }
}
