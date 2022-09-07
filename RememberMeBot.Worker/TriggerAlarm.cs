using RabbitMQ.Client;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RememberMeBot.Worker
{
    public static class TriggerAlarm
    {
        public static bool Trigger(TimeOnly alarm)
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
                    var body = Encoding.UTF8.GetBytes(alarm.ToString());

                    channel.ExchangeDeclare(exchange: "amq.direct", type: ExchangeType.Direct, durable: true, autoDelete: false);

                    channel.BasicPublish(exchange: "amq.direct",
                                         routingKey: "trigger",
                                         basicProperties: null,
                                         body: body);

                    return true;
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                return false;
            }
        }
    }
}
