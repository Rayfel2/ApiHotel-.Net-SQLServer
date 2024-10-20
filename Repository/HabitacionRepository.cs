using APIHotel.Data;
using APIHotel.Interfaces;
using APIHotel.Models;

namespace APIHotel.Repository
{
    public class HabitacionRepository : IHabitacionRepository
    {
        private readonly DataContext _context;

        // constructor
        public HabitacionRepository(DataContext context)
        {
            this._context = context;
        }

        public ICollection<Habitaciones> GetHabitaciones()
        {
            return _context.Habitaciones.OrderBy(H => H.IdHabitacion).ToList();
        }

        public Habitaciones GetHabitaciones(int idHabitacion)
        {
#pragma warning disable CS8603 // Posible tipo de valor devuelto de referencia nulo
            return _context.Habitaciones
                .Where(H => H.IdHabitacion == idHabitacion).FirstOrDefault();
#pragma warning restore CS8603 // Posible tipo de valor devuelto de referencia nulo
        }

        public ICollection<Habitaciones> GetHabitaciones(string descripcion)
        {
            return _context.Habitaciones.Where(H => H.Descripcion.Contains(descripcion)).ToList();
        }

        public int GetLimitHabitacion(int idHabitacion)
        {
            return _context.Habitaciones
                .Where(H => H.IdHabitacion == idHabitacion)
                    .Select(H => H.Limite)
                .FirstOrDefault();
        }


    }
}
