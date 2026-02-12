using Microsoft.EntityFrameworkCore;
using BrickingBadStore.Api.Models;

namespace BrickingBadStore.Api.Data;

public class StoreDbContext : DbContext
{
    public StoreDbContext(DbContextOptions<StoreDbContext> options) : base(options)
    {
    }

    public DbSet<Store> Stores { get; set; }
    public DbSet<Cabinet> Cabinets { get; set; }
    public DbSet<Group> Groups { get; set; }
    public DbSet<Container> Containers { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        // Configure relationships
        modelBuilder.Entity<Store>()
            .HasMany(s => s.Cabinets)
            .WithOne(c => c.Store)
            .HasForeignKey(c => c.StoreId);

        modelBuilder.Entity<Cabinet>()
            .HasMany(c => c.Groups)
            .WithOne(g => g.Cabinet)
            .HasForeignKey(g => g.CabinetId);

        modelBuilder.Entity<Group>()
            .HasMany(g => g.Containers)
            .WithOne(c => c.Group)
            .HasForeignKey(c => c.GroupId);

        // Seed data
        var storeId = 1;
        modelBuilder.Entity<Store>().HasData(
            new Store { Id = storeId, Name = "Bricking Bad Store" }
        );

        // Cabinet 1
        var cabinet1Id = 1;
        modelBuilder.Entity<Cabinet>().HasData(
            new Cabinet { Id = cabinet1Id, Name = "Cabinet A", StoreId = storeId }
        );

        // Groups for Cabinet 1
        var group1Id = 1;
        var group2Id = 2;
        modelBuilder.Entity<Group>().HasData(
            new Group { Id = group1Id, Name = "Group 1", CabinetId = cabinet1Id },
            new Group { Id = group2Id, Name = "Group 2", CabinetId = cabinet1Id }
        );

        // Containers for Group 1
        modelBuilder.Entity<Container>().HasData(
            new Container { Id = 1, Capacity = 100, GroupId = group1Id },
            new Container { Id = 2, Capacity = 150, GroupId = group1Id },
            new Container { Id = 3, Capacity = 200, GroupId = group1Id }
        );

        // Containers for Group 2
        modelBuilder.Entity<Container>().HasData(
            new Container { Id = 4, Capacity = 120, GroupId = group2Id },
            new Container { Id = 5, Capacity = 180, GroupId = group2Id }
        );

        // Cabinet 2
        var cabinet2Id = 2;
        modelBuilder.Entity<Cabinet>().HasData(
            new Cabinet { Id = cabinet2Id, Name = "Cabinet B", StoreId = storeId }
        );

        // Groups for Cabinet 2
        var group3Id = 3;
        modelBuilder.Entity<Group>().HasData(
            new Group { Id = group3Id, Name = "Group 3", CabinetId = cabinet2Id }
        );

        // Containers for Group 3
        modelBuilder.Entity<Container>().HasData(
            new Container { Id = 6, Capacity = 250, GroupId = group3Id },
            new Container { Id = 7, Capacity = 300, GroupId = group3Id },
            new Container { Id = 8, Capacity = 175, GroupId = group3Id },
            new Container { Id = 9, Capacity = 225, GroupId = group3Id }
        );
    }
}
