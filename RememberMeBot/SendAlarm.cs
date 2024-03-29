﻿using RabbitMQ.Client;
using System.Text;

namespace RememberMeBot
{
    public static class SendAlarm
    {
        public static bool Send(string alarm)
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
                    var body = Encoding.UTF8.GetBytes(alarm);

                    channel.ExchangeDeclare(exchange: "amq.direct", type: ExchangeType.Direct, durable: true, autoDelete: false);

                    channel.BasicPublish(exchange: "amq.direct",
                                         routingKey: "create",
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
