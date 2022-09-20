using Microsoft.EntityFrameworkCore;

using LocaleCounter.Entities;

namespace LocaleCounter.Data;

public class LocalizationDBContext : DbContext
{
    public DbSet<Culture>? Cultures { get; set; }
    public DbSet<Word>? Words { get; set; }

     public LocalizationDBContext(DbContextOptions<LocalizationDBContext> options)
            : base(options)
    {
    }

    // protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    // {
        // optionsBuilder.UseInMemoryDatabase("LocaleCounter");
    // }
}
