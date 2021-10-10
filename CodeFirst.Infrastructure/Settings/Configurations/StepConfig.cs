using CodeFirst.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CodeFirst.Infrastructure.Settings.Configurations
{
    public class StepConfig : IEntityTypeConfiguration<Step>
    {
        public void Configure(EntityTypeBuilder<Step> builder)
        {
            builder.ToTable("Step");

            builder.HasKey(a => a.Id);

            builder.Property(a => a.Id)
                   .HasColumnName("IdStep")
                   .HasComment("Identificador del Step")
                   .IsRequired();

            builder.Property(a => a.Code)
                   .HasColumnName("Code")
                   .HasColumnType<string>("nvarchar(50)")
                   .HasComment("Codigo del Step")
                   .HasMaxLength(50)
                   .IsRequired();

            builder.Property(a => a.Name)
                   .HasColumnName("Name")
                   .HasColumnType<string>("nvarchar(50)")
                   .HasComment("Nombre del Step")
                   .IsRequired();


        }
    }
}
