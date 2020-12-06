using BuisnessLogic.Domain;
using BuissnesLogic_Interface;
using Domain;
using Domain.Enums;
using Exceptiones;
using Microsoft.AspNetCore.Mvc;
using Moq;
using NUnit.Framework;
using Obligatorio.Controllers;
using System;
using System.Collections.Generic;
using System.Text;

namespace Controller_Test
{
    public class ReservasController_Test
    {
        //POST Tests
        //------------------
        [Test]
        public void PostReservaOk()
        {
            string stringPrueba = "test";
            var logicMock = new Mock<IReserva>(MockBehavior.Strict);
            var logicMockHospedaje = new Mock<IHospedaje>(MockBehavior.Strict);
            ReservasController controller = new ReservasController(logicMock.Object,logicMockHospedaje.Object);
            DateTime checkIn = new DateTime(2020, 10, 9);
            DateTime checkOut = new DateTime(2020, 10, 11);
            const int intTest = 1;
            CantHuespedes huespedes = new CantHuespedes()
            {
                CantJubilados = 0,
                CantAdultos = intTest,
                CantBebes = intTest,
                CantNinios = intTest,
            };
            HospedajeFiltro filtro =new HospedajeFiltro() 
            {
                Huespedes=huespedes,
                CheckIn= checkIn,
                CheckOut = checkOut,
            };

            DatosUsuario datos = new DatosUsuario() 
            {
                Nombre= stringPrueba,
                Apellido= stringPrueba,
                Mail= stringPrueba
            };

            logicMock.Setup(x => x.Reserva(filtro,intTest,datos)).Returns(It.IsAny<Reserva>());
            logicMock.Setup(x => x.AgregarReserva(It.IsAny<Reserva>()));

            ObjetoPostReserva objeto = new ObjetoPostReserva() { HospedajeId = intTest, Datos = datos, Filtro = filtro };

            var result = controller.Post(intTest,objeto);
            var okResult = result as OkObjectResult;

            logicMock.VerifyAll();
        }

        [Test]
        public void PostReservaDatosNull()
        {
            var logicMock = new Mock<IReserva>(MockBehavior.Strict);
            var logicMockHospedaje = new Mock<IHospedaje>(MockBehavior.Strict);
            ReservasController controller = new ReservasController(logicMock.Object, logicMockHospedaje.Object);
            DateTime checkIn = new DateTime(2020, 10, 9);
            DateTime checkOut = new DateTime(2020, 10, 11);
            const int intTest = 1;
            CantHuespedes huespedes = new CantHuespedes()
            {
                CantJubilados = 0,
                CantAdultos = intTest,
                CantBebes = intTest,
                CantNinios = intTest,
            };

            HospedajeFiltro filtro = new HospedajeFiltro()
            {
                Huespedes=huespedes,
                CheckIn = checkIn,
                CheckOut = checkOut,
            };
            ObjetoPostReserva objeto = new ObjetoPostReserva() { HospedajeId = intTest, Datos = null, Filtro = filtro };

            var result = controller.Post(intTest, objeto);
            var okResult = result as BadRequestObjectResult;

            logicMock.VerifyAll();
        }


        [Test]
        public void PostReservaFiltroNull()
        {
            string stringPrueba = "test";
            var logicMock = new Mock<IReserva>(MockBehavior.Strict);
            var logicMockHospedaje = new Mock<IHospedaje>(MockBehavior.Strict);
            ReservasController controller = new ReservasController(logicMock.Object, logicMockHospedaje.Object);
            DateTime checkIn = new DateTime(2020, 10, 9);
            DateTime checkOut = new DateTime(2020, 10, 11);
            const int intTest = 1;
            DatosUsuario datos = new DatosUsuario()
            {
                Nombre = stringPrueba,
                Apellido = stringPrueba,
                Mail = stringPrueba
            };
            ObjetoPostReserva objeto = new ObjetoPostReserva() { HospedajeId = intTest, Datos = datos, Filtro = null };

            var result = controller.Post(intTest, objeto);
            var okResult = result as BadRequestObjectResult;

            logicMock.VerifyAll();
        }

