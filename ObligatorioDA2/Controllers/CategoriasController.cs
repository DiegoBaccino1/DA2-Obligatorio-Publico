using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BuissnesLogic_Interface;
using Domain;
using Exceptiones;
using Microsoft.AspNetCore.Mvc;
using Obligatorio.Models;

namespace Obligatorio.Controllers
{
    [ApiController]
    [Route("[Controller]")]
    public class CategoriasController : ControllerBase
    {
        private readonly ICategoria logica;
        public CategoriasController(ICategoria logica)
        {
            this.logica = logica;
        }
        // GET: /<ValuesController>
        [HttpGet]
        public IActionResult Get()
        {
            List<Categoria> categorias = logica.ObtenerTodas();
            return Ok(categorias); 
        }

        // GET /<ValuesController>/5
        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            try 
            {
                Categoria categoria=logica.ObtenerCategoriaId(id);
                return Ok(categoria);
            }
            catch (EntidadNoExisteExcepcion)
            {
                return NotFound("No Existe la categoria");
            }
        }

        // POST /<ValuesController>
        [HttpPost]
        public IActionResult Post(int id,[FromBody] CategoriaModel categoriaModel)
        {
            try 
            {
                Categoria categoria = logica.Categoria(categoriaModel.Nombre);
                logica.AgregarCategoria(categoria);
                return Ok(categoria);
            } 
            catch (NombreNoValidoException)
            {
                return BadRequest("Nombre no valido");
            }
        }

        // PUT /<ValuesController>/5
        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody] Categoria categoria)
        {
            try
            {
                logica.ActualizarCategoria(id,categoria);
                return Ok(categoria);
            }
            catch (EntidadNoExisteExcepcion)
            {
                return NotFound("No Existe esa entidad");
            }
        }

        // DELETE /<ValuesController>/5
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            try
            {
                logica.BorrarCategoriaId(id);
                return Ok();
            }
            catch (EntidadNoExisteExcepcion)
            {
                return NotFound("No Existe la Categoria");
            }
        }
    }
}
