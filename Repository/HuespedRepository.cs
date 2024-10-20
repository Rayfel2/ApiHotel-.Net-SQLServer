using APIHotel.Data;
using APIHotel.Interfaces;
using APIHotel.Models;

namespace APIHotel.Repository
{
    public class HuespedRepository : IHuesped
    {
        private readonly DataContext _context;

        // constructor
        public HuespedRepository(DataContext context)
        {
            _context = context;
        }

        public bool CreateHuesped(Huespedes huesped)
        {
            _context.Add(huesped);
            return save();
        }

        public ICollection<Huespedes> GetHuespedes()
        {
            return _context.Huespedes.OrderBy(H => H.IdHuesped).ToList();
        }

        public Huespedes GetHuespedes(int idHuesped)
        {
#pragma warning disable CS8603 // Posible tipo de valor devuelto de referencia nulo
            return _context.Huespedes
                .Where(H => H.IdHuesped == idHuesped).FirstOrDefault();
#pragma warning restore CS8603 // Posible tipo de valor devuelto de referencia nulo
        }

        public ICollection<Huespedes> GetHuespedes(string Nombre)
        {
            return _context.Huespedes.Where(H => H.Nombre.Contains(Nombre)).ToList();
        }

        public bool save()
        {
            var saved = _context.SaveChanges();
            return saved > 0 ? true : false;
        }

    }
}
