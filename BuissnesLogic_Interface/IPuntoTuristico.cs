using BuisnessLogic.Domain;
using Domain;
using System.Collections.Generic;

namespace BuissnesLogic_Interface
{
    public interface IPuntoTuristico
    {
       string ValidarNombre(string nombre);
       string ValidarDescripcion(string descripcion);
       PuntoTuristico PuntoTuristico(string nombre, string descripcion);
       void CargarImagen(PuntoTuristico punto,Imagen imagen);
       void AgregarPunto(PuntoTuristico punto);
       List<PuntoTuristico> ObtenerTodos();
       PuntoTuristico ObtenerPuntoId(int id);
       List<PuntoTuristico> PuntosPorCategoria(List<PuntoTuristico>puntos,int[] idCategorias);
       void ActualizarPunto(int id,PuntoTuristico punto);
       void BorrarPuntoId(int id);
       void AgregarPuntoCategoria(int puntoId, int categoriaId);
        List<string> ObtenerNombreCategorias(PuntoTuristico punto);
    }
}
