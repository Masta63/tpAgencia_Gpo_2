using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace tpAgencia_Gpo_2
{
     class Conexion : DbContext
    {
        public DbSet<Usuario> usuarios { get; set; }
        public DbSet<Ciudad> ciudades { get; set; }
        public DbSet<Hotel> hoteles { get; set; }
        public DbSet<Vuelo> vuelos { get; set; }
        public DbSet<ReservaHotel> reservaHoteles { get; set; }
        public DbSet<ReservaVuelo> reservaVuelos { get; set; }




        private String _connectionStr = Properties.Resources.ConnectionStr;
        public Conexion() { }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(_connectionStr);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Ignore<Agencia>();//dejamos fuera del modelo a la clase logica

            modelBuilder.Entity<Usuario>()
                .ToTable("Usuarios")
                .HasKey(u => u.id);

            modelBuilder.Entity<Ciudad>()
                .ToTable("Ciudades")
                .HasKey(c => c.id);
            
            modelBuilder.Entity<Hotel>()
                .ToTable("Hoteles")
                .HasKey(h => h.id);

            modelBuilder.Entity<Vuelo>()
                .ToTable("Vuelos")
                .HasKey(v => v.id);

            modelBuilder.Entity<ReservaHotel>()
                .ToTable("ReservasHoteles")
                .HasKey(r => r.idReservaHotel);

            modelBuilder.Entity<ReservaVuelo>()
                .ToTable("ReservasVuelos")
                .HasKey(r => r.idReservaVuelo);
                

            

        }
    }
}
