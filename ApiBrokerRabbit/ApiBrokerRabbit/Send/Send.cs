using RabbitMQ.Client;
using System.Text;

namespace ApiBrokerRabbit.Send
{
    public class Send
    {

        private IModel _channel;
        public Send()
        {
            CreatingConnection();
        }

        public void CreatingConnection()
        {
            var factory = new ConnectionFactory { HostName = "localhost" };
            using var connection = factory.CreateConnection();
            _channel = connection.CreateModel();
            _channel.QueueDeclare(queue:"hello",durable:false, exclusive:false, autoDelete: false, arguments:null);
        }

        public void Publish(string message)
        {
            var body = Encoding.UTF8.GetBytes(message);
            _channel.BasicPublish(exchange: string.Empty, routingKey: "hello", basicProperties: null, body: body);
            Console.WriteLine($" [x] Sent {message}");
            Console.WriteLine($" Press [enter] to exit.");
            Console.ReadLine();
        }

    }
}
