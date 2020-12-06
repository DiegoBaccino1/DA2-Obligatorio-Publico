using BuissnesLogic;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Text;

namespace BuisnessLogic_Test
{
    class CostoJubilado_Test
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void TestCalcularCostoUnHuespedPagaTotal()
        {
            int precioPorNoche = 140;
            int cantHuespedes = 1;
            int dias = 3;
            var esperado = 420;
            var logica = new CostoJubilado();
            var resultado = logica.Costo(dias, precioPorNoche, cantHuespedes);
            Assert.AreEqual(esperado, resultado);
        }

        [Test]
        public void TestCalcularCostoUnHuespedPagaTotalYUnoDescuento()
        {
            int precioPorNoche = 140;
            int cantHuespedes = 2;
            int dias = 3;
            var esperado = 714;
            var logica = new CostoJubilado();
            var resultado = logica.Costo(dias, precioPorNoche, cantHuespedes);
            Assert.AreEqual(esperado, resultado);
        }
        [Test]
        public void TestCalcularCostoDosHuespedPagaTotalYUnoDescuento()
        {
            int precioPorNoche = 140;
            int cantHuespedes = 3;
            int dias = 3;
            var esperado = 1134;
            var logica = new CostoJubilado();
            var resultado = logica.Costo(dias, precioPorNoche, cantHuespedes);
            Assert.AreEqual(esperado, resultado);
        }
        [Test]
        public void TestCalcularCostoDosHuespedPagaTotalYDosDescuento()
        {
            int precioPorNoche = 140;
            int cantHuespedes = 4;
            int dias = 3;
            var esperado = 1428;
            var logica = new CostoJubilado();
            var resultado = logica.Costo(dias, precioPorNoche, cantHuespedes);
            Assert.AreEqual(esperado, resultado);
        }
        [Test]
        public void TestCalcularCostoSinHuespedes()
        {
            int precioPorNoche = 140;
            int cantHuespedes = 0;
            int dias = 3;
            var esperado = 0;
            var logica = new CostoJubilado();
            var resultado = logica.Costo(dias, precioPorNoche, cantHuespedes);
            Assert.AreEqual(esperado, resultado);
        }
    }
}
