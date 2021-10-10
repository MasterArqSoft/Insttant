using CodeFirst.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CodeFirst.Infrastructure.Settings.Configurations
{
    public class FlowConfig : IEntityTypeConfiguration<Flow>
    {
        public void Configure(EntityTypeBuilder<Flow> builder)
        {
            builder.ToTable("Flow");

            builder.HasKey(a => a.Id);

            builder.Property(a => a.Id)
                   .HasColumnName("IdFlow")
                   .HasComment("Identificador del Flow")
                   .IsRequired();

            builder.Property(a => a.Code)
                   .HasColumnName("Code")
                   .HasColumnType<string>("nvarchar(50)")
                   .HasComment("Codigo del Flow")
                   .HasMaxLength(50)
                   .IsRequired();

            builder.Property(a => a.Name)
                   .HasColumnName("Name")
                   .HasColumnType<string>("nvarchar(50)")
                   .HasComment("Nombre del Flow")
                   .IsRequired();
        }
    }
}
