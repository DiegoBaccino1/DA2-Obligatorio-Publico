using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BuisnessLogic.Domain;
using BuissnesLogic_Interface;
using Domain;
using Exceptiones;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Infrastructure;
using Obligatorio.Models;


namespace Obligatorio.Controllers
{
    [Route("/[controller]")]
    [ApiController]
    public class HospedajesController : ControllerBase
    {
        private readonly IHospedaje logic;
        public HospedajesController(IHospedaje logic)
        {
            this.logic = logic;
        }

        [HttpGet]
        public IActionResult Get()
        {
            List<Hospedaje> hospedajes = logic.ObtenerTodos();
            return Ok(hospedajes);
        }
        
        [Authorize(Roles = "Admin")]
        [HttpPost]
        public IActionResult Post(int id,[FromBody]HospedajeModel hospedajeModel)
        {
            try
            {
                Hospedaje hospedaje = hospedajeModel.ToEntity();
                logic.AgregarHospedaje(hospedaje);
                return Ok(hospedaje);
            }
            catch(NombreNoValidoException)
            {
                return BadRequest("Nombre de punto no valido");
            }
        }
        
        [Authorize(Roles = "Admin")]
        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody] HospedajeModel hospedajeModel)
        {
            try
            {
                Hospedaje hospedaje = hospedajeModel.ToEntity();
                hospedaje.Id = id;
                logic.ActualizarHospedaje(hospedaje);
                return Ok();
            }
            catch (EntidadNoExisteExcepcion)
            {
                return NotFound("No existe el hospedaje");
            }
        }

        [Authorize(Roles = "Admin")]
        [HttpPut("{id}/puntos/{puntoId}")]
        public IActionResult PutAgregarPunto(int id,int puntoId)
        {
            try
            {
                logic.AgregarPunto(id,puntoId);
                return Ok();
            }
            catch (EntidadNoExisteExcepcion)
            {
                return NotFound("No existe el punto o el hospedaje");
            }
        }
        
        [Authorize(Roles = "Admin")]
        [HttpPut("{id}/capacidad")]
        public IActionResult PutCambiarCapacidad(int id,[FromQuery] int nuevaCapacidad)
        {
            try
            {
                logic.CambiarCapacidad(id,nuevaCapacidad);
                return Ok();
            }
            catch (EntidadNoExisteExcepcion)
            {
                return NotFound("No existe el hospedaje");
            }
            catch (CapacidadNoValidaExcepcion)
            {
                return BadRequest("La capacidad tiene que ser mayor que 0");
            }
        }
        
        [Authorize(Roles = "Admin")]
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            try
            {
                logic.BorrarHospedaje(id);
                return Ok();
            }
            catch(EntidadNoExisteExcepcion)
            {
                return NotFound("No Existe este hospedaje");
            }
        }
        
        [Authorize(Roles = "Admin")]
        [HttpDelete("puntos/{id}")]
        public IActionResult DeleteSegunPunto(int id)
        {
            try
            {
                logic.BorrarHospedajeSegunPunto(id);
                return Ok();
            }
            catch (EntidadNoExisteExcepcion)
            {
                return NotFound("No Existe este punto");
            }
            catch (Microsoft.EntityFrameworkCore.DbUpdateException)
            {
                return Conflict("Es necesario borrar sus dependencias antes");
            }
        }

        [HttpGet("{id}")]
        public IActionResult GetPorId(int id)
        {
            try
            {
                Hospedaje hospedaje = logic.ObtenerPorId(id);
                return Ok(hospedaje);
            }
            catch (EntidadNoExisteExcepcion)
            {
                return NotFound("No existe el hospedaje");
            }
            catch (HospedajeOcupadoExcepcion)
            {
                return BadRequest("Ese hospedaje esta ocupado");
            }
        }
       
        [HttpPost("puntos/{id}")]
        public IActionResult GetFiltro(int id,[FromBody]HospedajeFiltro filtro)
        {
            try
            {
                List<Hospedaje> hospedaje = logic.BuscarHospedajePunto(id,filtro);
                return Ok(hospedaje);
            }
            catch (RevisarFechaExcepcion)
            {
                return BadRequest("Revisar CheckIn y CheckOut");
            }
            catch (EntidadNoExisteExcepcion)
            {
                return NotFound("El hospedaje o el punto no existen ");
            }
            catch (FechaVaciaException)
            {
                return BadRequest("Revisar CheckIn y CheckOut, uno de los dos no fue seteado correctamente");
            }
        }
    }
}