using MassTransit;
using OpenTelemetry;
using OpenTelemetry.Metrics;
using OpenTelemetry.Resources;
using OpenTelemetry.Trace;
using Payment.Write.Application;
using Payment.Write.Application.Commands;
using Payment.Write.Application.Publishers;
using Payment.Write.Application.Settings;
using Payment.Write.Domain.Events;
using Payment.Write.Domain.Repositories;
using Payment.Write.HostedService;
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
        s.AddMeter("Payment")
        .AddPrometheusExporter();
    });

builder.Services.Configure<EventStoreSettings>(builder.Configuration.GetSection("EventStore"));

builder.Services.AddSingleton<IPaymentRepository, PaymentRepository>();
builder.Services.AddScoped<IEventPublisher, EventPublisher>();
builder.Services.AddHostedService<EventPublisherHostedService>();

builder.Services.AddMediatR(cfg => {
    cfg.RegisterServicesFromAssembly(typeof(CreatePaymentCommand).Assembly);
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

        cfg.Message<PaymentCreated>(e => e.SetEntityName("payment-created"));
        cfg.Publish<PaymentCreated>(e => e.ExchangeType = ExchangeType.Topic);
        
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
