using SmartBudget.TransactionsService.Application.Configuration;
using SmartBudget.TransactionsService.Infrastructure.Persistance.Configuration;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();

builder.Services.AddInfrasctructureLayer(builder.Configuration);

builder.Services.AddApplicationLayer();

var app = builder.Build();

app.UseHttpsRedirection();

app.MapControllers();

app.Run();
