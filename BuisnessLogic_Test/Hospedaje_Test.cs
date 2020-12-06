using BuisnessLogic.Domain;
using BuissnesLogic;
using BuissnesLogic_Interface;
using DataAccessInterface;
using Domain;
using Exceptiones;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using NUnit.Framework;
using Obligatorio.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Assert = NUnit.Framework.Assert;

namespace BuisnessLogic_Test
{
    public class Hospedaje_Test
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void TestSetNombreValido()
        {
            string nombre = "Hotel X";
            var repoMock = new Mock<IRepository<Hospedaje>>(MockBehavior.Strict);
            var logicaPuntoMock = new Mock<IPuntoTuristico>(MockBehavior.Strict);
            Hospedaje_Logic logica = new Hospedaje_Logic(repoMock.Object, logicaPuntoMock.Object);
            string nombreResultado = logica.ValidaNombreHospedaje(nombre); 
            Assert.AreEqual(nombre, nombreResultado);
        }

        [Test]
        [ExpectedException(typeof(StringVacioException))]
        public void TestSetNombreVacio()
        {
            string nombre = "";
            var repoMock = new Mock<IRepository<Hospedaje>>(MockBehavior.Strict);
            var logicaPuntoMock = new Mock<IPuntoTuristico>(MockBehavior.Strict);
            Hospedaje_Logic logica = new Hospedaje_Logic(repoMock.Object, logicaPuntoMock.Object);
            Assert.Throws<StringVacioException>(() => logica.ValidaNombreHospedaje(nombre));
        }

        [Test]
        [ExpectedException(typeof(StringVacioException))]
        public void TestSetNombreVacioEspacio()
        {
            string nombre = " ";
            var repoMock = new Mock<IRepository<Hospedaje>>(MockBehavior.Strict);
            var logicaPuntoMock = new Mock<IPuntoTuristico>(MockBehavior.Strict);
            Hospedaje_Logic logica = new Hospedaje_Logic(repoMock.Object, logicaPuntoMock.Object);
            Assert.Throws<StringVacioException>(() => logica.ValidaNombreHospedaje(nombre));
        }

        [Test]
        public void TestObtenerTodosOk()
        {
            string nombre = "AAA";
            Hospedaje esperado = new Hospedaje() { NombreHospedaje = nombre, };
            var repoMock = new Mock<IRepository<Hospedaje>>(MockBehavior.Strict);
            var logicaPuntoMock = new Mock<IPuntoTuristico>(MockBehavior.Strict);
            Hospedaje_Logic logica = new Hospedaje_Logic(repoMock.Object, logicaPuntoMock.Object);
            Hospedaje hospedaje = new Hospedaje() { NombreHospedaje = nombre, };
            repoMock.Setup(x => x.GetAll()).Returns(new List<Hospedaje>() { hospedaje });
            List<Hospedaje> puntos = logica.ObtenerTodos();
            Assert.AreEqual(esperado.NombreHospedaje, puntos.First().NombreHospedaje);
        }

