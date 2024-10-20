using APIHotel.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;

namespace APIHotel.Data
{
    public class Seed
    {
        private readonly DataContext dataContext;

        public Seed(DataContext context)
        {
            this.dataContext = context;
        }

        public void SeedDataContext()
        {
            if (!dataContext.CuentasPorCobrar.Any())
            {
                var cuentasPorCobrar = new List<CuentasPorCobrar>()
                {
                    new CuentasPorCobrar()
                    {
                        IdCuenta = 1,
                        FechaVencimiento = new DateTime(2023, 7, 12),
                        Balance = 1000,
                        IsDeleted = false,
                        CreatedAt = DateTime.Now,
                        UpdatedAt = DateTime.Now
                    },
                    new CuentasPorCobrar()
                    {
                        IdCuenta = 2,
                        FechaVencimiento = new DateTime(2023, 7, 15),
                        Balance = 500,
                        IsDeleted = false,
                        CreatedAt = DateTime.Now,
                        UpdatedAt = DateTime.Now
                    }
                    // Agregar más objetos CuentasPorCobrar si es necesario
                };

                dataContext.CuentasPorCobrar.AddRange(cuentasPorCobrar);
                dataContext.SaveChanges();
            }

            if (!dataContext.Empleados.Any())
            {
                var empleados = new List<Empleados>()
                {
                    new Empleados()
                    {
                        IdEmpleado = 1,
                        Nombre = "John Doe",
                        Direccion = "1234",
                        Telefono = "987654321",
                        Sueldo = 2000,
                        IsDeleted = false,
                        CreatedAt = DateTime.Now,
                        UpdatedAt = DateTime.Now
                    },
                    new Empleados()
                    {
                        IdEmpleado = 2,
                        Nombre = "Jane Smith",
                        Direccion = "5678",
                        Telefono = "123456789",
                        Sueldo = 2500,
                        IsDeleted = false,
                        CreatedAt = DateTime.Now,
                        UpdatedAt = DateTime.Now
                    }
                    // Agregar más objetos Empleados si es necesario
                };

                dataContext.Empleados.AddRange(empleados);
                dataContext.SaveChanges();
            }

            if (!dataContext.Facturas.Any())
            {
                var facturas = new List<Facturas>()
                {
                    new Facturas()
                    {
                        IdFactura = 1,
                        MontoTotal = 1000,
                        Fecha =  DateTime.Now,
                        IsDeleted = false,
                        CreatedAt = DateTime.Now,
                        UpdatedAt = DateTime.Now
                    },
                    new Facturas()
                    {
                        IdFactura = 2,
                        MontoTotal = 500,
                        Fecha =  DateTime.Now,
                        IsDeleted = false,
                        CreatedAt = DateTime.Now,
                        UpdatedAt = DateTime.Now
                    }
                    // Agregar más objetos Facturas si es necesario
                };

                dataContext.Facturas.AddRange(facturas);
                dataContext.SaveChanges();
            }

            if (!dataContext.Habitaciones.Any())
            {
                var habitaciones = new List<Habitaciones>()
                {
                    new Habitaciones()
                    {
                        IdHabitacion = 1,
                        Descripcion = "Habitación de lujo",
                        Precio = 200,
                        IsDeleted = false,
                        CreatedAt = DateTime.Now,
                        UpdatedAt = DateTime.Now
                    },
                    new Habitaciones()
                    {
                        IdHabitacion = 2,
                        Descripcion = "Habitación estándar",
                        Precio = 100,
                        IsDeleted = false,
                        CreatedAt = DateTime.Now,
                        UpdatedAt = DateTime.Now
                    }
                    // Agregar más objetos Habitaciones si es necesario
                };

                dataContext.Habitaciones.AddRange(habitaciones);
                dataContext.SaveChanges();
            }

            if (!dataContext.Huespedes.Any())
            {
                var huespedes = new List<Huespedes>()
                {
                    new Huespedes()
                    {
                        IdHuesped = 1,
                        Nombre = "John Smith",
                        Apellidos = "Doe",
                        Telefono = "987654321",
                        IsDeleted = false,
                        CreatedAt = DateTime.Now,
                        UpdatedAt = DateTime.Now
                    },
                    new Huespedes()
                    {
                        IdHuesped = 2,
                        Nombre = "Jane",
                        Apellidos = "Smith",
                        Telefono = "123456789",
                        IsDeleted = false,
                        CreatedAt = DateTime.Now,
                        UpdatedAt = DateTime.Now
                    }
                    // Agregar más objetos Huespedes si es necesario
                };

                dataContext.Huespedes.AddRange(huespedes);
                dataContext.SaveChanges();
            }

            

            if (!dataContext.Reservaciones.Any())
            {
                var reservaciones = new List<Reservaciones>()
                {
                    new Reservaciones()
                    {
                        IdReservacion = 1,
                        FechaEntrada = new DateTime(2023, 7, 10),
                        FechaSalida = new DateTime(2023, 7, 12),
                        Cantidad = 2,
                        IsDeleted = false,
                        CreatedAt = DateTime.Now,
                        UpdatedAt = DateTime.Now
                    },
                    new Reservaciones()
                    {
                        IdReservacion = 2,
                        FechaEntrada = new DateTime(2023, 7, 12),
                        FechaSalida = new DateTime(2023, 7, 15),
                       Cantidad = 3,
                        IsDeleted = false,
                        CreatedAt = DateTime.Now,
                        UpdatedAt = DateTime.Now
                    }
                    // Agregar más objetos Reservaciones si es necesario
                };

                dataContext.Reservaciones.AddRange(reservaciones);
                dataContext.SaveChanges();
            }

            if (!dataContext.Roles.Any())
            {
                var roles = new List<Roles>()
                {
                    new Roles()
                    {
                        Id = 1,
                        Nombre = "Administrador",
                        IsDeleted = false,
                        CreatedAt = DateTime.Now,
                        UpdatedAt = DateTime.Now
                    },
                    new Roles()
                    {
                        Id = 2,
                        Nombre = "Usuario",
                        IsDeleted = false,
                        CreatedAt = DateTime.Now,
                        UpdatedAt = DateTime.Now
                    }
                    // Agregar más objetos Roles si es necesario
                };

                dataContext.Roles.AddRange(roles);
                dataContext.SaveChanges();
            }

            if (!dataContext.Servicios.Any())
            {
                var servicios = new List<Servicios>()
                {
                    new Servicios()
                    {
                        IdServicio = 1,
                        Descripcion = "Servicio 1",
                        Precio = 50,
                        IsDeleted = false,
                        CreatedAt = DateTime.Now,
                        UpdatedAt = DateTime.Now
                    },
                    new Servicios()
                    {
                        IdServicio = 2,
                        Descripcion = "Servicio 2",
                        Precio = 75,
                        IsDeleted = false,
                        CreatedAt = DateTime.Now,
                        UpdatedAt = DateTime.Now
                    }
                    // Agregar más objetos Servicios si es necesario
                };

                dataContext.Servicios.AddRange(servicios);
                dataContext.SaveChanges();
            }

            if (!dataContext.ServiciosFacturas.Any())
            {
                var serviciosFacturas = new List<ServiciosFacturas>()
                {
                    new ServiciosFacturas()
                    {
                        IdServicio = 1,
                        IdFacturas = 1,
                    },
                    new ServiciosFacturas()
                    {
                        IdServicio = 2,
                        IdFacturas = 1,
                    }
                    // Agregar más objetos ServiciosFacturas si es necesario
                };

                dataContext.ServiciosFacturas.AddRange(serviciosFacturas);
                dataContext.SaveChanges();
            }

            if (!dataContext.Tarjetas_de_creditos.Any())
            {
                var tarjetasDeCredito = new List<Tarjetas_de_creditos>()
                {
                    new Tarjetas_de_creditos()
                    {
                        IdTarjetaDeCredito = 1,
                        Numero = 1234567890,
                        FechaVencimiento = new DateTime(2025, 12, 31),
                        CVV = "123",
                        NombreTitular = "John Doe",
                        IsDeleted = false,
                        CreatedAt = DateTime.Now,
                        UpdatedAt = DateTime.Now
                    },
                    new Tarjetas_de_creditos()
                    {
                        IdTarjetaDeCredito = 2,
                        Numero = 987657,
                        FechaVencimiento = new DateTime(2024, 10, 31),
                        CVV = "456",
                        NombreTitular = "Jane Smith",
                        IsDeleted = false,
                        CreatedAt = DateTime.Now,
                        UpdatedAt = DateTime.Now
                    }
                    // Agregar más objetos Tarjetas_de_creditos si es necesario
                };

                dataContext.Tarjetas_de_creditos.AddRange(tarjetasDeCredito);
                dataContext.SaveChanges();
            }

          

           

            if (!dataContext.Usuarios.Any())
            {
                var usuarios = new List<Usuarios>()
                {
                    new Usuarios()
                    {
                        Id = 1,
                        ConteoAccesosFallidos = 0,
                        Email = "john.doe@example.com",
                        EmailConfirmed = 1,
                        PasswordHash = "hash123",
                        NumeroTelefono = "9876543210",
                        NumeroTelefonoConfirmed = 1,
                        IsDeleted = 0,
                        CreatedAt = DateTime.Now,
                        UpdatedAt = DateTime.Now
                    },
                    new Usuarios()
                    {
                        Id = 2,
                        ConteoAccesosFallidos = 0,
                        Email = "jane.smith@example.com",
                        EmailConfirmed = 1,
                        PasswordHash = "hash456",
                        NumeroTelefono = "1234567890",
                        NumeroTelefonoConfirmed = 1,
                        IsDeleted = 0,
                        CreatedAt = DateTime.Now,
                        UpdatedAt = DateTime.Now
                    }
                    // Agregar más objetos Usuarios si es necesario
                };

                //dataContext.Usuarios.AddRange(Usuarios);
                dataContext.SaveChanges();
            }
        }
    }
}
