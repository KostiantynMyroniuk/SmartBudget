using Ocelot.DependencyInjection;
using Ocelot.Middleware;
using SmartBudget.Gateway.Interfaces;
using SmartBudget.Gateway.Services;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();

builder.Configuration.AddJsonFile("ocelot.json", optional: false, reloadOnChange: true);

builder.Services.AddOcelot();

builder.Services.AddHttpClient();

builder.Services.AddScoped<ITransactionAggregatorService, TransactionAggregatorService>();

var app = builder.Build();

app.UseHttpsRedirection();

app.UseRouting();

app.MapControllers();

await app.UseOcelot();

app.Run();
