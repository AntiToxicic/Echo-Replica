using Echo_Replica.Core.Entities;
using Echo_Replica.Infrastructure.Configurations;
using Microsoft.EntityFrameworkCore;

namespace Echo_Replica.Infrastructure;

public sealed class SqliteContext : DbContext
{
    public SqliteContext(DbContextOptions<SqliteContext> options) : base(options)
    {
        Database.EnsureCreated();
    }

    public DbSet<Replica> Replicas { get; set; } = null!;
    public DbSet<Word> Words { get; set; } = null!;
    public DbSet<ReplicaWord> ReplicaWords { get; set; } = null!;

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.ApplyConfigurationsFromAssembly(typeof(AssemblyMarker).Assembly);
    }
}