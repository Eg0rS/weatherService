using Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Persistence;

public sealed class Context : DbContext
{
    public Context(DbContextOptions options)
        : base(options)
    {
    }

    public DbSet<User?> Users { get; set; }

    public DbSet<GeoPoint> GeoPoints { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder) =>
        modelBuilder.ApplyConfigurationsFromAssembly(typeof(Context).Assembly);
}