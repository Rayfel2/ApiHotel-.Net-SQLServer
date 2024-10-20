using APIHotel.Interfaces;
using APIHotel.Models;
using APIHotel.Dto;
using AutoMapper;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Mvc;

namespace APIHotel.Controllers
{
    [Microsoft.AspNetCore.Mvc.Route("api/[controller]")]
    [ApiController]
    public class HotelController : Controller
    {
        private readonly IHotelRepository _hotelRepository;
        private readonly IMapper _mapper;

        public HotelController(IHotelRepository hotelRepository, IMapper mapper)
        {
            _hotelRepository = hotelRepository;
            _mapper = mapper;
        }


        [HttpGet]
        [ProducesResponseType(200, Type = typeof(IEnumerable<Usuarios>))]

        public IActionResult GetUsuarios()
        {
            var usuarios = _mapper.Map<List<UsuariosDto>>(_hotelRepository.GetUsuarios());
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            return Ok(usuarios);
        }
        [HttpGet("{userId}")]
        [ProducesResponseType(200, Type = typeof(Usuarios))]
        [ProducesResponseType(400)]
        public IActionResult GetUsuarios(int userId)
        {
            if (!_hotelRepository.UserExist(userId))
                return NotFound();

            var hotel = _mapper.Map<UsuariosDto>(_hotelRepository.GetUsuarios(userId));

            if(!ModelState.IsValid)
                return BadRequest(ModelState);

            return Ok(hotel);
        }

        [HttpPost]
        [ProducesResponseType(204)]
        [ProducesResponseType(400)]
        public IActionResult CreateUsuario([FromQuery] int rolesId, [FromBody] UsuariosDto usuariosCreate)
        {
            if (usuariosCreate == null)
                return BadRequest(ModelState);

            var usuarios = _hotelRepository.GetUsuariosTrimToUpper(usuariosCreate);

            if (usuarios != null)
            {
                ModelState.AddModelError("", "user already exists");
                return StatusCode(422, ModelState);
            }

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var userMap = _mapper.Map<Usuarios>(usuariosCreate);


            if (!_hotelRepository.CreateUsuario(rolesId, userMap))
            {
                ModelState.AddModelError("", "Something went wrong while savin");
                return StatusCode(500, ModelState);
            }

            return Ok("Successfully created");
        }


    }
}
