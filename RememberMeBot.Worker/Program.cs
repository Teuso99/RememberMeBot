using RememberMeBot.Worker;

Console.WriteLine("Worker onliners!");

List<DateTime> alarms = new List<DateTime>();

while (true)
{
    var alarm = ReceiveAlarm.Receive();

    if (!string.IsNullOrEmpty(alarm))
    {
        AddAlarm(alarm);
    }

    if (alarms.Any())
    {
        CheckAlarms(alarms);
    }

}

void AddAlarm(string alarm)
{
    var alarmTime = DateTime.Parse(alarm);

    var alarmDateTime = new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day, alarmTime.Hour, alarmTime.Minute, alarmTime.Second);

    alarms.Add(alarmDateTime);
}

void CheckAlarms(List<DateTime> alarms)
{
    foreach (var alarm in alarms)
    {
        if (alarm == DateTime.Now)
        {
            //trigger
        }
    }
}