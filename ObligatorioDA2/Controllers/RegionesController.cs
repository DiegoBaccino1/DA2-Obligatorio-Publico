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
using Obligatorio.Models;

namespace Obligatorio.Controllers
{
    [ApiController]
    [Route("[Controller]")]
    public class RegionesController : ControllerBase
    {
        private readonly IRegion logica;
        public RegionesController(IRegion logica)
        {
            this.logica = logica;
        }

        [HttpGet]
        public IActionResult Get()
        {
            List<Region> regiones = logica.ObtenerTodas();
            return Ok(regiones);
        }

        [HttpGet("{id}")]
        public IActionResult GetPorId(int id)
        {
            try
            {
                Region region = logica.ObtenerRegionId(id);
                return Ok(region);
            }
            catch (EntidadNoExisteExcepcion)
            {
                return NotFound("No existe la region");
            }
        }
        
        [HttpPost]
        public IActionResult Post(int id,[FromBody]RegionModel regionModelo)
        {
            try
            {
                Region region = logica.Region(regionModelo.Nombre);
                region.Id = id;
                if (regionModelo.Puntos != null)
                    region.Puntos = regionModelo.Puntos;

                logica.AgregarRegion(region);
                return Ok(region);
            }
            catch (NombreNoValidoException)
            {
                return BadRequest("Nombre no valido");
            }
        }
        
        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody] RegionModel regionModel)
        {
            try
            {
                Region region = regionModel.ToEntity();
                region.Id = id;
                logica.ActualizarRegion(region);
                return Ok();
            }
            catch (EntidadNoExisteExcepcion)
            {
                return NotFound("No existe esa region");
            }
        }
        [Authorize(Roles = "Admin")]
        [HttpPut("{regionId}/puntos/{puntoId}")]
        public IActionResult PutPunto(int regionId,int puntoId)
        {
            try
            {
                logica.AgregarPunto(regionId,puntoId);
                return Ok();
            }
            catch (EntidadNoExisteExcepcion)
            {
                return NotFound("No existe la region o el punto turistico");
            }
        }
      
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            try
            {
                logica.BorrarRegionId(id);
                return Ok();
            }catch (EntidadNoExisteExcepcion){
                return NotFound("No existe esa region");
            }
        }
    }
}
