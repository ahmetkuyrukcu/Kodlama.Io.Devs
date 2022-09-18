using Kodlama.io.Devs.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace Kodlama.io.Devs.Persistence.Contexts;

public class BaseDbContext : DbContext
{
    protected IConfiguration Configuration { get; set; }

    public DbSet<ProgrammingLanguage> ProgrammingLanguages { get; set; }

    public DbSet<Technology> Technologies { get; set; }


    public BaseDbContext(DbContextOptions dbContextOptions, IConfiguration configuration) : base(dbContextOptions)
    {
        Configuration = configuration;
    }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        //if (!optionsBuilder.IsConfigured)
        //    base.OnConfiguring(
        //        optionsBuilder.UseSqlServer(Configuration.GetConnectionString("SomeConnectionString")));
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<ProgrammingLanguage>(x =>
        {
            x.ToTable("ProgrammingLanguages").HasKey(k => k.Id);
            x.Property(p => p.Id).HasColumnName("Id");
            x.Property(p => p.Name).HasColumnName("Name");
        });

        modelBuilder.Entity<Technology>(x =>
        {
            x.ToTable("Technologies").HasKey(k => k.Id);
            x.Property(p => p.Id).HasColumnName("Id");
            x.Property(p => p.Name).HasColumnName("Name");
            x.HasOne(p => p.ProgrammingLanguage).WithMany(p => p.Technologies).HasForeignKey(p => p.ProgrammingLanguageId);

        });

        var cSharpId = Guid.NewGuid();
        var javaId = Guid.NewGuid();

        ProgrammingLanguage[] programmingLanguageEntitySeeds = { new(cSharpId, "C#"), new(javaId, "Java") };

        Technology[] technologyEntitySeeds = { new(Guid.NewGuid(), "WPF") { ProgrammingLanguageId = cSharpId }, new(Guid.NewGuid(), ".NET") { ProgrammingLanguageId = cSharpId }, new(Guid.NewGuid(), "Spring") { ProgrammingLanguageId = javaId } };

        modelBuilder.Entity<ProgrammingLanguage>().HasData(programmingLanguageEntitySeeds);
        modelBuilder.Entity<Technology>().HasData(technologyEntitySeeds);
    }
}