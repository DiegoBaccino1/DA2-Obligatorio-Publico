using BuisnessLogic.Domain;
using System;
using System.Collections.Generic;
using System.Text;

namespace Domain
{
    public class PuntoTuristicoCategoria
    {
        public int PuntoTuristicoId { get; set; }
        public virtual PuntoTuristico PuntoTuristico { get; set; }
        public int CategoriaId { get; set; }
        public virtual Categoria Categoria { get; set; }
        public override bool Equals(object obj)
        {
            try
            {
                PuntoTuristicoCategoria comparar = (PuntoTuristicoCategoria)obj;
                return this.CategoriaId == comparar.CategoriaId && this.PuntoTuristicoId == comparar.PuntoTuristicoId;
                //no pueden haber 2 puntos con misma id. Analogo para categorias
            }
            catch (Exception)
            {
                return false;
            }
        }
    }
}
