using BuisnessLogic.Domain;
using BuissnesLogic_Interface;
using Domain;
using Exceptiones;
using Microsoft.AspNetCore.Mvc;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using NUnit.Framework;
using Obligatorio.Controllers;
using Obligatorio.Models;
using System;
using System.Collections.Generic;
using System.Text;
using Assert = NUnit.Framework.Assert;

namespace Controller_Test
{
    public class HospedajesController_Test
    {
        //POST Tests
        //------------------
        [Test]
        public void PostHospedajeOk()
        {
            string stringPrueba = "Test";
            int intPrueba = 5;
            var logicMock = new Mock<IHospedaje>(MockBehavior.Strict);
            HospedajesController controller = new HospedajesController(logicMock.Object);
            HospedajeModel hospedajeModel = new HospedajeModel()
            {
                NombreHospedaje = stringPrueba,
                Descripcion = stringPrueba,
                Direccion = stringPrueba,
                CantidadEstrellas = intPrueba,
                Capacidad = intPrueba,
                PrecioPorNoche = intPrueba,
                PrecioTotalPeriodo = intPrueba,
                Imagenes = new List<Imagen>() { new Imagen() { Ruta = stringPrueba, Id = intPrueba } },
            };
            Hospedaje hospedaje = hospedajeModel.ToEntity();

            logicMock.Setup(x => x.AgregarHospedaje(It.IsAny<Hospedaje>()));

            var result = controller.Post(1, hospedajeModel);

            var okResult = result as OkObjectResult;
            var hospedajeRet = okResult.Value as Hospedaje;

            logicMock.VerifyAll();
            Assert.AreEqual(stringPrueba, hospedajeRet.NombreHospedaje);
        }

        [Test]
        public void PostHospedajeNombreVacio()
        {
            string stringPrueba = "Test";
            int intPrueba = 5;
            var logicMock = new Mock<IHospedaje>(MockBehavior.Strict);
            HospedajesController controller = new HospedajesController(logicMock.Object);
            HospedajeModel hospedajeModel = new HospedajeModel()
            {
                NombreHospedaje = stringPrueba,
                Descripcion = stringPrueba,
                Direccion = stringPrueba,
                CantidadEstrellas = intPrueba,
                Capacidad = intPrueba,
                PrecioPorNoche = intPrueba,
                PrecioTotalPeriodo = intPrueba,
                Imagenes = new List<Imagen>() { new Imagen() { Ruta = stringPrueba, Id = intPrueba } },
            };
            Hospedaje hospedaje = hospedajeModel.ToEntity();

            logicMock.Setup(x => x.AgregarHospedaje(It.IsAny<Hospedaje>())).
                            Throws(new NombreNoValidoException());

            var result = controller.Post(1, hospedajeModel);
            var okResult = result as BadRequestObjectResult;
            logicMock.VerifyAll();
            Assert.AreEqual(400, okResult.StatusCode);
        }

        [Test]
        public void PostHospedajeNombreVacioEspacio()
        {
            string stringPrueba = "Test";
            int intPrueba = 5;
            var logicMock = new Mock<IHospedaje>(MockBehavior.Strict);
            HospedajesController controller = new HospedajesController(logicMock.Object);
            HospedajeModel hospedajeModel = new HospedajeModel()
            {
                NombreHospedaje = stringPrueba,
                Descripcion = stringPrueba,
                Direccion = stringPrueba,
                CantidadEstrellas = intPrueba,
                Capacidad = intPrueba,
                PrecioPorNoche = intPrueba,
                PrecioTotalPeriodo = intPrueba,
                Imagenes = new List<Imagen>() { new Imagen() { Ruta = stringPrueba, Id = intPrueba } },
            };
            Hospedaje hospedaje = hospedajeModel.ToEntity();

            logicMock.Setup(x => x.AgregarHospedaje(It.IsAny<Hospedaje>())).
                            Throws(new NombreNoValidoException());

            var result = controller.Post(1, hospedajeModel);
            var okResult = result as BadRequestObjectResult;
            logicMock.VerifyAll();
            Assert.AreEqual(400, okResult.StatusCode);
        }

