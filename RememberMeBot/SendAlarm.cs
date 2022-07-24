using RabbitMQ.Client;
using System.Text;

namespace RememberMeBot
{
    public static class SendAlarm
    {
        public static bool Send(string alarm)
        {
            try
            {
                var factory = new ConnectionFactory() { HostName = "localhost" };
                using (var connection = factory.CreateConnection())
                using (var channel = connection.CreateModel())
                {
                    channel.QueueDeclare(queue: "alarms",
                                         durable: false,
                                         exclusive: false,
                                         autoDelete: false,
                                         arguments: null);

                    var body = Encoding.UTF8.GetBytes(alarm);

                    channel.BasicPublish(exchange: "",
                                         routingKey: "alarms",
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
