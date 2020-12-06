using Domain;
using System;
using System.Collections.Generic;

namespace BuisnessLogic.Domain
{
    public class PuntoTuristico
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public string Descripcion { get; set; }      
        public virtual Imagen Imagen { get; set; }
        public virtual List<PuntoTuristicoCategoria> PuntosTuristicosCategoria { get; set; }

        public override bool Equals(object obj)
        {
            try 
            {
                PuntoTuristico punto = (PuntoTuristico)obj;
                return punto.Id == this.Id;
            }
            catch (Exception) 
            {
                return false;
            }
        }
    }
}