        [Test]
        public void PostHospedajeInValido()
        {
            string stringPrueba = "test";
            var logicMock = new Mock<IReserva>(MockBehavior.Strict);
            var logicMockHospedaje = new Mock<IHospedaje>(MockBehavior.Strict);
            ReservasController controller = new ReservasController(logicMock.Object, logicMockHospedaje.Object);
            DateTime checkIn = new DateTime(2020, 10, 9);
            DateTime checkOut = new DateTime(2020, 10, 11);
            const int intTest = 1;
            CantHuespedes huespedes = new CantHuespedes()
            {
                CantJubilados = 0,
                CantAdultos = intTest,
                CantBebes = intTest,
                CantNinios = intTest,
            };

            HospedajeFiltro filtro = new HospedajeFiltro()
            {
                Huespedes=huespedes,
                CheckIn = checkIn,
                CheckOut = checkOut,
            };
            DatosUsuario datos = new DatosUsuario()
            {
                Nombre = stringPrueba,
                Apellido = stringPrueba,
                Mail = stringPrueba
            };
            ObjetoPostReserva objeto = new ObjetoPostReserva() { HospedajeId = 15, Datos = datos, Filtro = filtro };
            
            logicMock.Setup(x => x.Reserva(filtro,(int)objeto.HospedajeId, datos)).Throws(new EntidadNoExisteExcepcion());
            
            var result = controller.Post(intTest, objeto);
            var okResult = result as NotFoundObjectResult;

            logicMock.VerifyAll();
        }

        [Test]
        public void PostReservaYaExisteId()
        {
            string stringPrueba = "test";
            var logicMock = new Mock<IReserva>(MockBehavior.Strict);
            var logicMockHospedaje = new Mock<IHospedaje>(MockBehavior.Strict);
            ReservasController controller = new ReservasController(logicMock.Object, logicMockHospedaje.Object);
            DateTime checkIn = new DateTime(2020, 10, 9);
            DateTime checkOut = new DateTime(2020, 10, 11);
            const int intTest = 1;
            CantHuespedes huespedes = new CantHuespedes()
            {
                CantJubilados = 0,
                CantAdultos = intTest,
                CantBebes = intTest,
                CantNinios = intTest,
            };

            HospedajeFiltro filtro = new HospedajeFiltro()
            {
                Huespedes=huespedes,
                CheckIn = checkIn,
                CheckOut = checkOut,
            };

            DatosUsuario datos = new DatosUsuario()
            {
                Nombre = stringPrueba,
                Apellido = stringPrueba,
                Mail = stringPrueba
            };

            logicMock.Setup(x => x.Reserva(filtro, intTest, datos)).Returns(It.IsAny<Reserva>());
            logicMock.Setup(x => x.AgregarReserva(It.IsAny<Reserva>())).Throws(new YaExisteLaEntidadExcepcion());
            
            ObjetoPostReserva objeto = new ObjetoPostReserva() { HospedajeId = intTest, Datos = datos, Filtro = filtro };

            var result = controller.Post(intTest, objeto);
            var okResult = result as BadRequestObjectResult;

            logicMock.VerifyAll();
        }

        //GET Tests
        //------------------
        [Test]
        public void GetAllReservasConElementoOk()
        {
            var logicMock = new Mock<IReserva>(MockBehavior.Strict);
            var logicMockHospedaje = new Mock<IHospedaje>(MockBehavior.Strict);
            ReservasController controller = new ReservasController(logicMock.Object, logicMockHospedaje.Object);

            logicMock.Setup(x => x.ObtenerTodos())
                .Returns(new List<Reserva>() { It.IsAny<Reserva>()});

            var result = controller.Get();
            var okResult = result as OkObjectResult;
            logicMock.VerifyAll();
        }

        [Test]
        public void GetAllReservasSinElementoOk()
        {
            var logicMock = new Mock<IReserva>(MockBehavior.Strict);
            var logicMockHospedaje = new Mock<IHospedaje>(MockBehavior.Strict);
            ReservasController controller = new ReservasController(logicMock.Object, logicMockHospedaje.Object);

            logicMock.Setup(x => x.ObtenerTodos())
                .Returns(new List<Reserva>());

            var result = controller.Get();
            var okResult = result as OkObjectResult;
            logicMock.VerifyAll();
        }