        [Test]
        public void TestBorrarSegunPuntoOk()
        {
            string nombre = "AAA";
            var repoMock = new Mock<IRepository<Hospedaje>>(MockBehavior.Strict);
            var logicaPuntoMock = new Mock<IPuntoTuristico>(MockBehavior.Strict);
            Hospedaje_Logic logica = new Hospedaje_Logic(repoMock.Object, logicaPuntoMock.Object);
            PuntoTuristico punto = new PuntoTuristico() { Id = 0 };
            Hospedaje hospedaje = new Hospedaje() { NombreHospedaje = nombre,Id=0 };
            Hospedaje hospedaje2 = new Hospedaje() { NombreHospedaje = nombre, Id = 1,PuntoTuristico=punto };
            repoMock.Setup(x => x.Delete(hospedaje2));
            repoMock.Setup(x => x.Save());
            repoMock.Setup(x => x.Get(hospedaje2.Id)).Returns(hospedaje2);
            repoMock.Setup(x => x.GetAll()).Returns(new List<Hospedaje>() { hospedaje,hospedaje2 });
            logica.BorrarHospedajeSegunPunto(punto.Id);
            repoMock.Setup(x => x.GetAll()).Returns(new List<Hospedaje>() { hospedaje});
            List<Hospedaje> puntos = logica.ObtenerTodos();
            Assert.AreEqual(1, puntos.Count);
        }
        [Test]
        public void TestCambiarCapacidadOk()
        {
            var repoMock = new Mock<IRepository<Hospedaje>>(MockBehavior.Strict);
            var logicaPuntoMock = new Mock<IPuntoTuristico>(MockBehavior.Strict);
            Hospedaje_Logic logica = new Hospedaje_Logic(repoMock.Object, logicaPuntoMock.Object);
            Hospedaje hospedaje2 = new Hospedaje() { NombreHospedaje = "Test",Capacidad=6};
            int nuevaCapacidad = 1;
            repoMock.Setup(x => x.Update(hospedaje2));
            repoMock.Setup(x => x.Save());
            repoMock.Setup(x => x.Get(hospedaje2.Id)).Returns(hospedaje2);
            logica.CambiarCapacidad(hospedaje2.Id,nuevaCapacidad);
            repoMock.Setup(x => x.GetAll()).Returns(new List<Hospedaje>() { hospedaje2 });
            List<Hospedaje> puntos = logica.ObtenerTodos();
            Assert.AreEqual(1, puntos.First().Capacidad);
        }
        [Test]
        [ExpectedException(typeof(CapacidadNoValidaExcepcion))]
        public void TestCambiarCapacidadMenorCero()
        {
            var repoMock = new Mock<IRepository<Hospedaje>>(MockBehavior.Strict);
            var logicaPuntoMock = new Mock<IPuntoTuristico>(MockBehavior.Strict);
            Hospedaje_Logic logica = new Hospedaje_Logic(repoMock.Object, logicaPuntoMock.Object);
            Hospedaje hospedaje2 = new Hospedaje() { Id=0,NombreHospedaje = "Test", Capacidad = 6 };
            int nuevaCapacidad = -1;
            repoMock.Setup(x => x.Get(hospedaje2.Id)).Returns(hospedaje2);
            Assert.Throws<CapacidadNoValidaExcepcion>(()=> logica.CambiarCapacidad(hospedaje2.Id, nuevaCapacidad));
        }

        [Test]
        public void TestActualizarRegionOk()
        {
            var repoMock = new Mock<IRepository<Hospedaje>>(MockBehavior.Strict);
            var logicaPuntoMock = new Mock<IPuntoTuristico>(MockBehavior.Strict);
            Hospedaje_Logic logica = new Hospedaje_Logic(repoMock.Object, logicaPuntoMock.Object);
            Hospedaje hospedaje = new Hospedaje() { NombreHospedaje = "Test", Id = 0 };
            repoMock.Setup(x => x.Update(hospedaje));
            repoMock.Setup(x => x.Save());
            repoMock.Setup(x => x.Get(hospedaje.Id)).Returns(hospedaje);
            hospedaje.NombreHospedaje = "Prueba";
            logica.ActualizarHospedaje(hospedaje);
            repoMock.VerifyAll();
        }

        [Test]
        public void TestBorrarOk()
        {
            var repoMock = new Mock<IRepository<Hospedaje>>(MockBehavior.Strict);
            var logicaPuntoMock = new Mock<IPuntoTuristico>(MockBehavior.Strict);
            Hospedaje_Logic logica = new Hospedaje_Logic(repoMock.Object, logicaPuntoMock.Object);
            Hospedaje hospedaje = new Hospedaje() { Id = 0, NombreHospedaje = "Test", };
            repoMock.Setup(x => x.Delete(hospedaje));
            repoMock.Setup(x => x.Save());
            repoMock.Setup(x => x.Get(hospedaje.Id)).Returns(hospedaje);
            logica.BorrarHospedaje(hospedaje.Id);
            repoMock.VerifyAll();
        }

