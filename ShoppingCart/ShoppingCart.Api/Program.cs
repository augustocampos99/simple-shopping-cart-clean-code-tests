using Microsoft.EntityFrameworkCore;
using ShoppingCart.Domain.Interfaces.Repositories;
using ShoppingCart.Domain.Interfaces.Services;
using ShoppingCart.Domain.Services;
using ShoppingCart.Infrastructure.Context;
using ShoppingCart.Infrastructure.Repositories;

var builder = WebApplication.CreateBuilder(args);

// DI Context
var connectionString = builder.Configuration.GetConnectionString("MySQLConnection");
builder.Services.AddDbContext<MySQLContext>(options =>
        options.UseMySql(connectionString, ServerVersion.AutoDetect(connectionString)));

// DI Repositories
builder.Services.AddTransient<IProductRepository, ProductRepository>();

// DI Services
builder.Services.AddTransient<IProductService, ProductService>();

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
