using Microsoft.EntityFrameworkCore;
using Productos.API;
using Productos.API.Dto;
using Productos.API.Entity;
using Productos.API.Interface;
using Productos.API.Repository;
using Productos.API.Services;
using Shared.Models.Repositories;
using Shared.Models.Repositories.Interfaces;
using Shared.Models.Services;
using Shared.Models.Services.Interfaces;

var builder = WebApplication.CreateBuilder(args);
var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");
// Add services to the container.

builder.Services.AddDbContext<ApplicationDbContext>(options => 
    options.UseSqlServer(connectionString));

//Registrar un servicio de aplicación
builder.Services.AddScoped<IStoredFileService, StoredFileService>();
builder.Services.AddScoped<ICrudRepository<Product, int>, ProductRepository>();
builder.Services.AddScoped<ICrudService<ProductDto, ProductResponseDto, int>, ProductService>();



builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddAutoMapper(typeof(Program));

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.UseStaticFiles();

app.MapControllers();

app.Run();
