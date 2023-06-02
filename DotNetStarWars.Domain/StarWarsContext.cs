using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace DotNetStarWars.Domain;

public class StarWarsContext : DbContext
{
    private readonly IConfiguration _configuration;

    public StarWarsContext(DbContextOptions<StarWarsContext> options, IConfiguration configuration)
        : base(options)
    {
        _configuration = configuration;
    }

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