using Microsoft.EntityFrameworkCore;
using ProductWebApi;

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
//var dbHost = "localhost";
//var dbName = "dms_product";

//var connectionString = $"Data Source={dbHost}; Initial Catalog={dbName}; integrated security=true";
var connectionString = $"Data Source={dbHost}; Initial Catalog={dbName}; User=sa; Password={dbpass}";

builder.Services.AddDbContext<ProductDbContext>(x => x.UseSqlServer(connectionString));

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