        [Test]
        public void GetReporteConElementoOk()
        {
            var reporteMock = new Mock<IGenerarReporte>(MockBehavior.Strict);
            var logicMock = new Mock<IReserva>(MockBehavior.Strict);
            var logicMockHospedaje = new Mock<IHospedaje>(MockBehavior.Strict);
            ReservasController controller = new ReservasController(logicMock.Object, logicMockHospedaje.Object);

            PuntoTuristico punto = new PuntoTuristico() { Id = 0, Nombre = "Test" };
            DatosReporte datos = new DatosReporte() { PuntoId = punto.Id };

            logicMock.Setup(x => x.ObtenerTodos())
                .Returns(new List<Reserva>() { new Reserva() { Id=0,Hospedaje=new Hospedaje()
                { Id=0,PuntoTuristico=punto },NombreTurista="Test"} });

            reporteMock.Setup(x => x.GenerarReporte(datos)).Returns(It.IsAny<List<CantReservasPorHospedaje>>());

            var result = controller.GetReporte(datos);
            var okResult = result as OkObjectResult;
            logicMock.VerifyAll();
        }
        [Test]
        public void GetReporteSinReservas()
        {
            var reporteMock = new Mock<IGenerarReporte>(MockBehavior.Strict);
            var logicMock = new Mock<IReserva>(MockBehavior.Strict);
            var logicMockHospedaje = new Mock<IHospedaje>(MockBehavior.Strict);
            ReservasController controller = new ReservasController(logicMock.Object, logicMockHospedaje.Object);

            logicMock.Setup(x => x.ObtenerTodos()).Returns(new List<Reserva>());
            reporteMock.Setup(x => x.GenerarReporte(It.IsAny<DatosReporte>())).Throws(new NoHayReservasException());

            var result = controller.GetReporte(It.IsAny<DatosReporte>());
            var okResult = result as BadRequestObjectResult;
            logicMock.VerifyAll();
        }
        [Test]
        public void GetReporteSinFecha()
        {
            var reporteMock = new Mock<IGenerarReporte>(MockBehavior.Strict);
            var logicMock = new Mock<IReserva>(MockBehavior.Strict);
            var logicMockHospedaje = new Mock<IHospedaje>(MockBehavior.Strict);
            ReservasController controller = new ReservasController(logicMock.Object, logicMockHospedaje.Object);

            logicMock.Setup(x => x.ObtenerTodos()).Returns(new List<Reserva>());
            reporteMock.Setup(x => x.GenerarReporte(It.IsAny<DatosReporte>())).Throws(new FechaVaciaException());

            var result = controller.GetReporte(It.IsAny<DatosReporte>());
            var okResult = result as BadRequestObjectResult;
            logicMock.VerifyAll();
        }
        [Test]
        public void GetEstadoOk()
        {
            var logicMock = new Mock<IReserva>(MockBehavior.Strict);
            var logicMockHospedaje = new Mock<IHospedaje>(MockBehavior.Strict);
            ReservasController controller = new ReservasController(logicMock.Object, logicMockHospedaje.Object);

            logicMock.Setup(x => x.ConsultarEstado(It.IsAny<int>())).Returns("Creada  Test");

            var result = controller.GetEstado(It.IsAny<int>());
            var okResult = result as OkObjectResult;
            logicMock.VerifyAll();
        }

        [Test]
        public void GetReservaIdOk()
        {
            var logicMock = new Mock<IReserva>(MockBehavior.Strict);
            var logicMockHospedaje = new Mock<IHospedaje>(MockBehavior.Strict);
            ReservasController controller = new ReservasController(logicMock.Object, logicMockHospedaje.Object);

            logicMock.Setup(x => x.ObtenerPorId(It.IsAny<int>())).Returns(It.IsAny<Reserva>());

            var result = controller.GetPorId(It.IsAny<int>());
            var okResult = result as OkObjectResult;
            logicMock.VerifyAll();
        }

        [Test]
        public void GetReservaIdNoExiste()
        {
            var logicMock = new Mock<IReserva>(MockBehavior.Strict);
            var logicMockHospedaje = new Mock<IHospedaje>(MockBehavior.Strict);
            ReservasController controller = new ReservasController(logicMock.Object, logicMockHospedaje.Object);

            logicMock.Setup(x => x.ObtenerPorId(It.IsAny<int>())).Throws(new EntidadNoExisteExcepcion());

            var result = controller.GetPorId(It.IsAny<int>());
            var okResult = result as NotFoundObjectResult;
            logicMock.VerifyAll();
        }

