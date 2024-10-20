using APIHotel.Dto;
using APIHotel.Models;
using AutoMapper;

namespace APIHotel.Helper
{
    public class MappingController : Profile
    {
        public MappingController() {
            // Get
            CreateMap<Usuarios, UsuariosDto>();
            CreateMap<Reservaciones, ReservacionDto>();
            CreateMap<Facturas, FacturaDto>();
            CreateMap<Huespedes, HuespedDTO>();
            CreateMap<Habitaciones, HabitacionDTO>();
            CreateMap<Huespedes, HuespedDTO>();
            CreateMap<Facturas, FacturaDto>();
            

            // Post
            CreateMap<UsuariosDto, Usuarios>();
            CreateMap<ReservacionDto, Reservaciones>();
            CreateMap<FacturaDto, Facturas>();
            CreateMap<HuespedDTO, Huespedes>();
            CreateMap<TarjetaDTO, Tarjetas_de_creditos>();
        }  
    }
}
