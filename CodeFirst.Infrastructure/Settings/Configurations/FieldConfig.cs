using CodeFirst.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CodeFirst.Infrastructure.Settings.Configurations
{
    public class FieldConfig : IEntityTypeConfiguration<Field>
    {
        public void Configure(EntityTypeBuilder<Field> builder)
        {
            builder.ToTable("Field");

            builder.HasKey(a => a.Id);

            builder.Property(a => a.Id)
                   .HasColumnName("IdField")
                   .HasComment("Identificador del Field")
                   .IsRequired();

            builder.Property(a => a.Code)
                   .HasColumnName("Code")
                   .HasColumnType<string>("nvarchar(50)")
                   .HasComment("Codigo del Field")
                   .HasMaxLength(50)
                   .IsRequired();

            builder.Property(a => a.Name)
                   .HasColumnName("Name")
                   .HasColumnType<string>("nvarchar(50)")
                   .HasComment("Nombre del Field")
                   .IsRequired();
        }
    }
}