        //DELETE Tests
        //------------------
        [Test]
        public void DeleteReservaOk()
        {
            var logicMock = new Mock<IReserva>(MockBehavior.Strict);
            var logicMockHospedaje = new Mock<IHospedaje>(MockBehavior.Strict);
            ReservasController controller = new ReservasController(logicMock.Object, logicMockHospedaje.Object);

            logicMock.Setup(x => x.BorrarReserva(1));

            var result = controller.Delete(1);
            var okResult = result as OkObjectResult;

            logicMock.VerifyAll();
        }

        [Test]
        public void DeleteReservaNoExiste()
        {
            var logicMock = new Mock<IReserva>(MockBehavior.Strict);
            var logicMockHospedaje = new Mock<IHospedaje>(MockBehavior.Strict);
            ReservasController controller = new ReservasController(logicMock.Object, logicMockHospedaje.Object);

            logicMock.Setup(x => x.BorrarReserva(1)).Throws(new EntidadNoExisteExcepcion());

            var result = controller.Delete(1);
            var okResult = result as NotFoundObjectResult;

            logicMock.VerifyAll();

            Assert.AreEqual(404, okResult.StatusCode);
        }

        //PUT Tests
        //------------------
        [Test]
        public void PutModificarEstadoOk()
        {

            var logicMock = new Mock<IReserva>(MockBehavior.Strict);
            var logicMockHospedaje = new Mock<IHospedaje>(MockBehavior.Strict);
            ReservasController controller = new ReservasController(logicMock.Object, logicMockHospedaje.Object);

            int id = 1;
            string desc = "test";
            EstadoReserva estado = EstadoReserva.Aceptada;
            
            logicMock.Setup(x => x.ModificarEstado(id,desc,estado));

            var result = controller.PutEstado(id,desc,estado);
            var okResult = result as OkObjectResult;

            logicMock.VerifyAll();
        }

        [Test]
        public void PutModificarEstadoNoExiste()
        {
            var logicMock = new Mock<IReserva>(MockBehavior.Strict);
            var logicMockHospedaje = new Mock<IHospedaje>(MockBehavior.Strict);
            ReservasController controller = new ReservasController(logicMock.Object, logicMockHospedaje.Object);

            int id = 0;
            string desc = "test";
            EstadoReserva estado = EstadoReserva.Aceptada;
            
            logicMock.Setup(x => x.ModificarEstado(id, desc, estado)).
                        Throws(new EntidadNoExisteExcepcion());

            var result = controller.PutEstado(id, desc, estado);
            var okResult = result as NotFoundObjectResult;

            logicMock.VerifyAll();

            Assert.AreEqual(404, okResult.StatusCode);
        }

