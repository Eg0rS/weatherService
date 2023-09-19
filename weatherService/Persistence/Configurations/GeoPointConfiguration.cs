using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistence.Configurations;

internal sealed class GeoPointConfiguration : IEntityTypeConfiguration<GeoPoint>
{
    public void Configure(EntityTypeBuilder<GeoPoint> builder)
    {
        builder.ToTable(nameof(GeoPoint));
        
        builder.HasKey(account => account.Id);
        
        builder.Property(account => account.Id).ValueGeneratedOnAdd();
        
        builder.Property(account => account.Latitude).IsRequired();
        
        builder.Property(account => account.Longitude).IsRequired();
        builder.Property(account => account.PointType).HasMaxLength(50);
        
        builder.Property(account => account.DateAdded).IsRequired();
    }
}