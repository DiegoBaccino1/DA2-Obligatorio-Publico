using Domain;
using Exceptiones;
using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Text;

namespace BuissnesLogic
{
    public class ValidadorDatosUsuario
    {
        public static void ValidarDatos(DatosUsuario datos)
        {
            ValidadorString.ValidarStringVacio(datos.Apellido);
            ValidadorString.ValidarStringVacio(datos.Nombre);
            ValidadorString.ValidarStringVacio(datos.Mail);
            ValidadorFormatoMail.ValidarFormato(datos.Mail);
        }

    }
}
