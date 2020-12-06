using BuissnesLogic_Interface;
using Domain;
using Exceptiones;
using Microsoft.AspNetCore.Mvc;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using NUnit.Framework;
using Obligatorio.Controllers;
using Obligatorio.Models;
using Obligatorio.Traductor;
using System;
using System.Collections.Generic;
using System.Text;
using Assert = NUnit.Framework.Assert;

namespace Controller_Test
{
    class UsuarioController_Test
    {
        //POST Tests
        //------------------
        [Test]
        public void PostUsuarioOk()
        {
            int intTest = 0;
            var logicMock = new Mock<IUsuario>(MockBehavior.Strict);
            UsuariosController controller = new UsuariosController(logicMock.Object);

            DatosUsuario datos = new DatosUsuario()
            {
                Apellido = "Asd",
                Mail = "a@b.c",
                Nombre = "Juan",
            };
            UsuarioModel usuarioModel = new UsuarioModel()
            {
                IsAdmin = false,
                Datos = datos,
                Token = "Recien Creado",
                Contrasenia = "Contraseña",
            };

            Usuario usuario = TraductorUsuario.AEntidad(usuarioModel);
            Usuario usuarioRet = usuario;
            usuarioRet.Id = intTest;

            logicMock.Setup(x => x.CrearUsuario(intTest,It.IsAny<Usuario>())).Returns(It.IsAny<Usuario>());
            logicMock.Setup(x => x.AgregarUsuario(It.IsAny<Usuario>()));

            var result = controller.Post(intTest, usuarioModel);
            var okResult = result as OkObjectResult;

            logicMock.VerifyAll();
        }

        [Test]
        public void PostUsuarioDatosVacio()
        {
            var logicMock = new Mock<IUsuario>(MockBehavior.Strict);
            UsuariosController controller = new UsuariosController(logicMock.Object);
            Usuario usuario = new Usuario()
            {
                IsAdmin = false,
                Datos = new DatosUsuario(),
                Id = 0,
                Token = "Recien Creado",
                Contrasenia = "Contraseña",
            };
            UsuarioModel usuarioModel = TraductorUsuario.AModelo(usuario);

            logicMock.Setup(x => x.CrearUsuario(usuario.Id,It.IsAny<Usuario>())).Throws(new StringVacioException());
            
            var result = controller.Post(usuario.Id, usuarioModel);
            var okResult = result as BadRequestObjectResult;

            logicMock.VerifyAll();
        }

        [Test]
        [ExpectedException(typeof(StringVacioException))]
        public void PostUsuarioDatosNull()
        {
            var logicMock = new Mock<IUsuario>(MockBehavior.Strict);
            UsuariosController controller = new UsuariosController(logicMock.Object);
            UsuarioModel usuarioModel = new UsuarioModel()
            {
                IsAdmin = false,
                Datos = null,
                Token = "Recien Creado",
                Contrasenia = "Contraseña",
            };

            logicMock.Setup(x=>x.CrearUsuario(It.IsAny<int>(),It.IsAny<Usuario>())).Throws(new StringVacioException());

            var result = controller.Post(It.IsAny<int>(),usuarioModel);
            var okResult = result as BadRequestObjectResult;

            logicMock.VerifyAll();
        }
        [Test]
        [ExpectedException(typeof(FormatoInvalidoException))]
        public void PostErrorFormatoMail()
        {
            var logicMock = new Mock<IUsuario>(MockBehavior.Strict);
            UsuariosController controller = new UsuariosController(logicMock.Object);
            DatosUsuario datos = new DatosUsuario()
            {
                Apellido = "Asd",
                Mail = "a@b.c",
                Nombre = "Juan",
            };
            UsuarioModel usuarioModel = new UsuarioModel()
            {
                IsAdmin = false,
                Datos = datos,
                Token = "Recien Creado",
                Contrasenia = "Contraseña",
            };

            logicMock.Setup(x => x.CrearUsuario(It.IsAny<int>(), It.IsAny<Usuario>())).Throws(new FormatoInvalidoException());

            var result = controller.Post(It.IsAny<int>(), usuarioModel);
            var okResult = result as BadRequestObjectResult;

            logicMock.VerifyAll();
        }

        [Test]
        [ExpectedException(typeof(MailNoUnicoException))]
        public void PostErrorMailNoUnico()
        {
            var logicMock = new Mock<IUsuario>(MockBehavior.Strict);
            UsuariosController controller = new UsuariosController(logicMock.Object);
            DatosUsuario datos = new DatosUsuario()
            {
                Apellido = "Asd",
                Mail = "a@b.c",
                Nombre = "Juan",
            };
            UsuarioModel usuarioModel = new UsuarioModel()
            {
                IsAdmin = false,
                Datos = datos,
                Token = "Recien Creado",
                Contrasenia = "Contraseña",
            };

            logicMock.Setup(x => x.CrearUsuario(It.IsAny<int>(), It.IsAny<Usuario>())).Throws(new MailNoUnicoException());

            var result = controller.Post(It.IsAny<int>(), usuarioModel);
            var okResult = result as BadRequestObjectResult;

            logicMock.VerifyAll();
        }

