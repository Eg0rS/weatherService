using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistence.Configurations;

internal sealed class GeoPointConfiguration : IEntityTypeConfiguration<GeoPoint>
{
    public void Configure(EntityTypeBuilder<GeoPoint> builder)
    {
        builder.ToTable(nameof(GeoPoint));
        
        builder.HasKey(point => point.Id);
        
        builder.Property(point => point.Id).ValueGeneratedOnAdd();
        
        builder.Property(point => point.Latitude).IsRequired();
        
        builder.Property(point => point.Longitude).IsRequired();
        builder.Property(point => point.PointType).HasMaxLength(50);
        
        builder.Property(point => point.DateAdded).IsRequired();
    }
}