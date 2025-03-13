using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new OpenApiInfo { Title = "Weather API", Version = "v1" });
});

var app = builder.Build();

// Enable Swagger for API documentation
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI(c =>
    {
        c.SwaggerEndpoint("/swagger/v1/swagger.json", "Weather API v1");
    });
}

// Use Static Files & HTTPS Redirection
app.UseStaticFiles();
app.UseHttpsRedirection();

// Sample Weather Data Store (In-memory)
var weatherData = new List<WeatherForecast>
{
    new WeatherForecast(1, DateOnly.FromDateTime(DateTime.Now.AddDays(1)), 25, "Warm"),
    new WeatherForecast(2, DateOnly.FromDateTime(DateTime.Now.AddDays(2)), 30, "Hot"),
    new WeatherForecast(3, DateOnly.FromDateTime(DateTime.Now.AddDays(3)), 15, "Chilly")
};

// 📌 CRUD API Endpoints

// ✅ Get All Weather Forecasts
app.MapGet("/weatherforecast", () => weatherData)
   .WithName("GetAllWeather");

// ✅ Get Weather by ID
app.MapGet("/weatherforecast/{id}", (int id) =>
{
    var weather = weatherData.FirstOrDefault(w => w.Id == id);
    return weather is not null ? Results.Ok(weather) : Results.NotFound($"Weather with ID {id} not found.");
})
.WithName("GetWeatherById");

// ✅ Create a New Weather Entry
app.MapPost("/weatherforecast", ([FromBody] WeatherForecast newWeather) =>
{
    newWeather.Id = weatherData.Count + 1;
    weatherData.Add(newWeather);
    return Results.Created($"/weatherforecast/{newWeather.Id}", newWeather);
})
.WithName("CreateWeather");

// ✅ Update Weather by ID
app.MapPut("/weatherforecast/{id}", (int id, [FromBody] WeatherForecast updatedWeather) =>
{
    var weather = weatherData.FirstOrDefault(w => w.Id == id);
    if (weather is null) return Results.NotFound($"Weather with ID {id} not found.");

    weather.Date = updatedWeather.Date;
    weather.TemperatureC = updatedWeather.TemperatureC;
    weather.Summary = updatedWeather.Summary;
    
    return Results.Ok(weather);
})
.WithName("UpdateWeather");

// ✅ Delete Weather by ID
app.MapDelete("/weatherforecast/{id}", (int id) =>
{
    var weather = weatherData.FirstOrDefault(w => w.Id == id);
    if (weather is null) return Results.NotFound($"Weather with ID {id} not found.");

    weatherData.Remove(weather);
    return Results.Ok($"Weather with ID {id} deleted.");
})
.WithName("DeleteWeather");

// Run the application
app.Run();

// 📌 Weather Forecast Class
class WeatherForecast
{
    public int Id { get; set; }
    public DateOnly Date { get; set; }
    public int TemperatureC { get; set; }
    public string? Summary { get; set; }

    public int TemperatureF => 32 + (int)(TemperatureC / 0.5556);

    public WeatherForecast(int id, DateOnly date, int temperatureC, string summary)
    {
        Id = id;
        Date = date;
        TemperatureC = temperatureC;
        Summary = summary;
    }
}
