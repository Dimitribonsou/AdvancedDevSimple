using AdvancedDevSample.Api.Middlewares;
using AdvancedDevSample.Application.Services;
using AdvancedDevSample.Domain.Entities;
using AdvancedDevSample.Domain.Interfaces.Order;
using AdvancedDevSample.Domain.Interfaces.Products;
using AdvancedDevSample.Infrastructure.Repositories;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();

builder.Services.AddEndpointsApiExplorer();

// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
//builder.Services.AddOpenApi();

//
builder.Services.AddSwaggerGen(options =>
{
    var basePath = AppContext.BaseDirectory;

    foreach (var xmlFile in Directory.GetFiles(basePath, "*.xml"))
    {
        options.IncludeXmlComments(xmlFile);
    }
});

// =============Dependances Application ===================
builder.Services.AddScoped<IProductRepository, EfProductRepository>();

builder.Services.AddSingleton<IOrderRepository, InMemoryOrderRepository>();
builder.Services.AddScoped<OrderService>();
// InMemory Repository
builder.Services.AddSingleton<IProductRepository, InMemoryProductRepository>();
// =============Dependances Infrastructure ===================
builder.Services.AddScoped<ProductService>();

var app = builder.Build();

var repository = app.Services.GetRequiredService<IProductRepository>();

if (repository is InMemoryProductRepository inMemoryRepo)
{
    var product = new Product(
        id: Guid.NewGuid(),
        name: "Iphone 4",
        price: 300,
        isActive: true
    );

    inMemoryRepo.Seed(product);
}

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    //app.MapOpenApi();
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.UseMiddleware<ExceptionHandlingMiddleware>();

app.MapControllers();

app.Run();
public partial class Program { }