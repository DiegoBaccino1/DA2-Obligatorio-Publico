using Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Obligatorio.Models
{
    public class PuntoTuristicoModel
    {
        public string Nombre { get; set; }
        public string Descripcion { get; set; }
        public Imagen Imagen { get; set; }
        public List<string> Categorias { get; set; } 
    }
}
