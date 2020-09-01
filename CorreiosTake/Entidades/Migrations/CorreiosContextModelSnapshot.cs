﻿// <auto-generated />
using Entidades.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace Entidades.Migrations
{
    [DbContext(typeof(CorreiosContext))]
    partial class CorreiosContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.7")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("Entidades.Models.Cidade", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("IdEstado")
                        .HasColumnType("int");

                    b.Property<string>("NomeCidade")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Sigla")
                        .IsRequired()
                        .HasColumnType("nvarchar(2)")
                        .HasMaxLength(2);

                    b.HasKey("Id");

                    b.HasIndex("IdEstado");

                    b.HasIndex("Sigla")
                        .HasName("IXCidade_Sigla");

                    b.HasIndex("Sigla", "IdEstado")
                        .IsUnique()
                        .HasName("IXCidade_Sigla_Estado");

                    b.ToTable("Cidade");
                });

            modelBuilder.Entity("Entidades.Models.Estado", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("NomeEstado")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Sigla")
                        .IsRequired()
                        .HasColumnType("nvarchar(2)")
                        .HasMaxLength(2);

                    b.HasKey("Id");

                    b.HasIndex("Sigla")
                        .IsUnique()
                        .HasName("IXEstado_Sigla");

                    b.ToTable("Estado");
                });

            modelBuilder.Entity("Entidades.Models.Trexo", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("IdCidadeDestino")
                        .HasColumnType("int");

                    b.Property<int>("IdCidadePartida")
                        .HasColumnType("int");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("bit");

                    b.Property<int>("NumDiasTrexo")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("IdCidadeDestino");

                    b.HasIndex("IdCidadePartida");

                    b.ToTable("Trexo");
                });

            modelBuilder.Entity("Entidades.Models.Cidade", b =>
                {
                    b.HasOne("Entidades.Models.Estado", "Estado")
                        .WithMany("Cidades")
                        .HasForeignKey("IdEstado")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Entidades.Models.Trexo", b =>
                {
                    b.HasOne("Entidades.Models.Cidade", "CidadeDestino")
                        .WithMany("TrexosDeDestino")
                        .HasForeignKey("IdCidadeDestino")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("Entidades.Models.Cidade", "CidadePartida")
                        .WithMany("TrexosDePartida")
                        .HasForeignKey("IdCidadePartida")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}
