using BuissnesLogic_Interface;
using Domain;
using Exceptiones;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Moq;
using NUnit.Framework;
using Obligatorio.Controllers;
using System;
using System.Collections.Generic;
using System.Text;

namespace Controller_Test
{
    class LoginController_Test
    {
        [Test]
        public void GetObtenerPorCredencialesOk()
        {
            var logicMock = new Mock<IUsuario>(MockBehavior.Strict);
            var configMock = new Mock<IConfiguration>(MockBehavior.Strict);
            LoginController controller = new LoginController(logicMock.Object,configMock.Object);
            string mail = "a@b.c";
            string contrasenia = "123";

            Usuario usuario = new Usuario() { Contrasenia = contrasenia, Datos = new DatosUsuario() { Mail = mail }, IsAdmin = true };

            logicMock.Setup(x => x.ObtenerPorCredenciales(mail,contrasenia)).Returns(usuario);
            configMock.Setup(x => x["Secret"]).Returns("Super_Mega_Secret_Key");

            var result = controller.GetPorCredenciales(mail, contrasenia);
            var okResult = result as OkObjectResult;
            logicMock.VerifyAll();
        }
        [Test]
        public void GetObtenerPorCredencialesMailVacio()
        {
            var logicMock = new Mock<IUsuario>(MockBehavior.Strict);
            var configMock = new Mock<IConfiguration>(MockBehavior.Strict);
            LoginController controller = new LoginController(logicMock.Object, configMock.Object);
            string mail = " ";
            string contrasenia = "123";

            logicMock.Setup(x => x.ObtenerPorCredenciales(mail, contrasenia)).Throws(new StringVacioException());
            configMock.Setup(x => x["Secret"]).Returns("Super_Mega_Secret_Key");

            var result = controller.GetPorCredenciales(mail, contrasenia);
            var okResult = result as BadRequestObjectResult;
            logicMock.VerifyAll();
        }

        [Test]
        public void GetObtenerPorCredencialesContrasenialVacio()
        {
            var logicMock = new Mock<IUsuario>(MockBehavior.Strict);
            var configMock = new Mock<IConfiguration>(MockBehavior.Strict);
            LoginController controller = new LoginController(logicMock.Object, configMock.Object);
            string mail = "a@b.c";
            string contrasenia = " ";

            logicMock.Setup(x => x.ObtenerPorCredenciales(mail, contrasenia)).Throws(new StringVacioException());
            configMock.Setup(x => x["Secret"]).Returns("Super_Mega_Secret_Key");

            var result = controller.GetPorCredenciales(mail, contrasenia);
            var okResult = result as BadRequestObjectResult;
            logicMock.VerifyAll();
        }

        [Test]
        public void GetObtenerPorCredencialesMailFormatoInvalido()
        {
            var logicMock = new Mock<IUsuario>(MockBehavior.Strict);
            var configMock = new Mock<IConfiguration>(MockBehavior.Strict);
            LoginController controller = new LoginController(logicMock.Object, configMock.Object);
            string mail = "a@b";
            string contrasenia = "123";

            logicMock.Setup(x => x.ObtenerPorCredenciales(mail, contrasenia)).Throws(new FormatoInvalidoException());
            configMock.Setup(x => x["Secret"]).Returns("Super_Mega_Secret_Key");

            var result = controller.GetPorCredenciales(mail, contrasenia);
            var okResult = result as BadRequestObjectResult;
            logicMock.VerifyAll();
        }
    }
}
