using APIHotel.Models;

namespace APIHotel.Interfaces
{
    public interface ITarjetaRepository
    {
        bool CreateTajeta(int idHuesped, Tarjetas_de_creditos tarjeta);
        bool save();
        bool HuespedExist(int idHuesped);

        // get si se quiere añadir
        ICollection<Tarjetas_de_creditos> GetTarjetas();
        Tarjetas_de_creditos GetTarjetas(int idTarjeta);
        ICollection<Tarjetas_de_creditos> GetTarjetas(string titular);
    }
}
