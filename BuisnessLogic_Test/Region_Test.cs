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
    public class Region_Test
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void TestSetNombreValido()
        {
            string nombre = "Este";
            var logicaPuntoMock = new Mock<IPuntoTuristico>(MockBehavior.Strict);
            var repoMock = new Mock<IRepository<Region>>(MockBehavior.Strict);
            Region_Logic logica = new Region_Logic(repoMock.Object, logicaPuntoMock.Object);
            string nombreResultado = logica.ValidarNombre(nombre);
            Assert.AreEqual(nombre, nombreResultado);
        }
        
        [Test]
        [ExpectedException(typeof(StringVacioException))]
        public void TestSetNombreVacio()
        {
            string nombre = "";
            var logicaPuntoMock = new Mock<IPuntoTuristico>(MockBehavior.Strict);
            var repoMock = new Mock<IRepository<Region>>(MockBehavior.Strict);          
            Region_Logic logica = new Region_Logic(repoMock.Object,logicaPuntoMock.Object);
            Assert.Throws<StringVacioException>(() => logica.ValidarNombre(nombre));
        }
        
        [Test]
        [ExpectedException(typeof(StringVacioException))]
        public void TestSetNombreVacioEspacio()
        {
            string nombre = " ";
            var logicaPuntoMock = new Mock<IPuntoTuristico>(MockBehavior.Strict);
            var repoMock = new Mock<IRepository<Region>>(MockBehavior.Strict);
            Region_Logic logica = new Region_Logic(repoMock.Object, logicaPuntoMock.Object);
            Assert.Throws<StringVacioException>(() => logica.ValidarNombre(nombre));
        }
        [Test]
        [ExpectedException(typeof(StringVacioException))]
        public void TestSetNombreInvalido()
        {
            string nombre = "XX";
            var logicaPuntoMock = new Mock<IPuntoTuristico>(MockBehavior.Strict);
            var repoMock = new Mock<IRepository<Region>>(MockBehavior.Strict);
            Region_Logic logica = new Region_Logic(repoMock.Object, logicaPuntoMock.Object);
            Assert.Throws<NombreNoValidoException>(() => logica.ValidarNombre(nombre));
        }

        [Test]
        public void TestObtenerTodosOk()
        {
            string nombre = "Este";
            Region esperado = new Region() { Nombre = nombre, };
            var repoMock = new Mock<IRepository<Region>>(MockBehavior.Strict);
            var repoLogicaPunto = new Mock<IPuntoTuristico>(MockBehavior.Strict);
            Region_Logic logica = new Region_Logic(repoMock.Object, repoLogicaPunto.Object);
            Region region = new Region() { Nombre = nombre, };
            repoMock.Setup(x => x.GetAll()).Returns(new List<Region>() { region });
            List<Region> puntos = logica.ObtenerTodas();
            Assert.AreEqual(esperado.Nombre, puntos.First().Nombre);
        }

        [Test]
        public void TestActualizarRegionOk()
        {
            var repoMock = new Mock<IRepository<Region>>(MockBehavior.Strict);
            var repoLogicaPunto = new Mock<IPuntoTuristico>(MockBehavior.Strict);
            Region_Logic logica = new Region_Logic(repoMock.Object, repoLogicaPunto.Object);
            Region region = new Region() { Nombre = "Metropolitana",Id=0 };
            repoMock.Setup(x => x.Update(region));
            repoMock.Setup(x => x.Save());
            region.Nombre = "Este";
            logica.ActualizarRegion(region);
            repoMock.VerifyAll();
        }
        
        [Test]
        public void TestBorrarOk()
        {
            var repoMock = new Mock<IRepository<Region>>(MockBehavior.Strict);
            var repoLogicaPunto = new Mock<IPuntoTuristico>(MockBehavior.Strict);
            Region_Logic logica = new Region_Logic(repoMock.Object, repoLogicaPunto.Object);
            Region region = new Region() { Id = 0, Nombre = "Este", };
            repoMock.Setup(x => x.Delete(region));
            repoMock.Setup(x => x.Save());
            repoMock.Setup(x => x.Get(region.Id)).Returns(region);
            logica.BorrarRegionId(region.Id);
            repoMock.VerifyAll();
        }

        [Test]
        public void TestCrearRegionValido()
        {
            string nombre = "Este";
            var logicaPuntoMock = new Mock<IPuntoTuristico>(MockBehavior.Strict);
            var repoMock = new Mock<IRepository<Region>>(MockBehavior.Strict);
            Region_Logic logica = new Region_Logic(repoMock.Object, logicaPuntoMock.Object);
            Region region = logica.Region(nombre);
            Assert.AreEqual(nombre, region.Nombre);
        }
        
        [Test]
        [ExpectedException(typeof(YaExisteLaEntidadExcepcion))]
        public void TestAgregarRegionYaExsiste()
        {
            string nombre = "Este";
            string nombre2 = "Metropolitana";
            var logicaPuntoMock = new Mock<IPuntoTuristico>(MockBehavior.Strict);
            var repoMock = new Mock<IRepository<Region>>(MockBehavior.Strict);
            Region_Logic logica = new Region_Logic(repoMock.Object, logicaPuntoMock.Object);
            Region region = logica.Region(nombre);
            region.Id = 0;
            Region region2 = logica.Region(nombre2);
            region2.Id = 0;
            repoMock.Setup(x => x.Create(region));
            repoMock.Setup(x => x.Save());
            repoMock.Setup(x => x.Get(0)).Throws(new EntidadNoExisteExcepcion());
            logica.AgregarRegion(region);
            repoMock.Setup(x => x.Get(0)).Throws(new YaExisteLaEntidadExcepcion());
            Assert.Throws<YaExisteLaEntidadExcepcion>(()=>logica.AgregarRegion(region2));
        }

        [Test]
        public void AgregarPuntoTuristicoValido()
        {
            string nombre = "Este";
            var logicaPuntoMock = new Mock<IPuntoTuristico>(MockBehavior.Strict);
            var repoMock = new Mock<IRepository<Region>>(MockBehavior.Strict);
            Region_Logic logica = new Region_Logic(repoMock.Object, logicaPuntoMock.Object);
            Region region = logica.Region(nombre);
            int regionId = 1;
            region.Id = regionId;

            PuntoTuristico puntoRet = new PuntoTuristico();
            string nombrePunto = "prueba";
            string desc = "test";
            puntoRet.Nombre = nombrePunto;
            puntoRet.Descripcion = desc;
            logicaPuntoMock.Setup(x => x.PuntoTuristico(nombrePunto, desc)).Returns(puntoRet);
            PuntoTuristico punto = logicaPuntoMock.Object.PuntoTuristico(nombrePunto, desc);
            punto.Id = 1;

            logicaPuntoMock.Setup(x => x.ObtenerPuntoId(punto.Id)).Returns(punto);
            repoMock.Setup(x => x.Get(regionId)).Returns(region);
            repoMock.Setup(x => x.Update(region));
            repoMock.Setup(x => x.Save());

            logica.AgregarPunto(regionId, punto.Id);
            Assert.AreEqual(1, region.Puntos.Count);
        }
        
        [Test]
        [ExpectedException(typeof(EntidadNoExisteExcepcion))]
        public void ObtenerRegionIdNoExiste()
        {
            string nombre = "Este";
            var logicaPuntoMock = new Mock<IPuntoTuristico>(MockBehavior.Strict);
            var repoMock = new Mock<IRepository<Region>>(MockBehavior.Strict);
            Region_Logic logica = new Region_Logic(repoMock.Object, logicaPuntoMock.Object);
            Region region = logica.Region(nombre);
            region.Id = 1;
            repoMock.Setup(x => x.Get(2)).Throws(new EntidadNoExisteExcepcion());            
            Assert.Throws<EntidadNoExisteExcepcion>(()=> logica.ObtenerRegionId(2));
        }

        [Test]
        public void ObtenerRegionIdValido()
        {
            string nombre = "Este";
            var logicaPuntoMock = new Mock<IPuntoTuristico>(MockBehavior.Strict);
            var repoMock = new Mock<IRepository<Region>>(MockBehavior.Strict);
            Region_Logic logica = new Region_Logic(repoMock.Object, logicaPuntoMock.Object);
            Region region = logica.Region(nombre);
            region.Id = 1;
            repoMock.Setup(x => x.Get(1)).Returns(region);
            Region resultado = logica.ObtenerRegionId(1);
            Assert.AreEqual(nombre, resultado.Nombre);
        }

        [Test]
        public void ObtenerPuntosTuristicosRegionIdValido()
        {
            string nombre = "Este";
            var logicaPuntoMock = new Mock<IPuntoTuristico>(MockBehavior.Strict);
            var repoMock = new Mock<IRepository<Region>>(MockBehavior.Strict);
            Region_Logic logica = new Region_Logic(repoMock.Object, logicaPuntoMock.Object);
            Region region = logica.Region(nombre);
            region.Id = 1;
            Region region2 = logica.Region(nombre);
            region2.Id = 2;

            string nombrePunto = "prueba";
            string nombrePunto2 = "prueba2";
            string desc = "test";
            PuntoTuristico puntoRet = new PuntoTuristico();
            puntoRet.Nombre = nombrePunto;
            puntoRet.Descripcion = desc;
            PuntoTuristico puntoRet2 = new PuntoTuristico();
            puntoRet2.Nombre = nombrePunto2;
            puntoRet2.Descripcion = desc;
            var repoMock2 = new Mock<IRepository<PuntoTuristico>>(MockBehavior.Strict);
            
            logicaPuntoMock.Setup(x => x.PuntoTuristico(nombrePunto, desc)).Returns(puntoRet);
            PuntoTuristico punto = logicaPuntoMock.Object.PuntoTuristico(nombrePunto, desc);
            punto.Id = 1;
            logicaPuntoMock.Setup(x => x.ObtenerPuntoId(punto.Id)).Returns(punto);

            logicaPuntoMock.Setup(x => x.PuntoTuristico(nombrePunto2, desc)).Returns(puntoRet2);
            PuntoTuristico punto2 = logicaPuntoMock.Object.PuntoTuristico(nombrePunto2, desc);
            punto2.Id = 2;
            
            logicaPuntoMock.Setup(x => x.ObtenerPuntoId(punto2.Id)).Returns(punto2);
            
            repoMock.Setup(x => x.Get(1)).Returns(region);
            repoMock.Setup(x => x.Get(2)).Returns(region2);
            repoMock.Setup(x => x.Update(region));
            repoMock.Setup(x => x.Save());

            logica.AgregarPunto(region.Id, punto.Id);
            repoMock.Setup(x => x.Update(region2));
            repoMock.Setup(x => x.Save());

            logica.AgregarPunto(region2.Id, punto2.Id);

            var resultado = logica.ObtenerPuntosTuristicos(1);
            Assert.AreEqual(nombrePunto, resultado.First().Nombre);
        }
    }
}
