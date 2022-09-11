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

                    channel.QueueDeclare(queue: "createAlarm",
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

                    channel.BasicConsume(queue: "createAlarm",
                                     autoAck: true,
                                     consumer: consumer);

                    Thread.Sleep(5000);

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
