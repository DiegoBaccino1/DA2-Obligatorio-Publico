using BuisnessLogic.Domain;
using BuissnesLogic;
using BuissnesLogic_Interface;
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
    public class PuntoTuristico_Test
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void TestSetNombreValido()
        {
            string nombre = "Punta del este";
            var repoMock = new Mock<IRepository<PuntoTuristico>>(MockBehavior.Strict);
            var repoLogicaCat = new Mock<ICategoria>(MockBehavior.Strict);
            PuntoTuristico_Logic logica = new PuntoTuristico_Logic(repoMock.Object, repoLogicaCat.Object);
            string nombreResultado = logica.ValidarNombre(nombre); 
            Assert.AreEqual(nombre, nombreResultado);
        }
        
        [Test]
        [ExpectedException(typeof(StringVacioException))]
        public void TestSetNombreVacio()
        {
            string nombre = "";
            var repoMock = new Mock<IRepository<PuntoTuristico>>(MockBehavior.Strict);
            var repoLogicaCat = new Mock<ICategoria>(MockBehavior.Strict);
            PuntoTuristico_Logic logica = new PuntoTuristico_Logic(repoMock.Object, repoLogicaCat.Object);
            Assert.Throws<StringVacioException>(()=> logica.ValidarNombre(nombre));
        }

        [Test]
        [ExpectedException(typeof(StringVacioException))]
        public void TestSetNombreVacioConEspacio()
        {
            string nombre = " ";
            var repoMock = new Mock<IRepository<PuntoTuristico>>(MockBehavior.Strict);
            var repoLogicaCat = new Mock<ICategoria>(MockBehavior.Strict);
            PuntoTuristico_Logic logica = new PuntoTuristico_Logic(repoMock.Object, repoLogicaCat.Object);
            Assert.Throws<StringVacioException>(() => logica.ValidarNombre(nombre));
        }

        [Test]
        [ExpectedException(typeof(YaExisteLaEntidadExcepcion))]
        public void TestAgregarPuntoYaExsiste()
        {
            var repoMock = new Mock<IRepository<PuntoTuristico>>(MockBehavior.Strict);
            var repoLogicaCat = new Mock<ICategoria>(MockBehavior.Strict);
            PuntoTuristico_Logic logica = new PuntoTuristico_Logic(repoMock.Object, repoLogicaCat.Object);
            PuntoTuristico punto = new PuntoTuristico() { Id = 0 };
            PuntoTuristico punto2 = new PuntoTuristico() { Id = 0 };
            repoMock.Setup(x => x.Create(punto));
            repoMock.Setup(x => x.Save());
            repoMock.Setup(x => x.Get(0)).Throws(new EntidadNoExisteExcepcion());
            logica.AgregarPunto(punto);
            repoMock.Setup(x => x.Get(0)).Throws(new YaExisteLaEntidadExcepcion());
        }


        [Test]
        public void TestObtenerNombreCategoriaOk()
        {
            string descripcion = "Prueba";
            var repoMock = new Mock<IRepository<PuntoTuristico>>(MockBehavior.Strict);
            var repoLogicaCat = new Mock<ICategoria>(MockBehavior.Strict);
            PuntoTuristico_Logic logica = new PuntoTuristico_Logic(repoMock.Object, repoLogicaCat.Object);
            Categoria categoria = new Categoria() { Id = 0, Nombre = descripcion };
            PuntoTuristico punto = new PuntoTuristico() 
            {
                Id=0,
                Nombre="Test",
                PuntosTuristicosCategoria=new List<PuntoTuristicoCategoria>()
            };
            PuntoTuristicoCategoria ptc = new PuntoTuristicoCategoria()
            {
                Categoria = categoria,
                CategoriaId=categoria.Id,
                PuntoTuristicoId=punto.Id,
                PuntoTuristico=punto
            };
            punto.PuntosTuristicosCategoria.Add(ptc);
            List<string> descripcionResultado = logica.ObtenerNombreCategorias(punto);
            Assert.AreEqual(descripcion, descripcionResultado.First());
        }

        [Test]
        public void TestAgregarDescripcionValida()
        {
            string descripcion = "Prueba";
            var repoMock = new Mock<IRepository<PuntoTuristico>>(MockBehavior.Strict);
            var repoLogicaCat = new Mock<ICategoria>(MockBehavior.Strict);
            PuntoTuristico_Logic logica = new PuntoTuristico_Logic(repoMock.Object, repoLogicaCat.Object);
            string descripcionResultado = logica.ValidarDescripcion(descripcion);
            Assert.AreEqual(descripcion, descripcionResultado);
        }
        
        [Test]
        [ExpectedException(typeof(MaxCantDeCaracteresException))]
        public void TestAgregarDescripcionMasDeMaxCantDeCaracteres()
        {
            string descripcion = "";
            for (int i = 0; i < 2001; i++)
                descripcion += "x";
            var repoMock = new Mock<IRepository<PuntoTuristico>>(MockBehavior.Strict);
            var repoLogicaCat = new Mock<ICategoria>(MockBehavior.Strict);
            PuntoTuristico_Logic logica = new PuntoTuristico_Logic(repoMock.Object, repoLogicaCat.Object);
            Assert.Throws<MaxCantDeCaracteresException>(() => logica.ValidarDescripcion(descripcion));
        }

        [Test]
        public void TestCrearPuntoValido()
        {
            string nombre = "Punta del este";
            string descripcion = "aaaaa";
            PuntoTuristico esperado = new PuntoTuristico();
            esperado.Nombre = nombre;
            esperado.Descripcion = descripcion;
            var repoMock = new Mock<IRepository<PuntoTuristico>>(MockBehavior.Strict);
            var repoLogicaCat = new Mock<ICategoria>(MockBehavior.Strict);
            PuntoTuristico_Logic logica = new PuntoTuristico_Logic(repoMock.Object, repoLogicaCat.Object);
            PuntoTuristico punto = logica.PuntoTuristico(nombre,descripcion);
            Assert.AreEqual(esperado.Nombre,punto.Nombre);
        }

        [Test]
        public void TestObtenerTodosOk()
        {
            string nombre = "Punta del este";
            string descripcion = "aaaaa";
            PuntoTuristico esperado = new PuntoTuristico() { Nombre = nombre, Descripcion = descripcion,};
            var repoMock = new Mock<IRepository<PuntoTuristico>>(MockBehavior.Strict);
            var repoLogicaCat = new Mock<ICategoria>(MockBehavior.Strict);
            PuntoTuristico_Logic logica = new PuntoTuristico_Logic(repoMock.Object, repoLogicaCat.Object);
            PuntoTuristico punto = new PuntoTuristico() { Nombre = nombre, Descripcion = descripcion };
            repoMock.Setup(x => x.GetAll()).Returns(new List<PuntoTuristico>() { punto });
            List<PuntoTuristico> puntos = logica.ObtenerTodos();
            Assert.AreEqual(esperado.Nombre, puntos.First().Nombre);
        }

        [Test]
        public void TestBorrarOk()
        {
            var repoMock = new Mock<IRepository<PuntoTuristico>>(MockBehavior.Strict);
            var repoLogicaCat = new Mock<ICategoria>(MockBehavior.Strict);
            PuntoTuristico_Logic logica = new PuntoTuristico_Logic(repoMock.Object, repoLogicaCat.Object);
            PuntoTuristico punto = new PuntoTuristico() {Id=0, Nombre = "Test", Descripcion = "Test" };
            repoMock.Setup(x => x.Delete(punto));
            repoMock.Setup(x => x.Save());
            repoMock.Setup(x => x.Get(punto.Id)).Returns(punto);
            logica.BorrarPuntoId(punto.Id);
            repoMock.VerifyAll();
        }
        [Test]
        public void TestSubirImagenValido()
        {
            string nombre = "Punta del este";
            string descripcion = "aaaaa";
            Imagen path = new Imagen() { Id=0,Ruta="test"};
            var repoMock = new Mock<IRepository<PuntoTuristico>>(MockBehavior.Strict);
            var repoLogicaCat = new Mock<ICategoria>(MockBehavior.Strict);
            PuntoTuristico_Logic logica = new PuntoTuristico_Logic(repoMock.Object, repoLogicaCat.Object);
            PuntoTuristico punto = logica.PuntoTuristico(nombre, descripcion);
            logica.CargarImagen(punto,path);
            Assert.IsNotNull(punto.Imagen);
        }
        [Test]
        [ExpectedException(typeof(EntidadNoExisteExcepcion))]
        public void ObtenerPuntoIdNoExiste()
        {
            string nombre = "Este";
            string descripcion = "Prueba";
            var repoMock = new Mock<IRepository<PuntoTuristico>>(MockBehavior.Strict);
            var repoLogicaCat = new Mock<ICategoria>(MockBehavior.Strict);
            PuntoTuristico_Logic logica = new PuntoTuristico_Logic(repoMock.Object, repoLogicaCat.Object);
            PuntoTuristico punto = logica.PuntoTuristico(nombre, descripcion);
            punto.Id = 1;
            repoMock.Setup(x => x.Get(2)).Throws(new EntidadNoExisteExcepcion());
            Assert.Throws<EntidadNoExisteExcepcion>(() => logica.ObtenerPuntoId(2));
        }

        [Test]
        public void ObtenerPuntoIdValido()
        {
            string nombre = "Este";
            string descripcion = "Prueba";
            var repoMock = new Mock<IRepository<PuntoTuristico>>(MockBehavior.Strict);
            var repoLogicaCat = new Mock<ICategoria>(MockBehavior.Strict);
            PuntoTuristico_Logic logica = new PuntoTuristico_Logic(repoMock.Object, repoLogicaCat.Object);
            PuntoTuristico punto = logica.PuntoTuristico(nombre,descripcion);
            punto.Id = 1;
            repoMock.Setup(x => x.Get(1)).Returns(punto);
            PuntoTuristico resultado = logica.ObtenerPuntoId(1);
            Assert.AreEqual(nombre, resultado.Nombre);
        }
        [Test]
        public void ObtenerPuntosCategoriaValido()
        {
            string nombre = "Este";
            string descripcion = "Prueba";
            var repoMock = new Mock<IRepository<PuntoTuristico>>(MockBehavior.Strict);
            var repoLogicaCat = new Mock<ICategoria>(MockBehavior.Strict);
            PuntoTuristico_Logic logica = new PuntoTuristico_Logic(repoMock.Object, repoLogicaCat.Object);
            PuntoTuristico punto = logica.PuntoTuristico(nombre, descripcion);
            punto.Id = 1;
            PuntoTuristico punto2 = logica.PuntoTuristico(nombre+"2", descripcion+"2");
            punto.Id = 2;

            Categoria categoria = new Categoria() 
            {
                Id=1,
                Nombre="Playa"
            };
            PuntoTuristicoCategoria ptc = new PuntoTuristicoCategoria()
            {
                Categoria = categoria,
                CategoriaId = categoria.Id,
                PuntoTuristico=punto,
                PuntoTuristicoId=punto.Id
            };
            Categoria categoria2 = new Categoria()
            {
                Id = 2,
                Nombre = "Playa"
            };
            PuntoTuristicoCategoria ptc2 = new PuntoTuristicoCategoria()
            {
                Categoria = categoria2,
                CategoriaId = categoria2.Id,
                PuntoTuristico = punto2,
                PuntoTuristicoId = punto2.Id
            };
            punto.PuntosTuristicosCategoria.Add(ptc);
            punto2.PuntosTuristicosCategoria.Add(ptc2);
            List<PuntoTuristico> lista = new List<PuntoTuristico>();
            lista.Add(punto);
            lista.Add(punto2);
            int[] idCat = { 1 };
            List<PuntoTuristico> resultado = logica.PuntosPorCategoria(lista,idCat);
            Assert.AreEqual(1, resultado.Count);
        }
        [Test]
        public void ObtenerPuntosCategoriaElementosNoValido()
        {
            string nombre = "Este";
            string descripcion = "Prueba";
            var repoMock = new Mock<IRepository<PuntoTuristico>>(MockBehavior.Strict);
            var repoLogicaCat = new Mock<ICategoria>(MockBehavior.Strict);
            PuntoTuristico_Logic logica = new PuntoTuristico_Logic(repoMock.Object, repoLogicaCat.Object);
            PuntoTuristico punto = logica.PuntoTuristico(nombre, descripcion);
            punto.Id = 1;
            PuntoTuristico punto2 = logica.PuntoTuristico(nombre + "2", descripcion + "2");
            punto.Id = 2;

            Categoria categoria = new Categoria()
            {
                Id = 0,
                Nombre = "Playa"
            };
            PuntoTuristicoCategoria ptc = new PuntoTuristicoCategoria()
            {
                Categoria = categoria,
                CategoriaId = categoria.Id,
                PuntoTuristico = punto,
                PuntoTuristicoId = punto.Id
            };
            Categoria categoria2 = new Categoria()
            {
                Id = 2,
                Nombre = "Playa"
            };
            PuntoTuristicoCategoria ptc2 = new PuntoTuristicoCategoria()
            {
                Categoria = categoria2,
                CategoriaId = categoria2.Id,
                PuntoTuristico = punto2,
                PuntoTuristicoId = punto2.Id
            };
            punto.PuntosTuristicosCategoria.Add(ptc);
            punto2.PuntosTuristicosCategoria.Add(ptc2);
            List<PuntoTuristico> lista = new List<PuntoTuristico>();
            lista.Add(punto);
            lista.Add(punto2);
            int[] idCat = { 1 };
            List<PuntoTuristico> resultado = logica.PuntosPorCategoria(lista, idCat);
            Assert.AreEqual(0, resultado.Count);
        }

        [Test]
        public void AgregarPuntosCategoriaOK()
        {
            string nombre = "Este";
            string descripcion = "Prueba";
            var repoMock = new Mock<IRepository<PuntoTuristico>>(MockBehavior.Strict);
            var repoLogicaCat = new Mock<ICategoria>(MockBehavior.Strict);
            PuntoTuristico_Logic logica = new PuntoTuristico_Logic(repoMock.Object, repoLogicaCat.Object);
            PuntoTuristico punto = logica.PuntoTuristico(nombre, descripcion);
            punto.Id = 1;

            Categoria categoria = new Categoria()
            {
                Id = 0,
                Nombre = "Playa"
            };

            repoMock.Setup(x => x.Get(punto.Id)).Returns(punto);
            repoLogicaCat.Setup(x => x.ObtenerCategoriaId(categoria.Id)).Returns(categoria);
            repoMock.Setup(x => x.Update(punto));
            repoMock.Setup(x => x.Save());

            logica.AgregarPuntoCategoria(punto.Id, categoria.Id);

            Assert.AreEqual(1, punto.PuntosTuristicosCategoria.Count);
        }
    }
}