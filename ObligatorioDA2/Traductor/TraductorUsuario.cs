using Domain;
using Obligatorio.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Obligatorio.Traductor
{
    public class TraductorUsuario
    {
        public static Usuario AEntidad(UsuarioModel modelo)
        {
            Usuario usuario = new Usuario();
            usuario.Datos = modelo.Datos;
            usuario.IsAdmin = modelo.IsAdmin;
            usuario.Contrasenia = modelo.Contrasenia;
            return usuario;
        }
        public static UsuarioModel AModelo(Usuario usuario)
        {
            UsuarioModel modelo = new UsuarioModel();
            modelo.Datos = usuario.Datos;
            modelo.IsAdmin = usuario.IsAdmin;
            modelo.Token = usuario.Token;
            modelo.Contrasenia ="No se muestra la contraseña" ;
            return modelo;
        }
    }
}
