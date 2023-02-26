using MassTransit;
using Microsoft.Extensions.Caching.Distributed;
using Order.Read.Handlers;
using RabbitMQ.Client;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddMassTransit(mt =>
{
    mt.UsingRabbitMq((context, cfg) =>
    {
        cfg.Host("localhost", "service", h =>
        {
            h.Username("guest");
            h.Password("guest");
        });

        cfg.ReceiveEndpoint("order-created-read", re =>
        {
            re.ConfigureConsumeTopology = false;
            re.Consumer(() => new OrderCreatedHandler(context.GetService<IDistributedCache>()));
            re.Bind("order-created", e =>
            {
                e.RoutingKey = "*";
                e.ExchangeType = ExchangeType.Topic;
            });
        });

        cfg.ReceiveEndpoint("order-canceled-read", re =>
        {
            re.ConfigureConsumeTopology = false;
            re.Consumer(() => new OrderCanceledHandler(context.GetService<IDistributedCache>()));
            re.Bind("order-canceled", e =>
            {
                e.RoutingKey = "*";
                e.ExchangeType = ExchangeType.Topic;
            });
        });

        cfg.ReceiveEndpoint("order-delivery-address-changed-read", re =>
        {
            re.ConfigureConsumeTopology = false;
            re.Consumer(() => new OrderDeliveryAddressChangedHandler(context.GetService<IDistributedCache>()));
            re.Bind("order-delivery-address-changed", e =>
            {
                e.RoutingKey = "*";
                e.ExchangeType = ExchangeType.Topic;
            });
        });
    });
});

builder.Services.AddStackExchangeRedisCache(options =>
{
    options.Configuration = "localhost:6379";
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
