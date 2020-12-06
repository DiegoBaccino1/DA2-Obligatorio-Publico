using BuisnessLogic.Domain;
using BuissnesLogic_Interface;
using Domain;
using Exceptiones;
using Microsoft.AspNetCore.Mvc;
using Moq;
using NUnit.Framework;
using Obligatorio.Controllers;
using Obligatorio.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Controller_Test
{
    public class PuntosController_Test
    {
        //POST Tests
        //------------------
        [Test]
        public void PostPuntoOk()
        {
            var logicMock = new Mock<IPuntoTuristico>(MockBehavior.Strict);
            var logicRegionMock = new Mock<IRegion>(MockBehavior.Strict);
            PuntosController controller = new PuntosController(logicMock.Object,logicRegionMock.Object);
            PuntoTuristicoModel puntoModel = new PuntoTuristicoModel()
            {
                Nombre = "Este",
                Descripcion="Prueba",
            };
            PuntoTuristico punto = new PuntoTuristico()
            {
                Nombre = puntoModel.Nombre,
                Descripcion=puntoModel.Descripcion,
                Id = 0,
            };

            logicMock.Setup(x => x.PuntoTuristico(puntoModel.Nombre,puntoModel.Descripcion))
                        .Returns(punto);
            logicMock.Setup(x => x.AgregarPunto(punto));

            var result = controller.Post(1, puntoModel);
            var okResult = result as OkObjectResult;

            logicMock.VerifyAll();
        }
        
        [Test]
        public void PostPuntoNombreNoValido()
        {
            var logicMock = new Mock<IPuntoTuristico>(MockBehavior.Strict);
            var logicRegionMock = new Mock<IRegion>(MockBehavior.Strict);
            PuntosController controller = new PuntosController(logicMock.Object, logicRegionMock.Object);
            PuntoTuristicoModel puntoModel = new PuntoTuristicoModel()
            {
                Nombre = "Este",
                Descripcion = "Prueba",
            };
            PuntoTuristico punto = new PuntoTuristico()
            {
                Nombre = puntoModel.Nombre,
                Descripcion = puntoModel.Descripcion,
                Id = 0,
            };

            logicMock.Setup(x => x.PuntoTuristico(puntoModel.Nombre, puntoModel.Descripcion))
                .Throws(new NombreNoValidoException());

            var result = controller.Post(1, puntoModel);
            var okResult = result as BadRequestObjectResult;

            logicMock.VerifyAll();

            Assert.AreEqual(400, okResult.StatusCode);
        }
        
        [Test]
        public void PostPuntoDescripcionMaxCaracteresNoValido()
        {
            var logicMock = new Mock<IPuntoTuristico>(MockBehavior.Strict);
            var logicRegionMock = new Mock<IRegion>(MockBehavior.Strict);
            PuntosController controller = new PuntosController(logicMock.Object, logicRegionMock.Object);
            PuntoTuristicoModel puntoModel = new PuntoTuristicoModel()
            {
                Nombre = "Este",
                Descripcion = "Prueba",
            };
            PuntoTuristico punto = new PuntoTuristico()
            {
                Nombre = puntoModel.Nombre,
                Descripcion = puntoModel.Descripcion,
                Id = 0,
            };

            logicMock.Setup(x => x.PuntoTuristico(puntoModel.Nombre, puntoModel.Descripcion))
                .Throws(new MaxCantDeCaracteresException());

            var result = controller.Post(1, puntoModel);
            var okResult = result as BadRequestObjectResult;

            logicMock.VerifyAll();

            Assert.AreEqual(400, okResult.StatusCode);
        }

        //GET Tests
        //------------------
        [Test]
        public void GetPuntosConElementoOk()
        {
            var logicMock = new Mock<IPuntoTuristico>(MockBehavior.Strict);
            var logicRegionMock = new Mock<IRegion>(MockBehavior.Strict);
            PuntosController controller = new PuntosController(logicMock.Object, logicRegionMock.Object);
            PuntoTuristicoModel puntoModel = new PuntoTuristicoModel()
            {
                Nombre = "Este",
                Descripcion = "Prueba",
            };
            PuntoTuristico punto = new PuntoTuristico()
            {
                Nombre = puntoModel.Nombre,
                Descripcion = puntoModel.Descripcion,
                Id = 0,
            };
            List<PuntoTuristico> lista = new List<PuntoTuristico>();
            lista.Add(punto);

            logicMock.Setup(x => x.PuntoTuristico(puntoModel.Nombre, puntoModel.Descripcion))
                        .Returns(punto);
            logicMock.Setup(x => x.AgregarPunto(punto));
            logicMock.Setup(x => x.ObtenerTodos()).Returns(lista);

            controller.Post(1, puntoModel);

            var result = controller.Get();
            var okResult = result as OkObjectResult;
            var retorno = okResult.Value as List<PuntoTuristicoModel>;
            logicMock.VerifyAll();
        }
        
        [Test]
        public void GetPuntosSinElementoOk()
        {
            var logicMock = new Mock<IPuntoTuristico>(MockBehavior.Strict);
            var logicRegionMock = new Mock<IRegion>(MockBehavior.Strict);
            PuntosController controller = new PuntosController(logicMock.Object, logicRegionMock.Object);
            List<PuntoTuristico> lista = new List<PuntoTuristico>();

            logicMock.Setup(x => x.ObtenerTodos()).Returns(lista);

            var result = controller.Get();
            var okResult = result as OkObjectResult;
            var retorno = okResult.Value as List<PuntoTuristicoModel>;
            logicMock.VerifyAll();
        }
        [Test]
        public void GetPuntoIdOk()
        {
            var logicMock = new Mock<IPuntoTuristico>(MockBehavior.Strict);
            var logicRegionMock = new Mock<IRegion>(MockBehavior.Strict);
            PuntosController controller = new PuntosController(logicMock.Object, logicRegionMock.Object);
            PuntoTuristicoModel puntoModel = new PuntoTuristicoModel()
            {
                Nombre = "Este",
                Descripcion = "Prueba",
            };
            PuntoTuristico punto = new PuntoTuristico()
            {
                Nombre = puntoModel.Nombre,
                Descripcion = puntoModel.Descripcion,
                Id = 0,
            };
            logicMock.Setup(x => x.PuntoTuristico(puntoModel.Nombre, puntoModel.Descripcion))
                        .Returns(punto);
            logicMock.Setup(x => x.AgregarPunto(punto));
            logicMock.Setup(x => x.ObtenerPuntoId(1)).Returns(punto);

            controller.Post(1, puntoModel);

            var result = controller.GetPorId(1);
            var okResult = result as OkObjectResult;
            var retorno = okResult.Value as PuntoTuristicoModel;
            logicMock.VerifyAll();
        }

        [Test]
        public void GetPuntosPorCategoriaOk()
        {
            var logicMock = new Mock<IPuntoTuristico>(MockBehavior.Strict);
            var logicRegionMock = new Mock<IRegion>(MockBehavior.Strict);
            PuntosController controller = new PuntosController(logicMock.Object, logicRegionMock.Object);
            PuntoTuristicoModel puntoModel = new PuntoTuristicoModel()
            {
                Nombre = "Este",
                Descripcion = "Prueba",
            };
            PuntoTuristico punto = new PuntoTuristico()
            {
                Nombre = puntoModel.Nombre,
                Descripcion = puntoModel.Descripcion,
                PuntosTuristicosCategoria = new List<PuntoTuristicoCategoria>(),
                Id = 1,
            };
            PuntoTuristicoModel puntoModel2 = new PuntoTuristicoModel()
            {
                Nombre = "Este2",
                Descripcion = "Prueba2",
            };
            PuntoTuristico punto2 = new PuntoTuristico()
            {
                Nombre = puntoModel2.Nombre,
                Descripcion = puntoModel2.Descripcion,
                PuntosTuristicosCategoria = new List<PuntoTuristicoCategoria>(),
                Id = 2,
            };
            Categoria categoria = new Categoria() 
            {
                Id = 1,
                Nombre = "playa",
                PuntosTuristicosCategoria = new List<PuntoTuristicoCategoria>()
            };
            PuntoTuristicoCategoria ptc = new PuntoTuristicoCategoria()
            {
                PuntoTuristico = punto,
                PuntoTuristicoId = punto.Id,
                Categoria = categoria,
                CategoriaId = categoria.Id,
            };            
            punto.PuntosTuristicosCategoria.Add(ptc);
            Region region = new Region()
            {
                Id = 0,
                Nombre = "Este",
                Puntos = new List<PuntoTuristico>()
                {
                    punto,
                    punto2,
                },
            };
            List<PuntoTuristico> listaPorRegion = new List<PuntoTuristico>() { punto,punto2 };
            List<PuntoTuristico> listaPorCategoria = new List<PuntoTuristico>() { punto };
            List<string> listaNombreCategoria = new List<string>() { categoria.Nombre, };
            int[] categoriasABuscar = new int[] { categoria.Id, };

            logicMock.Setup(x => x.PuntoTuristico(puntoModel.Nombre, puntoModel.Descripcion))
                        .Returns(punto);
            
            logicMock.Setup(x => x.AgregarPunto(punto));

            logicMock.Setup(x => x.PuntoTuristico(puntoModel2.Nombre, puntoModel2.Descripcion))
                       .Returns(punto2);
            logicMock.Setup(x => x.AgregarPunto(punto2));
            logicRegionMock.Setup(x => x.ObtenerPuntosTuristicos(region.Id))
                        .Returns(listaPorRegion);
            logicMock.Setup(x => x.PuntosPorCategoria(listaPorRegion,categoriasABuscar))
                            .Returns(listaPorCategoria);

            controller.Post(punto.Id, puntoModel);
            
            controller.Post(punto2.Id, puntoModel2);

            var result = controller.GetCategorias(categoriasABuscar,region.Id);
            var okResult = result as OkObjectResult;
            logicMock.VerifyAll();
        }

        [Test]
        public void GetPuntoIdNoExsiste()
        {
            var logicMock = new Mock<IPuntoTuristico>(MockBehavior.Strict);
            var logicRegionMock = new Mock<IRegion>(MockBehavior.Strict);
            PuntosController controller = new PuntosController(logicMock.Object, logicRegionMock.Object);

            logicMock.Setup(x => x.ObtenerPuntoId(1)).Throws(new EntidadNoExisteExcepcion());

            var result = controller.GetPorId(1);
            var okResult = result as NotFoundObjectResult;
            logicMock.VerifyAll();
            Assert.AreEqual(404, okResult.StatusCode);
        }

        //DELETE Tests
        //------------------
        [Test]
        public void DeletePuntoOk()
        {
            var logicMock = new Mock<IPuntoTuristico>(MockBehavior.Strict);
            var logicRegionMock = new Mock<IRegion>(MockBehavior.Strict);
            PuntosController controller = new PuntosController(logicMock.Object, logicRegionMock.Object);
            PuntoTuristicoModel puntoModel = new PuntoTuristicoModel()
            {
                Nombre = "Este",
                Descripcion = "Prueba",
            };
            PuntoTuristico punto = new PuntoTuristico()
            {
                Nombre = puntoModel.Nombre,
                Descripcion = puntoModel.Descripcion,
                Id = 0,
            };

            logicMock.Setup(x => x.PuntoTuristico(puntoModel.Nombre, puntoModel.Descripcion)).Returns(punto);
            logicMock.Setup(x => x.AgregarPunto(punto));


            controller.Post(1, puntoModel);

            logicMock.Setup(x => x.BorrarPuntoId(1));

            var result = controller.Delete(1);
            var okResult = result as OkObjectResult;

            logicMock.VerifyAll();
        }

        [Test]
        public void DeletePuntoNoExiste()
        {
            var logicMock = new Mock<IPuntoTuristico>(MockBehavior.Strict);
            var logicRegionMock = new Mock<IRegion>(MockBehavior.Strict);
            PuntosController controller = new PuntosController(logicMock.Object, logicRegionMock.Object);

            logicMock.Setup(x => x.BorrarPuntoId(1)).Throws(new EntidadNoExisteExcepcion());

            var result = controller.Delete(1);
            var okResult = result as NotFoundObjectResult;

            logicMock.VerifyAll();

            Assert.AreEqual(404, okResult.StatusCode);
        }

        //PUT Tests
        //------------------
        [Test]
        public void PutPuntoOk()
        {
            var logicMock = new Mock<IPuntoTuristico>(MockBehavior.Strict);
            var logicRegionMock = new Mock<IRegion>(MockBehavior.Strict);
            PuntosController controller = new PuntosController(logicMock.Object, logicRegionMock.Object);
            PuntoTuristicoModel puntoModel = new PuntoTuristicoModel()
            {
                Nombre = "Este",
                Descripcion = "Prueba",
            };
            PuntoTuristico punto = new PuntoTuristico()
            {
                Nombre = puntoModel.Nombre,
                Descripcion = puntoModel.Descripcion,
                Id = 0,
            };

            logicMock.Setup(x => x.PuntoTuristico(puntoModel.Nombre, puntoModel.Descripcion)).Returns(punto);
            logicMock.Setup(x => x.AgregarPunto(punto));
            controller.Post(0, puntoModel);
            punto.Nombre = "prueba";
            logicMock.Setup(x => x.ActualizarPunto(punto.Id,punto));
         
            var result = controller.Put(punto.Id, punto);
            var okResult = result as OkObjectResult;

            logicMock.VerifyAll();
            Assert.AreEqual("prueba", punto.Nombre);
        }

        [Test]
        public void PutPuntoNoExiste()
        {
            var logicMock = new Mock<IPuntoTuristico>(MockBehavior.Strict);
            var logicRegionMock = new Mock<IRegion>(MockBehavior.Strict);
            PuntosController controller = new PuntosController(logicMock.Object, logicRegionMock.Object);
            PuntoTuristicoModel puntoModel = new PuntoTuristicoModel()
            {
                Nombre = "Este",
                Descripcion = "Prueba",
            };
            PuntoTuristico punto = new PuntoTuristico()
            {
                Nombre = puntoModel.Nombre,
                Descripcion = puntoModel.Descripcion,
                Id = 0,
            };

            logicMock.Setup(x => x.ActualizarPunto(punto.Id, punto)).Throws(new EntidadNoExisteExcepcion());

            var result = controller.Put(punto.Id, punto);
            var okResult = result as NotFoundObjectResult;

            logicMock.VerifyAll();

            Assert.AreEqual(404, okResult.StatusCode);
        }

        [Test]
        public void PutAgregarPuntoOk()
        {
            var logicMock = new Mock<IPuntoTuristico>(MockBehavior.Strict);
            var logicRegionMock = new Mock<IRegion>(MockBehavior.Strict);
            PuntosController controller = new PuntosController(logicMock.Object, logicRegionMock.Object);
            PuntoTuristico punto = new PuntoTuristico()
            {
                Id = 1,
                Nombre = "prueba",
                Imagen = new Imagen() { Ruta = "ddaaxxx.jpg", Id = 0, },
                Descripcion = "xssx",
                PuntosTuristicosCategoria = new List<PuntoTuristicoCategoria>(),
            };
            Categoria categoria = new Categoria()
            {
                Nombre = "test",
                Id = 0,
                PuntosTuristicosCategoria = new List<PuntoTuristicoCategoria>(),
            };

            logicMock.Setup(x => x.AgregarPuntoCategoria(punto.Id, categoria.Id));

            var result = controller.PutCategoria(punto.Id, categoria.Id);

            var okResult = result as OkObjectResult;

            logicMock.VerifyAll();
        }
    }
}
