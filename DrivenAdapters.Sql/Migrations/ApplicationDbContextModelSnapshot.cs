﻿// <auto-generated />
using System;
using DrivenAdapters.Sql.Contexts;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace SistemaDeSeguros.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    partial class ApplicationDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.8")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("Domain.Model.Entities.PolizaSeguros", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<DateTime>("FechaCompra")
                        .HasColumnType("datetime2");

                    b.Property<string>("NombrePoliza")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("TarifaPoliza")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("PolizaSeguros");
                });

            modelBuilder.Entity("Domain.Model.Entities.PolizaVehiculo", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("ColorVehiculo")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Linea")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("MarcaVehiculo")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("VehiculoActivo")
                        .HasColumnType("bit");

                    b.HasKey("Id");

                    b.ToTable("PolizaVehiculos");
                });

            modelBuilder.Entity("Domain.Model.Entities.Usuario", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("Apellido")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Cedula")
                        .HasColumnType("int");

                    b.Property<int>("Celular")
                        .HasColumnType("int");

                    b.Property<string>("Direccion")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("FechaNacimineto")
                        .HasColumnType("datetime2");

                    b.Property<string>("Nombre")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("UsuarioActivo")
                        .HasColumnType("bit");

                    b.HasKey("Id");

                    b.ToTable("Usuarios");
                });

            modelBuilder.Entity("Domain.Model.Entities.UsuarioPoliza", b =>
                {
                    b.Property<int>("UsuarioPolizaId")
                        .HasColumnType("int");

                    b.Property<int>("PolizaId")
                        .HasColumnType("int");

                    b.Property<int?>("PolizaSegurosId")
                        .HasColumnType("int");

                    b.Property<int?>("UsuarioId")
                        .HasColumnType("int");

                    b.HasKey("UsuarioPolizaId", "PolizaId");

                    b.HasIndex("PolizaSegurosId");

                    b.HasIndex("UsuarioId");

                    b.ToTable("UsuarioPolizas");
                });

            modelBuilder.Entity("Domain.Model.Entities.UsuarioVehiculo", b =>
                {
                    b.Property<int>("UsuarioVehiculoId")
                        .HasColumnType("int");

                    b.Property<int>("VehiculoId")
                        .HasColumnType("int");

                    b.Property<int?>("PolizaVehiculoId")
                        .HasColumnType("int");

                    b.Property<int?>("UsuarioId")
                        .HasColumnType("int");

                    b.HasKey("UsuarioVehiculoId", "VehiculoId");

                    b.HasIndex("PolizaVehiculoId");

                    b.HasIndex("UsuarioId");

                    b.ToTable("UsuarioVehiculos");
                });

            modelBuilder.Entity("Domain.Model.Entities.UsuarioPoliza", b =>
                {
                    b.HasOne("Domain.Model.Entities.PolizaSeguros", "PolizaSeguros")
                        .WithMany("UsuarioPolizas")
                        .HasForeignKey("PolizaSegurosId");

                    b.HasOne("Domain.Model.Entities.Usuario", "Usuario")
                        .WithMany("UsuarioPolizas")
                        .HasForeignKey("UsuarioId");

                    b.Navigation("PolizaSeguros");

                    b.Navigation("Usuario");
                });

            modelBuilder.Entity("Domain.Model.Entities.UsuarioVehiculo", b =>
                {
                    b.HasOne("Domain.Model.Entities.PolizaVehiculo", "PolizaVehiculo")
                        .WithMany("UsuarioVehiculo")
                        .HasForeignKey("PolizaVehiculoId");

                    b.HasOne("Domain.Model.Entities.Usuario", "Usuario")
                        .WithMany("UsuarioVehiculo")
                        .HasForeignKey("UsuarioId");

                    b.Navigation("PolizaVehiculo");

                    b.Navigation("Usuario");
                });

            modelBuilder.Entity("Domain.Model.Entities.PolizaSeguros", b =>
                {
                    b.Navigation("UsuarioPolizas");
                });

            modelBuilder.Entity("Domain.Model.Entities.PolizaVehiculo", b =>
                {
                    b.Navigation("UsuarioVehiculo");
                });

            modelBuilder.Entity("Domain.Model.Entities.Usuario", b =>
                {
                    b.Navigation("UsuarioPolizas");

                    b.Navigation("UsuarioVehiculo");
                });
#pragma warning restore 612, 618
        }
    }
}