        [Test]
        public void TestAgregarPuntoOk()
        {
            var repoMock = new Mock<IRepository<Hospedaje>>(MockBehavior.Strict);
            var logicaPuntoMock = new Mock<IPuntoTuristico>(MockBehavior.Strict);
            Hospedaje_Logic logica = new Hospedaje_Logic(repoMock.Object, logicaPuntoMock.Object);
            Hospedaje hospedaje = new Hospedaje() { Id = 0, NombreHospedaje = "Test", };
            PuntoTuristico punto = new PuntoTuristico() { Id = 0, Nombre = "Prueba" };
            logicaPuntoMock.Setup(x => x.ObtenerPuntoId(punto.Id)).Returns(punto);
            repoMock.Setup(x => x.Save());
            repoMock.Setup(x => x.Get(hospedaje.Id)).Returns(hospedaje);
            repoMock.Setup(x => x.Update(hospedaje));
            logica.AgregarPunto(hospedaje.Id,punto.Id);
            repoMock.VerifyAll();
        }

        [Test]
        public void AgregarHospedajeOk()
        {
            var repoMock = new Mock<IRepository<Hospedaje>>(MockBehavior.Strict);
            var logicaPuntoMock = new Mock<IPuntoTuristico>(MockBehavior.Strict);
            Hospedaje_Logic logica = new Hospedaje_Logic(repoMock.Object, logicaPuntoMock.Object);
            HospedajeModel modelo = new HospedajeModel()
            {
                NombreHospedaje = "Hotel Este no puede estar",
                Descripcion = "Test",
                Direccion = "Test",
                CantidadEstrellas = 2,
                Capacidad = 5,
                PrecioPorNoche = 140,
                PrecioTotalPeriodo = 200,
                Imagenes = new List<Imagen>() { new Imagen() { Id = 0, Ruta = "test.jpg", }, },
            };
            Hospedaje hospedaje = modelo.ToEntity();
            hospedaje.Id = 1500000000;
            repoMock.Setup(x => x.Create(hospedaje));
            repoMock.Setup(x => x.Save());
            repoMock.Setup(x => x.GetAll()).Returns(new List<Hospedaje>());
            logica.AgregarHospedaje(hospedaje);
            repoMock.Setup(x => x.GetAll()).Returns(new List<Hospedaje>() { hospedaje});
            Hospedaje resultado = logica.ObtenerTodos().First();
            Assert.AreEqual(modelo.NombreHospedaje, resultado.NombreHospedaje);
        }

        [Test]
        [ExpectedException(typeof(YaExisteLaEntidadExcepcion))]
        public void TestAgregarHospedajeYaExsisteMismaId()
        {
            var repoMock = new Mock<IRepository<Hospedaje>>(MockBehavior.Strict);
            var logicaPuntoMock = new Mock<IPuntoTuristico>(MockBehavior.Strict);
            Hospedaje_Logic logica = new Hospedaje_Logic(repoMock.Object, logicaPuntoMock.Object);
            Hospedaje hospedaje = new Hospedaje() { Id = 0,NombreHospedaje="Test" };
            Hospedaje hospedaje2 = new Hospedaje() { Id = 0,NombreHospedaje="Prueba" };
            repoMock.Setup(x => x.Create(hospedaje));
            repoMock.Setup(x => x.Save());
            repoMock.Setup(x => x.GetAll()).Returns(new List<Hospedaje>());
            logica.AgregarHospedaje(hospedaje);
            repoMock.Setup(x => x.GetAll()).Returns(new List<Hospedaje>() { hospedaje});
            Assert.Throws<YaExisteLaEntidadExcepcion>(() => logica.AgregarHospedaje(hospedaje));
        }

        [Test]
        [ExpectedException(typeof(YaExisteLaEntidadExcepcion))]
        public void TestAgregarHospedajeYaExsisteMismoNombre()
        {
            var repoMock = new Mock<IRepository<Hospedaje>>(MockBehavior.Strict);
            var logicaPuntoMock = new Mock<IPuntoTuristico>(MockBehavior.Strict);
            Hospedaje_Logic logica = new Hospedaje_Logic(repoMock.Object, logicaPuntoMock.Object);
            Hospedaje hospedaje = new Hospedaje() { Id = 0, NombreHospedaje = "Test" };
            Hospedaje hospedaje2 = new Hospedaje() { Id = 2, NombreHospedaje = "Test" };
            repoMock.Setup(x => x.Create(hospedaje));
            repoMock.Setup(x => x.Save());
            repoMock.Setup(x => x.GetAll()).Returns(new List<Hospedaje>());
            logica.AgregarHospedaje(hospedaje);
            repoMock.Setup(x => x.GetAll()).Returns(new List<Hospedaje>() { hospedaje });
            Assert.Throws<YaExisteLaEntidadExcepcion>(() => logica.AgregarHospedaje(hospedaje2));
        }


