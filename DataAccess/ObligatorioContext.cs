using BuisnessLogic.Domain;
using Domain;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataAccess
{
    public class ObligatorioContext: DbContext
    {
        public DbSet<PuntoTuristico> puntoTuristicos { get; set; }
        public DbSet<Region> regiones { get; set; }
        public DbSet<Categoria> categorias { get; set; }
        public DbSet<PuntoTuristicoCategoria> puntoTuristicoCategoria { get; set; }
        public DbSet<Hospedaje> hospedajes { get; set; }
        public DbSet<Imagen> imagenes { get; set; }
        public DbSet<Reserva> reservas { get; set; }
        public DbSet<Usuario> usuarios { get; set; }
        public DbSet<CantHuespedes> huespedes { get; set; }
        public ObligatorioContext(DbContextOptions options) : base(options)
        {
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseLazyLoadingProxies();
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<PuntoTuristicoCategoria>()
                .HasKey(x => new { x.PuntoTuristicoId, x.CategoriaId });

            modelBuilder.Entity<PuntoTuristicoCategoria>()
                .HasOne(x => x.PuntoTuristico)
                .WithMany(x => x.PuntosTuristicosCategoria)
                .HasForeignKey(x => x.PuntoTuristicoId);

            modelBuilder.Entity<PuntoTuristicoCategoria>()
                .HasOne(x => x.Categoria)
                .WithMany(x => x.PuntosTuristicosCategoria)
                .HasForeignKey(x => x.CategoriaId);
        }
    }
}
