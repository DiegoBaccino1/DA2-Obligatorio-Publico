using Domain;
using System;
using System.Collections.Generic;
using System.Text;

namespace BuissnesLogic_Interface
{
    public interface ICategoria
    {
        string ValidarNombre(string nombre);
        Categoria Categoria(string nombre);
        void AgregarCategoria(Categoria categoria);
        Categoria ObtenerCategoriaId(int id);
        void BorrarCategoriaId(int id);
        void ActualizarCategoria(int id, Categoria categoria);
        List<Categoria> ObtenerTodas();
    }
}
