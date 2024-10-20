using APIHotel.Models;

namespace APIHotel.Interfaces
{
    public interface IHuesped
    {
        // gets
        ICollection<Huespedes> GetHuespedes();
        Huespedes GetHuespedes(int idHuesped);
        ICollection<Huespedes> GetHuespedes(string Nombre);

        // post
        bool CreateHuesped(Huespedes huesped);
        bool save();
    }
}
