using CodeFirst.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CodeFirst.Infrastructure.Settings.Configurations
{
    public class StepToFlowConfig : IEntityTypeConfiguration<StepToFlow>
    {
        public void Configure(EntityTypeBuilder<StepToFlow> builder)
        {
            builder.ToTable("StepToFlow");

            builder.HasKey(i => i.Id);

            builder.Property(i => i.Id)
                   .HasColumnName("IdStepToFlow")
                   .HasComment("Identificador la StepToFlow")
                   .IsRequired();

            builder.Property(i => i.IdFlow)
                   .HasColumnName("IdFlow")
                   .HasColumnType<int>("int")
                   .HasComment("Identificador del Flow")
                   .IsRequired();

            builder.Property(i => i.IdSetp)
                   .HasColumnName("IdStep")
                   .HasColumnType<int>("int")
                   .HasComment("Identificador del step")
                   .IsRequired();

            builder.HasOne(d => d.Flow)
                   .WithMany(p => p.StepToFlow)
                   .HasForeignKey(d => d.IdFlow)
                   .OnDelete(DeleteBehavior.ClientSetNull)
                   .HasConstraintName("FK_StepToFlow_Flow");

            builder.HasOne(d => d.Step)
                   .WithMany(p => p.StepToFlow)
                   .HasForeignKey(d => d.IdSetp)
                   .OnDelete(DeleteBehavior.ClientSetNull)
                   .HasConstraintName("FK_StepToFlow_Step");

            builder.HasOne(d => d.Field)
                   .WithMany(p => p.StepToFlow)
                   .HasForeignKey(d => d.IdField)
                   .OnDelete(DeleteBehavior.ClientSetNull)
                   .HasConstraintName("FK_StepToFlow_Field");
        }
    }
}
