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
    public class ValidadorFecha_Test
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void TestEsFechaMenorOIgualOk()
        {
            DateTime fecha = new DateTime(2020, 10, 9);
            DateTime fecha2 = new DateTime(2020, 10, 19);
            var resultado = ValidadorFecha.FechaMenorOIgual(fecha,fecha2);
            Assert.IsTrue(resultado);
        }
        [Test]
        public void TestEsFechaIgualOk()
        {
            DateTime fecha = new DateTime(2020, 10, 19);
            DateTime fecha2 = new DateTime(2020, 10, 19);
            var resultado = ValidadorFecha.FechaMenorOIgual(fecha, fecha2);
            Assert.IsTrue(resultado);
        }
        [Test]
        public void TestNoEsFechaMenorOIgual()
        {
            DateTime fecha = new DateTime(2020, 10, 9);
            DateTime fecha2 = new DateTime(2020, 10, 19);
            var resultado = ValidadorFecha.FechaMenorOIgual(fecha2, fecha);
            Assert.IsFalse(resultado);
        }

        [Test]
        public void TestEsFechaMenorOk()
        {
            DateTime fecha = new DateTime(2020, 10, 9);
            DateTime fecha2 = new DateTime(2020, 10, 19);
            var resultado = ValidadorFecha.FechaMenor(fecha, fecha2);
            Assert.IsTrue(resultado);
        }
        [Test]
        public void TestNoEsFechaMenor()
        {
            DateTime fecha = new DateTime(2020, 10, 9);
            DateTime fecha2 = new DateTime(2020, 10, 19);
            var resultado = ValidadorFecha.FechaMenor(fecha2, fecha);
            Assert.IsFalse(resultado);
        }

        [Test]
        public void TestEsFechaIgualNoMenorOk()
        {
            DateTime fecha = new DateTime(2020, 10, 19);
            DateTime fecha2 = new DateTime(2020, 10, 19);
            var resultado = ValidadorFecha.FechaMenor(fecha, fecha2);
            Assert.IsFalse(resultado);
        }
        [Test]
        [ExpectedException(typeof(FechaVaciaException))]
        public void TestFechaVaciaEnMenorEstricto()
        {
            DateTime fecha = new DateTime();
            DateTime fecha2 = new DateTime(2020, 10, 19);
            Assert.Throws<FechaVaciaException>(() => ValidadorFecha.FechaMenor(fecha, fecha2));
        }

        [Test]
        [ExpectedException(typeof(FechaVaciaException))]
        public void TestFechaVacia()
        {
            DateTime fecha = new DateTime();
            DateTime fecha2 = new DateTime(2020, 10, 19);
            Assert.Throws<FechaVaciaException>(()=> ValidadorFecha.FechaMenorOIgual(fecha, fecha2));
        }

    }
}
