using JetFlow.Products.Api.EndPoints.FlightProduct.Group;
using JetFlow.Products.Api.Extensions;
using JwtFlow.Infra.Data.Context;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");

builder.Services.AddDbContext<AppDbContext>(x =>
    x.UseSqlServer(connectionString,
        b => b.MigrationsAssembly("JetFlow.Products.Api")));
builder.Services.AddOpenApi();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddDependencyInjection();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.MapFlight();        
app.UseHttpsRedirection();
app.Run();