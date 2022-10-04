using Core.Security.Entities;
using Kodlama.Io.Devs.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace Kodlama.Io.Devs.Persistence.Contexts;

public class BaseDbContext : DbContext
{
    public DbSet<ProgrammingLanguage> ProgrammingLanguages { get; set; }

    public DbSet<Technology> Technologies { get; set; }

    public DbSet<User> Users { get; set; }

    public DbSet<OperationClaim> OperationClaims { get; set; }

    public DbSet<UserOperationClaim> UserOperationClaims { get; set; }

    public DbSet<RefreshToken> RefreshTokens { get; set; }

    protected IConfiguration Configuration { get; set; }

    public BaseDbContext(DbContextOptions dbContextOptions, IConfiguration configuration) : base(dbContextOptions)
    {
        Configuration = configuration;
    }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        // if (!optionsBuilder.IsConfigured)
        //     base.OnConfiguring(
        //         optionsBuilder.UseSqlServer(Configuration.GetConnectionString("SomeConnectionString")));
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Technology>(x =>
        {
            x.HasOne(p => p.ProgrammingLanguage).WithMany(p => p.Technologies).HasForeignKey(p => p.ProgrammingLanguageId).OnDelete(DeleteBehavior.Cascade);
        });

        var cSharpId = Guid.NewGuid();
        var javaId = Guid.NewGuid();

        ProgrammingLanguage[] programmingLanguageEntitySeeds = { new(cSharpId, "C#"), new(javaId, "Java") };

        Technology[] technologyEntitySeeds = { new(Guid.NewGuid(), "WPF") { ProgrammingLanguageId = cSharpId }, new(Guid.NewGuid(), ".NET") { ProgrammingLanguageId = cSharpId }, new(Guid.NewGuid(), "Spring") { ProgrammingLanguageId = javaId } };

        modelBuilder.Entity<ProgrammingLanguage>().HasData(programmingLanguageEntitySeeds);
        modelBuilder.Entity<Technology>().HasData(technologyEntitySeeds);
    }
}