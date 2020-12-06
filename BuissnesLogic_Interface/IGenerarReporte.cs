using Domain;
using System;
using System.Collections.Generic;
using System.Text;

namespace BuissnesLogic_Interface
{
    public interface IGenerarReporte
    {
        List<CantReservasPorHospedaje> GenerarReporte(DatosReporte datos);
    }
}
