using DSharpPlus.Entities;
using RabbitMQ.Client;
using RabbitMQ.Client.Events;
using RememberMeBot.Resources;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RememberMeBot
{
    public static class ReceiveAlarmTrigger
    {
        private static List<string> _alarmTriggers = new List<string>();

        public static Task ReceiveTrigger()
        {
            try
            {
                var factory = new ConnectionFactory()
                {
                    Uri = new Uri(@"amqp://guest:guest@127.0.0.1:5672/"),
                    NetworkRecoveryInterval = TimeSpan.FromSeconds(10),
                    AutomaticRecoveryEnabled = true
                };

                using (var connection = factory.CreateConnection())
                using (var channel = connection.CreateModel())
                {
                    var message = string.Empty;

                    channel.QueueDeclare(queue: "triggerAlarm",
                                         durable: true,
                                         exclusive: false,
                                         autoDelete: false,
                                         arguments: null);

                    var consumer = new EventingBasicConsumer(channel);
                    consumer.Received += (model, ea) =>
                    {
                        var body = ea.Body.ToArray();
                        message = Encoding.UTF8.GetString(body);
                    };

                    channel.BasicConsume(queue: "triggerAlarm",
                                     autoAck: true,
                                     consumer: consumer);
                    
                    Thread.Sleep(5000);

                    if (!string.IsNullOrEmpty(message))
                    {
                        _alarmTriggers.Add(message);
                    }
                    
                    return Task.CompletedTask;
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                return Task.FromException(e);
            }
  
        }

        public static DiscordMessageBuilder? TriggerAlarm(DiscordUser? user = null)
        {
            ReceiveTrigger();

            if (!_alarmTriggers.Any())
            {
                return null;
            }

            foreach (var alarmMsg in _alarmTriggers)
            {
                var alarm = TimeOnly.Parse(alarmMsg);

                if (alarm.CompareHoursAndMinutesOnly(TimeOnly.FromDateTime(DateTime.Now)))
                {
                    DiscordMessageBuilder msg = user != null 
                        ? new DiscordMessageBuilder().WithContent($"{user.Mention}, it is {alarmMsg}!").WithAllowedMentions(new IMention[] { new UserMention(user) }) 
                        : new DiscordMessageBuilder().WithContent($"It is {alarmMsg}");

                    _alarmTriggers.Remove(alarmMsg);

                    return msg;
                }
            }

            return null;
        }
    }
}