        //GET Tests
        //------------------
        [Test]
        public void GetAllHospedajesConElementoOk()
        {
            string stringPrueba = "Test";
            int intPrueba = 5;
            var logicMock = new Mock<IHospedaje>(MockBehavior.Strict);
            HospedajesController controller = new HospedajesController(logicMock.Object);
            HospedajeModel hospedajeModel = new HospedajeModel()
            {
                NombreHospedaje = stringPrueba,
                Descripcion = stringPrueba,
                Direccion = stringPrueba,
                CantidadEstrellas = intPrueba,
                Capacidad = intPrueba,
                PrecioPorNoche = intPrueba,
                PrecioTotalPeriodo = intPrueba,
                Imagenes = new List<Imagen>() { new Imagen() { Ruta = stringPrueba, Id = intPrueba } },
            };
            Hospedaje hospedaje = hospedajeModel.ToEntity();

            List<Hospedaje> lista = new List<Hospedaje>() { hospedaje};
            logicMock.Setup(x => x.ObtenerTodos()).Returns(lista);

            var result = controller.Get();
            var okResult = result as OkObjectResult;
            var retorno = okResult.Value as List<Hospedaje>;
            logicMock.VerifyAll();
            Assert.AreEqual(1, retorno.Count);
        }

        [Test]
        public void GetAllHospedajesSinElementoOk()
        {
            var logicMock = new Mock<IHospedaje>(MockBehavior.Strict);
            HospedajesController controller = new HospedajesController(logicMock.Object);
            List<Hospedaje> lista = new List<Hospedaje>();

            logicMock.Setup(x => x.ObtenerTodos()).Returns(lista);

            var result = controller.Get();
            var okResult = result as OkObjectResult;
            var retorno = okResult.Value as List<Hospedaje>;
            logicMock.VerifyAll();
            Assert.AreEqual(0, retorno.Count);
        }

        [Test]
        public void GetHospedajesPorPuntoYFiltroOk()
        {
            string stringPrueba = "Test";
            int intPrueba = 5;
            int puntoId = 0;
            var logicMock = new Mock<IHospedaje>(MockBehavior.Strict);
            HospedajesController controller = new HospedajesController(logicMock.Object);
            HospedajeModel hospedajeModel = new HospedajeModel()
            {
                NombreHospedaje = stringPrueba,
                Descripcion = stringPrueba,
                Direccion = stringPrueba,
                CantidadEstrellas = intPrueba,
                Capacidad = intPrueba,
                PrecioPorNoche = intPrueba,
                PrecioTotalPeriodo = intPrueba,
                Imagenes = new List<Imagen>() { new Imagen() { Ruta = stringPrueba, Id = intPrueba } },
            };
            Hospedaje hospedaje = hospedajeModel.ToEntity();
            hospedaje.PuntoTuristico = new PuntoTuristico() { Id = puntoId, Nombre = "Test" };
            CantHuespedes huespedes = new CantHuespedes()
            {
                CantJubilados = 0,
                CantAdultos = 1,
                CantBebes = 0,
                CantNinios = 1,
            };

            HospedajeFiltro filtro = new HospedajeFiltro()
            {
                Huespedes = huespedes,
                CheckIn = new DateTime(2020, 10, 9),
                CheckOut = new DateTime(2020, 10, 19),
            };
            logicMock.Setup(x => x.BuscarHospedajePunto(puntoId, filtro)).
                        Returns(new List<Hospedaje>() { hospedaje });

            var result = controller.GetFiltro(puntoId, filtro);
            var okResult = result as OkObjectResult;
            var retorno = okResult.Value as List<Hospedaje>;
            logicMock.VerifyAll();
            Assert.AreEqual(1, retorno.Count);
        }
        [Test]
        public void GetHospedajesPorPuntoYFiltroFechaNoSeteada()
        {
            var logicMock = new Mock<IHospedaje>(MockBehavior.Strict);
            HospedajesController controller = new HospedajesController(logicMock.Object);

            logicMock.Setup(x => x.BuscarHospedajePunto(It.IsAny<int>(), It.IsAny<HospedajeFiltro>())).Throws(new FechaVaciaException());

            var result = controller.GetFiltro(It.IsAny<int>(), It.IsAny<HospedajeFiltro>());
            var okResult = result as BadRequestObjectResult;
            logicMock.VerifyAll();
        }

        [Test]
        public void GetHospedajesPorPuntoYFiltroRevisarFecha()
        {
            var logicMock = new Mock<IHospedaje>(MockBehavior.Strict);
            HospedajesController controller = new HospedajesController(logicMock.Object);

            logicMock.Setup(x => x.BuscarHospedajePunto(It.IsAny<int>(), It.IsAny<HospedajeFiltro>()))
                .Throws(new RevisarFechaExcepcion());

            var result = controller.GetFiltro(It.IsAny<int>(), It.IsAny<HospedajeFiltro>());
            var okResult = result as BadRequestObjectResult;
            logicMock.VerifyAll();
        }

