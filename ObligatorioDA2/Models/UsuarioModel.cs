using Domain;
using System;
namespace Obligatorio.Models
{
    public class UsuarioModel
    {
        public DatosUsuario Datos { get; set; }
        public bool IsAdmin { get; set; }
        public string Token { get; set; }
        public string Contrasenia { get; set; }
    }
}
