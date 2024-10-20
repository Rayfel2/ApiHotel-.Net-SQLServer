using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace APIHotel.Migrations
{
    /// <inheritdoc />
    public partial class initialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Habitaciones",
                columns: table => new
                {
                    IdHabitacion = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Descripcion = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Limite = table.Column<int>(type: "int", nullable: false),
                    Precio = table.Column<int>(type: "int", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Habitaciones", x => x.IdHabitacion);
                });

            migrationBuilder.CreateTable(
                name: "Roles",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nombre = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Roles", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Servicios",
                columns: table => new
                {
                    IdServicio = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Descripcion = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Precio = table.Column<int>(type: "int", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Servicios", x => x.IdServicio);
                });

            migrationBuilder.CreateTable(
                name: "Usuarios",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ConteoAccesosFallidos = table.Column<int>(type: "int", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    EmailConfirmed = table.Column<int>(type: "int", nullable: false),
                    PasswordHash = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    NumeroTelefono = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    NumeroTelefonoConfirmed = table.Column<int>(type: "int", nullable: false),
                    IsDeleted = table.Column<int>(type: "int", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Usuarios", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Empleados",
                columns: table => new
                {
                    IdEmpleado = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nombre = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Direccion = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Telefono = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Sueldo = table.Column<int>(type: "int", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UsuariosId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Empleados", x => x.IdEmpleado);
                    table.ForeignKey(
                        name: "FK_Empleados_Usuarios_UsuariosId",
                        column: x => x.UsuariosId,
                        principalTable: "Usuarios",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Huespedes",
                columns: table => new
                {
                    IdHuesped = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nombre = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Apellidos = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Telefono = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UsuariosId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Huespedes", x => x.IdHuesped);
                    table.ForeignKey(
                        name: "FK_Huespedes_Usuarios_UsuariosId",
                        column: x => x.UsuariosId,
                        principalTable: "Usuarios",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "RolesUsuarios",
                columns: table => new
                {
                    IdUsuario = table.Column<int>(type: "int", nullable: false),
                    IdRol = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RolesUsuarios", x => new { x.IdUsuario, x.IdRol });
                    table.ForeignKey(
                        name: "FK_RolesUsuarios_Roles_IdRol",
                        column: x => x.IdRol,
                        principalTable: "Roles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_RolesUsuarios_Usuarios_IdUsuario",
                        column: x => x.IdUsuario,
                        principalTable: "Usuarios",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Reservaciones",
                columns: table => new
                {
                    IdReservacion = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    checkin = table.Column<bool>(type: "bit", nullable: false),
                    FechaEntrada = table.Column<DateTime>(type: "datetime2", nullable: false),
                    FechaSalida = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Cantidad = table.Column<int>(type: "int", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    HabitacionesIdHabitacion = table.Column<int>(type: "int", nullable: true),
                    HuespedesIdHuesped = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Reservaciones", x => x.IdReservacion);
                    table.ForeignKey(
                        name: "FK_Reservaciones_Habitaciones_HabitacionesIdHabitacion",
                        column: x => x.HabitacionesIdHabitacion,
                        principalTable: "Habitaciones",
                        principalColumn: "IdHabitacion");
                    table.ForeignKey(
                        name: "FK_Reservaciones_Huespedes_HuespedesIdHuesped",
                        column: x => x.HuespedesIdHuesped,
                        principalTable: "Huespedes",
                        principalColumn: "IdHuesped");
                });

            migrationBuilder.CreateTable(
                name: "Tarjetas_de_creditos",
                columns: table => new
                {
                    IdTarjetaDeCredito = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Numero = table.Column<int>(type: "int", nullable: false),
                    FechaVencimiento = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CVV = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    NombreTitular = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    HuespedesIdHuesped = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tarjetas_de_creditos", x => x.IdTarjetaDeCredito);
                    table.ForeignKey(
                        name: "FK_Tarjetas_de_creditos_Huespedes_HuespedesIdHuesped",
                        column: x => x.HuespedesIdHuesped,
                        principalTable: "Huespedes",
                        principalColumn: "IdHuesped");
                });

            migrationBuilder.CreateTable(
                name: "Facturas",
                columns: table => new
                {
                    IdFactura = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    MontoTotal = table.Column<int>(type: "int", nullable: false),
                    Fecha = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ReservacionesIdReservacion = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Facturas", x => x.IdFactura);
                    table.ForeignKey(
                        name: "FK_Facturas_Reservaciones_ReservacionesIdReservacion",
                        column: x => x.ReservacionesIdReservacion,
                        principalTable: "Reservaciones",
                        principalColumn: "IdReservacion");
                });

            migrationBuilder.CreateTable(
                name: "CuentasPorCobrar",
                columns: table => new
                {
                    IdCuenta = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FechaVencimiento = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Balance = table.Column<int>(type: "int", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    FacturasIdFactura = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CuentasPorCobrar", x => x.IdCuenta);
                    table.ForeignKey(
                        name: "FK_CuentasPorCobrar_Facturas_FacturasIdFactura",
                        column: x => x.FacturasIdFactura,
                        principalTable: "Facturas",
                        principalColumn: "IdFactura");
                });

            migrationBuilder.CreateTable(
                name: "ServiciosFacturas",
                columns: table => new
                {
                    IdServicio = table.Column<int>(type: "int", nullable: false),
                    IdFacturas = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ServiciosFacturas", x => new { x.IdServicio, x.IdFacturas });
                    table.ForeignKey(
                        name: "FK_ServiciosFacturas_Facturas_IdFacturas",
                        column: x => x.IdFacturas,
                        principalTable: "Facturas",
                        principalColumn: "IdFactura",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ServiciosFacturas_Servicios_IdServicio",
                        column: x => x.IdServicio,
                        principalTable: "Servicios",
                        principalColumn: "IdServicio",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_CuentasPorCobrar_FacturasIdFactura",
                table: "CuentasPorCobrar",
                column: "FacturasIdFactura");

            migrationBuilder.CreateIndex(
                name: "IX_Empleados_UsuariosId",
                table: "Empleados",
                column: "UsuariosId");

            migrationBuilder.CreateIndex(
                name: "IX_Facturas_ReservacionesIdReservacion",
                table: "Facturas",
                column: "ReservacionesIdReservacion");

            migrationBuilder.CreateIndex(
                name: "IX_Huespedes_UsuariosId",
                table: "Huespedes",
                column: "UsuariosId");

            migrationBuilder.CreateIndex(
                name: "IX_Reservaciones_HabitacionesIdHabitacion",
                table: "Reservaciones",
                column: "HabitacionesIdHabitacion");

            migrationBuilder.CreateIndex(
                name: "IX_Reservaciones_HuespedesIdHuesped",
                table: "Reservaciones",
                column: "HuespedesIdHuesped");

            migrationBuilder.CreateIndex(
                name: "IX_RolesUsuarios_IdRol",
                table: "RolesUsuarios",
                column: "IdRol");

            migrationBuilder.CreateIndex(
                name: "IX_ServiciosFacturas_IdFacturas",
                table: "ServiciosFacturas",
                column: "IdFacturas");

            migrationBuilder.CreateIndex(
                name: "IX_Tarjetas_de_creditos_HuespedesIdHuesped",
                table: "Tarjetas_de_creditos",
                column: "HuespedesIdHuesped");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CuentasPorCobrar");

            migrationBuilder.DropTable(
                name: "Empleados");

            migrationBuilder.DropTable(
                name: "RolesUsuarios");

            migrationBuilder.DropTable(
                name: "ServiciosFacturas");

            migrationBuilder.DropTable(
                name: "Tarjetas_de_creditos");

            migrationBuilder.DropTable(
                name: "Roles");

            migrationBuilder.DropTable(
                name: "Facturas");

            migrationBuilder.DropTable(
                name: "Servicios");

            migrationBuilder.DropTable(
                name: "Reservaciones");

            migrationBuilder.DropTable(
                name: "Habitaciones");

            migrationBuilder.DropTable(
                name: "Huespedes");

            migrationBuilder.DropTable(
                name: "Usuarios");
        }
    }
}
