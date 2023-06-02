using DotNetStarWars.Domain;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
var dbConnectionString = builder.Configuration.GetConnectionString("DefaultConnection");
builder.Services.AddDbContext<StarWarsContext>(options => options.UseSqlite(dbConnectionString));

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();
ApplyMigrations(app);

// Configure the HTTP request pipeline.

app.UseStaticFiles();
app.UseRouting();

app.MapControllers();
app.UseSwagger();
app.UseSwaggerUI();
app.MapFallbackToFile("/index.html");

app.Run();


void ApplyMigrations(WebApplication application)
{
    using var scope = application.Services.CreateScope();
    var erpContext = scope.ServiceProvider.GetRequiredService<StarWarsContext>();
    erpContext.Database.Migrate();
}