        //GET Tests
        //------------------
        [Test]
        public void GetAllUsuariosConElementoOk()
        {
            var logicMock = new Mock<IUsuario>(MockBehavior.Strict);
            UsuariosController controller = new UsuariosController(logicMock.Object);
            DatosUsuario datos = new DatosUsuario()
            {
                Apellido = "Asd",
                Mail = "a@b.c",
                Nombre = "Juan",
            };
            Usuario usuario = new Usuario()
            {
                IsAdmin=false,
                Datos=datos,
                Id=0,
                Token = "Recien Creado",
                Contrasenia="Contraseña",
            };
            logicMock.Setup(x => x.ObtenerTodos())
                .Returns(new List<Usuario>() { usuario });

            var result = controller.Get();
            var okResult = result as OkObjectResult;
            logicMock.VerifyAll();
        }

        [Test]
        public void GetAllUsuariosSinElementoOk()
        {
            var logicMock = new Mock<IUsuario>(MockBehavior.Strict);
            UsuariosController controller = new UsuariosController(logicMock.Object);

            logicMock.Setup(x => x.ObtenerTodos())
                .Returns(new List<Usuario>());

            var result = controller.Get();
            var okResult = result as OkObjectResult;
            logicMock.VerifyAll();
        }

        [Test]
        public void GetPorNombreOk()
        {
            var logicMock = new Mock<IUsuario>(MockBehavior.Strict);
            UsuariosController controller = new UsuariosController(logicMock.Object);
            DatosUsuario datos = new DatosUsuario()
            {
                Apellido = "Asd",
                Mail = "a@b.c",
                Nombre = "Juan",
            };
            Usuario usuario = new Usuario()
            {
                IsAdmin = false,
                Datos = datos,
                Id = 0,
                Token = "Recien Creado",
                Contrasenia = "Contraseña",
            };
            logicMock.Setup(x => x.ObtenerPorNombre(datos.Nombre)).Returns(usuario);

            var result = controller.GetPorNombre(datos.Nombre);
            var okResult = result as OkObjectResult;
            logicMock.VerifyAll();
        }

        [Test]
        public void GetPorNombreNoExiste()
        {
            var logicMock = new Mock<IUsuario>(MockBehavior.Strict);
            UsuariosController controller = new UsuariosController(logicMock.Object);

            logicMock.Setup(x => x.ObtenerPorNombre(It.IsAny<string>())).Throws(new EntidadNoExisteExcepcion());

            var result = controller.GetPorNombre(It.IsAny<string>());
            var okResult = result as NotFoundObjectResult;
            logicMock.VerifyAll();
        }


        [Test]
        public void GetPorIdOk()
        {
            var logicMock = new Mock<IUsuario>(MockBehavior.Strict);
            UsuariosController controller = new UsuariosController(logicMock.Object);
            DatosUsuario datos = new DatosUsuario()
            {
                Apellido = "Asd",
                Mail = "a@b.c",
                Nombre = "Juan",
            };
            Usuario usuario = new Usuario()
            {
                IsAdmin = false,
                Datos = datos,
                Id = 0,
                Token = "Recien Creado",
                Contrasenia = "Contraseña",
            };
            logicMock.Setup(x => x.ObtenerPorId(usuario.Id)).Returns(usuario);

            var result = controller.GetPorId(usuario.Id);
            var okResult = result as OkObjectResult;
            logicMock.VerifyAll();
        }

        [Test]
        public void GetPorIdNoExiste()
        {
            var logicMock = new Mock<IUsuario>(MockBehavior.Strict);
            UsuariosController controller = new UsuariosController(logicMock.Object);

            logicMock.Setup(x => x.ObtenerPorId(It.IsAny<int>())).Throws(new EntidadNoExisteExcepcion());

            var result = controller.GetPorId(It.IsAny<int>());
            var okResult = result as NotFoundObjectResult;
            logicMock.VerifyAll();
        }

        //DELETE Tests
        //------------------
        [Test]
        public void DeleteUsuarioOk()
        {
            var logicMock = new Mock<IUsuario>(MockBehavior.Strict);
            UsuariosController controller = new UsuariosController(logicMock.Object);

            logicMock.Setup(x => x.BorrarUsuario(It.IsAny<int>()));

            var result = controller.Delete(It.IsAny<int>());
            var okResult = result as OkObjectResult;

            logicMock.VerifyAll();
        }

