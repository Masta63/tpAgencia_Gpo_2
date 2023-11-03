﻿using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace tpAgencia_Gpo_2
{
    class MiContexto : DbContext
    {
        public DbSet<Usuario> usuarios { get; set; }
        public DbSet<Ciudad> ciudades { get; set; }
        public DbSet<Hotel> hoteles { get; set; }
        public DbSet<Vuelo> vuelos { get; set; }
        public DbSet<ReservaHotel> reservaHoteles { get; set; }
        public DbSet<ReservaVuelo> reservaVuelos { get; set; }




        private String _connectionStr = Properties.Resources.conexion;
        public MiContexto() { }

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


            //RELACIONES

            //CIUDAD -> HOTEL
            modelBuilder.Entity<Hotel>()
                .HasOne(H => H.ubicacion)
                .WithMany(C => C.listHoteles)
                .HasForeignKey(H => H.idCiudad)
                .OnDelete(DeleteBehavior.Cascade);

            //CIUDAD -> VUELO
            //modelBuilder.Entity<Vuelo>()
            //    .HasOne(V => V.origen)
            //    .WithMany(C => C.listVuelos)
            //    .HasForeignKey(V => V.)


            //USUARIO -> RESERVAHOTEL

            modelBuilder.Entity<ReservaHotel>()
               .HasOne(R => R.miUsuario)
               .WithMany(U => U.listMisReservasHoteles)
               .HasForeignKey(R => R.idUsuario)
               .OnDelete(DeleteBehavior.Cascade);


            //USUARIO -> RESERVAVUELO

            modelBuilder.Entity<ReservaVuelo>()
                .HasOne(R => R.miUsuario)
                .WithMany(U => U.listMisReservasVuelo)
                .HasForeignKey(R => R.idUsuario)
                .OnDelete(DeleteBehavior.Cascade);

            //USUARIO -> VUELO many to many
            modelBuilder.Entity<Usuario>()
                .HasMany(U => U.listVuelosTomados)
                .WithMany(V => V.listPasajeros)
                .UsingEntity<VueloUsuario>(
                euv => euv.HasOne(uv => uv.vuelo).WithMany(v => v.vueloUsuarios).HasForeignKey(u => u.idVuelo),
                euv => euv.HasOne(uv => uv.user).WithMany(u => u.vueloUsuarios).HasForeignKey(u => u.idUsuario),
                euv => euv.HasKey(k => new { k.idVuelo, k.idUsuario })
                );

            //USUARIO -> HOTEL many to many
            modelBuilder.Entity<Usuario>()
               .HasMany(u => u.listHotelesVisitados)
               .WithMany(h => h.listHuespedes)
               .UsingEntity<HotelUsuario>(
                ehu => ehu.HasOne(hu => hu.hotel).WithMany(h => h.hotelUsuario).HasForeignKey(u => u.idHotel),
                ehu => ehu.HasOne(hu => hu.user).WithMany(u => u.hotelUsuario).HasForeignKey(u => u.idUsuario),
                ehu => ehu.HasKey(k => new { k.idHotel, k.idUsuario })
                );
            //


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
                    c.Property(c => c.nombre).HasColumnType("varchar(50)");
                    c.Property(c => c.nombre).IsRequired(true);
                }

                );

            modelBuilder.Entity<Hotel>(
                hts =>
                {
                    hts.Property(h => h.ubicacion).HasColumnType("int");
                    hts.Property(h => h.ubicacion).IsRequired(true);
                    hts.Property(h => h.capacidad).HasColumnType("int");
                    hts.Property(h => h.capacidad).IsRequired(true);
                    hts.Property(h => h.costo).HasColumnType("float");
                    hts.Property(h => h.costo).IsRequired(true);
                    hts.Property(h => h.nombre).HasColumnType("varchar(50)");
                    hts.Property(h => h.nombre).IsRequired(true);
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
                    //rh.Property(r => r.miUsuario).HasColumnType("int");
                    //rh.Property(r => r.miUsuario).IsRequired(true); 
                    rh.Property(r => r.fechaDesde).HasColumnType("datetime");
                    rh.Property(r => r.fechaDesde).IsRequired(true);
                    rh.Property(r => r.fechaHasta).HasColumnType("datetime");
                    rh.Property(r => r.fechaHasta).IsRequired(true);
                    rh.Property(r => r.pagado).HasColumnType("float");
                    //rh.Property(r => r.miHotel).HasColumnType("int");
                    //rh.Property(r => r.miHotel).IsRequired(true);


                }
                );

            modelBuilder.Entity<ReservaVuelo>(
                rv =>
                {//verificar orden
                    //rv.Property(r => r.miVuelo).HasColumnType("int");
                    //rv.Property(r => r.miVuelo).IsRequired(true);
                    //rv.Property(r => r.miUsuario).HasColumnType("int");
                    //rv.Property(r => r.miUsuario).IsRequired(true);
                    rv.Property(r => r.pagado).HasColumnType("float");
                    rv.Property(r => r.pagado).IsRequired(true);
                }
                );



        }
    }
}
