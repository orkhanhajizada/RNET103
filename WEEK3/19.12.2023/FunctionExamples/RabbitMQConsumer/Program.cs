// See https://aka.ms/new-console-template for more information

using RabbitMQ.Client;

IConnectionFactory connectionFactory = new ConnectionFactory()
{
    Uri = new Uri("amqps://khrwxrzl:4Atc_KzZJI2-bqTEthUX6BUUrWBKSiI8@cow.rmq2.cloudamqp.com/khrwxrzl")
};

using var conenction = connectionFactory.CreateConnection();
using var channel = conenction.CreateModel();
channel.QueueDeclare(queue: "emailQueue",
    durable: false,
    exclusive: false,
    autoDelete: false,
    arguments: null);