using APIHotel.Dto;
using APIHotel.Models;

namespace APIHotel.Interfaces

{
    public interface IHotelRepository
    {
        ICollection<Usuarios> GetUsuarios();
        Usuarios GetUsuarios(int id); 
        Usuarios GetUsuarios(string email);
        decimal GetUsuariosRoles(int Id);

        bool CreateUsuario(int rolesId, Usuarios Usuarios);
        bool save();

        bool UserExist(int userId);

        Usuarios GetUsuariosTrimToUpper(UsuariosDto usuarioCreate);





    }
}
