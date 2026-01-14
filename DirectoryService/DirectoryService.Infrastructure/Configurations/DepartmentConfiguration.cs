using DirectoryService.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DirectoryService.Infrastructure.Configurations;

public class DepartmentConfiguration : IEntityTypeConfiguration<Department>
{
    public void Configure(EntityTypeBuilder<Department> builder)
    {
        builder.ToTable("departments");

        builder.HasKey(d => d.Id).HasName("pk_department");

        builder.ComplexProperty(d => d.Name, propertyBuilder =>
        {
            propertyBuilder.Property(n => n.Name)
                .HasColumnName("name")
                .IsRequired()
                .HasMaxLength(200);
        });

        builder.ComplexProperty(d => d.Identifier, propertyBuilder =>
        {
            propertyBuilder.Property(i => i.Identifier)
                .HasColumnName("identifier")
                .IsRequired()
                .HasMaxLength(150);
        });

        builder.Property(d => d.ParentId)
            .IsRequired(false)
            .HasColumnName("parent_id");

        builder.Property(d => d.Path)
            .IsRequired()
            .HasColumnName("path")
            .HasMaxLength(500);

        builder.Property(d => d.Depth)
            .IsRequired()
            .HasColumnName("depth");

        builder.Property(d => d.IsActive)
            .IsRequired()
            .HasColumnName("is_active");

        builder.Property(d => d.CreatedAt)
            .IsRequired()
            .HasColumnName("created_at");

        builder.Property(d => d.UpdatedAt)
            .IsRequired()
            .HasColumnName("updated_at");
    }
}