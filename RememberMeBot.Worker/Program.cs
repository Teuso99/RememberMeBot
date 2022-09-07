using RememberMeBot.Resources;
using RememberMeBot.Worker;

Console.WriteLine("Worker onliners!");

List<TimeOnly> alarms = new List<TimeOnly>();

while (true)
{
    var alarm = ReceiveAlarm.Receive();

    if (!string.IsNullOrEmpty(alarm))
    {
        Console.WriteLine("ae pora pegou a queue");

        AddAlarm(alarm);
    }

    if (alarms.Any())
    {
        Console.WriteLine("ae pora ta tentando mandar pra queue");

        CheckAlarms(alarms);
    }
}

void AddAlarm(string alarm)
{
    var alarmTime = TimeOnly.Parse(alarm);

    alarms.Add(alarmTime);
}

void CheckAlarms(List<TimeOnly> alarms)
{
    foreach (var alarm in alarms)
    {
        if (alarm.CompareHoursAndMinutesOnly(TimeOnly.FromDateTime(DateTime.Now)))
        {
            var result = false;

            do
            {
                result = TriggerAlarm.Trigger(alarm);
                Console.WriteLine("tentou o bagui");

            } while (!result && alarm.CompareHoursAndMinutesOnly(TimeOnly.FromDateTime(DateTime.Now)));            
        }
    }
}