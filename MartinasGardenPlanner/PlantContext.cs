using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;

public class PlantContext : DbContext
{
    public DbSet<Plant> Plants { get; set; }

    public string DbPath { get; }

    public PlantContext()
    {
        var folder = Environment.SpecialFolder.LocalApplicationData;
        var path = Environment.GetFolderPath(folder);
        DbPath = System.IO.Path.Join(path, "plant.db");
    }

    // The following configures EF to create a Sqlite database file in the
    // special "local" folder for your platform.
    protected override void OnConfiguring(DbContextOptionsBuilder options)
        => options.UseSqlite($"Data Source={DbPath}");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Plant>()
            .HasMany(p => p.CompanionPlants)
            .WithMany()
            .UsingEntity<Dictionary<string, object>>(
                "PlantCompanions",
                j => j
                    .HasOne<Plant>() // The current plant
                    .WithMany() // The companion plants
                    .HasForeignKey("PlantId") // Foreign key for the current plant
                    .OnDelete(DeleteBehavior.Cascade), // Optional: Specify the delete behavior
                j => j
                    .HasOne<Plant>() // The companion plants
                    .WithMany() // The current plant
                    .HasForeignKey("CompanionPlantId") // Foreign key for the companion plants
                    .OnDelete(DeleteBehavior.Cascade), // Optional: Specify the delete behavior
                j =>
                {
                    // Optional: Configure additional properties of the join table if needed
                    j.Property<int>("Id").ValueGeneratedOnAdd();
                });

        // Configure other entity mappings here if needed
    }
}

public class Plant
{
    public int PlantId { get; set; }
    public string? CommonName { get; set; }
    public string? ScientificName { get; set; }

    /// <summary>
    /// full sun, semi-shade, shade
    /// </summary>
    public string? SunRequirement { get; set; }

    public bool IsWaterSmart { get; set; }
    public bool HasAggressiveRootSystem { get; set; }
    public double MaxHeight { get; set; }

    public string? GrowthRate { get; set; }
    public bool IsDeciduous { get; set; }
    public string? BirdsAttract { get; set; }
    public string? PestsProne { get; set; }

    //todo: should this rather be a list of other plants
    //public ICollection<Plant> CompanionPlants { get; set; }
    public List<Plant> CompanionPlants { get; } = [];
    //

    public string? CareInstructions { get; set; }

    /// <summary>
    /// sandy, loam, clay
    /// </summary>
    public string? SoilType { get; set; }

    public bool IsIndigenous { get; set; }
    public bool IsClimber { get; set; }
    public string? Color { get; set; }
    public bool IsFlowering { get; set; }

    /// <summary>
    /// bush, tree, ground cover, grass etc.
    /// </summary>
    public string? PlantType { get; set; }

    public bool IsPoisonous { get; set; }
}