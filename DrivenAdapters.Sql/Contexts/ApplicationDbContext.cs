using Domain.Model.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DrivenAdapters.Sql.Contexts
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions options) : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<UsuarioPoliza>().HasKey(x => new { x.UsuarioPolizaId, x.PolizaId }); // configuracion de FK para la tabla de relacion UsuarioPoliza

            modelBuilder.Entity<UsuarioVehiculo>().HasKey(x => new { x.UsuarioVehiculoId, x.VehiculoId }); // Configuracion de la FK para la tabla de relacion UsuarioVehiculo

            base.OnModelCreating(modelBuilder);
        }

        public DbSet<Usuario> Usuarios { get; set; }

        public DbSet<PolizaSeguros> PolizaSeguros { get; set; }

        public DbSet<PolizaVehiculo> PolizaVehiculos { get; set; }

        public DbSet<UsuarioPoliza> UsuarioPolizas { get; set; }

        public DbSet<UsuarioVehiculo> UsuarioVehiculos { get; set; }
    }
}
