using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;
using BuissnesLogic;
using BuissnesLogic_Interface;
using Domain;
using Exceptiones;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Obligatorio.Controllers
{
    [Route("[Controller]")]
    [ApiController]
    public class ImportadoresController : ControllerBase
    {
        private readonly IHospedaje logicaHospedaje;
        private readonly IPuntoTuristico logicaPunto;
        private readonly IConfiguration configuration;
        public ImportadoresController(IHospedaje logicaHospedaje, IPuntoTuristico logicaPunto,IConfiguration config)
        {
            this.logicaHospedaje = logicaHospedaje;
            this.logicaPunto = logicaPunto;
            this.configuration = config;
        }
        // GET: api/<ImportadoresController>
        [HttpGet]
        public IActionResult GetAllImportadores()
        {
            List<IArchivoImportador> importadores = CargarImportadores();
            List<string> retorno = new List<string>();
            for (int i = 0; i < importadores.Count; i++)
            {
                IArchivoImportador importador = importadores[i];
                retorno.Add(importador.GetName());
            }
            return Ok(retorno);
        }

        private List<IArchivoImportador> CargarImportadores()
        {
            DllImportador dllImporter = new DllImportador();
            string path2 = configuration["Directory"];
            Assembly assembly = dllImporter.CargarAssembly(path2);
            List<IArchivoImportador> importadores = dllImporter.ObtenerImporters(assembly);
            return importadores;
        }

        // GET api/<ImportadoresController>/5
        [HttpGet("{nombre}")]
        public IActionResult GetCargarHospedajes(string nombre,[FromQuery] string path)
        {
            try
            {
                path = ValidadorString.ValidarStringVacio(path);
                IArchivoImportador importador = CargarImportadores().Where(x => x.GetName().Equals(nombre)).FirstOrDefault();
                if (importador == null)
                    return BadRequest("importador no existe");

                List<Hospedaje> hospedajes = importador.ImportarHospedajes(path);
                try
                {
                    foreach (Hospedaje hospedaje in hospedajes)
                    {
                        if (hospedaje.PuntoTuristico != null)
                            this.logicaPunto.AgregarPunto(hospedaje.PuntoTuristico);
                        logicaHospedaje.AgregarHospedaje(hospedaje);
                    }
                }
                catch (EntidadNoExisteExcepcion)
                {
                }
                return Ok();
            }
            catch (StringVacioException)
            {
                return BadRequest("Alguno de los parametros es vacio");
            }
        }
    }
}
