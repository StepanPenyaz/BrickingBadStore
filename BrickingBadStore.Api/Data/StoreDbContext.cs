using BrickingBadStore.Api.Models;
using Microsoft.EntityFrameworkCore;

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

        // Seed data
        modelBuilder.Entity<Store>().HasData(
            new Store { Id = 1, Name = "Bricking Bad Store" }
        );

        modelBuilder.Entity<Cabinet>().HasData(
            new Cabinet { Id = 1, Name = "Cabinet A", StoreId = 1 },
            new Cabinet { Id = 2, Name = "Cabinet B", StoreId = 1 },
            new Cabinet { Id = 3, Name = "Cabinet C", StoreId = 1 }
        );

        modelBuilder.Entity<Group>().HasData(
            new Group { Id = 1, CabinetId = 1 },
            new Group { Id = 2, CabinetId = 1 },
            new Group { Id = 3, CabinetId = 2 },
            new Group { Id = 4, CabinetId = 2 },
            new Group { Id = 5, CabinetId = 3 }
        );

        modelBuilder.Entity<Container>().HasData(
            // Group 1 containers
            new Container { Id = 1, Capacity = 10, GroupId = 1 },
            new Container { Id = 2, Capacity = 20, GroupId = 1 },
            new Container { Id = 3, Capacity = 15, GroupId = 1 },
            // Group 2 containers
            new Container { Id = 4, Capacity = 25, GroupId = 2 },
            new Container { Id = 5, Capacity = 30, GroupId = 2 },
            // Group 3 containers
            new Container { Id = 6, Capacity = 12, GroupId = 3 },
            new Container { Id = 7, Capacity = 18, GroupId = 3 },
            new Container { Id = 8, Capacity = 22, GroupId = 3 },
            new Container { Id = 9, Capacity = 28, GroupId = 3 },
            // Group 4 containers
            new Container { Id = 10, Capacity = 35, GroupId = 4 },
            new Container { Id = 11, Capacity = 40, GroupId = 4 },
            // Group 5 containers
            new Container { Id = 12, Capacity = 50, GroupId = 5 },
            new Container { Id = 13, Capacity = 45, GroupId = 5 },
            new Container { Id = 14, Capacity = 55, GroupId = 5 }
        );
    }
}
