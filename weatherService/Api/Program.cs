using Api.Middleware;
using Microsoft.EntityFrameworkCore;
using Persistence;
using Repository;
using Repository.Abstractions;

var builder = WebApplication.CreateBuilder(args);




builder.Services.AddControllers();

//builder.Services.AddScoped<IServiceManager, ServiceManager>();

builder.Services.AddScoped<IRepositoryManager, RepositoryManager>();

builder.Services.AddDbContext<Context>(builderDb =>
{
    var connectionString = builder.Configuration.GetConnectionString("Database");

    builderDb.UseNpgsql(connectionString);
});

using var scope = builder.Services.BuildServiceProvider().CreateScope();
await using var dbContext = scope.ServiceProvider.GetRequiredService<Context>();
await dbContext.Database.MigrateAsync();

builder.Services.AddTransient<ExceptionHandlingMiddleware>();


builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();


app.UseSwagger();
app.UseSwaggerUI();

app.UseMiddleware<ExceptionHandlingMiddleware>();
app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();