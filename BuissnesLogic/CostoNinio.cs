using System;
using System.Collections.Generic;
using System.Text;

namespace BuissnesLogic
{
    public class CostoNinio : ICosto
    {
        protected override void SetMultiplicador()
        {
            MULTIPLICADOR = 0.5;
        }
    }
}
