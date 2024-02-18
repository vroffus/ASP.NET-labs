using System;

public class TimeOfDayService
{
    public string GetTimeOfDay()
    {
        var currentTime = DateTime.Now;
        var hour = currentTime.Hour;

        if (hour >= 6 && hour < 12)
        {
            return "����� �����";
        }
        else if (hour >= 12 && hour < 18)
        {
            return "����� ����";
        }
        else if (hour >= 18 && hour < 24)
        {
            return "����� �����";
        }
        else
        {
            return "����� ��";
        }
    }
}
