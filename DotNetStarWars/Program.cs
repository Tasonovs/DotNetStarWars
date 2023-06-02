using DotNetStarWars.Application.ApiClients;
using DotNetStarWars.Domain;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Refit;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
var dbConnectionString = builder.Configuration.GetConnectionString("DefaultConnection");
builder.Services.AddDbContext<StarWarsContext>(options => options.UseSqlite(dbConnectionString));

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var currentDomainAssemblies = AppDomain.CurrentDomain.GetAssemblies();
builder.Services.AddMediatR(currentDomainAssemblies);
builder.Services
    .AddRefitClient<ISwapiApiClient>()
    .ConfigureHttpClient(client =>
    {
        client.BaseAddress = new Uri("https://swapi.dev");
    });


var app = builder.Build();
ApplyMigrations(app);

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseDeveloperExceptionPage();
}

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