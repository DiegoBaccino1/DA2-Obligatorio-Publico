using Exceptiones;
using System;
using System.Collections.Generic;
using System.Net.Mail;
using System.Text;

namespace BuissnesLogic
{
    public class ValidadorFormatoMail
    {
        public static void ValidarFormato(string email)
        {
            try
            {
                MailAddress mail = new MailAddress(email);
            }
            catch (FormatException)
            {
                throw new FormatoInvalidoException();
            }
        }
    }
}
