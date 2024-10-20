using APIHotel.Dto;
using APIHotel.Interfaces;
using APIHotel.Models;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace APIHotel.Controllers
{
    [Microsoft.AspNetCore.Mvc.Route("api/[controller]")]
    [ApiController]
    public class HabitacionesController : Controller
    {
        private readonly IHabitacionRepository _habitacionRepository;
        private readonly IMapper _mapper;

        // constructor
        public HabitacionesController(IHabitacionRepository habitacionRepository, IMapper mapper)
        {
            this._habitacionRepository = habitacionRepository;
            this._mapper = mapper;
        }
        // get Lista
        [HttpGet]
        [ProducesResponseType(200, Type = typeof(IEnumerable<HabitacionDTO>))]
        
        public IActionResult Get()
        {
            var habitacion = _mapper.Map<List<HabitacionDTO>>(_habitacionRepository.GetHabitaciones());
            if (!ModelState.IsValid)
            {
                ModelState.AddModelError("", "No se puedo enlistar las habitaciones");
                return StatusCode(400, ModelState);
            }
            return Ok(habitacion);
        }

        // get con ID
        [HttpGet("{idHabitacion:int}")]
        [ProducesResponseType(200, Type = typeof(HabitacionDTO))]

        public IActionResult Get([FromRoute] int idHabitacion)
        {
            var habitaciones = _mapper.Map<HabitacionDTO>(_habitacionRepository.GetHabitaciones(idHabitacion));
            if (habitaciones == null || !ModelState.IsValid)
            {
                ModelState.AddModelError("", "No se puedo encontro la habitación");
                return StatusCode(404, ModelState);
            }
            return Ok(habitaciones);
        }

        //get de ID para el limite
        [HttpGet("limite/{idHabitacion:int}")]
        [ProducesResponseType(200, Type = typeof(int))]

        public IActionResult GetLimit([FromRoute] int idHabitacion)
        {

            int limite = _habitacionRepository.GetLimitHabitacion(idHabitacion);
            if (limite <= 0 || !ModelState.IsValid)
            {
                ModelState.AddModelError("", "No se puedo encontro el limite de habitación");
                return StatusCode(404, ModelState);
            }
            return Ok(limite);
        }

        // get por descricion devulve lista
        [HttpGet("descripcion")]
        [ProducesResponseType(200, Type = typeof(IEnumerable<HabitacionDTO>))]

        public IActionResult Get([FromQuery] string descripcion)
        {
            var habitaciones = _mapper.Map<List<HabitacionDTO>>(_habitacionRepository.GetHabitaciones(descripcion));
            if (habitaciones == null || !ModelState.IsValid)
            {
                ModelState.AddModelError("", "No se puedo encontro la habitación");
                return StatusCode(404, ModelState);
            }
            return Ok(habitaciones);
        }

    }
}
