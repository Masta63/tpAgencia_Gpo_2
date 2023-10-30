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

            //tablas de la base
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


            
            
            //propiedades de los datos
            modelBuilder.Entity<Usuario>(
                usr =>//armo un array de todas las propiedades que deseo setear, sino seria una instruccion por cada dato
                {
                    usr.Property(u => u.name).HasColumnType("varchar(50)");
                    usr.Property(u => u.apellido).HasColumnType("varchar(50)");
                    usr.Property(u => u.mail).HasColumnType("varchar(256)");
                    usr.Property(u => u.mail).IsRequired(true);
                    usr.Property(u => u.dni).HasColumnType("varchar(10)");
                    usr.Property(u => u.dni).IsRequired(true);
                    usr.Property(u => u.password).HasColumnType("varchar(50)");
                    usr.Property(u => u.password).IsRequired(true);
                    usr.Property(u => u.intentosFallidos).HasColumnType("int");
                    usr.Property(u => u.bloqueado).HasColumnType("bit");
                    usr.Property(u => u.credito).HasColumnType("float");
                    usr.Property(u => u.esAdmin).HasColumnType("bit");
                    
                });

            modelBuilder.Entity<Ciudad>(
                c =>
                {
                    c.Property(c=> c.nombre).HasColumnType("varchar(50)");
                }
                
                );

            modelBuilder.Entity<Hotel>(
                hts =>
                {//verificar orden de las propiedades con dev
                    hts.Property(h => h.nombre).HasColumnType("varchar(50)");
                    hts.Property(h => h.nombre).IsRequired(true);
                    hts.Property(h => h.capacidad).HasColumnType("int");
                    hts.Property(h => h.capacidad).IsRequired(true);
                    hts.Property(h => h.costo).HasColumnType("float");
                    hts.Property(h => h.costo).IsRequired(true);
                    hts.Property(h => h.ubicacion).HasColumnType("int");
                    hts.Property(h => h.ubicacion).IsRequired(true);
                }

                );

            modelBuilder.Entity<Vuelo>(
                vue =>
                {//verificar datos y ordes con los metodos
                    vue.Property(v => v.origen).HasColumnType("int");
                    vue.Property(v => v.origen).IsRequired(true);
                    vue.Property(v => v.destino).HasColumnType("int");
                    vue.Property(v => v.destino).IsRequired(true);
                    vue.Property(v => v.capacidad).HasColumnType("int");
                    vue.Property(v => v.capacidad).IsRequired(true);
                    vue.Property(v => v.vendido).HasColumnType("int");
                    vue.Property(v => v.costo).HasColumnType("float");
                    vue.Property(v => v.costo).IsRequired(true);
                    vue.Property(v => v.fecha).HasColumnType("datetime");
                    vue.Property(v => v.fecha).IsRequired(true);
                    vue.Property(v => v.aerolinea).HasColumnType("varchar(50)");
                    vue.Property(v => v.aerolinea).IsRequired(true);
                    vue.Property(v => v.avion).HasColumnType("varchar(50");
                    vue.Property(v => v.avion).IsRequired(true);

                }
                );

            modelBuilder.Entity<ReservaHotel>(
                rh =>
                {//verificar el ordden
                    rh.Property(r => r.miUsuario).HasColumnType("int");
                    rh.Property(r => r.miUsuario).IsRequired(true);
                    rh.Property(r => r.miHotel).HasColumnType("int");
                    rh.Property(r => r.miHotel).IsRequired(true);
                    rh.Property(r => r.fechaDesde).HasColumnType("datetime");
                    rh.Property(r => r.fechaDesde).IsRequired(true);
                    rh.Property(r => r.fechaHasta).HasColumnType("datetime");
                    rh.Property(r => r.fechaHasta).IsRequired(true);
                    rh.Property(r => r.pagado).HasColumnType("float");


                }
                );

            modelBuilder.Entity<ReservaVuelo>(
                rv =>
                {//verificar orden
                    rv.Property(r => r.miVuelo).HasColumnType("int");
                    rv.Property(r => r.miVuelo).IsRequired(true);
                    rv.Property(r => r.miUsuario).HasColumnType("int");
                    rv.Property(r => r.miUsuario).IsRequired(true);
                    rv.Property(r => r.pagado).HasColumnType("float");
                    rv.Property(r => r.pagado).IsRequired(true);
                }
                );



        }
    }
}
