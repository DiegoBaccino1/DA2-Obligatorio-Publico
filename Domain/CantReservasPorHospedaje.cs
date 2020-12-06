using System;
using System.Collections.Generic;
using System.Text;

namespace Domain
{
    public class CantReservasPorHospedaje
    {
        public string NombreHospedaje { get; set; }
        public int CantReservas { get; set; }

        public override bool Equals(object obj)
        {
            try
            {
                CantReservasPorHospedaje cantReservas = (CantReservasPorHospedaje)obj;
                return this.NombreHospedaje.Equals(cantReservas.NombreHospedaje);
            }
            catch (Exception) 
            {
                return false;
            }
        }

        public override string ToString()
        {
            return NombreHospedaje+ "(Cantidad de reservas = "+CantReservas;
        }
    }
}
