using BuissnesLogic;
using BuissnesLogic_Interface;
using DataAccessInterface;
using Domain;
using Domain.Enums;
using Exceptiones;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Text;
using Assert = NUnit.Framework.Assert;

namespace BuisnessLogic_Test
{
    public class Reserva_Test
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void TestCrearReservaValido()
        {
            CantHuespedes huespedes = new CantHuespedes()
            {
                CantAdultos = 1,
                CantBebes = 1,
                CantNinios = 1,
                CantJubilados=0,
            };
            HospedajeFiltro filtro = new HospedajeFiltro()
            {
                Huespedes = huespedes,
                CheckIn = new DateTime(2020, 10, 2),
                CheckOut = new DateTime(2020, 10, 2),
            };
            Hospedaje hospedaje = new Hospedaje() { Id = 0 };
            DatosUsuario datosTurista = new DatosUsuario() 
            {   
                Apellido = "test",
                Nombre = "Prueba",
                Mail = "test"
            };
            var logicaHospedajeMock = new Mock<IHospedaje>(MockBehavior.Strict);
            var repoMock = new Mock<IRepository<Reserva>>(MockBehavior.Strict);
            Reserva_Logic logica = new Reserva_Logic(repoMock.Object, logicaHospedajeMock.Object);
            logicaHospedajeMock.Setup(x => x.ObtenerPorId(0)).Returns(hospedaje);
            logicaHospedajeMock.Setup(x => x.ActualizarHospedaje(hospedaje));
            Reserva reserva = logica.Reserva(filtro,hospedaje.Id,datosTurista);
            Assert.AreEqual(hospedaje.Id, reserva.Hospedaje.Id);
        }

        [Test]
        [ExpectedException(typeof(YaExisteLaEntidadExcepcion))]
        public void TestAgregarReservaYaExsiste()
        {
            var logicaHospedajeMock = new Mock<IHospedaje>(MockBehavior.Strict);
            var repoMock = new Mock<IRepository<Reserva>>(MockBehavior.Strict);
            Reserva_Logic logica = new Reserva_Logic(repoMock.Object, logicaHospedajeMock.Object);
            Reserva reserva = new Reserva() { Id = 0 };
            Reserva reserva2 = new Reserva() { Id = 0 };
            repoMock.Setup(x => x.Create(reserva));
            repoMock.Setup(x => x.Save());
            repoMock.Setup(x => x.Get(0)).Throws(new EntidadNoExisteExcepcion());
            logica.AgregarReserva(reserva);
            repoMock.Setup(x => x.Get(0)).Throws(new YaExisteLaEntidadExcepcion());
            Assert.Throws<YaExisteLaEntidadExcepcion>(() => logica.AgregarReserva(reserva2));
        }

        [Test]
        public void ModificarEstadoTest()
        {
            var logicaHospedajeMock = new Mock<IHospedaje>(MockBehavior.Strict);
            var repoMock = new Mock<IRepository<Reserva>>(MockBehavior.Strict);
            Reserva_Logic logica = new Reserva_Logic(repoMock.Object, logicaHospedajeMock.Object);
            Reserva reserva = new Reserva()
            {
                Id = 0,
                Descripcion = "",
                Estado = EstadoReserva.Creada,
            };
            EstadoReserva nuevoEstado = EstadoReserva.Aceptada;
            string desc = "Test";
            string esperado = "Aceptada" + " " + "Test";
            repoMock.Setup(x => x.Get(reserva.Id)).Returns(reserva);
            repoMock.Setup(x => x.Update(reserva));
            repoMock.Setup(x => x.Save());
            logica.ModificarEstado(reserva.Id, desc, nuevoEstado);
            string resultado = logica.ConsultarEstado(reserva.Id);
            Assert.AreEqual(esperado, resultado);
        }

