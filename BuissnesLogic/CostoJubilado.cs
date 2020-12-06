using System;
using System.Collections.Generic;
using System.Text;

namespace BuissnesLogic
{
    public class CostoJubilado : ICosto
    {
        private static bool PaganTotal = false;
        public override int Costo(int dias, int precioPorNoche, int cantHuespedes)
        {
            int costoTotal = 0;
            int cantPaganDescuento=CantidadPaganDescuento(cantHuespedes);
            costoTotal = CalcularCostoDescontado(dias, precioPorNoche,cantPaganDescuento);

            int cantPaganTotal = cantHuespedes - cantPaganDescuento;
            costoTotal += CalcularTotal(dias, precioPorNoche, cantPaganTotal);

            return costoTotal;
        }

        private int CalcularTotal(int dias, int precioPorNoche, int cantPaganTotal)
        {
            PaganTotal = true;
            SetMultiplicador();
            return base.Costo(dias, precioPorNoche, cantPaganTotal);
        }

        private int CalcularCostoDescontado(int dias, int precioPorNoche,int cantPaganDescuento)
        {
            PaganTotal = false;
            SetMultiplicador();
            return base.Costo(dias, precioPorNoche, cantPaganDescuento);
        }

        private int CantidadPaganDescuento(int cantHuespedes)
        {
           return cantHuespedes/2;
        }

        protected override void SetMultiplicador()
        {
            if (PaganTotal)
                MULTIPLICADOR = 1;
            else
                MULTIPLICADOR = 0.7;
        }
    }
}
