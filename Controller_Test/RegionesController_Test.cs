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
using System.Collections.Generic;
using Assert = NUnit.Framework.Assert;

namespace Controller_Test
{
    public class RegionesController_Test
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void PostRegionOk()
        {
            var logicMock = new Mock<IRegion>(MockBehavior.Strict);
            RegionesController controller = new RegionesController(logicMock.Object);
            RegionModel regionModel = new RegionModel()
            {
                Nombre="Este",
            };
            Region region = new Region()
            {
                Nombre = regionModel.Nombre,
                Puntos = new List<PuntoTuristico>(),
                Id = 0,
            };

            logicMock.Setup(x => x.Region(regionModel.Nombre)).Returns(region);
            logicMock.Setup(x => x.AgregarRegion(region));

            var result = controller.Post(1,regionModel);
            var okResult = result as OkObjectResult;

            logicMock.VerifyAll();
        }
        
        [Test]
        public void PostRegionNombreNoValido()
        {
            var logicMock = new Mock<IRegion>(MockBehavior.Strict);
            RegionesController controller = new RegionesController(logicMock.Object);
            RegionModel regionModel = new RegionModel()
            {
                Nombre = "Prueba",
                Puntos = new List<PuntoTuristico>(),
            };

            logicMock.Setup(x => x.Region("Prueba")).Throws(new NombreNoValidoException());

            var result = controller.Post(1,regionModel);
            var okResult = result as BadRequestObjectResult;

            logicMock.VerifyAll();

            Assert.AreEqual(400, okResult.StatusCode);
        }
       
        [Test]
        public void PutRegionOk()
        {
            var logicMock = new Mock<IRegion>(MockBehavior.Strict);
            RegionesController controller = new RegionesController(logicMock.Object);
            RegionModel regionModel = new RegionModel()
            {
                Nombre = "Este",
                Puntos = new List<PuntoTuristico>(),
            };

            logicMock.Setup(x => x.ActualizarRegion(It.IsAny<Region>()));

            var result = controller.Put(1, regionModel);
            var okResult = result as OkObjectResult;

            logicMock.VerifyAll();
        }
        
        [Test]
        public void PutRegionNoExiste()
        {
            var logicMock = new Mock<IRegion>(MockBehavior.Strict);
            RegionesController controller = new RegionesController(logicMock.Object);
            RegionModel regionModel = new RegionModel()
            {
                Nombre = "Este",
                Puntos = new List<PuntoTuristico>(),
            };

            logicMock.Setup(x => x.ActualizarRegion(It.IsAny<Region>())).Throws(new EntidadNoExisteExcepcion());

            var result = controller.Put(1, regionModel);
            var okResult = result as NotFoundObjectResult;

            logicMock.VerifyAll();

            Assert.AreEqual(404, okResult.StatusCode);
        }
        
        [Test]
        public void DeleteRegionOk()
        {
            var logicMock = new Mock<IRegion>(MockBehavior.Strict);
            RegionesController controller = new RegionesController(logicMock.Object);
            RegionModel regionModel = new RegionModel()
            {
                Nombre = "Este",
                Puntos = new List<PuntoTuristico>(),
            };
            Region region = new Region()
            {
                Nombre = regionModel.Nombre,
                Puntos = new List<PuntoTuristico>(),
                Id = 0,
            };

            logicMock.Setup(x => x.Region(regionModel.Nombre)).Returns(region);
            logicMock.Setup(x => x.AgregarRegion(region));

            controller.Post(1, regionModel);

            logicMock.Setup(x => x.BorrarRegionId(1));

            var result = controller.Delete(1);
            var okResult = result as OkObjectResult;

            logicMock.VerifyAll();
        }
        
        [Test]
        public void DeleteRegionNoExiste()
        {
            var logicMock = new Mock<IRegion>(MockBehavior.Strict);
            RegionesController controller = new RegionesController(logicMock.Object);
            RegionModel regionModel = new RegionModel()
            {
                Nombre = "Este",
                Puntos = new List<PuntoTuristico>(),
            };

            logicMock.Setup(x => x.BorrarRegionId(1)).Throws(new EntidadNoExisteExcepcion());

            var result = controller.Delete(1);
            var okResult = result as NotFoundObjectResult;

            logicMock.VerifyAll();

            Assert.AreEqual(404, okResult.StatusCode);
        }

