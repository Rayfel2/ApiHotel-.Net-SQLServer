using APIHotel.Dto;
using APIHotel.Interfaces;
using APIHotel.Models;
using APIHotel.Repository;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace APIHotel.Controllers
{
    [Microsoft.AspNetCore.Mvc.Route("api/[controller]")]
    [ApiController]
    public class TarjetaController : Controller
    {
        // eyeccion de dependencias
        private readonly ITarjetaRepository _TarjetaRepository;
        private readonly IMapper _mapper;

        public TarjetaController(ITarjetaRepository TarjetaRepository, IMapper mapper)
        {
            _TarjetaRepository = TarjetaRepository;
            _mapper = mapper;
        }

        // post 
        [HttpPost]
        [ProducesResponseType(200)]
        [ProducesResponseType(400)]
        public IActionResult Post([FromBody] TarjetaDTO tarjetaDTO, [FromQuery] int idHuesped)
        {
            // por si el DTO es null
            if (tarjetaDTO == null || !ModelState.IsValid) { return BadRequest(ModelState); }
           
            var tarjeta = _mapper.Map<Tarjetas_de_creditos>(tarjetaDTO);

            // agregarlo a la DB
            if (!_TarjetaRepository.HuespedExist(idHuesped))
            {
                ModelState.AddModelError("", "No existe Huesped con este ID");
                return StatusCode(404, ModelState);
            }
            if (!_TarjetaRepository.CreateTajeta(idHuesped, tarjeta))
            {
                ModelState.AddModelError("", "No se puede Añadir esta tarjeta");
                return StatusCode(400, ModelState);
            }
            else
            {
                return Ok("Se ha registrado");
            }

        }

        // get Lista y por el titular
        [HttpGet]
        [ProducesResponseType(200, Type = typeof(IEnumerable<TarjetaDTO>))]

        public IActionResult Get([FromQuery] string? titular = null)
        {
            List<TarjetaDTO> tarjetas;
            if (!string.IsNullOrEmpty(titular))
            {
                tarjetas = _mapper.Map<List<TarjetaDTO>>(_TarjetaRepository.GetTarjetas(titular)).ToList();
            }
            else
            {
                tarjetas = _mapper.Map<List<TarjetaDTO>>(_TarjetaRepository.GetTarjetas()).ToList();
            }
            if (!ModelState.IsValid)
            {
                ModelState.AddModelError("", "No se puedo enlistar las tarjetas");
                return StatusCode(400, ModelState);
            }
            return Ok(tarjetas);
        }

        // get por ID
        [HttpGet("{idTarjeta:int}")]
        [ProducesResponseType(200, Type = typeof(TarjetaDTO))]

        public IActionResult Get([FromRoute] int idTarjeta)
        {
            var tarjeta = _mapper.Map<TarjetaDTO>(_TarjetaRepository.GetTarjetas(idTarjeta));
            if (tarjeta == null || !ModelState.IsValid)
            {
                ModelState.AddModelError("", "No se puedo encontro la tarjeta");
                return StatusCode(404, ModelState);
            }
            return Ok(tarjeta);
        }
    }
}
