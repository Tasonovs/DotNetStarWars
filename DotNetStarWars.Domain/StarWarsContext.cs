using DotNetStarWars.Domain.Models.Characters;
using DotNetStarWars.Domain.Models.Films;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
#pragma warning disable CS8618

namespace DotNetStarWars.Domain;

public class StarWarsContext : DbContext
{
    private readonly IConfiguration _configuration;

    public StarWarsContext(DbContextOptions<StarWarsContext> options)
        : base(options)
    {
    }
    public StarWarsContext(DbContextOptions<StarWarsContext> options, IConfiguration configuration)
        : base(options)
    {
        _configuration = configuration;
    }
    
    public DbSet<Character> Characters { get; set; }
    public DbSet<Film> Films { get; set; }

    public override int SaveChanges()
    {
        // ChangeTracker.DetectChanges();
        // update JSON file .GetAwaiter().GetResult();

        return base.SaveChanges();
    }

    public override async Task<int> SaveChangesAsync(CancellationToken cancellationToken = new())
    {
        // ChangeTracker.DetectChanges();
        // update JSON file, get file path from _configuration

        return await base.SaveChangesAsync(cancellationToken);
    }
}