        [Test]
        [ExpectedException(typeof(EntidadNoExisteExcepcion))]
        public void ObtenerHospedajeIdNoExiste()
        {
            string nombre = "prueba";
            var repoMock = new Mock<IRepository<Hospedaje>>(MockBehavior.Strict);
            var logicaPuntoMock = new Mock<IPuntoTuristico>(MockBehavior.Strict);
            Hospedaje_Logic logica = new Hospedaje_Logic(repoMock.Object, logicaPuntoMock.Object);
            Hospedaje hospedaje = new Hospedaje() { Id=0,NombreHospedaje=nombre,};
            repoMock.Setup(x => x.Get(2)).Throws(new EntidadNoExisteExcepcion());
            Assert.Throws<EntidadNoExisteExcepcion>(() => logica.ObtenerPorId(2));
        }

        [Test]
        public void ObtenerHospedajeIdValido()
        {
            string nombre = "prueba";
            var repoMock = new Mock<IRepository<Hospedaje>>(MockBehavior.Strict);
            var logicaPuntoMock = new Mock<IPuntoTuristico>(MockBehavior.Strict);
            Hospedaje_Logic logica = new Hospedaje_Logic(repoMock.Object, logicaPuntoMock.Object);
            Hospedaje hospedaje = new Hospedaje() { Id = 0, NombreHospedaje = nombre, };
            repoMock.Setup(x => x.Get(1)).Returns(hospedaje);
            Hospedaje resultado = logica.ObtenerPorId(1);
            Assert.AreEqual(nombre, resultado.NombreHospedaje);
        }

        [Test]
        public void BuscarPorPuntoIdValido()
        {
            List<Imagen> imagenes = new List<Imagen>() { new Imagen() { Id = 0, Ruta = "test.jpg", }, };
            var repoMock = new Mock<IRepository<Hospedaje>>(MockBehavior.Strict);
            var logicaPuntoMock = new Mock<IPuntoTuristico>(MockBehavior.Strict);
            Hospedaje_Logic logica = new Hospedaje_Logic(repoMock.Object,logicaPuntoMock.Object);
            PuntoTuristico punto = new PuntoTuristico()
            {
                Nombre = "Prueba",
                Descripcion = "DASD",
                Imagen = imagenes.First(),
                Id = 0,
                PuntosTuristicosCategoria = new List<PuntoTuristicoCategoria>(),
            };
            Hospedaje hospedaje = new Hospedaje()
            {
                Id = 0,
                NombreHospedaje = "Hotel X",
                Descripcion = "Test",
                Direccion = "Test",
                CantidadEstrellas = 2,
                Capacidad = 5,
                PrecioPorNoche = 140,
                PrecioTotalPeriodo = 200,
                Imagenes = imagenes,
                Ocupado = false,
                PuntoTuristico = punto,
            };
            Hospedaje hospedaje2 = new Hospedaje()
            {
                Id = 1,
                NombreHospedaje = "Hotel XX",
                Descripcion = "Test2",
                Direccion = "Test2",
                CantidadEstrellas = 2,
                Capacidad = 5,
                PrecioPorNoche = 140,
                PrecioTotalPeriodo = 200,
                Imagenes = imagenes,
                Ocupado = false,
                PuntoTuristico =new PuntoTuristico() { Id=20},
            };
            List<Hospedaje> lista = new List<Hospedaje>() { hospedaje, hospedaje2 };
            
            repoMock.Setup(x => x.GetAll()).Returns(lista);
            repoMock.Setup(x => x.Create(hospedaje));
            repoMock.Setup(x => x.Create(hospedaje2));
            repoMock.Setup(x => x.Save());
            repoMock.Setup(x => x.GetAll()).Returns(new List<Hospedaje>());
            logica.AgregarHospedaje(hospedaje);
            repoMock.Setup(x => x.GetAll()).Returns(new List<Hospedaje>() { hospedaje});
            logica.AgregarHospedaje(hospedaje2);

            CantHuespedes huespedes = new CantHuespedes()
            {
                CantAdultos = 1,
                CantBebes = 0,
                CantNinios = 1,
                CantJubilados = 0,
            };

            HospedajeFiltro filtro = new HospedajeFiltro()
            {
                Huespedes = huespedes,
                CheckIn = new DateTime(2020, 10, 9),
                CheckOut = new DateTime(2020, 10, 11),
            };
            List<Hospedaje> retorno = logica.BuscarHospedajePunto(punto.Id,filtro);
            Hospedaje hospedajeRet = retorno.First();
            bool retornoHospedajeOk= hospedaje.NombreHospedaje.Equals(hospedajeRet.NombreHospedaje);
            bool precioOk = 420 == hospedajeRet.PrecioTotalPeriodo;
            Assert.IsTrue(retornoHospedajeOk&&precioOk);
        }
        
