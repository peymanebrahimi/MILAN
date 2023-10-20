using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Migrations;
using WebApi1.Orders;
using WebApi1.Products;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
var connectionString = builder.Configuration.GetConnectionString("Database");

builder.Services.AddDbContext<OrdersDbContext>(
    options => options.UseSqlServer(connectionString,
                o => o.MigrationsHistoryTable(HistoryRepository.DefaultTableName, "orders")));

builder.Services.AddDbContext<ProductsDbContext>(
    options => options.UseSqlServer(connectionString,
    o => o.MigrationsHistoryTable(HistoryRepository.DefaultTableName, "products"))
    .UseQueryTrackingBehavior(QueryTrackingBehavior.NoTracking));

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

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
