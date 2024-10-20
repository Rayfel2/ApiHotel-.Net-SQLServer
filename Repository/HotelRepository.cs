using APIHotel.Data;
using APIHotel.Dto;
using APIHotel.Interfaces;
using APIHotel.Models;
using Microsoft.EntityFrameworkCore;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace APIHotel.Repository
{
    public class HotelRepository : IHotelRepository 
    {
        private readonly DataContext _context;
        public HotelRepository (DataContext context)
        {
            _context = context;
        }

        public bool CreateUsuario(int rolesId, Usuarios Usuarios)
        {
            var usuarioRolesEntity = _context.Roles.Where(r => r.Id == rolesId).FirstOrDefault();

            var rolesusuarios = new RolesUsuarios()
            {
                Roles = usuarioRolesEntity,
                Usuarios = Usuarios
            };

            _context.Add(rolesusuarios);
            _context.Add(Usuarios);


            return save();
        }



        public ICollection<Usuarios> GetUsuarios()
        {
            return _context.Usuarios.OrderBy(U => U.Id).ToList();
        }

        public Usuarios GetUsuarios(int id)
        {
            return _context.Usuarios.Where(p => p.Id == id).FirstOrDefault();
        }

        public Usuarios GetUsuarios(string email)
        {
            return _context.Usuarios.Where(p => p.Email == email).FirstOrDefault();
        }



        public decimal GetUsuariosRoles(int Id)
        {
            var roles = _context.RolesUsuarios.Where(UR => UR.IdUsuario == Id);
            if (roles.Count() <= 0)
                return 0;

            return ((decimal)roles.Sum(r => r.IdRol) / roles.Count());
        }

        public Usuarios GetUsuariosTrimToUpper(UsuariosDto usuarioCreate)
        {
            return GetUsuarios().Where(c => c.Email.Trim().ToUpper() == usuarioCreate.Email.TrimEnd().ToUpper())
                .FirstOrDefault();
        }

        public bool save()
        {
            var saved = _context.SaveChanges();
            return saved > 0 ? true : false;
        }

        public bool UserExist(int id)
        {
            return _context.Usuarios.Any(p => p.Id == id);
        }
    }
}
