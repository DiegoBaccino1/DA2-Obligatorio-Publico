using BuisnessLogic.Domain;
using BuissnesLogic;
using BuissnesLogic_Interface;
using Domain;
using Exceptiones;
using Microsoft.AspNetCore.Mvc;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using NUnit.Framework;
using Obligatorio.Controllers;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Reflection;
using System.Text;

namespace Controller_Test
{
    class ImportadoresController_Test
    {
        [Test]
        public void GetAllImportadoresOk()
        {
            var logicMock = new Mock<DllImportador>(MockBehavior.Strict);
            var hospedajesMock= new Mock<IHospedaje>(MockBehavior.Strict);
            var puntosMock = new Mock<IPuntoTuristico>(MockBehavior.Strict);
            var configMock = new Mock<IConfiguration>(MockBehavior.Strict);
            ImportadoresController controller = new ImportadoresController(hospedajesMock.Object, puntosMock.Object,configMock.Object);
            string path = "C:\\Users\\diego\\Desktop\\Obligatorio_DA2\\ImportadorJSON\\bin\\Debug\\netcoreapp3.1\\Importador.dll";
            configMock.Setup(x => x["Directory"]).Returns(path);
            var result = controller.GetAllImportadores();
            var okResult = result as OkObjectResult;
            logicMock.VerifyAll();
        }
        [Test]
        public void GetCargarHospedajesImportadoresOk()
        {
            string importador = "Importador JSON";
            var importadorMock = new Mock<IArchivoImportador>(MockBehavior.Strict);
            var hospedajesMock = new Mock<IHospedaje>(MockBehavior.Strict);
            var puntosMock = new Mock<IPuntoTuristico>(MockBehavior.Strict);
            var configMock = new Mock<IConfiguration>(MockBehavior.Strict);
            
            ImportadoresController controller = new ImportadoresController(hospedajesMock.Object, puntosMock.Object, configMock.Object);
            string path = "C:\\Users\\diego\\Desktop\\Obligatorio_DA2\\ImportadorJSON\\bin\\Debug\\netcoreapp3.1\\Importador.dll";
            
            configMock.Setup(x => x["Directory"]).Returns(path);
            hospedajesMock.Setup(x => x.AgregarHospedaje(It.IsAny<Hospedaje>()));
            puntosMock.Setup(x => x.AgregarPunto(It.IsAny<PuntoTuristico>()));

            var result = controller.GetCargarHospedajes(importador,path);
            var okResult = result as OkObjectResult;
            importadorMock.VerifyAll();
        }
        [Test]
        [ExpectedException(typeof(StringVacioException))]
        public void GetCargarHospedajesImportadoresNombreVacio()
        {
            var importadorMock = new Mock<IArchivoImportador>(MockBehavior.Strict);
            var hospedajesMock = new Mock<IHospedaje>(MockBehavior.Strict);
            var puntosMock = new Mock<IPuntoTuristico>(MockBehavior.Strict);
            var configMock = new Mock<IConfiguration>(MockBehavior.Strict);

            ImportadoresController controller = new ImportadoresController(hospedajesMock.Object, puntosMock.Object, configMock.Object);
            string path = "C:\\Users\\diego\\Desktop\\Obligatorio_DA2\\ImportadorJSON\\bin\\Debug\\netcoreapp3.1\\Importador.dll";

            configMock.Setup(x => x["Directory"]).Returns(path);

            var result = controller.GetCargarHospedajes("", It.IsAny<string>());
            var okResult = result as BadRequestObjectResult;
            importadorMock.VerifyAll();
        }
    }
}
