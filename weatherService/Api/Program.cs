using Api.Middleware;
using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Persistence;
using Repository;
using Repository.Abstractions;
using Service;
using Service.Abstractions;

var builder = WebApplication.CreateBuilder(args);


builder.Services.AddControllers();

builder.Services.AddScoped<IServiceManager, ServiceManager>();

builder.Services.AddScoped<IRepositoryManager, RepositoryManager>();

builder.Services.AddDbContext<Context>(builderDb =>
{
    var connectionString = builder.Configuration.GetConnectionString("Database");
    Console.WriteLine(connectionString);
    builderDb.UseNpgsql(connectionString);
}, ServiceLifetime.Singleton);


builder.Services.AddTransient<ExceptionHandlingMiddleware>();


builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

using (var context = (Context)app.Services.GetService(typeof(Context))!)
{
    context.Database.EnsureCreated();
}


app.UseSwagger();
app.UseSwaggerUI();

app.UseMiddleware<ExceptionHandlingMiddleware>();
app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();