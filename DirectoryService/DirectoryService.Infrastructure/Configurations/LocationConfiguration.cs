using DirectoryService.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DirectoryService.Infrastructure.Configurations;

public class LocationConfiguration : IEntityTypeConfiguration<Location>
{
    public void Configure(EntityTypeBuilder<Location> builder)
    {
        builder.ToTable("locations");

        builder.HasKey(l => l.Id).HasName("pk_location");

        builder.ComplexProperty(l => l.Name, propertyBuilder =>
        {
            propertyBuilder.Property(n => n.Name)
                .HasColumnName("name")
                .IsRequired()
                .HasMaxLength(120);
        });

        builder.ComplexProperty(l => l.Address, propertyBuilder =>
        {
            propertyBuilder.Property(a => a.Country)
                .HasColumnName("country")
                .IsRequired()
                .HasMaxLength(100);

            propertyBuilder.Property(a => a.Town)
                .HasColumnName("town")
                .IsRequired()
                .HasMaxLength(100);

            propertyBuilder.Property(a => a.Street)
                .HasColumnName("street")
                .IsRequired()
                .HasMaxLength(150);

            propertyBuilder.Property(a => a.BuildingNumber)
                .HasColumnName("building_number")
                .IsRequired()
                .HasMaxLength(20);
        });

        builder.ComplexProperty(l => l.Timezone, propertyBuilder =>
        {
            propertyBuilder.Property(t => t.Timezone)
                .HasColumnName("timezone")
                .IsRequired()
                .HasMaxLength(100);
        });

        builder.Property(l => l.IsActive)
            .IsRequired()
            .HasColumnName("is_active");

        builder.Property(l => l.CreatedAt)
            .IsRequired()
            .HasColumnName("created_at");

        builder.Property(l => l.UpdatedAt)
            .IsRequired()
            .HasColumnName("updated_at");
    }
}
