using System;
using System.Collections.Generic;
using System.Text;

namespace BuissnesLogic
{
    public class CostoBebe : ICosto
    {
        protected override void SetMultiplicador()
        {
            MULTIPLICADOR = 0.25 ;
        }
    }
}
