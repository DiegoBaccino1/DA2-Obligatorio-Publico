using System.Collections.Generic;
using Domain;

namespace BuissnesLogic_Interface
{
    public interface IHospedaje
    {
        string ValidaNombreHospedaje(string nombre);
        List<Hospedaje> ObtenerTodos();
        void AgregarHospedaje(Hospedaje hospedaje);
        void ActualizarHospedaje(Hospedaje hospedaje);
        void AgregarPunto(int hospedajeId, int puntoId);
        void BorrarHospedaje(int id);
        void BorrarHospedajeSegunPunto(int puntoId);
        void CambiarCapacidad(int hospedajeId, int nuevaCapacidad);
        Hospedaje ObtenerPorId(int id);
        List<Hospedaje> BuscarHospedajePunto(int puntoId,HospedajeFiltro filtro);
        double CalcularPromedio(Hospedaje hospedaje);
        void AgregarResenia(Hospedaje hospedajeNuevo, Resenia resenia);
    }
}
