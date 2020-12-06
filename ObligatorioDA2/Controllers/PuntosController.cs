using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BuisnessLogic.Domain;
using BuissnesLogic_Interface;
using Exceptiones;
using Microsoft.AspNetCore.Mvc;
using Obligatorio.Models;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Obligatorio.Controllers
{
    [Route("[Controller]")]
    [ApiController]
    public class PuntosController : ControllerBase
    {
        private readonly IPuntoTuristico logica;
        private readonly IRegion regionLogica;
        public PuntosController(IPuntoTuristico logica, IRegion regionLogica)
        {
            this.logica = logica;
            this.regionLogica = regionLogica;
        }

        [HttpGet]
        public IActionResult Get()
        {
            List<PuntoTuristico> retorno = logica.ObtenerTodos();
            return Ok(retorno);
        }

        // GET api/<PuntosController>/5
        [HttpGet("{id}")]
        public IActionResult GetPorId(int id)
        {
            try
            {
                PuntoTuristico punto = logica.ObtenerPuntoId(id);
                return Ok(punto);
            } catch (EntidadNoExisteExcepcion)
            {
                return NotFound("No Existe el punto");
            }
        }


        [HttpGet("filtro")]
        public IActionResult GetCategorias([FromQuery] int[] Id, [FromQuery] int? regionId)
        {
            List<PuntoTuristico> retorno = new List<PuntoTuristico>();
            if (regionId != null)
                retorno = regionLogica.ObtenerPuntosTuristicos((int)regionId);
            else
                retorno = logica.ObtenerTodos();
            if (Id != null)
                retorno = logica.PuntosPorCategoria(retorno, Id);

            return Ok(retorno);
        }

        // POST /<PuntosController>
        [HttpPost]
        public IActionResult Post(int id,[FromBody] PuntoTuristicoModel puntoModel)
        {
            try
            {
                PuntoTuristico punto = logica.PuntoTuristico
                    (puntoModel.Nombre, puntoModel.Descripcion);
                punto.Id = id;
                if (puntoModel.Imagen != null)
                    punto.Imagen = puntoModel.Imagen;
                logica.AgregarPunto(punto);
                return Ok(punto);
            }
            catch (NombreNoValidoException)
            {
                return BadRequest("Nombre no valido");
            }
            catch (MaxCantDeCaracteresException)
            {
                return BadRequest("La descripcion supera " +
                                    "la cantidad de caracteres");
            }
        }

        // PUT /<PuntosController>/5
        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody] PuntoTuristico punto)
        {
            try
            {
                logica.ActualizarPunto(id,punto);
                return Ok();
            }catch (EntidadNoExisteExcepcion)
            {
                return NotFound("El punto no existe");
            }
        }

        [HttpPut("{puntoId}/categorias/{categoriaId}")]
        public IActionResult PutCategoria(int puntoId, int categoriaId)
        {
            try
            {
                logica.AgregarPuntoCategoria(puntoId, categoriaId);
                return Ok();
            }
            catch (EntidadNoExisteExcepcion)
            {
                return NotFound("El punto no existe");
            }
        }

        // DELETE /<PuntosController>/5
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            try
            {
                logica.BorrarPuntoId(id);
                return Ok();
            }
            catch (EntidadNoExisteExcepcion)
            {
                return NotFound("No existe el punto");
            }
        }
    }
}
