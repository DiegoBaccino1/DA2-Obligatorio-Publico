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
    public class CategoriasController_Test
    {
        //POST Tests
        //------------------
        [Test]
        public void PostCategoriaOk()
        {
            var logicMock = new Mock<ICategoria>(MockBehavior.Strict);
            CategoriasController controller = new CategoriasController(logicMock.Object);
            CategoriaModel catModel = new CategoriaModel()
            {
                Nombre="Playa",
            };
            Categoria cat = new Categoria()
            {
                Nombre = catModel.Nombre,
                Id = 0,
            };

            logicMock.Setup(x => x.Categoria(catModel.Nombre)).Returns(cat);
            logicMock.Setup(x => x.AgregarCategoria(cat));

            var result = controller.Post(1, catModel);
            var okResult = result as OkObjectResult;

            logicMock.VerifyAll();
        }

        [Test]
        public void PostCategoriaNombreNoValido()
        {
            var logicMock = new Mock<ICategoria>(MockBehavior.Strict);
            CategoriasController controller = new CategoriasController(logicMock.Object);
            CategoriaModel catModel = new CategoriaModel()
            {
                Nombre = " ",
            };
            Categoria cat = new Categoria()
            {
                Id = 0,
            };

            logicMock.Setup(x => x.Categoria(catModel.Nombre)).Throws(new NombreNoValidoException());

            var result = controller.Post(1, catModel);
            var okResult = result as BadRequestObjectResult;

            logicMock.VerifyAll();

            Assert.AreEqual(400, okResult.StatusCode);
        }

        //GET Tests
        //------------------
        [Test]
        public void GetCategoriasConElementoOk()
        {
            var logicMock = new Mock<ICategoria>(MockBehavior.Strict);
            CategoriasController controller = new CategoriasController(logicMock.Object);
            CategoriaModel catModel = new CategoriaModel()
            {
                Nombre = "Playa",
            };
            Categoria cat = new Categoria()
            {
                Nombre = catModel.Nombre,
                Id = 0,
            };

            logicMock.Setup(x => x.Categoria(catModel.Nombre)).Returns(cat);
            logicMock.Setup(x => x.AgregarCategoria(cat));

            List<Categoria> lista = new List<Categoria>();
            lista.Add(cat);

            logicMock.Setup(x => x.ObtenerTodas()).Returns(lista);

            controller.Post(1, catModel);

            var result = controller.Get();
            var okResult = result as OkObjectResult;
            var retorno = okResult.Value as List<Categoria>;
            logicMock.VerifyAll();
            Assert.AreEqual(1, retorno.Count);
        }

        [Test]
        public void GetCategoriasSinElementoOk()
        {
            var logicMock = new Mock<ICategoria>(MockBehavior.Strict);
            CategoriasController controller = new CategoriasController(logicMock.Object);

            List<Categoria> lista = new List<Categoria>();

            logicMock.Setup(x => x.ObtenerTodas()).Returns(lista);

            var result = controller.Get();
            var okResult = result as OkObjectResult;
            var retorno = okResult.Value as List<Categoria>;
            logicMock.VerifyAll();
            Assert.AreEqual(0, retorno.Count);
        }
        
        [Test]
        public void GetCategoriaIdOk()
        {
            var logicMock = new Mock<ICategoria>(MockBehavior.Strict);
            CategoriasController controller = new CategoriasController(logicMock.Object);
            CategoriaModel catModel = new CategoriaModel()
            {
                Nombre = "Playa",
            };
            Categoria cat = new Categoria()
            {
                Nombre = catModel.Nombre,
                Id = 0,
            };

            logicMock.Setup(x => x.Categoria(catModel.Nombre)).Returns(cat);
            logicMock.Setup(x => x.AgregarCategoria(cat));

            logicMock.Setup(x => x.ObtenerCategoriaId(1)).Returns(cat);

            controller.Post(1, catModel);

            var result = controller.Get(1);
            var okResult = result as OkObjectResult;
            var retorno = okResult.Value as Categoria;
            logicMock.VerifyAll();
            Assert.AreEqual(catModel.Nombre, retorno.Nombre);
        }
        
        [Test]
        public void GetCategoriaIdNoExsiste()
        {
            var logicMock = new Mock<ICategoria>(MockBehavior.Strict);
            CategoriasController controller = new CategoriasController(logicMock.Object);

            logicMock.Setup(x => x.ObtenerCategoriaId(1)).Throws(new EntidadNoExisteExcepcion());

            var result = controller.Get(1);
            var okResult = result as NotFoundObjectResult;
            logicMock.VerifyAll();
            Assert.AreEqual(404, okResult.StatusCode);
        }

        //DELETE Tests
        //------------------
        [Test]
        public void DeleteCategoriaOk()
        {
            var logicMock = new Mock<ICategoria>(MockBehavior.Strict);
            CategoriasController controller = new CategoriasController(logicMock.Object);
            CategoriaModel catModel = new CategoriaModel()
            {
                Nombre = "Playa",
            };
            Categoria cat = new Categoria()
            {
                Nombre = catModel.Nombre,
                Id = 0,
            };

            logicMock.Setup(x => x.Categoria(catModel.Nombre)).Returns(cat);
            logicMock.Setup(x => x.AgregarCategoria(cat));

            controller.Post(1, catModel);

            logicMock.Setup(x => x.BorrarCategoriaId(1));

            var result = controller.Delete(1);
            var okResult = result as OkObjectResult;

            logicMock.VerifyAll();
        }

        [Test]
        public void DeletePuntoNoExiste()
        {
            var logicMock = new Mock<ICategoria>(MockBehavior.Strict);
            CategoriasController controller = new CategoriasController(logicMock.Object);

            logicMock.Setup(x => x.BorrarCategoriaId(1)).Throws(new EntidadNoExisteExcepcion());

            var result = controller.Delete(1);
            var okResult = result as NotFoundObjectResult;

            logicMock.VerifyAll();

            Assert.AreEqual(404, okResult.StatusCode);
        }

        //PUT Tests
        //------------------
        [Test]
        public void PutCategoriaOk()
        {
            var logicMock = new Mock<ICategoria>(MockBehavior.Strict);
            CategoriasController controller = new CategoriasController(logicMock.Object);
            CategoriaModel catModel = new CategoriaModel()
            {
                Nombre = "Playa",
            };
            Categoria cat = new Categoria()
            {
                Nombre = catModel.Nombre,
                Id = 0,
            };

            logicMock.Setup(x => x.Categoria(catModel.Nombre)).Returns(cat);
            logicMock.Setup(x => x.AgregarCategoria(cat));

            controller.Post(0, catModel);
            cat.Nombre = "prueba";
            logicMock.Setup(x => x.ActualizarCategoria(cat.Id, cat));

            var result = controller.Put(cat.Id, cat);
            var okResult = result as OkObjectResult;

            logicMock.VerifyAll();
            Assert.AreEqual("prueba", cat.Nombre);
        }

        [Test]
        public void PutPuntoNoExiste()
        {
            var logicMock = new Mock<ICategoria>(MockBehavior.Strict);
            CategoriasController controller = new CategoriasController(logicMock.Object);
            CategoriaModel catModel = new CategoriaModel()
            {
                Nombre = "Playa",
            };
            Categoria cat = new Categoria()
            {
                Nombre = catModel.Nombre,
                Id = 0,
            };

            logicMock.Setup(x => x.ActualizarCategoria(cat.Id, cat)).
                Throws(new EntidadNoExisteExcepcion());

            var result = controller.Put(cat.Id, cat);
            var okResult = result as NotFoundObjectResult;

            logicMock.VerifyAll();

            Assert.AreEqual(404, okResult.StatusCode);
        }
    }
}
