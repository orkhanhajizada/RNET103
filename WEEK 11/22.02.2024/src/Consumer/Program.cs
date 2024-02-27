using Configurations;
using Consumer.Services;
using MassTransit;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();

var config = builder.Configuration
    .GetSection("RabbitMQ")
    .Get<RabbitMqConfig>();
 
builder.Services.AddMassTransit(options =>
{ 
    options.AddConsumer<OrderConsumer>();

    options.UsingRabbitMq((context, cfg) =>
    {
        cfg.Host(
            host: config.Host,
            virtualHost: config.VirtualHost,
            configure: user =>
            {
                user.Username(config.UserName);
                user.Password(config.Password);
            }
        );
        cfg.ReceiveEndpoint($"{config.Pattern}-queue", e =>
        {
            e.ConfigureConsumer<OrderConsumer>(context);
        });
        cfg.ConfigureEndpoints(context);
    });
});
 
var app = builder.Build();

// Configure the HTTP request pipeline.

app.UseAuthorization();

app.MapControllers();

app.Run();