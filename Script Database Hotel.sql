-- Crear Tabla Usuarios
CREATE TABLE Usuarios (
    Id INT PRIMARY KEY,
    ConteoAccesosFallidos INT,
    Email VARCHAR(255),
    EmailConfirmed BIT,
    NombreUsuario VARCHAR(50),
    PasswordHash VARCHAR(255),
    NumeroTelefono VARCHAR(15),
    NumeroTelefonoConfirmed BIT,
    is_deleted BIT,
    created_at DATETIME,
    updated_at DATETIME
);

-- Crear Tabla Roles
CREATE TABLE Roles (
    Id INT PRIMARY KEY,
    Nombre VARCHAR(50),
    Is_deleted BIT,
    created_at DATETIME,
    updated_at DATETIME
);

-- Crear Tabla RolesUsuarios
CREATE TABLE RolesUsuarios (
    Id_Usuario INT,
    id_Rol INT,
    PRIMARY KEY (Id_Usuario, id_Rol),
    FOREIGN KEY (Id_Usuario) REFERENCES Usuarios(Id),
    FOREIGN KEY (id_Rol) REFERENCES Roles(Id)
);

-- Crear Tabla Paises
CREATE TABLE Paises (
    Id_Pais INT PRIMARY KEY,
    Nombre VARCHAR(50)
);

-- Crear Tabla Empleados
CREATE TABLE Empleados (
    ID_Empleado INT PRIMARY KEY,
    Nombre VARCHAR(50),
    Id_Pais INT,
    Direccion VARCHAR(255),
    Telefono VARCHAR(15),
    Correo_electronico VARCHAR(255),
    Sueldo DECIMAL(10, 2),
    Horarios VARCHAR(50),
    Id_Usuario INT,
    is_deleted BIT,
    created_at DATETIME,
    updated_at DATETIME,
    FOREIGN KEY (Id_Pais) REFERENCES Paises(Id_Pais),
    FOREIGN KEY (Id_Usuario) REFERENCES Usuarios(Id)
);

-- Crear Tabla Id_TiposHabitaciones
CREATE TABLE Id_TiposHabitaciones (
    Id_TipoHabitacion INT PRIMARY KEY,
    Descripcion VARCHAR(50)
);

-- Crear Tabla Habitaciones
CREATE TABLE Habitaciones (
    ID_Habitacion INT PRIMARY KEY,
    Id_TipoHabitacion INT,
    Descripcion VARCHAR(255),
    Precio DECIMAL(10, 2),
    is_deleted BIT,
    created_at DATETIME,
    updated_at DATETIME,
    FOREIGN KEY (Id_TipoHabitacion) REFERENCES Id_TiposHabitaciones(Id_TipoHabitacion)
);

-- Crear Tabla Huespedes
CREATE TABLE Huespedes (
    ID_Huesped INT PRIMARY KEY,
    Nombre VARCHAR(50),
    Apellidos VARCHAR(50),
    Telefono VARCHAR(15),
    Id_Usuario INT,
    Id_Pais INT,
    is_deleted BIT,
    created_at DATETIME,
    updated_at DATETIME,
    FOREIGN KEY (Id_Usuario) REFERENCES Usuarios(Id),
    FOREIGN KEY (Id_Pais) REFERENCES Paises(Id_Pais)
);

-- Crear Tabla Reservaciones
CREATE TABLE Reservaciones (
    ID_Reservacion INT PRIMARY KEY,
    ID_Huesped INT,
    ID_Habitacion INT,
    Fecha_entrada DATETIME,
    Fecha_salida DATETIME,
    Detalles_pago VARCHAR(255),
    created_at DATETIME,
    updated_at DATETIME,
    FOREIGN KEY (ID_Huesped) REFERENCES Huespedes(ID_Huesped),
    FOREIGN KEY (ID_Habitacion) REFERENCES Habitaciones(ID_Habitacion)
);

-- Crear Tabla Id_TiposTransaccion
CREATE TABLE Id_TiposTransaccion (
    Id_TipoTransaccion INT PRIMARY KEY,
    Descripcion VARCHAR(50)
);

-- Crear Tabla Servicios
CREATE TABLE Servicios (
    IdServicio INT PRIMARY KEY,
    Descripcion VARCHAR(50),
    Precio DECIMAL(10, 2),
    IsDeleted BIT,
    CreatedAt DATETIME,
    UpdatedAt DATETIME
);

