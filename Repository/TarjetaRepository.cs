using APIHotel.Data;
using APIHotel.Interfaces;
using APIHotel.Models;

namespace APIHotel.Repository
{
    public class TarjetaRepository : ITarjetaRepository
    {
        private readonly DataContext _context;

        // constructor
        public TarjetaRepository(DataContext context)
        {
            this._context = context;
        }
        public bool CreateTajeta(int idHuesped, Tarjetas_de_creditos tarjeta)
        {
            // buscar el huesped con este ID
            var huesped = _context.Huespedes.Where(h => h.IdHuesped == idHuesped).FirstOrDefault();

            _context.Add(tarjeta);
            huesped.Tarjetas = new List<Tarjetas_de_creditos>() { tarjeta };
            

            return save();
        }

        public Tarjetas_de_creditos GetTarjetas(int idTarjeta)
        {
#pragma warning disable CS8603 // Posible tipo de valor devuelto de referencia nulo
            return _context.Tarjetas_de_creditos.Where(T => T.IdTarjetaDeCredito == idTarjeta).FirstOrDefault();
#pragma warning restore CS8603 // Posible tipo de valor devuelto de referencia nulo
        }

        public ICollection<Tarjetas_de_creditos> GetTarjetas()
        {
            return _context.Tarjetas_de_creditos.OrderBy(T => T.IdTarjetaDeCredito).ToList();
        }

        public ICollection<Tarjetas_de_creditos> GetTarjetas(string titular)
        {
            return _context.Tarjetas_de_creditos
                .Where(T => T.NombreTitular.Contains(titular))
                    .ToList();
        }

        public bool HuespedExist(int idHuesped)
        {
            var huesped = _context.Huespedes.Where(h => h.IdHuesped == idHuesped).FirstOrDefault();

            return huesped != null;
        }

        public bool save()
        {
            var saved = _context.SaveChanges();
            return saved > 0 ? true : false;
        }
    }
}
