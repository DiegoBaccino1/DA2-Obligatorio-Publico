using BuisnessLogic.Domain;
using Domain;
using System;
using System.Collections.Generic;
using System.Text;

namespace BuissnesLogic_Interface
{
    public interface IRegion
    {
        string ValidarNombre(string nombre);
        Region Region(string nombre);
        void AgregarRegion(Region region);
        void ActualizarRegion(Region region);
        void BorrarRegionId(int id);
        List<Region> ObtenerTodas();
        Region ObtenerRegionId(int id);
        void AgregarPunto(int regionId,int puntoId);
        List<PuntoTuristico> ObtenerPuntosTuristicos(int regionId);
    }
}