-- Crear Tabla Tarjetas_de_creditos
CREATE TABLE Tarjetas_de_creditos (
    IdTarjetaDeCredito INT PRIMARY KEY,
    IdHuesped INT,
    Numero VARCHAR(20),
    FechaVencimiento DATE,
    CVV VARCHAR(4),
    NombreTitular VARCHAR(50),
    IsDeleted BIT,
    CreatedAt DATETIME,
    UpdatedAt DATETIME,
    FOREIGN KEY (IdHuesped) REFERENCES Huespedes(ID_Huesped)
);

-- Crear Tabla Facturas
CREATE TABLE Facturas (
    IdFactura INT PRIMARY KEY,
    MontoTotal DECIMAL(10, 2),
    Fecha DATE,
    IdReservacion INT,
    IdHuesped INT,
    IsDeleted BIT,
    CreatedAt DATETIME,
    UpdatedAt DATETIME,
    CuentasPorCobrarIdCuenta INT,
    FOREIGN KEY (IdReservacion) REFERENCES Reservaciones(ID_Reservacion),
    FOREIGN KEY (IdHuesped) REFERENCES Huespedes(ID_Huesped)
);

-- Crear Tabla CuentasPorCobrar
CREATE TABLE CuentasPorCobrar (
    IdCuenta INT PRIMARY KEY,
    IdFactura INT,
    FechaVencimiento DATE,
    Balance DECIMAL(10, 2),
    Estado INT,
    IsDeleted BIT,
    CreatedAt DATETIME,
    UpdatedAt DATETIME,
    FOREIGN KEY (IdFactura) REFERENCES Facturas(IdFactura)
);

-- Ingresar datos en la tabla Usuarios
INSERT INTO Usuarios (Id, ConteoAccesosFallidos, Email, EmailConfirmed, NombreUsuario, PasswordHash, NumeroTelefono, NumeroTelefonoConfirmed, is_deleted, created_at, updated_at)
VALUES
  (1, '0', 'cliente1@example.com', 1, 'cliente1', 'password1', '1234567890', 1, 0, GETDATE(), GETDATE()),
  (2, '0', 'cliente2@example.com', 1, 'cliente2', 'password2', '0987654321', 1, 0, GETDATE(), GETDATE()),
  (3, '0', 'admin@example.com', 1, 'admin', 'adminpassword', '9876543210', 1, 0, GETDATE(), GETDATE()),
  (4, '0', 'empleado@example.com', 1, 'empleado', 'empleadopassword', '0123456789', 1, 0, GETDATE(), GETDATE()),
  (5, '0', 'consultor@example.com', 1, 'consultor', 'consultorpassword', '1122334455', 1, 0, GETDATE(), GETDATE());

-- Ingresar datos en la tabla Roles
INSERT INTO Roles (Id, Nombre, Is_deleted, created_at, updated_at)
VALUES
  (1, 'Cliente', 0, GETDATE(), GETDATE()),
  (2, 'Admin', 0, GETDATE(), GETDATE()),
  (3, 'Empleado', 0, GETDATE(), GETDATE()),
  (4, 'Consultor', 0, GETDATE(), GETDATE());

-- Ingresar datos en la tabla RolesUsuarios
INSERT INTO RolesUsuarios (Id_Usuario, id_Rol)
VALUES
  (1, 1),
  (2, 1),
  (3, 2),
  (4, 3),
  (5, 4);

-- Ingresar datos en la tabla Paises
INSERT INTO Paises (Id_Pais, Nombre)
VALUES
  (1, 'Pais1'),
  (2, 'Pais2'),
  (3, 'Pais3');

-- Ingresar datos en la tabla Empleados
INSERT INTO Empleados (ID_Empleado, Nombre, Id_Pais, Direccion, Telefono, Correo_electronico, Sueldo, Horarios, Id_Usuario, is_deleted, created_at, updated_at)
VALUES
  (1, 'Empleado1', 1, '123', '5551234567', 'empleado1@example.com', 2000, '9AM-5PM', 4, 0, GETDATE(), GETDATE()),
  (2, 'Empleado2', 2, '456', '5559876543', 'empleado2@example.com', 1800, '8AM-4PM', 4, 0, GETDATE(), GETDATE());

