using MediatR;
using Microsoft.EntityFrameworkCore;
using RestApiMocker.Api.CQRS.Queries;
using RestApiMocker.Data;
using RestApiMocker.Data.Entities;
using System.Reflection;

var builder = WebApplication.CreateBuilder(args);
builder.Configuration.AddJsonFile("appsettings.json");

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddDbContext<MockerContext>(options => options.UseSqlServer(builder.Configuration.GetConnectionString("MockerContext")));
builder.Services.AddMediatR(typeof(GetAllRulesQuery).Assembly); // add this if class lib used.
//builder.Services.AddMediatR(typeof(Program)); // add this if class lib used.
builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseAuthorization();

app.MapControllers();

app.Run();
