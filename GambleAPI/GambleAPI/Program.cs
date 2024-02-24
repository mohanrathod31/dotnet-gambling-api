using GambleAPI.GambleAPI.Application.Services;
using GambleAPI.GambleAPI.Infrastructure.Repositories;
using GambleAPI.Middleware;
using Microsoft.AspNetCore.Diagnostics;
using System.Text.Json;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddScoped<IPlayerRepository, PlayerRepository>();
builder.Services.AddScoped<IGameService, GameService>();
builder.Services.AddScoped<IRandomNumberGenerator, RandomNumberGenerator>();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
    app.UseDeveloperExceptionPage();
}
else
{
    // Custom exception handler for production
    app.UseExceptionHandler(a => a.Run(async context =>
    {
        var exceptionHandlerPathFeature = context.Features.Get<IExceptionHandlerPathFeature>();
        var exception = exceptionHandlerPathFeature?.Error;
        var result = JsonSerializer.Serialize(new { error = exception?.Message ?? "An error occurred." });
        context.Response.ContentType = "application/json";
        await context.Response.WriteAsync(result);
    }));
}

app.UseHttpsRedirection();

app.UseAuthorization();

//Registering Middleware
//app.UseMiddleware<ErrorHandlingMiddleware>();

app.MapControllers();

app.Run();