        [Test]
        public void BuscarPorPuntoIdValidoSinCapacidad()
        {
            List<Imagen> imagenes = new List<Imagen>() { new Imagen() { Id = 0, Ruta = "test.jpg", }, };
            var repoMock = new Mock<IRepository<Hospedaje>>(MockBehavior.Strict);
            var logicaPuntoMock = new Mock<IPuntoTuristico>(MockBehavior.Strict);
            Hospedaje_Logic logica = new Hospedaje_Logic(repoMock.Object, logicaPuntoMock.Object);
            PuntoTuristico punto = new PuntoTuristico()
            {
                Nombre = "Prueba",
                Descripcion = "DASD",
                Imagen = imagenes.First(),
                Id = 0,
                PuntosTuristicosCategoria = new List<PuntoTuristicoCategoria>(),
            };
            Hospedaje hospedaje = new Hospedaje()
            {
                Id = 0,
                NombreHospedaje = "Hotel X",
                Descripcion = "Test",
                Direccion = "Test",
                CantidadEstrellas = 2,
                Capacidad = 5,
                PrecioPorNoche = 140,
                PrecioTotalPeriodo = 200,
                Imagenes = imagenes,
                Ocupado = false,
                PuntoTuristico = punto,
            };
            List<Hospedaje> lista = new List<Hospedaje>() { hospedaje};

            repoMock.Setup(x => x.GetAll()).Returns(lista);

            CantHuespedes huespedes = new CantHuespedes()
            {
                CantAdultos = 1,
                CantBebes = 0,
                CantNinios = 5,
                CantJubilados = 0,
            };

            HospedajeFiltro filtro = new HospedajeFiltro()
            {
                Huespedes=huespedes,
                CheckIn = new DateTime(2020, 10, 9),
                CheckOut = new DateTime(2020, 10, 11),
            };
            List<Hospedaje> retorno = logica.BuscarHospedajePunto(punto.Id, filtro);

            Assert.AreEqual(0,retorno.Count);
        }
        
        [Test]
        public void BuscarPuntoIdValidoOcupado()
        {
            List<Imagen> imagenes = new List<Imagen>() { new Imagen() { Id = 0, Ruta = "test.jpg", }, };
            var repoMock = new Mock<IRepository<Hospedaje>>(MockBehavior.Strict);
            var logicaPuntoMock = new Mock<IPuntoTuristico>(MockBehavior.Strict);
            Hospedaje_Logic logica = new Hospedaje_Logic(repoMock.Object, logicaPuntoMock.Object);
            PuntoTuristico punto = new PuntoTuristico()
            {
                Nombre = "Prueba",
                Descripcion = "DASD",
                Imagen = imagenes.First(),
                Id = 0,
                PuntosTuristicosCategoria = new List<PuntoTuristicoCategoria>(),
            };
            Hospedaje hospedaje = new Hospedaje()
            {
                Id = 0,
                NombreHospedaje = "Hotel X",
                Descripcion = "Test",
                Direccion = "Test",
                CantidadEstrellas = 2,
                Capacidad = 5,
                PrecioPorNoche = 140,
                PrecioTotalPeriodo = 200,
                Imagenes = imagenes,
                Ocupado = true,
                PuntoTuristico = punto,
            };
            List<Hospedaje> lista = new List<Hospedaje>() { hospedaje };

            repoMock.Setup(x => x.GetAll()).Returns(lista);

            CantHuespedes huespedes = new CantHuespedes()
            {
                CantAdultos = 1,
                CantBebes = 0,
                CantNinios = 1,
                CantJubilados = 0,
            };

            HospedajeFiltro filtro = new HospedajeFiltro()
            {
                Huespedes= huespedes,
                CheckIn = new DateTime(2020, 10, 9),
                CheckOut = new DateTime(2020, 10, 11),
            };
            List<Hospedaje> retorno = logica.BuscarHospedajePunto(punto.Id, filtro);

            Assert.AreEqual(0, retorno.Count);
        }