-- Ingresar datos en la tabla Id_TiposHabitaciones
INSERT INTO Id_TiposHabitaciones (Id_TipoHabitacion, Descripcion)
VALUES
  (1, 'Tipo1'),
  (2, 'Tipo2'),
  (3, 'Tipo3');

-- Ingresar datos en la tabla Habitaciones
INSERT INTO Habitaciones (ID_Habitacion, Id_TipoHabitacion, Descripcion, Precio, is_deleted, created_at, updated_at)
VALUES
  (1, 1, 'Habitacion1', 100, 0, GETDATE(), GETDATE()),
  (2, 1, 'Habitacion2', 120, 0, GETDATE(), GETDATE()),
  (3, 2, 'Habitacion3', 150, 0, GETDATE(), GETDATE());

-- Ingresar datos en la tabla Huespedes
INSERT INTO Huespedes (ID_Huesped, Nombre, Apellidos, Telefono, Id_Usuario, Id_Pais, is_deleted, created_at, updated_at)
VALUES
  (1, 'Huesped1', 'Apellido1', '5551111111', 1, 1, 0, GETDATE(), GETDATE()),
  (2, 'Huesped2', 'Apellido2', '5552222222', 2, 2, 0, GETDATE(), GETDATE()),
  (3, 'Huesped3', 'Apellido3', '5553333333', 3, 3, 0, GETDATE(), GETDATE());

-- Ingresar datos en la tabla Reservaciones
INSERT INTO Reservaciones (ID_Reservacion, ID_Huesped, ID_Habitacion, Fecha_entrada, Fecha_salida, Detalles_pago, created_at, updated_at)
VALUES
  (1, 1, 1, GETDATE(), DATEADD(DAY, 1, GETDATE()), 'Pago1', GETDATE(), GETDATE()),
  (2, 2, 2, GETDATE(), DATEADD(DAY, 1, GETDATE()), 'Pago2', GETDATE(), GETDATE()),
  (3, 3, 3, GETDATE(), DATEADD(DAY, 1, GETDATE()), 'Pago3', GETDATE(), GETDATE());

-- Ingresar datos en la tabla Id_TiposTransaccion
INSERT INTO Id_TiposTransaccion (Id_TipoTransaccion, Descripcion)
VALUES
  (1, 'TipoTransaccion1'),
  (2, 'TipoTransaccion2');

-- Ingresar datos en la tabla Servicios
INSERT INTO Servicios (IdServicio, Descripcion, Precio, IsDeleted, CreatedAt, UpdatedAt)
VALUES
  (1, 'Servicio1', 50, 0, GETDATE(), GETDATE()),
  (2, 'Servicio2', 75, 0, GETDATE(), GETDATE());

-- Ingresar datos en la tabla Tarjetas_de_creditos
INSERT INTO Tarjetas_de_creditos (IdTarjetaDeCredito, IdHuesped, Numero, FechaVencimiento, CVV, NombreTitular, IsDeleted, CreatedAt, UpdatedAt)
VALUES
  (1, 1, '1234567812345678', '2025-12-31', '123', 'Huesped1', 0, GETDATE(), GETDATE()),
  (2, 2, '2345678923456789', '2026-11-30', '234', 'Huesped2', 0, GETDATE(), GETDATE());

-- Ingresar datos en la tabla Facturas
INSERT INTO Facturas (IdFactura, MontoTotal, Fecha, IdReservacion, IdHuesped, IsDeleted, CreatedAt, UpdatedAt, CuentasPorCobrarIdCuenta)
VALUES
  (1, 150, GETDATE(), 1, 1, 0, GETDATE(), GETDATE(), 1),
  (2, 200, GETDATE(), 2, 2, 0, GETDATE(), GETDATE(), 2);

-- Ingresar datos en la tabla CuentasPorCobrar
INSERT INTO CuentasPorCobrar (IdCuenta, IdFactura, FechaVencimiento, Balance, Estado, IsDeleted, CreatedAt, UpdatedAt)
VALUES
  (1, 1, '2024-11-01', 0, 0, 0, GETDATE(), GETDATE()),
  (2, 2, '2024-12-01', 0, 0, 0, GETDATE(), GETDATE());
