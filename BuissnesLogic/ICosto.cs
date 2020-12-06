using System;
using System.Collections.Generic;
using System.Text;

namespace BuissnesLogic
{
    public abstract class ICosto
    {
        protected double MULTIPLICADOR { get; set; }
        public virtual int Costo(int dias, int precioPorNoche, int cantHuespedes) 
        {
            this.SetMultiplicador();
            return (int)( dias * precioPorNoche * cantHuespedes * MULTIPLICADOR);
        }
        protected abstract void SetMultiplicador();
    }
}
