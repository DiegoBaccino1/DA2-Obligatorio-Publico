using System;
using System.Collections.Generic;
using System.Text;

namespace Domain
{
    public class ObjetoPostReserva
    {
        public HospedajeFiltro Filtro { get; set; }
        public DatosUsuario Datos { get; set; }
        public int? HospedajeId { get; set; }
    }
}
