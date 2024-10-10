﻿// <auto-generated />
using Database;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace Database.Migrations
{
    [DbContext(typeof(ApplicationContext))]
    [Migration("20240527204418_InitialMigration")]
    partial class InitialMigration
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.19")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("Database.Models.Generos", b =>
                {
                    b.Property<int>("GeneroId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("GeneroId"));

                    b.Property<string>("Nombre")
                        .IsRequired()
                        .HasMaxLength(150)
                        .HasColumnType("nvarchar(150)");

                    b.HasKey("GeneroId");

                    b.ToTable("Generos", (string)null);
                });

            modelBuilder.Entity("Database.Models.Productora", b =>
                {
                    b.Property<int>("ProductoraId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ProductoraId"));

                    b.Property<string>("Nombre")
                        .IsRequired()
                        .HasMaxLength(150)
                        .HasColumnType("nvarchar(150)");

                    b.HasKey("ProductoraId");

                    b.ToTable("Productoras", (string)null);
                });

            modelBuilder.Entity("Database.Models.Series", b =>
                {
                    b.Property<int>("SerieId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("SerieId"));

                    b.Property<string>("Enlaces")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Nombre")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("nvarchar(255)");

                    b.Property<string>("Portada")
                        .IsRequired()
                        .HasColumnType("varchar(max)");

                    b.Property<int>("ProductoraId")
                        .HasColumnType("int");

                    b.HasKey("SerieId");

                    b.HasIndex("ProductoraId");

                    b.ToTable("Series", (string)null);
                });

            modelBuilder.Entity("Database.Models.SeriesGeneros", b =>
                {
                    b.Property<int>("SerieId")
                        .HasColumnType("int");

                    b.Property<int>("GeneroId")
                        .HasColumnType("int");

                    b.Property<bool>("primario")
                        .HasColumnType("bit");

                    b.HasKey("SerieId", "GeneroId");

                    b.HasIndex("GeneroId");

                    b.ToTable("SeriesGeneros", (string)null);
                });

            modelBuilder.Entity("Database.Models.Series", b =>
                {
                    b.HasOne("Database.Models.Productora", "Productora")
                        .WithMany("SerieProducturaLista")
                        .HasForeignKey("ProductoraId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Productora");
                });

            modelBuilder.Entity("Database.Models.SeriesGeneros", b =>
                {
                    b.HasOne("Database.Models.Generos", "Genero")
                        .WithMany("SeriesGenerosLista")
                        .HasForeignKey("GeneroId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Database.Models.Series", "Series")
                        .WithMany("SeriesGeneroLista")
                        .HasForeignKey("SerieId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Genero");

                    b.Navigation("Series");
                });

            modelBuilder.Entity("Database.Models.Generos", b =>
                {
                    b.Navigation("SeriesGenerosLista");
                });

            modelBuilder.Entity("Database.Models.Productora", b =>
                {
                    b.Navigation("SerieProducturaLista");
                });

            modelBuilder.Entity("Database.Models.Series", b =>
                {
                    b.Navigation("SeriesGeneroLista");
                });
#pragma warning restore 612, 618
        }
    }
}
