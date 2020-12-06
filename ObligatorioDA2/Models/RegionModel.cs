using BuisnessLogic.Domain;
using Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Obligatorio.Models
{
    public class RegionModel
    {
        public string Nombre { get; set; }
        public virtual List<PuntoTuristico> Puntos { get; set; }
        public Region ToEntity() => new Region()
        {
            Nombre = this.Nombre,
            Puntos=this.Puntos,
        };
    }
}
