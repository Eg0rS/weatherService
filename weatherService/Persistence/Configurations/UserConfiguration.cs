using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistence.Configurations;

internal sealed class UserConfiguration : IEntityTypeConfiguration<User>
{
    public void Configure(EntityTypeBuilder<User> builder)
    {
        builder.ToTable(nameof(User));

        builder.HasKey(user => user.Id);

        builder.Property(user => user.Id).ValueGeneratedOnAdd();

        builder.Property(user => user.Name).HasMaxLength(60);

        builder.Property(user => user.DateOfBirth).IsRequired();

        builder.Property(user => user.Address).HasMaxLength(100);

        builder.HasMany(user => user.GeoPoints)
            .WithOne()
            .HasForeignKey(point => point.UserId)
            .OnDelete(DeleteBehavior.Cascade);
    }
}