using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Text;

namespace BuissnesLogic
{
    public class CostoAdulto : ICosto
    {
        protected override void SetMultiplicador()
        {
            MULTIPLICADOR = 1;
        }
    }
}
