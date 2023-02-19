using OpenTelemetry;
using OpenTelemetry.Metrics;
using OpenTelemetry.Resources;
using OpenTelemetry.Trace;
using Payment.Write.Application;
using Payment.Write.Application.Publishers;
using Payment.Write.Application.Settings;
using Payment.Write.Domain.Repositories;
using Payment.Write.HostedService;

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
builder.Services.AddSingleton<IEventPublisher, EventPublisher>();
builder.Services.AddHostedService<EventPublisherHostedService>();

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