        [Test]
        public void DeleteUsuarioNoExiste()
        {
            var logicMock = new Mock<IUsuario>(MockBehavior.Strict);
            UsuariosController controller = new UsuariosController(logicMock.Object);

            logicMock.Setup(x => x.BorrarUsuario(It.IsAny<int>())).Throws(new EntidadNoExisteExcepcion());

            var result = controller.Delete(It.IsAny<int>());
            var okResult = result as NotFoundObjectResult;

            logicMock.VerifyAll();

            Assert.AreEqual(404, okResult.StatusCode);
        }

        //PUT Tests
        //------------------
        [Test]
        public void PutOk()
        {

            var logicMock = new Mock<IUsuario>(MockBehavior.Strict);
            UsuariosController controller = new UsuariosController(logicMock.Object);
            DatosUsuario datos = new DatosUsuario()
            {
                Apellido = "Asd",
                Mail = "a@b.c",
                Nombre = "Juan",
            };
            UsuarioModel usuarioModel = new UsuarioModel()
            {
                IsAdmin = false,
                Datos = datos,
                Token = "Recien Creado",
                Contrasenia = "Contraseña",
            };
            logicMock.Setup(x => x.ActualizarUsuario(It.IsAny<int>(),It.IsAny<Usuario>()));

            var result = controller.Put(It.IsAny<int>(),usuarioModel);
            var okResult = result as OkObjectResult;

            logicMock.VerifyAll();
        }

        [Test]
        public void PutNoExiste()
        {
            var logicMock = new Mock<IUsuario>(MockBehavior.Strict);
            UsuariosController controller = new UsuariosController(logicMock.Object);
            DatosUsuario datos = new DatosUsuario()
            {
                Apellido = "Asd",
                Mail = "a@b.c",
                Nombre = "Juan",
            };
            UsuarioModel usuarioModel = new UsuarioModel()
            {
                IsAdmin = false,
                Datos = datos,
                Token = "Recien Creado",
                Contrasenia = "Contraseña",
            };
            logicMock.Setup(x => x.ActualizarUsuario(It.IsAny<int>(), It.IsAny<Usuario>())).Throws(new EntidadNoExisteExcepcion());

            var result = controller.Put(It.IsAny<int>(), usuarioModel);
            var okResult = result as NotFoundObjectResult;

            logicMock.VerifyAll();

            Assert.AreEqual(404, okResult.StatusCode);
        }

        [Test]
        [ExpectedException(typeof(StringVacioException))]
        public void PutUsuarioDatosNull()
        {
            var logicMock = new Mock<IUsuario>(MockBehavior.Strict);
            UsuariosController controller = new UsuariosController(logicMock.Object);
            UsuarioModel usuarioModel = new UsuarioModel()
            {
                IsAdmin = false,
                Datos = null,
                Token = "Recien Creado",
                Contrasenia = "Contraseña",
            };

            logicMock.Setup(x => x.ActualizarUsuario(It.IsAny<int>(), It.IsAny<Usuario>())).Throws(new StringVacioException());

            var result = controller.Put(It.IsAny<int>(), usuarioModel);
            var okResult = result as BadRequestObjectResult;

            logicMock.VerifyAll();
        }
        [Test]
        [ExpectedException(typeof(FormatoInvalidoException))]
        public void PutErrorFormatoMail()
        {
            var logicMock = new Mock<IUsuario>(MockBehavior.Strict);
            UsuariosController controller = new UsuariosController(logicMock.Object);
            DatosUsuario datos = new DatosUsuario()
            {
                Apellido = "Asd",
                Mail = "a@b.c",
                Nombre = "Juan",
            };
            UsuarioModel usuarioModel = new UsuarioModel()
            {
                IsAdmin = false,
                Datos = datos,
                Token = "Recien Creado",
                Contrasenia = "Contraseña",
            };

            logicMock.Setup(x => x.ActualizarUsuario(It.IsAny<int>(), It.IsAny<Usuario>())).Throws(new FormatoInvalidoException());

            var result = controller.Put(It.IsAny<int>(), usuarioModel);
            var okResult = result as BadRequestObjectResult;

            logicMock.VerifyAll();
        }

        [Test]
        [ExpectedException(typeof(MailNoUnicoException))]
        public void PutErrorMailNoUnico()
        {
            var logicMock = new Mock<IUsuario>(MockBehavior.Strict);
            UsuariosController controller = new UsuariosController(logicMock.Object);
            DatosUsuario datos = new DatosUsuario()
            {
                Apellido = "Asd",
                Mail = "a@b.c",
                Nombre = "Juan",
            };
            UsuarioModel usuarioModel = new UsuarioModel()
            {
                IsAdmin = false,
                Datos = datos,
                Token = "Recien Creado",
                Contrasenia = "Contraseña",
            };

            logicMock.Setup(x => x.ActualizarUsuario(It.IsAny<int>(), It.IsAny<Usuario>())).Throws(new MailNoUnicoException());

            var result = controller.Put(It.IsAny<int>(), usuarioModel);
            var okResult = result as BadRequestObjectResult;

            logicMock.VerifyAll();
        }
    }
}
