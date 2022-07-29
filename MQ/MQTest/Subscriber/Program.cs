using RabbitMQ.Client;
using RabbitMQ.Client.Events;
using System.Text;
using Common.Consts;
using Common.Models;

var factory = new ConnectionFactory { HostName = "localhost" };
var connection = factory.CreateConnection();
using var channel = connection.CreateModel();

//channel.QueueDeclare("orders");

MessageQueueConfig? _mqConfig = null;

Console.WriteLine("Enter 1 for subscribing to Order service");

Console.WriteLine("Enter 2 for subscribing to Customer service");

Console.WriteLine("Enter 3 for subscribing to Project service");

var configNumber = Console.ReadLine();

switch (configNumber)
{
    case "1": _mqConfig = MQConfigs.OrderConfig; break;
    case "2": _mqConfig = MQConfigs.CustomerConfig; break;
    case "3": _mqConfig = MQConfigs.ProjectConfig; break;

    default:
        break;
}

channel.ExchangeDeclare(_mqConfig?.ExchangeName, ExchangeType.Direct);
channel.QueueDeclare(_mqConfig?.QueueName, false, false, false, null);
channel.QueueBind(_mqConfig?.QueueName, _mqConfig?.ExchangeName, _mqConfig?.RoutingKey, null);

var consumer = new EventingBasicConsumer(channel);
consumer.Received += (model, eventArgs) =>
{
    var body = eventArgs.Body.ToArray();
    var message = Encoding.UTF8.GetString(body);

    Console.WriteLine(message);
};

channel.BasicConsume(queue: _mqConfig?.QueueName, autoAck: true, consumer: consumer);

Console.WriteLine($"Start Listening to Localhost:15672 for messages from Service number {configNumber}...");
Console.ReadKey();


