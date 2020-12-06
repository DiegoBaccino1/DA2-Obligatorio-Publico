using System;
namespace Domain
{
    public class Usuario
    {
        public int Id { get; set; }
        public string Token;
        public virtual DatosUsuario Datos { get; set; }
        public bool IsAdmin { get; set; }
        public string Contrasenia { get; set; } 
    }
}
