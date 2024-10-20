namespace APIHotel.Models
{
    public class RolesUsuarios
    {
        public int IdUsuario { get; set; }
        public int IdRol { get; set; }
        public Usuarios Usuarios { get; set; }
        public Roles Roles { get; set; } 
        
    }
}
