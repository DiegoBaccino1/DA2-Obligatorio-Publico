using BuissnesLogic;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Text;

namespace BuisnessLogic_Test
{
    class CostoAdulto_Test
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void TestCalcularCostoOk()
        {
            int precioPorNoche = 140;
            int cantHuespedes = 2;
            int dias = 3;
            var esperado = 840;
            var logica = new CostoAdulto();
            var resultado = logica.Costo(dias,precioPorNoche,cantHuespedes);
            Assert.AreEqual(esperado, resultado);
        }
        [Test]
        public void TestCalcularCostoSinHuespedes()
        {
            int precioPorNoche = 140;
            int cantHuespedes = 0;
            int dias = 3;
            var esperado = 0;
            var logica = new CostoAdulto();
            var resultado = logica.Costo(dias, precioPorNoche, cantHuespedes);
            Assert.AreEqual(esperado, resultado);
        }
    }
}
