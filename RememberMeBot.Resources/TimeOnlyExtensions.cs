namespace RememberMeBot.Resources
{
    public static class TimeOnlyExtensions
    {
        public static bool CompareHoursAndMinutesOnly(this TimeOnly t1, TimeOnly t2)
        {
            TimeOnly time1 = new TimeOnly(t1.Hour, t1.Minute);
            TimeOnly time2 = new TimeOnly(t2.Hour, t2.Minute);

            if (time1 == time2)
            {
                return true;
            }

            return false;
        }
    }
}