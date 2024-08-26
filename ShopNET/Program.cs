using Microsoft.EntityFrameworkCore;
using ShopNET.Repository;
using ShopNET.Services;
using ShopNET.Interfaces;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<ShopNETDBContext>(optionsBuilder => optionsBuilder.UseNpgsql(builder.Configuration.GetConnectionString("DefaultConnection")));
builder.Services.AddScoped<IItemService, ItemService>();   // tell to use ItemService as implementation of IItemService
builder.Services.AddScoped<IUserService, UserService>();

builder.Services.AddControllers();
// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// builder.Services.AddHttpContextAccessor();
// builder.Services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();
// string connectionString = "Server=172.17.0.2;Port=5432;User Id=user;Password=pass;Database=mydb;";

var app = builder.Build();


// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

// app.UseHttpsRedirection();

// app.MapGet("/weatherforecast", () =>
// {
//     var forecast = Enumerable.Range(1, 5).Select(index =>
//         new WeatherForecast
//         (
//             DateOnly.FromDateTime(DateTime.Now.AddDays(index)),
//             Random.Shared.Next(-20, 55),
//             summaries[Random.Shared.Next(summaries.Length)]
//         ))
//         .ToArray();
//     return forecast;
// })
// .WithName("GetWeatherForecast")
// .WithOpenApi();

app.UseExceptionHandler("/error");   // reroute code errors to this controller so we get HTTP errors instead
app.MapControllers();
app.UseRouting();
app.Run();
