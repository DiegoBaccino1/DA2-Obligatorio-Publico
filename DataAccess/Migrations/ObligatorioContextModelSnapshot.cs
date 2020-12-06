﻿// <auto-generated />
using System;
using DataAccess;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace DataAccess.Migrations
{
    [DbContext(typeof(ObligatorioContext))]
    partial class ObligatorioContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.8")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("BuisnessLogic.Domain.PuntoTuristico", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Descripcion")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("ImagenId")
                        .HasColumnType("int");

                    b.Property<string>("Nombre")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("RegionId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("ImagenId");

                    b.HasIndex("RegionId");

                    b.ToTable("puntoTuristicos");
                });

            modelBuilder.Entity("Domain.CantHuespedes", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("CantAdultos")
                        .HasColumnType("int");

                    b.Property<int>("CantBebes")
                        .HasColumnType("int");

                    b.Property<int>("CantJubilados")
                        .HasColumnType("int");

                    b.Property<int>("CantNinios")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("huespedes");
                });

            modelBuilder.Entity("Domain.Categoria", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Nombre")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("categorias");
                });

            modelBuilder.Entity("Domain.DatosUsuario", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Apellido")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Mail")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Nombre")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("DatosUsuario");
                });

            modelBuilder.Entity("Domain.Hospedaje", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("CantidadEstrellas")
                        .HasColumnType("int");

                    b.Property<int>("Capacidad")
                        .HasColumnType("int");

                    b.Property<string>("Descripcion")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Direccion")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("NombreHospedaje")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("Ocupado")
                        .HasColumnType("bit");

                    b.Property<int>("PrecioPorNoche")
                        .HasColumnType("int");

                    b.Property<int>("PrecioTotalPeriodo")
                        .HasColumnType("int");

                    b.Property<double>("Puntaje")
                        .HasColumnType("float");

                    b.Property<int?>("PuntoTuristicoId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("PuntoTuristicoId");

                    b.ToTable("hospedajes");
                });

            modelBuilder.Entity("Domain.Imagen", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int?>("HospedajeId")
                        .HasColumnType("int");

                    b.Property<string>("Ruta")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("HospedajeId");

                    b.ToTable("imagenes");
                });

            modelBuilder.Entity("Domain.PuntoTuristicoCategoria", b =>
                {
                    b.Property<int>("PuntoTuristicoId")
                        .HasColumnType("int");

                    b.Property<int>("CategoriaId")
                        .HasColumnType("int");

                    b.HasKey("PuntoTuristicoId", "CategoriaId");

                    b.HasIndex("CategoriaId");

                    b.ToTable("puntoTuristicoCategoria");
                });

            modelBuilder.Entity("Domain.Region", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Nombre")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("regiones");
                });

            modelBuilder.Entity("Domain.Resenia", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int?>("DatosId")
                        .HasColumnType("int");

                    b.Property<int?>("HospedajeId")
                        .HasColumnType("int");

                    b.Property<int>("Puntaje")
                        .HasColumnType("int");

                    b.Property<string>("Texto")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("DatosId");

                    b.HasIndex("HospedajeId");

                    b.ToTable("Resenia");
                });

            modelBuilder.Entity("Domain.Reserva", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("ApellidoTurista")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("CantidadHuespedes")
                        .HasColumnType("int");

                    b.Property<DateTime>("CheckIn")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("CheckOut")
                        .HasColumnType("datetime2");

                    b.Property<string>("Descripcion")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Estado")
                        .HasColumnType("int");

                    b.Property<int?>("HospedajeId")
                        .HasColumnType("int");

                    b.Property<string>("MailTurista")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("NombreTurista")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("HospedajeId");

                    b.ToTable("reservas");
                });

            modelBuilder.Entity("Domain.Usuario", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Contrasenia")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("DatosId")
                        .HasColumnType("int");

                    b.Property<bool>("IsAdmin")
                        .HasColumnType("bit");

                    b.HasKey("Id");

                    b.HasIndex("DatosId");

                    b.ToTable("usuarios");
                });

            modelBuilder.Entity("BuisnessLogic.Domain.PuntoTuristico", b =>
                {
                    b.HasOne("Domain.Imagen", "Imagen")
                        .WithMany()
                        .HasForeignKey("ImagenId");

                    b.HasOne("Domain.Region", null)
                        .WithMany("Puntos")
                        .HasForeignKey("RegionId");
                });

            modelBuilder.Entity("Domain.Hospedaje", b =>
                {
                    b.HasOne("BuisnessLogic.Domain.PuntoTuristico", "PuntoTuristico")
                        .WithMany()
                        .HasForeignKey("PuntoTuristicoId");
                });

            modelBuilder.Entity("Domain.Imagen", b =>
                {
                    b.HasOne("Domain.Hospedaje", null)
                        .WithMany("Imagen")
                        .HasForeignKey("HospedajeId");
                });

            modelBuilder.Entity("Domain.PuntoTuristicoCategoria", b =>
                {
                    b.HasOne("Domain.Categoria", "Categoria")
                        .WithMany("PuntosTuristicosCategoria")
                        .HasForeignKey("CategoriaId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("BuisnessLogic.Domain.PuntoTuristico", "PuntoTuristico")
                        .WithMany("PuntosTuristicosCategoria")
                        .HasForeignKey("PuntoTuristicoId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Domain.Resenia", b =>
                {
                    b.HasOne("Domain.DatosUsuario", "Datos")
                        .WithMany()
                        .HasForeignKey("DatosId");

                    b.HasOne("Domain.Hospedaje", null)
                        .WithMany("Resenias")
                        .HasForeignKey("HospedajeId");
                });

            modelBuilder.Entity("Domain.Reserva", b =>
                {
                    b.HasOne("Domain.Hospedaje", "Hospedaje")
                        .WithMany()
                        .HasForeignKey("HospedajeId");
                });

            modelBuilder.Entity("Domain.Usuario", b =>
                {
                    b.HasOne("Domain.DatosUsuario", "Datos")
                        .WithMany()
                        .HasForeignKey("DatosId");
                });
#pragma warning restore 612, 618
        }
    }
}