        [Test]
        [ExpectedException(typeof(EntidadNoExisteExcepcion))]
        public void ObtenerReservaIdNoExiste()
        {
            var logicaHospedajeMock = new Mock<IHospedaje>(MockBehavior.Strict);
            var repoMock = new Mock<IRepository<Reserva>>(MockBehavior.Strict);
            Reserva_Logic logica = new Reserva_Logic(repoMock.Object, logicaHospedajeMock.Object);
            Reserva reserva = new Reserva() { Id = 0 };
            repoMock.Setup(x => x.Get(2)).Throws(new EntidadNoExisteExcepcion());
            Assert.Throws<EntidadNoExisteExcepcion>(() => logica.ObtenerPorId(2));
        }

        [Test]
        public void ObtenerReservaIdValido()
        {
            var logicaHospedajeMock = new Mock<IHospedaje>(MockBehavior.Strict);
            var repoMock = new Mock<IRepository<Reserva>>(MockBehavior.Strict);
            Reserva_Logic logica = new Reserva_Logic(repoMock.Object, logicaHospedajeMock.Object);
            Reserva reserva = new Reserva() { Id = 0 };
            repoMock.Setup(x => x.Get(reserva.Id)).Returns(reserva);
            Assert.AreEqual(0,reserva.Id);
        }

        [Test]
        public void ConsultarEstadoTest()
        {
            var logicaHospedajeMock = new Mock<IHospedaje>(MockBehavior.Strict);
            var repoMock = new Mock<IRepository<Reserva>>(MockBehavior.Strict);
            Reserva_Logic logica = new Reserva_Logic(repoMock.Object, logicaHospedajeMock.Object);
            Reserva reserva = new Reserva()
            {
                Id = 0,
                Descripcion = "Test",
                Estado = EstadoReserva.Creada,
            };
            repoMock.Setup(x => x.Get(reserva.Id)).Returns(reserva);
            string esperado = "Creada" + " " + "Test";
            string resultado = logica.ConsultarEstado(reserva.Id);
            Assert.AreEqual(esperado,resultado);
        }
        [Test]
        public void ObtenerTodosTest()
        {
            var logicaHospedajeMock = new Mock<IHospedaje>(MockBehavior.Strict);
            var repoMock = new Mock<IRepository<Reserva>>(MockBehavior.Strict);
            Reserva_Logic logica = new Reserva_Logic(repoMock.Object, logicaHospedajeMock.Object);
            Reserva reserva = new Reserva()
            {
                Id = 0,
                Descripcion = "Test",
                Estado = EstadoReserva.Creada,
            };
            repoMock.Setup(x => x.GetAll()).Returns(new List<Reserva>() { reserva });
            List<Reserva> resultado = logica.ObtenerTodos();
            Assert.AreEqual(1, resultado.Count);
        }
        [Test]
        public void BorrarReservaTest()
        {
            var logicaHospedajeMock = new Mock<IHospedaje>(MockBehavior.Strict);
            var repoMock = new Mock<IRepository<Reserva>>(MockBehavior.Strict);
            Reserva_Logic logica = new Reserva_Logic(repoMock.Object, logicaHospedajeMock.Object);
            Reserva reserva = new Reserva()
            {
                Id = 0,
                Descripcion = "Test",
                Estado = EstadoReserva.Creada,
            };
            repoMock.Setup(x => x.Create(reserva));
            repoMock.Setup(x => x.Save());
            repoMock.Setup(x => x.Get(reserva.Id)).Throws(new EntidadNoExisteExcepcion());
            logica.AgregarReserva(reserva);
            repoMock.Setup(x => x.Get(reserva.Id)).Returns(reserva);
            repoMock.Setup(x => x.Delete(reserva));
            logica.BorrarReserva(reserva.Id);
            repoMock.Setup(x => x.GetAll()).Returns(new List<Reserva>());
            List<Reserva> resultado = logica.ObtenerTodos();
            Assert.AreEqual(0, resultado.Count);
        }
    }
}