        [Test]
        public void BuscarPorPuntoCheckOutMenorCheckInValido()
        {
            List<Imagen> imagenes = new List<Imagen>() { new Imagen() { Id = 0, Ruta = "test.jpg", }, };
            var repoMock = new Mock<IRepository<Hospedaje>>(MockBehavior.Strict);
            var logicaPuntoMock = new Mock<IPuntoTuristico>(MockBehavior.Strict);
            Hospedaje_Logic logica = new Hospedaje_Logic(repoMock.Object, logicaPuntoMock.Object);
            PuntoTuristico punto = new PuntoTuristico()
            {
                Nombre = "Prueba",
                Descripcion = "DASD",
                Imagen = imagenes.First(),
                Id = 0,
                PuntosTuristicosCategoria = new List<PuntoTuristicoCategoria>(),
            };
            Hospedaje hospedaje = new Hospedaje()
            {
                Id = 0,
                NombreHospedaje = "Hotel X",
                Descripcion = "Test",
                Direccion = "Test",
                CantidadEstrellas = 2,
                Capacidad = 5,
                PrecioPorNoche = 140,
                PrecioTotalPeriodo = 200,
                Imagenes = imagenes,
                Ocupado = true,
                PuntoTuristico = punto,
            };
            List<Hospedaje> lista = new List<Hospedaje>() { hospedaje };

            repoMock.Setup(x => x.GetAll()).Returns(lista);
            repoMock.Setup(x => x.Create(hospedaje));
            repoMock.Setup(x => x.Save());
            repoMock.Setup(x => x.GetAll()).Returns(new List<Hospedaje>());
            logica.AgregarHospedaje(hospedaje);

            CantHuespedes huespedes = new CantHuespedes()
            {
                CantAdultos = 1,
                CantBebes = 0,
                CantNinios = 1,
                CantJubilados = 0,
            };

            HospedajeFiltro filtro = new HospedajeFiltro()
            {
                Huespedes=huespedes,
                CheckIn = new DateTime(2020, 10, 11),
                CheckOut = new DateTime(2020, 10, 9),
            };

            Assert.Throws<RevisarFechaExcepcion>(()=> logica.BuscarHospedajePunto(punto.Id, filtro));
        }

        [Test]
        public void BorrarHospedajeOk()
        {
            var repoMock = new Mock<IRepository<Hospedaje>>(MockBehavior.Strict);
            var logicaPuntoMock = new Mock<IPuntoTuristico>(MockBehavior.Strict);
            Hospedaje_Logic logica = new Hospedaje_Logic(repoMock.Object, logicaPuntoMock.Object);
            Hospedaje hospedaje = new Hospedaje()
            {
                Id = 0,
                Ocupado = false,
                PuntoTuristico = new PuntoTuristico(),
                NombreHospedaje = "Hotel X",
                Descripcion = "Test",
                Direccion = "Test",
                CantidadEstrellas = 2,
                Capacidad = 5,
                PrecioPorNoche = 140,
                PrecioTotalPeriodo = 200,
                Imagenes = new List<Imagen>() { new Imagen() { Id = 0, Ruta = "test.jpg", }, },
            };
            repoMock.Setup(x => x.Create(hospedaje));
            repoMock.Setup(x => x.Save());
            repoMock.Setup(x => x.GetAll()).Returns(new List<Hospedaje>());
            logica.AgregarHospedaje(hospedaje);
            repoMock.Setup(x => x.Get(hospedaje.Id)).Returns(hospedaje);
            
            repoMock.Setup(x => x.Delete(hospedaje));
            logica.BorrarHospedaje(hospedaje.Id);
            repoMock.Setup(x => x.GetAll()).Returns(new List<Hospedaje>());
            List<Hospedaje> resultado = logica.ObtenerTodos();
            Assert.AreEqual(0, resultado.Count);
        }
        