        [Test]
        public void GetHospedajeIdOk()
        {
            string stringPrueba = "Test";
            int intPrueba = 5;
            var logicMock = new Mock<IHospedaje>(MockBehavior.Strict);
            HospedajesController controller = new HospedajesController(logicMock.Object);
            HospedajeModel hospedajeModel = new HospedajeModel()
            {
                NombreHospedaje = stringPrueba,
                Descripcion = stringPrueba,
                Direccion = stringPrueba,
                CantidadEstrellas = intPrueba,
                Capacidad = intPrueba,
                PrecioPorNoche = intPrueba,
                PrecioTotalPeriodo = intPrueba,
                Imagenes = new List<Imagen>() { new Imagen() { Ruta = stringPrueba, Id = intPrueba } },
            };
            Hospedaje hospedaje = hospedajeModel.ToEntity();

            logicMock.Setup(x => x.ObtenerPorId(1)).Returns(hospedaje);

            var result = controller.GetPorId(1);
            var okResult = result as OkObjectResult;
            var retorno = okResult.Value as Hospedaje;
            logicMock.VerifyAll();
            Assert.AreEqual(hospedajeModel.NombreHospedaje, retorno.NombreHospedaje);
        }

        [Test]
        public void GetHospedajeIdNoExsiste()
        {
            var logicMock = new Mock<IHospedaje>(MockBehavior.Strict);
            HospedajesController controller = new HospedajesController(logicMock.Object);

            logicMock.Setup(x => x.ObtenerPorId(1)).Throws(new EntidadNoExisteExcepcion());

            var result = controller.GetPorId(1);
            var okResult = result as NotFoundObjectResult;
            logicMock.VerifyAll();
            Assert.AreEqual(404, okResult.StatusCode);
        }

        [Test]
        public void GetHospedajeIdOcupado()
        {
            var logicMock = new Mock<IHospedaje>(MockBehavior.Strict);
            HospedajesController controller = new HospedajesController(logicMock.Object);

            logicMock.Setup(x => x.ObtenerPorId(It.IsAny<int>())).Throws(new HospedajeOcupadoExcepcion());

            var result = controller.GetPorId(It.IsAny<int>());
            var okResult = result as BadRequestObjectResult;
            logicMock.VerifyAll();
            Assert.AreEqual(400, okResult.StatusCode);
        }

        //DELETE Tests
        //------------------
        [Test]
        public void DeleteHospedajeOk()
        {
            var logicMock = new Mock<IHospedaje>(MockBehavior.Strict);
            HospedajesController controller = new HospedajesController(logicMock.Object);

            logicMock.Setup(x => x.BorrarHospedaje(1));

            var result = controller.Delete(1);
            var okResult = result as OkObjectResult;

            logicMock.VerifyAll();
        }

        [Test]
        public void DeleteHospedajeNoExiste()
        {
            var logicMock = new Mock<IHospedaje>(MockBehavior.Strict);
            HospedajesController controller = new HospedajesController(logicMock.Object);

            logicMock.Setup(x => x.BorrarHospedaje(1)).Throws(new EntidadNoExisteExcepcion());

            var result = controller.Delete(1);
            var okResult = result as NotFoundObjectResult;

            logicMock.VerifyAll();

            Assert.AreEqual(404, okResult.StatusCode);
        }

        //------------------
        [Test]
        public void DeleteHospedajeSegunPuntoOk()
        {
            var logicMock = new Mock<IHospedaje>(MockBehavior.Strict);
            HospedajesController controller = new HospedajesController(logicMock.Object);

            logicMock.Setup(x => x.BorrarHospedajeSegunPunto(1));

            var result = controller.DeleteSegunPunto(1);
            var okResult = result as OkObjectResult;

            logicMock.VerifyAll();
        }

        //PUT Tests
        //------------------
        [Test]
        public void PutHospedajeOk()
        {

            var logicMock = new Mock<IHospedaje>(MockBehavior.Strict);
            HospedajesController controller = new HospedajesController(logicMock.Object);
            string stringPrueba = "Test";
            int intPrueba = 5;
            HospedajeModel hospedajeModel = new HospedajeModel()
            {
                NombreHospedaje = stringPrueba,
                Descripcion = stringPrueba,
                Direccion = stringPrueba,
                CantidadEstrellas = intPrueba,
                Capacidad = intPrueba,
                PrecioPorNoche = intPrueba,
                PrecioTotalPeriodo = intPrueba,
                Imagenes = new List<Imagen>() { new Imagen() { Ruta = stringPrueba, Id = intPrueba } },
            };

            logicMock.Setup(x => x.ActualizarHospedaje(It.IsAny<Hospedaje>()));

            var result = controller.Put(1, hospedajeModel);
            var okResult = result as OkObjectResult;

            logicMock.VerifyAll();
        }

