using Exceptiones;
using System;
using System.Collections.Generic;
using System.Text;

namespace BuissnesLogic
{
    public class ValidadorString
    {
        public static string ValidarStringVacio(string aValidar)
        {
            if (string.IsNullOrWhiteSpace(aValidar))
                throw new StringVacioException();
            return aValidar;
        }
    }
}
