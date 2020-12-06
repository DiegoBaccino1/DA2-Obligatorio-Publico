using System;
using System.Collections.Generic;
using Domain;

namespace BuissnesLogic_Interface
{
    public interface IUsuario
    {
        Usuario CrearUsuario(int id,Usuario modelo);
        void AgregarUsuario(Usuario usuario);   
        string ValidarMail(string emailAComprobar);
        List<Usuario> ObtenerTodos();
        Usuario ObtenerPorId(int id);
        Usuario ObtenerPorNombre(string name);
        Usuario ObtenerPorCredenciales(string mail, string contrasenia);
        void BorrarUsuario(int id);
        void ActualizarUsuario(int id,Usuario usuarioNuevo);
        string ValidarString(string stringAValidar);
    }
}
