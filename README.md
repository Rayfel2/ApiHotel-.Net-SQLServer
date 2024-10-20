# ApiHotel

## Descripción

**BasicApiHotel** es una aplicación diseñada para la gestión de un hotel, que permite la administración de usuarios, empleados, habitaciones, reservaciones y servicios. Esta API RESTful está desarrollada en .NET y utiliza SQL Server como base de datos.

## Estructura de la Base de Datos

La base de datos `aspnet-53bc9b9d-9d6a-45d4-8429-2a2761773502` incluye las siguientes tablas:

1. **Usuarios**
   - Almacena la información de los usuarios del sistema, incluyendo detalles de autenticación y contacto.

2. **Roles**
   - Define los roles de los usuarios dentro de la aplicación (Cliente, Admin, Empleado, Consultor).

3. **RolesUsuarios**
   - Relaciona los usuarios con sus respectivos roles.

4. **Paises**
   - Contiene información sobre los países de los huéspedes y empleados.

5. **Empleados**
   - Almacena datos sobre los empleados del hotel, incluyendo su información personal y laboral.

6. **Id_TiposHabitaciones**
   - Define los diferentes tipos de habitaciones disponibles en el hotel.

7. **Habitaciones**
   - Almacena información sobre las habitaciones, incluyendo su tipo y precio.

8. **Huespedes**
   - Contiene los datos de los huéspedes que se hospedan en el hotel.

9. **Reservaciones**
   - Gestiona las reservaciones realizadas por los huéspedes, incluyendo fechas de entrada y salida.

10. **Id_TiposTransaccion**
    - Define los tipos de transacciones disponibles en el sistema.

11. **Servicios**
    - Almacena información sobre los servicios ofrecidos por el hotel.

12. **Tarjetas_de_creditos**
    - Gestiona la información de las tarjetas de crédito de los huéspedes.

13. **Facturas**
    - Registra las facturas generadas para los huéspedes.

14. **CuentasPorCobrar**
    - Almacena información sobre las cuentas por cobrar asociadas a las facturas.

## Instalación

1. Clona el repositorio:
   ```bash
   git clone https://github.com/rayfel2/BasicApiHotel.git
   ```

2. Abre el proyecto en Visual Studio.

3. Restaura los paquetes NuGet necesarios.

4. Configura la conexión (Connection string) a la base de datos en el archivo `appsettings.json`.

5. Ejecuta las migraciones para crear la base de datos y las tablas:
   ```bash
   Update-Database
   ```

6. Inicia la aplicación.

## Uso

La API proporciona varios endpoints para gestionar los recursos del hotel. 
