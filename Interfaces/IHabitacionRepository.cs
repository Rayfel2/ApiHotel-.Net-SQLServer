using APIHotel.Models;

namespace APIHotel.Interfaces
{
    public interface IHabitacionRepository
    {
        int GetLimitHabitacion(int idHabitacion);
        ICollection<Habitaciones> GetHabitaciones();
        Habitaciones GetHabitaciones(int idHabitacion);
        ICollection<Habitaciones> GetHabitaciones(string descripcion);

    }
}
