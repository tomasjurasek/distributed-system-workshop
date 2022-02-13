using MassTransit;
using Writer.Application.Handlers.Commands;
using Writer.Infrastructure.Extensions;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddInfrastructure();

//builder.Services.AddMarten(opts =>
//{
//    opts.Connection("CS"); // TODO
//    opts.AutoCreateSchemaObjects = AutoCreate.All;
//});

builder.Services.AddMassTransit(x =>
{
    x.AddConsumer<CreatePaymentCommandHandler>();
    x.UsingInMemory((context, cfg) =>
    {
        cfg.ConfigureEndpoints(context);
    });
});

builder.Services.AddMassTransitHostedService();


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
