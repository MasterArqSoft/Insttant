﻿// <auto-generated />
using CodeFirst.Infrastructure.Settings;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace CodeFirst.Infrastructure.Migrations
{
    [DbContext(typeof(CodeFirstContext))]
    partial class CodeFirstContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.6")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("CodeFirst.Domain.Entities.Field", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("IdField")
                        .HasComment("Identificador del Field")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Code")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)")
                        .HasColumnName("Code")
                        .HasComment("Codigo del Field");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(50)")
                        .HasColumnName("Name")
                        .HasComment("Nombre del Field");

                    b.HasKey("Id");

                    b.ToTable("Field");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Code = "F-0001",
                            Name = "Primer nombre"
                        },
                        new
                        {
                            Id = 2,
                            Code = "F-0002",
                            Name = "Segundo nombre"
                        },
                        new
                        {
                            Id = 3,
                            Code = "F-0003",
                            Name = "Primer apellido"
                        },
                        new
                        {
                            Id = 4,
                            Code = "F-0004",
                            Name = "Segundo apellido"
                        },
                        new
                        {
                            Id = 5,
                            Code = "F-0005",
                            Name = "Tipo documento"
                        },
                        new
                        {
                            Id = 6,
                            Code = "F-0006",
                            Name = "Número de documento"
                        },
                        new
                        {
                            Id = 7,
                            Code = "F-0007",
                            Name = "Email"
                        },
                        new
                        {
                            Id = 8,
                            Code = "F-0007",
                            Name = "Valor Seguro"
                        });
                });

            modelBuilder.Entity("CodeFirst.Domain.Entities.Flow", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("IdFlow")
                        .HasComment("Identificador del Flow")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Code")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)")
                        .HasColumnName("Code")
                        .HasComment("Codigo del Flow");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(50)")
                        .HasColumnName("Name")
                        .HasComment("Nombre del Flow");

                    b.HasKey("Id");

                    b.ToTable("Flow");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Code = "P-0001",
                            Name = "Registrar Usuario"
                        },
                        new
                        {
                            Id = 2,
                            Code = "P-0002",
                            Name = "Solicitar poliza de seguro"
                        });
                });

            modelBuilder.Entity("CodeFirst.Domain.Entities.Step", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("IdStep")
                        .HasComment("Identificador del Step")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Code")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)")
                        .HasColumnName("Code")
                        .HasComment("Codigo del Step");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(50)")
                        .HasColumnName("Name")
                        .HasComment("Nombre del Step");

                    b.HasKey("Id");

                    b.ToTable("Step");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Code = "STP-0001",
                            Name = "RegisterUserAsync"
                        },
                        new
                        {
                            Id = 2,
                            Code = "STP-0002",
                            Name = "CreateSecureAsync"
                        },
                        new
                        {
                            Id = 3,
                            Code = "STP-0003",
                            Name = "SendEmailAsync"
                        },
                        new
                        {
                            Id = 4,
                            Code = "STP-0004",
                            Name = "ActiveUserAsync"
                        },
                        new
                        {
                            Id = 5,
                            Code = "STP-0005",
                            Name = "ActiveSecureAsync"
                        });
                });

            modelBuilder.Entity("CodeFirst.Domain.Entities.StepToFlow", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("IdStepToFlow")
                        .HasComment("Identificador la StepToFlow")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("IdField")
                        .HasColumnType("int");

                    b.Property<int>("IdFlow")
                        .HasColumnType("int")
                        .HasColumnName("IdFlow")
                        .HasComment("Identificador del Flow");

                    b.Property<int>("IdSetp")
                        .HasColumnType("int")
                        .HasColumnName("IdStep")
                        .HasComment("Identificador del step");

                    b.HasKey("Id");

                    b.HasIndex("IdField");

                    b.HasIndex("IdFlow");

                    b.HasIndex("IdSetp");

                    b.ToTable("StepToFlow");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            IdField = 1,
                            IdFlow = 1,
                            IdSetp = 1
                        },
                        new
                        {
                            Id = 2,
                            IdField = 2,
                            IdFlow = 1,
                            IdSetp = 1
                        },
                        new
                        {
                            Id = 3,
                            IdField = 3,
                            IdFlow = 1,
                            IdSetp = 1
                        },
                        new
                        {
                            Id = 4,
                            IdField = 4,
                            IdFlow = 1,
                            IdSetp = 1
                        },
                        new
                        {
                            Id = 5,
                            IdField = 5,
                            IdFlow = 1,
                            IdSetp = 1
                        },
                        new
                        {
                            Id = 6,
                            IdField = 6,
                            IdFlow = 1,
                            IdSetp = 1
                        },
                        new
                        {
                            Id = 7,
                            IdField = 7,
                            IdFlow = 1,
                            IdSetp = 1
                        },
                        new
                        {
                            Id = 8,
                            IdField = 5,
                            IdFlow = 1,
                            IdSetp = 2
                        },
                        new
                        {
                            Id = 9,
                            IdField = 6,
                            IdFlow = 1,
                            IdSetp = 2
                        },
                        new
                        {
                            Id = 10,
                            IdField = 7,
                            IdFlow = 2,
                            IdSetp = 3
                        },
                        new
                        {
                            Id = 11,
                            IdField = 5,
                            IdFlow = 2,
                            IdSetp = 3
                        },
                        new
                        {
                            Id = 12,
                            IdField = 6,
                            IdFlow = 2,
                            IdSetp = 3
                        },
                        new
                        {
                            Id = 13,
                            IdField = 8,
                            IdFlow = 2,
                            IdSetp = 3
                        },
                        new
                        {
                            Id = 14,
                            IdField = 5,
                            IdFlow = 2,
                            IdSetp = 4
                        },
                        new
                        {
                            Id = 15,
                            IdField = 6,
                            IdFlow = 2,
                            IdSetp = 4
                        },
                        new
                        {
                            Id = 16,
                            IdField = 5,
                            IdFlow = 2,
                            IdSetp = 5
                        },
                        new
                        {
                            Id = 17,
                            IdField = 6,
                            IdFlow = 2,
                            IdSetp = 5
                        });
                });

            modelBuilder.Entity("CodeFirst.Domain.Entities.StepToFlow", b =>
                {
                    b.HasOne("CodeFirst.Domain.Entities.Field", "Field")
                        .WithMany("StepToFlow")
                        .HasForeignKey("IdField")
                        .HasConstraintName("FK_StepToFlow_Field")
                        .IsRequired();

                    b.HasOne("CodeFirst.Domain.Entities.Flow", "Flow")
                        .WithMany("StepToFlow")
                        .HasForeignKey("IdFlow")
                        .HasConstraintName("FK_StepToFlow_Flow")
                        .IsRequired();

                    b.HasOne("CodeFirst.Domain.Entities.Step", "Step")
                        .WithMany("StepToFlow")
                        .HasForeignKey("IdSetp")
                        .HasConstraintName("FK_StepToFlow_Step")
                        .IsRequired();

                    b.Navigation("Field");

                    b.Navigation("Flow");

                    b.Navigation("Step");
                });

            modelBuilder.Entity("CodeFirst.Domain.Entities.Field", b =>
                {
                    b.Navigation("StepToFlow");
                });

            modelBuilder.Entity("CodeFirst.Domain.Entities.Flow", b =>
                {
                    b.Navigation("StepToFlow");
                });

            modelBuilder.Entity("CodeFirst.Domain.Entities.Step", b =>
                {
                    b.Navigation("StepToFlow");
                });
#pragma warning restore 612, 618
        }
    }
}
