using BuissnesLogic;
using Domain;
using Exceptiones;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Security.Cryptography.Xml;
using System.Text;
using Assert = NUnit.Framework.Assert;

namespace BuisnessLogic_Test
{
    public class ValidadorResenia_Test
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void TestPuntajeLimiteArribaOk()
        {
            int puntaje = 5;
            Resenia resenia = new Resenia()
            {
                Puntaje = puntaje,
                Texto = "Test",
                Datos = new DatosUsuario() { Apellido = "Test", Nombre = "Test", Mail = "a@b.c" },
            };
            ValidadorResenia.ValidarResenia(resenia);
        }
        [Test]
        public void TestPuntajeLimiteAbajoOk()
        {
            int puntaje = 1;
            Resenia resenia = new Resenia()
            {
                Puntaje = puntaje,
                Texto = "Test",
                Datos = new DatosUsuario() { Apellido = "Test", Nombre = "Test", Mail = "a@b.c" },
            };
            ValidadorResenia.ValidarResenia(resenia);
        }
        [Test]
        [ExpectedException(typeof(PuntajeFueraDeRangoException))]
        public void TestPuntajeMayorMaximo()
        {
            int puntaje = 6;
            Resenia resenia = new Resenia()
            {
                Puntaje = puntaje,
                Texto = "Test",
                Datos = new DatosUsuario() { Apellido = "Test", Nombre = "Test", Mail = "a@b.c" },
            };
            Assert.Throws<PuntajeFueraDeRangoException>(() => ValidadorResenia.ValidarResenia(resenia));
        }
        [Test]
        [ExpectedException(typeof(PuntajeFueraDeRangoException))]
        public void TestPuntajeMenorMinimo()
        {
            int puntaje = 0;
            Resenia resenia = new Resenia()
            {
                Puntaje = puntaje,
                Texto = "Test",
                Datos = new DatosUsuario() { Apellido = "Test", Nombre = "Test", Mail = "a@b.c" },
            };
            Assert.Throws<PuntajeFueraDeRangoException>(() => ValidadorResenia.ValidarResenia(resenia));
        }
    }
}
