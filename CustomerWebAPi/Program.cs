using CustomerWebAPi;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

//-----------------------------------DATABASE CONTEXT DEPENDENCY INJECTION---------------------//
var dbHost = Environment.GetEnvironmentVariable("DB_HOST");
var dbName = Environment.GetEnvironmentVariable("DB_NAME");
var dbpass = Environment.GetEnvironmentVariable("DB_SA_PASSWORD");

var connectionString = $"Data Source={dbHost}; Initial Catalog={dbName}; User=sa; Password={dbpass}";

builder.Services.AddDbContext<CustomerDbContext>(x => x.UseSqlServer(connectionString));

//============================================================================================//

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
