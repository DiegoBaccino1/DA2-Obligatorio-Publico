using BuisnessLogic.Domain;
using BuissnesLogic;
using DataAccessInterface;
using Domain;
using Exceptiones;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using NUnit.Framework;
using System.Collections.Generic;
using System.Linq;
using Assert = NUnit.Framework.Assert;

namespace BuisnessLogic_Test
{
    class Categoria_Test
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void TestSetNombreValido()
        {
            string nombre = "Ciudades";
            var repoMock = new Mock<IRepository<Categoria>>(MockBehavior.Strict);
            Categoria_Logic logica = new Categoria_Logic(repoMock.Object);
            string nombreResultado = logica.ValidarNombre(nombre);
            Assert.AreEqual(nombre, nombreResultado);
        }
        [Test]
        [ExpectedException(typeof(StringVacioException))]
        public void TestSetNombreVacio()
        {
            string nombre = "";
            var repoMock = new Mock<IRepository<Categoria>>(MockBehavior.Strict);
            Categoria_Logic logica = new Categoria_Logic(repoMock.Object);
            Assert.Throws<StringVacioException>(() => logica.ValidarNombre(nombre));
        }
        [Test]
        [ExpectedException(typeof(StringVacioException))]
        public void TestSetNombreVacioEspacio()
        {
            string nombre = " ";
            var repoMock = new Mock<IRepository<Categoria>>(MockBehavior.Strict);
            Categoria_Logic logica = new Categoria_Logic(repoMock.Object);
            Assert.Throws<StringVacioException>(() => logica.ValidarNombre(nombre));
        }

        [Test]
        public void TestObtenerTodosOk()
        {
            string nombre = "Punta del este";
            Categoria esperado = new Categoria() { Nombre = nombre, };
            var repoMock = new Mock<IRepository<Categoria>>(MockBehavior.Strict);
            Categoria_Logic logica = new Categoria_Logic(repoMock.Object);
            Categoria categoria = new Categoria() { Nombre = nombre};
            repoMock.Setup(x => x.GetAll()).Returns(new List<Categoria>() { categoria });
            List<Categoria> categorias = logica.ObtenerTodas();
            Assert.AreEqual(esperado.Nombre, categorias.First().Nombre);
        }

        [Test]
        public void TestBorrarOk()
        {
            var repoMock = new Mock<IRepository<Categoria>>(MockBehavior.Strict);
            Categoria_Logic logica = new Categoria_Logic(repoMock.Object);
            Categoria categoria = new Categoria() {Id=0, Nombre = "Test" };
            repoMock.Setup(x => x.Delete(categoria));
            repoMock.Setup(x => x.Save());
            repoMock.Setup(x => x.Get(categoria.Id)).Returns(categoria);
            logica.BorrarCategoriaId(categoria.Id);
            repoMock.VerifyAll();
        }
        [Test]
        public void TestActualizarCategoriaOk()
        {
            var repoMock = new Mock<IRepository<Categoria>>(MockBehavior.Strict);
            Categoria_Logic logica = new Categoria_Logic(repoMock.Object);
            Categoria categoria = new Categoria() { Id = 0, Nombre = "Test" };
            repoMock.Setup(x => x.Update(categoria));
            repoMock.Setup(x => x.Save());
            repoMock.Setup(x => x.Get(categoria.Id)).Returns(categoria);
            categoria.Nombre = "Prueba";
            logica.ActualizarCategoria(categoria.Id,categoria);
            repoMock.VerifyAll();
        }
        [Test]
        public void TestCrearCategoriaValido()
        {
            string nombre = "Este";
            var repoMock = new Mock<IRepository<Categoria>>(MockBehavior.Strict);
            Categoria_Logic logica = new Categoria_Logic(repoMock.Object);
            Categoria region = logica.Categoria(nombre);
            Assert.AreEqual(nombre, region.Nombre);
        }


        [Test]
        [ExpectedException(typeof(YaExisteLaEntidadExcepcion))]
        public void TestAgregarCategoriaYaExsiste()
        {
            string nombre = "Este";
            var repoMock = new Mock<IRepository<Categoria>>(MockBehavior.Strict);
            Categoria_Logic logica = new Categoria_Logic(repoMock.Object);
            Categoria categoria = new Categoria() { Id=0,Nombre=nombre};
            Categoria categoria2 = new Categoria() { Id = 0, Nombre = nombre };
            repoMock.Setup(x => x.Create(categoria));
            repoMock.Setup(x => x.Save());
            repoMock.Setup(x => x.Get(0)).Throws(new EntidadNoExisteExcepcion());
            logica.AgregarCategoria(categoria);
            repoMock.Setup(x => x.Get(0)).Throws(new YaExisteLaEntidadExcepcion());
            Assert.Throws<YaExisteLaEntidadExcepcion>(() => logica.AgregarCategoria(categoria2));
        }

        [Test]
        [ExpectedException(typeof(EntidadNoExisteExcepcion))]
        public void ObtenerRegionIdNoExiste()
        {
            string nombre = "Este";
            var repoMock = new Mock<IRepository<Categoria>>(MockBehavior.Strict);
            Categoria_Logic logica = new Categoria_Logic(repoMock.Object);
            Categoria categoria = logica.Categoria(nombre);
            categoria.Id = 1;
            repoMock.Setup(x => x.Get(2)).Throws(new EntidadNoExisteExcepcion());
            Assert.Throws<EntidadNoExisteExcepcion>(() => logica.ObtenerCategoriaId(2));
        }

        [Test]
        public void ObtenerCategoriaIdValido()
        {
            string nombre = "Este";
            var repoMock = new Mock<IRepository<Categoria>>(MockBehavior.Strict);
            Categoria_Logic logica = new Categoria_Logic(repoMock.Object);
            Categoria categoria = logica.Categoria(nombre);
            categoria.Id = 1;
            repoMock.Setup(x => x.Get(1)).Returns(categoria);
            Categoria resultado = logica.ObtenerCategoriaId(1);
            Assert.AreEqual(nombre, categoria.Nombre);
        }
    }
}
