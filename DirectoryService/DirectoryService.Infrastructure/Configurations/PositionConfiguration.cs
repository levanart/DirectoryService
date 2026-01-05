using DirectoryService.Domain.Entities.Position;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DirectoryService.Infrastructure.Configurations;

public class PositionConfiguration : IEntityTypeConfiguration<Position>
{
    public void Configure(EntityTypeBuilder<Position> builder)
    {
        builder.ToTable("positions");

        builder.HasKey(p => p.Id).HasName("pk_position");

        builder.ComplexProperty(p => p.Name, propertyBuilder =>
        {
            propertyBuilder.Property(n => n.Name)
                .HasColumnName("name")
                .IsRequired()
                .HasMaxLength(150);
        });

        builder.ComplexProperty(p => p.Description, propertyBuilder =>
        {
            propertyBuilder.Property(d => d.Description)
                .HasColumnName("description")
                .IsRequired()
                .HasMaxLength(1000);
        });

        builder.Property(p => p.IsActive)
            .IsRequired()
            .HasColumnName("is_active");

        builder.Property(p => p.CreatedAt)
            .IsRequired()
            .HasColumnName("created_at");

        builder.Property(p => p.UpdatedAt)
            .IsRequired()
            .HasColumnName("updated_at");
    }
}
