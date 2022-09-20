using Microsoft.EntityFrameworkCore;

using LocaleCounter.Entities;

namespace LocaleCounter.Data;

public class LocalizationDBContext : DbContext
{
    public DbSet<Culture> Cultures { get; set; }
    public DbSet<Word> Words { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseInMemoryDatabase("LocaleCounter");
    }
}