        [Test]
        public void GetRegionesConElementoOk()
        {
            var logicMock = new Mock<IRegion>(MockBehavior.Strict);
            RegionesController controller = new RegionesController(logicMock.Object);
            RegionModel regionModel = new RegionModel()
            {
                Nombre = "Este",
            };
            Region region = new Region()
            {
                Nombre = regionModel.Nombre,
                Puntos = new List<PuntoTuristico>(),
                Id = 0,
            };
            List<Region> lista = new List<Region>();
            lista.Add(region);
            logicMock.Setup(x => x.Region(regionModel.Nombre)).Returns(region);
            logicMock.Setup(x => x.AgregarRegion(region));
            logicMock.Setup(x => x.ObtenerTodas()).Returns(lista);
            
            controller.Post(1, regionModel);

            var result = controller.Get();
            var okResult = result as OkObjectResult;
            var retorno = okResult.Value as List<Region>;
            logicMock.VerifyAll();
            Assert.AreEqual(1, retorno.Count);
        }
        
        [Test]
        public void GetRegionesSinElementoOk()
        {
            var logicMock = new Mock<IRegion>(MockBehavior.Strict);
            RegionesController controller = new RegionesController(logicMock.Object);
            List<Region> lista = new List<Region>();
            logicMock.Setup(x => x.ObtenerTodas()).Returns(lista);

            var result = controller.Get();
            var okResult = result as OkObjectResult;
            var retorno = okResult.Value as List<Region>;
            logicMock.VerifyAll();
            Assert.AreEqual(0, retorno.Count);
        }

        [Test]
        public void GetRegionIdOk()
        {
            string stringPrueba = "Test";
            int intPrueba = 5;
            var logicMock = new Mock<IRegion>(MockBehavior.Strict);
            RegionesController controller = new RegionesController(logicMock.Object);
            Region region = new Region()
            {
                Nombre=stringPrueba,
                Id=intPrueba
            };

            logicMock.Setup(x => x.ObtenerRegionId(intPrueba)).Returns(region);

            var result = controller.GetPorId(intPrueba);
            var okResult = result as OkObjectResult;
            var retorno = okResult.Value as Region;
            logicMock.VerifyAll();
            Assert.AreEqual(region.Nombre, retorno.Nombre);
        }

        [Test]
        [ExpectedException(typeof(EntidadNoExisteExcepcion))]
        public void GetRegionIdNoExsiste()
        {
            var logicMock = new Mock<IRegion>(MockBehavior.Strict);
            RegionesController controller = new RegionesController(logicMock.Object);
            const int intPrueba = 1;

            logicMock.Setup(x => x.ObtenerRegionId(intPrueba)).Throws(new EntidadNoExisteExcepcion());

            var result = controller.GetPorId(intPrueba);
            var okResult = result as NotFoundObjectResult;
            logicMock.VerifyAll();
            Assert.AreEqual(404, okResult.StatusCode);
        }
        
        [Test]
        public void PutAgregarPuntoOk()
        {
            var logicMock = new Mock<IRegion>(MockBehavior.Strict);
            RegionesController controller = new RegionesController(logicMock.Object);
            Region region = new Region()
            {
                Id=1,
                Nombre = "Este",
                Puntos = new List<PuntoTuristico>(),
            };
            PuntoTuristico punto = new PuntoTuristico()
            {
                Id = 1,
                Imagen = new Imagen() { Id = 0, Ruta = "../algo.jpg" },
                Descripcion = "xssx",
                PuntosTuristicosCategoria = null,
            };
            
            logicMock.Setup(x => x.AgregarPunto(1,punto.Id));

            var result = controller.PutPunto(1,punto.Id);

            var okResult = result as OkObjectResult;
            
            logicMock.VerifyAll();
        }
    }
}