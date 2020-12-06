using System;
using System.Collections.Generic;
using System.Text;

namespace Domain
{
    public class Resenia
    {
        public int Id { get; set; }
        public int Puntaje { get; set; }
        public string Texto { get; set; }
        public virtual DatosUsuario Datos {get;set;}
    }
}
