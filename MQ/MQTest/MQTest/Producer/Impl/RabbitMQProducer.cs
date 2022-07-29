using Common.Consts;
using Common.Models;
using Newtonsoft.Json;
using RabbitMQ.Client;
using System.Text;

namespace MQTest.Producer.Impl
{
    public class RabbitMQProducer : IMessageProducer
    {
        public void SendMessage<T>(T message, MessageQueueConfig conf)
        {
            try
            {
                var factory = new ConnectionFactory { HostName = "localhost" };
                var connection = factory.CreateConnection();
                using var channel = connection.CreateModel();

                //channel.QueueDeclare("orders");

                channel.ExchangeDeclare(conf.ExchangeName, ExchangeType.Direct);
                channel.QueueDeclare(conf.QueueName, false, false, false, null);
                channel.QueueBind(conf.QueueName, conf.ExchangeName, conf.RoutingKey, null);

                var json = JsonConvert.SerializeObject(message);
                var body = Encoding.UTF8.GetBytes(json);

                channel.BasicPublish(exchange: conf.ExchangeName, routingKey: conf.RoutingKey, body: body);

            }
            catch(Exception e)
            {
 
            }

        }
    }
}
