using BuisnessLogic.Domain;
using BuissnesLogic;
using BuissnesLogic_Interface;
using Domain;
using Domain.Enums;
using Exceptiones;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Assert = NUnit.Framework.Assert;

namespace BuisnessLogic_Test
{
    class GenerarReporte_Test
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void TestGenerarReporteOk()
        {
            List<CantReservasPorHospedaje> lista = new List<CantReservasPorHospedaje>();
            var logicaReservaMock = new Mock<IReserva>(MockBehavior.Strict);
            IGenerarReporte generador = new GenerarReporteConcretoA(logicaReservaMock.Object);
            PuntoTuristico punto = new PuntoTuristico() { Id = 0, Nombre = "Test" };
            DateTime inicio = new DateTime(2020, 10, 9);
            DateTime fin = new DateTime(2020, 10, 19);
            EstadoReserva estado = EstadoReserva.Creada;
            DatosReporte datos = new DatosReporte() {PuntoId=punto.Id,Inicio=inicio,Fin=fin };
            Hospedaje hospedaje1 = new Hospedaje() { NombreHospedaje = "Hospedaje1",PuntoTuristico=punto };
            Hospedaje hospedaje2 = new Hospedaje() { NombreHospedaje = "Hospedaje2", PuntoTuristico = punto };
            Reserva reserva1 = new Reserva() { Hospedaje = hospedaje1, CheckIn = inicio, CheckOut = fin, Estado = estado };
            Reserva reserva2 = new Reserva() { Hospedaje = hospedaje1, CheckIn = inicio, CheckOut = fin, Estado = estado };
            Reserva reserva3 = new Reserva() { Hospedaje = hospedaje2, CheckIn = inicio, CheckOut = fin, Estado = estado };
            bool condicionCantElem = false;
            bool condicionElemOrd = false;
            bool condicion = false;
            List<Reserva> reservas = new List<Reserva>();
            reservas.Add(reserva1);
            reservas.Add(reserva2);
            reservas.Add(reserva3);

            logicaReservaMock.Setup(x => x.ObtenerTodos()).Returns(reservas);

            lista = generador.GenerarReporte(datos);
            condicionCantElem = (lista.Count == 2);
            condicionElemOrd = (lista.First().NombreHospedaje.Equals(hospedaje1.NombreHospedaje));
            
            condicion = condicionCantElem && condicionElemOrd;
            Assert.IsTrue(condicion);
        }

        [Test]
        [ExpectedException(typeof(NoHayReservasException))]
        public void TestGenerarReporteSinReservasParaEsePunto()
        {
            List<CantReservasPorHospedaje> lista = new List<CantReservasPorHospedaje>();
            var logicaReservaMock = new Mock<IReserva>(MockBehavior.Strict);
            IGenerarReporte generador = new GenerarReporteConcretoA(logicaReservaMock.Object);
            PuntoTuristico puntoEsta = new PuntoTuristico() { Id = 0 };
            PuntoTuristico puntoNoEsta = new PuntoTuristico() { Id = 1 };
            DateTime inicio = new DateTime(2020, 10, 9);
            DateTime fin = new DateTime(2020, 10, 19);
            EstadoReserva estado = EstadoReserva.Creada;
            DatosReporte datos = new DatosReporte() {PuntoId = puntoNoEsta.Id, Inicio = inicio, Fin = fin };

            Hospedaje hospedaje = new Hospedaje() { NombreHospedaje = "Hospedaje2", PuntoTuristico = puntoEsta };
            Reserva reserva = new Reserva() { Hospedaje = hospedaje, CheckIn = inicio, CheckOut = fin, Estado = estado };
            List<Reserva> reservas = new List<Reserva>() { reserva};


            logicaReservaMock.Setup(x => x.ObtenerTodos()).Returns(reservas);

            Assert.Throws<NoHayReservasException>(()=> generador.GenerarReporte(datos));
        }

        [Test]
        public void TestGenerarReporteFechaFueraDeRango()
        {
            List<CantReservasPorHospedaje> lista = new List<CantReservasPorHospedaje>();
            var logicaReservaMock = new Mock<IReserva>(MockBehavior.Strict);
            IGenerarReporte generador = new GenerarReporteConcretoA(logicaReservaMock.Object);
            PuntoTuristico puntoEsta = new PuntoTuristico() { Id = 0 };
            PuntoTuristico puntoNoEsta = new PuntoTuristico() { Id = 1 };
            DateTime datosInicio = new DateTime(2020, 10, 9);
            DateTime datosFin = new DateTime(2020, 10, 19);
            DateTime reservaInicio = new DateTime(2020, 9, 9);
            DateTime reservaFin = new DateTime(2020, 9, 19);
            EstadoReserva estado = EstadoReserva.Creada;
            DatosReporte datos = new DatosReporte() {PuntoId=puntoNoEsta.Id, Inicio = datosInicio, Fin = datosFin };

            Hospedaje hospedaje = new Hospedaje() { NombreHospedaje = "Hospedaje2", PuntoTuristico = puntoEsta };
            Reserva reserva = new Reserva() { Hospedaje = hospedaje, CheckIn = reservaInicio, CheckOut = reservaFin, Estado = estado };
            List<Reserva> reservas = new List<Reserva>() { reserva };


            logicaReservaMock.Setup(x => x.ObtenerTodos()).Returns(reservas);

            Assert.Throws<NoHayReservasException>(() => generador.GenerarReporte(datos));
        }

        [Test]
        public void TestGenerarReporteConEstadoInvalido()
        {
            List<CantReservasPorHospedaje> lista = new List<CantReservasPorHospedaje>();
            var logicaReservaMock = new Mock<IReserva>(MockBehavior.Strict);
            IGenerarReporte generador = new GenerarReporteConcretoA(logicaReservaMock.Object);
            PuntoTuristico punto = new PuntoTuristico() { Id = 0, Nombre = "Test" };
            DateTime inicio = new DateTime(2020, 10, 9);
            DateTime fin = new DateTime(2020, 10, 19);
            DatosReporte datos = new DatosReporte() {PuntoId=punto.Id, Inicio = inicio, Fin = fin };
            
            Hospedaje hospedaje1 = new Hospedaje() { NombreHospedaje = "Hospedaje1", PuntoTuristico = punto };
            Reserva reserva1 = new Reserva() { Hospedaje = hospedaje1, CheckIn = inicio, CheckOut = fin, Estado=EstadoReserva.Aceptada };
            Reserva reserva2 = new Reserva() { Hospedaje = hospedaje1, CheckIn = inicio, CheckOut = fin, Estado=EstadoReserva.Expirada };
            
            List<Reserva> reservas = new List<Reserva>();
            reservas.Add(reserva1);
            reservas.Add(reserva2);

            logicaReservaMock.Setup(x => x.ObtenerTodos()).Returns(reservas);

            lista = generador.GenerarReporte(datos);

            Assert.AreEqual(1,lista.Count);
        }
    }
}
