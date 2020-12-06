using BuissnesLogic_Interface;
using Domain;
using Exceptiones;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Obligatorio.Models;
using Obligatorio.Traductor;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Obligatorio.Controllers
{
    [ApiController]
    [Route("[Controller]")]
    public class UsuariosController : ControllerBase
    {
        private readonly IUsuario logica;
        public UsuariosController(IUsuario logica)
        {
            this.logica = logica;
        }
        [HttpGet]
        public IActionResult Get()
        {
            List<Usuario> usuarios = logica.ObtenerTodos();
            List<UsuarioModel> usuariosModel = new List<UsuarioModel>();
            foreach(Usuario usuario in usuarios)
                usuariosModel.Add(TraductorUsuario.AModelo(usuario));
            
            return Ok(usuariosModel);
        }

        [HttpGet("{id}")]
        public IActionResult GetPorId(int id)
        {
            try
            {
                UsuarioModel usuario = TraductorUsuario.AModelo(logica.ObtenerPorId(id));
                return Ok(usuario);
            }
            catch (EntidadNoExisteExcepcion)
            {
                return NotFound("No existe el usuario");
            }
        }

        [HttpGet("/nombre/{nombre}")]
        public IActionResult GetPorNombre(string nombre)
        {
            try
            {
                UsuarioModel usuario = TraductorUsuario.AModelo(logica.ObtenerPorNombre(nombre));
                return Ok(usuario);
            }
            catch (EntidadNoExisteExcepcion)
            {
                return NotFound("No existe el usuario");
            }
        }

        [Authorize(Roles = "Admin")]
        [HttpPost]
        public IActionResult Post(int id, [FromBody] UsuarioModel usuarioModel)
        {
            try
            {
                if (usuarioModel != null)
                {
                    Usuario usuarioAAgregar = TraductorUsuario.AEntidad(usuarioModel);
                    Usuario usuario = logica.CrearUsuario(id,usuarioAAgregar);
                    logica.AgregarUsuario(usuario);
                    return Ok(usuarioModel);
                }else
                    return BadRequest("Usuario no puede ser null");
            }
            catch (StringVacioException)
            {
                return BadRequest("Alguno de los datos son vacios o nulos. Solo los Admin pueden omitir el apellido");
            }
            catch (FormatoInvalidoException)
            {
                return BadRequest("Formato del email no valido. Debe ser _@_._");
            }
            catch (MailNoUnicoException)
            {
                return BadRequest("El email ya esta en uso");
            }
            catch (UnsupportedContentTypeException)
            {
                return BadRequest("El cuerpo debe estar en formato JSON");
            }
        }
        [Authorize(Roles = "Admin")]
        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody] UsuarioModel modelo)
        {
            try
            {
                if (modelo != null)
                {
                    Usuario usuario = TraductorUsuario.AEntidad(modelo);
                    logica.ActualizarUsuario(id,usuario);
                    return Ok(modelo);
                }
                else
                    return BadRequest("El usuario no puede ser nulo");
            }
            catch (EntidadNoExisteExcepcion)
            {
                return NotFound("No existe ese usuario");
            }
            catch (StringVacioException)
            {
                return BadRequest("Alguno de los datos son vacios o nulos. Solo los Admin pueden omitir el apellido");
            }
            catch (FormatoInvalidoException)
            {
                return BadRequest("Formato del email no valido. Debe ser _@_._");
            }
            catch (MailNoUnicoException)
            {
                return BadRequest("El email ya esta en uso");
            }
            catch (UnsupportedContentTypeException)
            {
                return BadRequest("El cuerpo debe estar en formato JSON");
            }
        }
        [Authorize(Roles = "Admin")]
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            try
            {
                logica.BorrarUsuario(id);
                return Ok();
            }
            catch (EntidadNoExisteExcepcion)
            {
                return NotFound("No existe ese usuario");
            }
        }
    }
}