        [Test]
        public void ActualizarHospedajeOk()
        {
            var repoMock = new Mock<IRepository<Hospedaje>>(MockBehavior.Strict);
            var logicaPuntoMock = new Mock<IPuntoTuristico>(MockBehavior.Strict);
            Hospedaje_Logic logica = new Hospedaje_Logic(repoMock.Object, logicaPuntoMock.Object);
            Hospedaje hospedaje = new Hospedaje()
            {
                Id = 0,
                Ocupado = false,
                PuntoTuristico = new PuntoTuristico(),
                NombreHospedaje = "Hotel X",
                Descripcion = "Test",
                Direccion = "Test",
                CantidadEstrellas = 2,
                Capacidad = 5,
                PrecioPorNoche = 140,
                PrecioTotalPeriodo = 200,
                Imagenes = new List<Imagen>() { new Imagen() { Id = 0, Ruta = "test.jpg", }, },
            };
            repoMock.Setup(x => x.Create(hospedaje));
            repoMock.Setup(x => x.Update(hospedaje));
            repoMock.Setup(x => x.Save());
            repoMock.Setup(x => x.GetAll()).Returns(new List<Hospedaje>());
            logica.AgregarHospedaje(hospedaje);
            repoMock.Setup(x => x.Get(hospedaje.Id)).Returns(hospedaje);
            hospedaje.NombreHospedaje = "TEST";
            logica.ActualizarHospedaje(hospedaje);
            Hospedaje resultado = logica.ObtenerPorId(hospedaje.Id);
            Assert.AreEqual("TEST", resultado.NombreHospedaje);
        }

        [Test]
        public void CalcularPromedio()
        {
            var repoMock = new Mock<IRepository<Hospedaje>>(MockBehavior.Strict);
            var logicaPuntoMock = new Mock<IPuntoTuristico>(MockBehavior.Strict);
            Hospedaje_Logic logica = new Hospedaje_Logic(repoMock.Object, logicaPuntoMock.Object);
            Resenia resenia1 = new Resenia() { Puntaje = 2 };
            Resenia resenia2 = new Resenia() { Puntaje = 1 };
            Hospedaje hospedaje = new Hospedaje()
            {
                Id = 0,
                Ocupado = false,
                PuntoTuristico = new PuntoTuristico(),
                NombreHospedaje = "Hotel X",
                Descripcion = "Test",
                Direccion = "Test",
                CantidadEstrellas = 2,
                Capacidad = 5,
                PrecioPorNoche = 140,
                PrecioTotalPeriodo = 200,
                Imagenes = new List<Imagen>() { new Imagen() { Id = 0, Ruta = "test.jpg", }, },
                Resenias = new List<Resenia>() { resenia1, resenia2 },
            };
            double esperado = 1.5;
            repoMock.Setup(x => x.Get(hospedaje.Id)).Returns(hospedaje);
            double resultado = logica.CalcularPromedio(hospedaje); 
            Assert.AreEqual(esperado, resultado);
        }
        [Test]
        public void CalcularPromedioRedondeo()
        {
            var repoMock = new Mock<IRepository<Hospedaje>>(MockBehavior.Strict);
            var logicaPuntoMock = new Mock<IPuntoTuristico>(MockBehavior.Strict);
            Hospedaje_Logic logica = new Hospedaje_Logic(repoMock.Object, logicaPuntoMock.Object);
            Resenia resenia1 = new Resenia() { Puntaje = 2 };
            Resenia resenia2 = new Resenia() { Puntaje = 2 };
            Resenia resenia3 = new Resenia() { Puntaje = 1 };
            Hospedaje hospedaje = new Hospedaje()
            {
                Id = 0,
                Ocupado = false,
                PuntoTuristico = new PuntoTuristico(),
                NombreHospedaje = "Hotel X",
                Descripcion = "Test",
                Direccion = "Test",
                CantidadEstrellas = 2,
                Capacidad = 5,
                PrecioPorNoche = 140,
                PrecioTotalPeriodo = 200,
                Imagenes = new List<Imagen>() { new Imagen() { Id = 0, Ruta = "test.jpg", }, },
                Resenias = new List<Resenia>() { resenia1, resenia2,resenia3 },
            };
            double esperado = 1.7;
            repoMock.Setup(x => x.Get(hospedaje.Id)).Returns(hospedaje);
            double resultado = logica.CalcularPromedio(hospedaje);
            Assert.AreEqual(esperado, resultado);
        }
        [Test]
        [ExpectedException(typeof(NoHayReseniaException))]
        public void CalcularPromedioSinResenia ()
        {
            var repoMock = new Mock<IRepository<Hospedaje>>(MockBehavior.Strict);
            var logicaPuntoMock = new Mock<IPuntoTuristico>(MockBehavior.Strict);
            Hospedaje_Logic logica = new Hospedaje_Logic(repoMock.Object, logicaPuntoMock.Object);
            Hospedaje hospedaje = new Hospedaje()
            {
                Id = 0,
                Ocupado = false,
                PuntoTuristico = new PuntoTuristico(),
                NombreHospedaje = "Hotel X",
                Descripcion = "Test",
                Direccion = "Test",
                CantidadEstrellas = 2,
                Capacidad = 5,
                PrecioPorNoche = 140,
                PrecioTotalPeriodo = 200,
                Imagenes = new List<Imagen>() { new Imagen() { Id = 0, Ruta = "test.jpg", }, },
                Resenias = new List<Resenia>(),
            };
            repoMock.Setup(x => x.Get(hospedaje.Id)).Returns(hospedaje);
            Assert.Throws<NoHayReseniaException>(()=>logica.CalcularPromedio(hospedaje));
        }

