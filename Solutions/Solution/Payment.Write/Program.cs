using MassTransit;
using OpenTelemetry.Metrics;
using OpenTelemetry.Resources;
using OpenTelemetry.Trace;
using Order.Contracts.Events;
using Order.Contracts.Orders.Events;
using Order.Write.Application;
using Order.Write.Application.Commands;
using Order.Write.Application.Metrics;
using Order.Write.Application.Publishers;
using Order.Write.Application.Settings;
using Order.Write.Domain.Repositories;
using Order.Write.HostedService;
using RabbitMQ.Client;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddOpenTelemetry()
    .WithTracing(s =>
    {
        s.SetResourceBuilder(
            ResourceBuilder.CreateDefault().AddService(builder.Environment.ApplicationName))
        .AddAspNetCoreInstrumentation()
        .AddHttpClientInstrumentation()
        .AddJaegerExporter(opts =>
        {
            opts.AgentHost = "localhost";
            opts.AgentPort = 6831;
        });

    })
    .WithMetrics(s => 
    {
        s.AddMeter("Order")
        .AddPrometheusExporter();
    });

builder.Services.Configure<EventStoreSettings>(builder.Configuration.GetSection("EventStore"));

builder.Services.AddSingleton<IOrderRepository, OrderRepository>();
builder.Services.AddSingleton<IMetrics, Metrics>();
builder.Services.AddScoped<IEventPublisher, EventPublisher>();
builder.Services.AddHostedService<EventPublisherHostedService>();

builder.Services.AddMediatR(cfg => {
    cfg.RegisterServicesFromAssembly(typeof(CreateOrderCommand).Assembly);
});

builder.Services.AddMassTransit(mt =>
{
    mt.UsingRabbitMq((context, cfg) =>
    {
        cfg.Host("localhost", "service", h =>
        {
            h.Username("guest");
            h.Password("guest");
        });

        cfg.Message<OrderCreated>(e => e.SetEntityName("order-created"));
        cfg.Publish<OrderCreated>(e => e.ExchangeType = ExchangeType.Topic);
        
    });
});

//builder.Services.AddMassTransitHostedService();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseOpenTelemetryPrometheusScrapingEndpoint();

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
