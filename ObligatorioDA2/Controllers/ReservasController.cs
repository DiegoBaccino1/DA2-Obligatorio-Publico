using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BuissnesLogic;
using BuissnesLogic_Interface;
using Domain;
using Domain.Enums;
using Exceptiones;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;

namespace Obligatorio.Controllers
{
    [Route("[Controller]")]
    [ApiController]
    public class ReservasController : ControllerBase
    {
        private readonly IReserva logica;
        private readonly IHospedaje logicaHospedaje;
        public ReservasController(IReserva logica,IHospedaje hospedaje)
        {
            this.logica = logica;
            logicaHospedaje = hospedaje;
        }
        
        // GET: /<ReservasController>
        [HttpGet]
        public IActionResult Get()
        {
            List<Reserva> reservas = logica.ObtenerTodos();
            return Ok(reservas);
        }
        [Authorize(Roles = "Admin")]
        [HttpPost("reporte")]
        public IActionResult GetReporte([FromBody]DatosReporte datos)
        {
            try
            {
                IGenerarReporte generar = new GenerarReporteConcretoA(logica);
                List<CantReservasPorHospedaje> salidaReporte = generar.GenerarReporte(datos);
                return Ok(salidaReporte);
            }catch (FechaVaciaException)
            {
                return BadRequest("La fecha no se seteo correctamente");
            }
            catch (NoHayReservasException)
            {
                return BadRequest("No hay reservas para ese punto");
            }
            catch (UnsupportedContentTypeException)
            {
                return BadRequest("Formato de cuerpo incorrecto. Debe ser JSON");
            }
        }

        // GET api/<ReservasController>/5
        [HttpGet("{id}")]
        public IActionResult GetPorId(int id)
        {
            try
            {
                Reserva reserva = logica.ObtenerPorId(id);
                return Ok(reserva);
            }
            catch (EntidadNoExisteExcepcion)
            {
                return NotFound("La reserva no existe");
            }
        }

        [HttpGet("{id}/estado")]
        public IActionResult GetEstado(int id)
        {
            try
            {
                string estado = logica.ConsultarEstado(id);
                return Ok(estado);
            }
            catch (EntidadNoExisteExcepcion)
            {
                return NotFound("La reserva no existe");
            }
        }

        // POST api/<ReservasController>
        [HttpPost]
        public IActionResult Post(int id,[FromBody] ObjetoPostReserva objeto)
        {
            if (objeto.Filtro == null)
                return BadRequest("Filtro no puede ser null");
            if (objeto.Datos == null)
                return BadRequest("Los datos no pueden ser null");
            if(objeto.HospedajeId==null)
                return BadRequest("El id del hospedaje no pueden ser null");
            try
            {
                HospedajeFiltro filtro = objeto.Filtro;
                DatosUsuario datos = objeto.Datos;
                int hospedajeId = (int)objeto.HospedajeId;
                Reserva reserva = logica.Reserva(filtro, hospedajeId, datos);
                logica.AgregarReserva(reserva);
                return Ok(reserva);
            }
            catch (YaExisteLaEntidadExcepcion)
            {
                return BadRequest("No se puede ingresar una reserva con el mismo id");
            }
            catch (EntidadNoExisteExcepcion)
            {
                return NotFound("No existe el hospedaje");
            }
        }

        [Authorize(Roles = "Admin")]
        // PUT api/<ReservasController>/5
        [HttpPut("{id}")]
        public IActionResult PutEstado(int id, [FromQuery] string descripcion,[FromQuery] EstadoReserva? estado)
        {
            if (descripcion == null)
                return BadRequest("Descripcion no puede ser null");
            if (estado == null)
                return BadRequest("El estado no puede ser null");
            try
            {
                logica.ModificarEstado(id, descripcion, (EstadoReserva)estado);
                return Ok();
            }
            catch (EntidadNoExisteExcepcion)
            {
                return NotFound("No existe la reserva");
            }
        }

        [HttpPut("{id}/resenia")]
        public IActionResult PutResenia(int id, [FromBody]Resenia resenia)
        {
            if (resenia == null)
                return BadRequest("Descripcion no puede ser null");
            try
            {
                Reserva reserva = this.logica.ObtenerPorId(id);
                resenia.Datos.Nombre = reserva.NombreTurista;
                resenia.Datos.Apellido = reserva.ApellidoTurista;
                ValidadorResenia.ValidarResenia(resenia);
                logicaHospedaje.AgregarResenia(reserva.Hospedaje, resenia);
                return Ok(reserva);
            }
            catch (EntidadNoExisteExcepcion)
            {
                return NotFound("No existe la reserva");
            }
            catch (StringVacioException)
            {
                return BadRequest("No pueden haber datos vacios");
            }
            catch (PuntajeFueraDeRangoException)
            {
                return BadRequest("Puntaje fuera de rango");
            }
            catch (UnsupportedContentTypeException)
            {
                return BadRequest("Formato no soportado. Debe ser JSON");
            }
        }
        // DELETE api/<ReservasController>/5
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            try
            {
                logica.BorrarReserva(id);
                return Ok();
            }
            catch (EntidadNoExisteExcepcion)
            {
                return NotFound("No existe la reserva");
            }
        }
    }
}
