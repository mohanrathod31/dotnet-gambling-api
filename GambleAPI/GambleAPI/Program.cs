using GambleAPI.Middleware;
using GambleAPI.Repositories;

var builder = WebApplication.CreateBuilder(args);

// Registering PlayerRepository.
builder.Services.AddScoped<IPlayerRepository, PlayerRepository>();

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

//Registering Middleware
app.UseMiddleware<ErrorHandlingMiddleware>();

app.MapControllers();

app.Run();