        [Test]
        public void PutCambiarCapacidadOk()
        {

            var logicMock = new Mock<IHospedaje>(MockBehavior.Strict);
            HospedajesController controller = new HospedajesController(logicMock.Object);
            string stringPrueba = "Test";
            int intPrueba = 5;
            HospedajeModel hospedajeModel = new HospedajeModel()
            {
                NombreHospedaje = stringPrueba,
                Descripcion = stringPrueba,
                Direccion = stringPrueba,
                CantidadEstrellas = intPrueba,
                Capacidad = intPrueba,
                PrecioPorNoche = intPrueba,
                PrecioTotalPeriodo = intPrueba,
                Imagenes = new List<Imagen>() { new Imagen() { Ruta = stringPrueba, Id = intPrueba } },
            };
            int idPrueba = 1;
            int nuevaCapacidad = intPrueba + 2;
            logicMock.Setup(x => x.CambiarCapacidad(idPrueba,nuevaCapacidad));

            var result = controller.PutCambiarCapacidad(idPrueba, nuevaCapacidad);
            var okResult = result as OkObjectResult;

            logicMock.VerifyAll();
        }

        [Test]
        public void PutCambiarCapacidadMenorCero()
        {

            var logicMock = new Mock<IHospedaje>(MockBehavior.Strict);
            HospedajesController controller = new HospedajesController(logicMock.Object);
            string stringPrueba = "Test";
            int intPrueba = 5;
            HospedajeModel hospedajeModel = new HospedajeModel()
            {
                NombreHospedaje = stringPrueba,
                Descripcion = stringPrueba,
                Direccion = stringPrueba,
                CantidadEstrellas = intPrueba,
                Capacidad = intPrueba,
                PrecioPorNoche = intPrueba,
                PrecioTotalPeriodo = intPrueba,
                Imagenes = new List<Imagen>() { new Imagen() { Ruta = stringPrueba, Id = intPrueba } },
            };
            int idPrueba = 1;
            int nuevaCapacidad = -1;
            logicMock.Setup(x => x.CambiarCapacidad(idPrueba,nuevaCapacidad))
                .Throws(new CapacidadNoValidaExcepcion());

            var result = controller.PutCambiarCapacidad(idPrueba, nuevaCapacidad);
            var okResult = result as BadRequestObjectResult;

            logicMock.VerifyAll();
        }

        [Test]
        public void PutPuntoNoExiste()
        {
            var logicMock = new Mock<IHospedaje>(MockBehavior.Strict);
            HospedajesController controller = new HospedajesController(logicMock.Object);
            string stringPrueba = "Test";
            int intPrueba = 5;
            HospedajeModel hospedajeModel = new HospedajeModel()
            {
                NombreHospedaje = stringPrueba,
                Descripcion = stringPrueba,
                Direccion = stringPrueba,
                CantidadEstrellas = intPrueba,
                Capacidad = intPrueba,
                PrecioPorNoche = intPrueba,
                PrecioTotalPeriodo = intPrueba,
                Imagenes = new List<Imagen>() { new Imagen() { Ruta = stringPrueba, Id = intPrueba } },
            };

            logicMock.Setup(x => x.ActualizarHospedaje(It.IsAny<Hospedaje>()))
                                .Throws(new EntidadNoExisteExcepcion());

            var result = controller.Put(1, hospedajeModel);
            var okResult = result as NotFoundObjectResult;

            logicMock.VerifyAll();

            Assert.AreEqual(404, okResult.StatusCode);
        }

        [Test]
        public void PutAgregarPuntoOk()
        {
            var logicMock = new Mock<IHospedaje>(MockBehavior.Strict);
            HospedajesController controller = new HospedajesController(logicMock.Object);

            logicMock.Setup(x => x.AgregarPunto(It.IsAny<int>(), It.IsAny<int>()));
            
            var result = controller.PutAgregarPunto(It.IsAny<int>(), It.IsAny<int>());

            var okResult = result as OkObjectResult;

            logicMock.VerifyAll();
        }
    }
}
