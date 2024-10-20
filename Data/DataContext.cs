using APIHotel.Dto;
using APIHotel.Models;
using Microsoft.EntityFrameworkCore;

namespace APIHotel.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options) { }

        public DbSet<CuentasPorCobrar> CuentasPorCobrar { get; set; }
        public DbSet<Empleados> Empleados { get; set; }
        public DbSet<Facturas> Facturas { get; set; }
        public DbSet<Habitaciones> Habitaciones { get; set; }
        public DbSet<Huespedes> Huespedes { get; set;}
        public DbSet<Reservaciones> Reservaciones { get; set; }
        public DbSet<Roles> Roles { get; set; }
        public DbSet<RolesUsuarios> RolesUsuarios { get; set; } // Puente
        public DbSet<Servicios> Servicios { get; set; }
        public DbSet<ServiciosFacturas> ServiciosFacturas { get;set; } // Puente
        public DbSet<Tarjetas_de_creditos> Tarjetas_de_creditos { get; set; }
        public DbSet<Usuarios> Usuarios { get; set; }



        
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<RolesUsuarios>()
            .HasKey(RU => new { RU.IdUsuario, RU.IdRol });
            modelBuilder.Entity<RolesUsuarios>()
                .HasOne(U => U.Usuarios)
                .WithMany(RU => RU.rolesUsuarios)
                .HasForeignKey(R => R.IdUsuario);
            modelBuilder.Entity<RolesUsuarios>()
                .HasOne(U => U.Roles)
                .WithMany(RU => RU.rolesUsuarios)
                .HasForeignKey(R => R.IdRol);

            modelBuilder.Entity<ServiciosFacturas>()
                .HasKey(sf => new { sf.IdServicio, sf.IdFacturas });

            modelBuilder.Entity<ServiciosFacturas>()
                .HasOne(sf => sf.Servicios)
                .WithMany(s => s.ServiciosFacturas)
                .HasForeignKey(sf => sf.IdServicio);

            modelBuilder.Entity<ServiciosFacturas>()
                .HasOne(sf => sf.Facturas)
                .WithMany(f => f.ServiciosFacturas)
                .HasForeignKey(sf => sf.IdFacturas);



            modelBuilder.Entity<CuentasPorCobrar>().HasKey(c => c.IdCuenta);
            modelBuilder.Entity<Empleados>().HasKey(e => e.IdEmpleado);
            modelBuilder.Entity<Facturas>().HasKey(f => f.IdFactura);
            modelBuilder.Entity<Habitaciones>().HasKey(h => h.IdHabitacion);
            modelBuilder.Entity<Huespedes>().HasKey(h => h.IdHuesped);
            modelBuilder.Entity<Reservaciones>().HasKey(r => r.IdReservacion);
            modelBuilder.Entity<Roles>().HasKey(r => r.Id);
            modelBuilder.Entity<RolesUsuarios>().HasKey(ru => new { ru.IdUsuario, ru.IdRol });
            modelBuilder.Entity<Servicios>().HasKey(s => s.IdServicio);
            modelBuilder.Entity<ServiciosFacturas>().HasKey(sf => new { sf.IdServicio, sf.IdFacturas });
            modelBuilder.Entity<Tarjetas_de_creditos>().HasKey(t => t.IdTarjetaDeCredito);
        }
        


    }
    
}
