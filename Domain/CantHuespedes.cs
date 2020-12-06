using System;
using System.Collections.Generic;
using System.Text;

namespace Domain
{
    public class CantHuespedes
    {
        public int Id { get; set; }
        public int CantAdultos { get; set; }
        public int CantNinios { get; set; }
        public int CantBebes { get; set; }
        public int CantJubilados { get; set; }

        public int CapacidadTotal()
        {
            return CantAdultos + CantBebes + CantJubilados + CantNinios;
        }
    }
}
