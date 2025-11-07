using SmartBudget.CategoriesService.Application.Configuration;
using SmartBudget.CategoriesService.Infrastructure.Persistance.Configuration;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();

builder.Services.AddInfrastructureLayer(builder.Configuration);

builder.Services.AddApplicationLayer();

var app = builder.Build();

app.UseHttpsRedirection();

app.MapControllers();

app.Run();