        [Test]
        public void AgregarReseniaOk()
        {
            var repoMock = new Mock<IRepository<Hospedaje>>(MockBehavior.Strict);
            var logicaPuntoMock = new Mock<IPuntoTuristico>(MockBehavior.Strict);
            Hospedaje_Logic logica = new Hospedaje_Logic(repoMock.Object, logicaPuntoMock.Object);
            Resenia resenia = new Resenia()
            {
                Datos = new DatosUsuario() { Apellido = "Test", Mail = "a@b.c", Nombre = "Test2" },
                Puntaje=5,
                Texto="Pruebas"
            };
            Hospedaje hospedaje = new Hospedaje()
            {
                Id = 0,
                Ocupado = false,
                PuntoTuristico = new PuntoTuristico(),
                NombreHospedaje = "Hotel X",
                Descripcion = "Test",
                Direccion = "Test",
                CantidadEstrellas = 2,
                Capacidad = 5,
                PrecioPorNoche = 140,
                PrecioTotalPeriodo = 200,
                Imagenes = new List<Imagen>() { new Imagen() { Id = 0, Ruta = "test.jpg", }, },
                Resenias = new List<Resenia>(),
            };
            repoMock.Setup(x => x.GetAll()).Returns(new List<Hospedaje>() { hospedaje });
            repoMock.Setup(x => x.Update(hospedaje));
            repoMock.Setup(x => x.Save());
            logica.AgregarResenia(hospedaje, resenia);
            Assert.AreEqual(resenia, hospedaje.Resenias.FirstOrDefault());
        }

        [Test]
        [ExpectedException(typeof(EntidadNoExisteExcepcion))]
        public void AgregarReseniaAHospedajeQueNoExiste()
        {
            var repoMock = new Mock<IRepository<Hospedaje>>(MockBehavior.Strict);
            var logicaPuntoMock = new Mock<IPuntoTuristico>(MockBehavior.Strict);
            Hospedaje_Logic logica = new Hospedaje_Logic(repoMock.Object, logicaPuntoMock.Object);

            Hospedaje hospedaje = new Hospedaje() { Id = 0 };

            repoMock.Setup(x => x.GetAll()).Throws(new EntidadNoExisteExcepcion());
            Assert.Throws<EntidadNoExisteExcepcion>(() => logica.AgregarResenia(hospedaje,It.IsAny<Resenia>()));
        }
    }
}
