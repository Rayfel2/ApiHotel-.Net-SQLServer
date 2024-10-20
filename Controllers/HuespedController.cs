using APIHotel.Dto;
using APIHotel.Interfaces;
using APIHotel.Models;
using APIHotel.Repository;
using AutoMapper;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;

namespace APIHotel.Controllers
{
    [Microsoft.AspNetCore.Mvc.Route("api/[controller]")]
    [ApiController]
    public class HuespedController : Controller
    {
        // eyeccion de dependencias
        private readonly IHuesped _HuespedRepository;
        private readonly IMapper _mapper;

        public HuespedController(IHuesped HuespedRepository, IMapper mapper)
        {
            _HuespedRepository = HuespedRepository;
            _mapper = mapper;
        }

        // post de huesped
        [HttpPost]
        [ProducesResponseType(200)]
        [ProducesResponseType(400)]

        public IActionResult Post([FromBody] HuespedDTO huespedDTO)
        {
            // por si el DTO es null
            if (huespedDTO == null || !ModelState.IsValid) { return BadRequest(ModelState); }

            var huesped = _mapper.Map<Huespedes>(huespedDTO);

            // agregarlo a la DB
            if (!_HuespedRepository.CreateHuesped(huesped))
            {
                ModelState.AddModelError("", "Something went wrong while saving");
                return StatusCode(400, ModelState);
            }
            else
            {
                return Ok("Se ha registrado");
            }
        }

        // get Lista y por nombre
        [HttpGet]
        [ProducesResponseType(200, Type = typeof(IEnumerable<HuespedDTO>))]
        
        public IActionResult Get([FromQuery] string? nombre = null)
        {
            List<HuespedDTO> huespedes;
            if (!string.IsNullOrEmpty(nombre))
            {
                huespedes = _mapper.Map<List<HuespedDTO>>(_HuespedRepository.GetHuespedes(nombre));
            }
            else
            {
                huespedes = _mapper.Map<List<HuespedDTO>>(_HuespedRepository.GetHuespedes());
            }
            if (!ModelState.IsValid)
            {
                ModelState.AddModelError("", "No se puedo enlistar los huespedes");
                return StatusCode(400, ModelState);
            }
            return Ok(huespedes);
        }

        // get por ID
        [HttpGet("{idHuesped:int}")]
        [ProducesResponseType(200, Type = typeof(HuespedDTO))]

        public IActionResult Get([FromRoute] int idHuesped)
        {
            var huesped = _mapper.Map<HuespedDTO>(_HuespedRepository.GetHuespedes(idHuesped));
            if (huesped == null || !ModelState.IsValid)
            {
                ModelState.AddModelError("", "No se puedo encontro el huesped");
                return StatusCode(404, ModelState);
            }
            return Ok(huesped);
        }


    }
}
