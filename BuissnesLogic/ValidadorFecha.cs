using Exceptiones;
using System;
using System.Collections.Generic;
using System.Text;

namespace BuissnesLogic
{
    public class ValidadorFecha
    {
        public static bool FechaMenorOIgual(DateTime fechaMenor, DateTime fecha)
        {
            FechaVacia(fecha);
            FechaVacia(fechaMenor);

            return fechaMenor <= fecha;
        }
        private static void FechaVacia(DateTime fecha)
        {
            DateTime vacia = new DateTime();
            if (fecha.Equals(vacia))
                throw new FechaVaciaException();
        }

        public static bool FechaMenor(DateTime fechaMenor, DateTime fecha)
        {
            FechaVacia(fecha);
            FechaVacia(fechaMenor);
            return fechaMenor < fecha;
        }
    }
}
