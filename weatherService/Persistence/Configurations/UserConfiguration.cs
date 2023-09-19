using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistence.Configurations;

internal sealed class UserConfiguration : IEntityTypeConfiguration<User>
{
    public void Configure(EntityTypeBuilder<User> builder)
    {
        builder.ToTable(nameof(User));

        builder.HasKey(owner => owner.Id);

        builder.Property(account => account.Id).ValueGeneratedOnAdd();

        builder.Property(owner => owner.Name).HasMaxLength(60);

        builder.Property(owner => owner.DateOfBirth).IsRequired();

        builder.Property(owner => owner.Address).HasMaxLength(100);

        builder.HasMany(owner => owner.GeoPoints)
            .WithOne()
            .HasForeignKey(account => account.UserId)
            .OnDelete(DeleteBehavior.Cascade);
    }
}