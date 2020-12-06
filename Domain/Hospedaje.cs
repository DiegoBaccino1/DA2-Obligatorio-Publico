using System;
using BuisnessLogic.Domain;

using System.Collections.Generic;

namespace Domain
{
    public class Hospedaje
    {
        public int Id { get; set; }
        public string NombreHospedaje { get; set; }
        public virtual PuntoTuristico PuntoTuristico { get; set; }
        public int CantidadEstrellas { get; set; }
        public string Direccion { get; set; }
        public virtual List<Imagen> Imagenes { get; set; }
        public int PrecioPorNoche { get; set; }
        public int PrecioTotalPeriodo { get; set; }
        public string Descripcion { get; set; }
        public bool Ocupado { get; set; }
        public int Capacidad { get; set; }
        public virtual List<Resenia> Resenias { get; set; }
        public double Puntaje { get; set; }
    }
}
