using Domain;
using Exceptiones;
using System;
using System.Collections.Generic;
using System.Text;

namespace BuissnesLogic
{
    public class ValidadorResenia
    {
        private const int MAX_PUNTAJE = 5;
        private const int MIN_PUNTAJE = 1;
        public static void ValidarResenia(Resenia resenia)
        {
            ValidadorString.ValidarStringVacio(resenia.Texto);
            ValidadorString.ValidarStringVacio(resenia.Datos.Apellido);
            ValidadorString.ValidarStringVacio(resenia.Datos.Nombre);
            ValidarPuntaje(resenia.Puntaje);
        }
        private static void ValidarPuntaje(int puntaje)
        {
            if (puntaje > MAX_PUNTAJE || puntaje < MIN_PUNTAJE)
                throw new PuntajeFueraDeRangoException();
        }
    }
}