        [Test]
        public void PutModificarEstadodescripcionNull()
        {
            var logicMock = new Mock<IReserva>(MockBehavior.Strict);
            var logicMockHospedaje = new Mock<IHospedaje>(MockBehavior.Strict);
            ReservasController controller = new ReservasController(logicMock.Object, logicMockHospedaje.Object);

            int id = 0;
            EstadoReserva estado = EstadoReserva.Aceptada;

            var result = controller.PutEstado(id, null, estado);
            var okResult = result as BadRequestObjectResult;

            logicMock.VerifyAll();

            Assert.AreEqual(400, okResult.StatusCode);
        }
        [Test]
        public void PutAgregarReseniaOk()
        {

            var logicMock = new Mock<IReserva>(MockBehavior.Strict);
            var logicMockHospedaje = new Mock<IHospedaje>(MockBehavior.Strict);
            ReservasController controller = new ReservasController(logicMock.Object, logicMockHospedaje.Object);

            Resenia resenia = new Resenia() 
            {
                Puntaje = 1,
                Texto = "Test",
                Datos = new DatosUsuario() 
                    { 
                        Apellido = "Test",
                        Nombre = "ASD",
                        Mail = "a@b.c" 
                }
            };
            Hospedaje hospedaje = new Hospedaje()
            {
                Id = 0,
            };
            Reserva reserva = new Reserva()
            {
                Id = 0,
                ApellidoTurista = "Test",
                NombreTurista = "Test",
                Hospedaje=hospedaje,
            };
            logicMockHospedaje.Setup(x => x.AgregarResenia(hospedaje,resenia));
            logicMock.Setup(x => x.ObtenerPorId(reserva.Id)).Returns(reserva);

            var result = controller.PutResenia(hospedaje.Id,resenia);
            var okResult = result as OkObjectResult;

            logicMock.VerifyAll();
        }
        [Test]
        public void PutAgregarReseniaReservaNoExiste()
        {

            var logicMock = new Mock<IReserva>(MockBehavior.Strict);
            var logicMockHospedaje = new Mock<IHospedaje>(MockBehavior.Strict);
            ReservasController controller = new ReservasController(logicMock.Object, logicMockHospedaje.Object);

            Resenia resenia = new Resenia()
            {
                Puntaje = 1,
                Texto = "Test",
                Datos = new DatosUsuario()
                {
                    Apellido = "Test",
                    Nombre = "ASD",
                    Mail = "a@b.c"
                }
            };
            Hospedaje hospedaje = new Hospedaje()
            {
                Id = 0,
            };

            logicMockHospedaje.Setup(x => x.AgregarResenia(hospedaje, resenia));
            logicMock.Setup(x => x.ObtenerPorId(0)).Throws(new EntidadNoExisteExcepcion());

            var result = controller.PutResenia(hospedaje.Id, resenia);
            var okResult = result as NotFoundObjectResult;

            logicMock.VerifyAll();
        }
        [Test]
        public void PutAgregarReseniaDatosVacios()
        {

            var logicMock = new Mock<IReserva>(MockBehavior.Strict);
            var logicMockHospedaje = new Mock<IHospedaje>(MockBehavior.Strict);
            ReservasController controller = new ReservasController(logicMock.Object, logicMockHospedaje.Object);

            Resenia resenia = new Resenia()
            {
                Puntaje = 1,
                Texto = "Test",
                Datos = new DatosUsuario()
                {
                    Apellido = "Test",
                    Nombre = "ASD",
                    Mail = "a@b.c"
                }
            };
            Hospedaje hospedaje = new Hospedaje()
            {
                Id = 0,
            };
            Reserva reserva = new Reserva()
            {
                Id = 0,
                ApellidoTurista = "Test",
                NombreTurista = "Test",
                Hospedaje = hospedaje,
            };
            logicMockHospedaje.Setup(x => x.AgregarResenia(hospedaje, resenia)).Throws(new StringVacioException());
            logicMock.Setup(x => x.ObtenerPorId(reserva.Id)).Returns(reserva);

            var result = controller.PutResenia(hospedaje.Id, resenia);
            var okResult = result as BadRequestObjectResult;

            logicMock.VerifyAll();
        }
        [Test]
        public void PutAgregarReseniaPuntajeFueraDeRango()
        {

            var logicMock = new Mock<IReserva>(MockBehavior.Strict);
            var logicMockHospedaje = new Mock<IHospedaje>(MockBehavior.Strict);
            ReservasController controller = new ReservasController(logicMock.Object, logicMockHospedaje.Object);

            Resenia resenia = new Resenia()
            {
                Puntaje = 10,
                Texto = "Test",
                Datos = new DatosUsuario()
                {
                    Apellido = "Test",
                    Nombre = "ASD",
                    Mail = "a@b.c"
                }
            };
            Hospedaje hospedaje = new Hospedaje()
            {
                Id = 0,
            };
            Reserva reserva = new Reserva()
            {
                Id = 0,
                ApellidoTurista = "Test",
                NombreTurista = "Test",
                Hospedaje = hospedaje,
            };
            logicMockHospedaje.Setup(x => x.AgregarResenia(hospedaje, resenia)).Throws(new PuntajeFueraDeRangoException());
            logicMock.Setup(x => x.ObtenerPorId(reserva.Id)).Returns(reserva);

            var result = controller.PutResenia(hospedaje.Id, resenia);
            var okResult = result as BadRequestObjectResult;

            logicMock.VerifyAll();
        }
    }
}
