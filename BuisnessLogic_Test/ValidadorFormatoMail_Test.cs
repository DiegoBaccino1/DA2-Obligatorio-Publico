using BuissnesLogic;
using Exceptiones;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Text;
using Assert = NUnit.Framework.Assert;

namespace BuisnessLogic_Test
{
    public class ValidadorFormatoMail_Test
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void TestFormatoOk()
        {
            string mail = "a@b.c";
            ValidadorFormatoMail.ValidarFormato(mail);
            
        }
        [Test]
        [ExpectedException(typeof(FormatoInvalidoException))]
        public void TestFormatoInvalidoOk()
        {
            string mail = "asd";
            Assert.Throws<FormatoInvalidoException>(() => ValidadorFormatoMail.ValidarFormato(mail));
        }
    }
}
