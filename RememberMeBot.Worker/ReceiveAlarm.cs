using RabbitMQ.Client;
using RabbitMQ.Client.Events;
using System.Text;

namespace RememberMeBot.Worker
{
    public static class ReceiveAlarm
    {
        public static string Receive()
        {
            try
            {
                var factory = new ConnectionFactory() { HostName = "localhost" };
                using (var connection = factory.CreateConnection())
                using (var channel = connection.CreateModel())
                {
                    var message = string.Empty;

                    channel.QueueDeclare(queue: "alarms",
                                         durable: false,
                                         exclusive: false,
                                         autoDelete: false,
                                         arguments: null);

                    var consumer = new EventingBasicConsumer(channel);
                    consumer.Received += (model, ea) =>
                    {
                        var body = ea.Body.ToArray();
                        message = Encoding.UTF8.GetString(body);
                    };
                    channel.BasicConsume(queue: "alarms",
                                         autoAck: true,
                                         consumer: consumer);

                    return message;
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                return string.Empty;
            }            
        }
    }
}
