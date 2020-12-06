using System;
using System.Collections.Generic;
using BuisnessLogic.Domain;
using Domain;

namespace Obligatorio.Models
{
    public class HospedajeModel
    {
        public string NombreHospedaje { get; set; }
        public string Descripcion { get; set; }
        public int CantidadEstrellas { get; set; }
        public string Direccion { get; set; }
        public List<Imagen> Imagenes { get; set; }
        public int PrecioPorNoche { get; set; }
        public int PrecioTotalPeriodo { get; set; }
        public int Capacidad { get; set; }
        public Hospedaje ToEntity() => new Hospedaje()
        {
            NombreHospedaje = this.NombreHospedaje,
            Descripcion = this.Descripcion,
            CantidadEstrellas=this.CantidadEstrellas,
            Direccion=this.Direccion,
            PrecioPorNoche=this.PrecioPorNoche,
            PrecioTotalPeriodo=this.PrecioTotalPeriodo,
            Capacidad=this.Capacidad,
            Imagenes = this.Imagenes,
        };
    }
}
