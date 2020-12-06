using BuisnessLogic.Domain;
using System;
using System.Collections.Generic;
using System.Text;

namespace Domain
{
    public class Categoria
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public virtual List<PuntoTuristicoCategoria> PuntosTuristicosCategoria { get; set; }
    }
}
