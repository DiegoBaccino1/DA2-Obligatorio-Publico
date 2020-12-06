using BuissnesLogic;
using DataAccessInterface;
using Domain;
using Exceptiones;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using Assert = NUnit.Framework.Assert;

namespace BuisnessLogic_Test
{
    class Usuario_Test
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void TestSetNombreValido()
        {
            string nombre = "Hola don pepito";
            var repoMock = new Mock<IRepository<Usuario>>(MockBehavior.Strict);
            Usuario_Logic logica = new Usuario_Logic(repoMock.Object);
            string nombreResultado = logica.ValidarString(nombre);
            Assert.AreEqual(nombre, nombreResultado);
        }
        [Test]
        [ExpectedException(typeof(StringVacioException))]
        public void TestSetNombreVacio()
        {
            string nombre = "";
            var repoMock = new Mock<IRepository<Usuario>>(MockBehavior.Strict);
            Usuario_Logic logica = new Usuario_Logic(repoMock.Object);
            Assert.Throws<StringVacioException>(() => logica.ValidarString(nombre));
        }
        [Test]
        [ExpectedException(typeof(StringVacioException))]
        public void TestSetNombreVacioConEspacio()
        {
            string nombre = " ";
            var repoMock = new Mock<IRepository<Usuario>>(MockBehavior.Strict);
            Usuario_Logic logica = new Usuario_Logic(repoMock.Object);
            Assert.Throws<StringVacioException>(() => logica.ValidarString(nombre));
        }
        [Test]
        [ExpectedException(typeof(StringVacioException))]
        public void TestSetNombreNull()
        {
            string nombre = null;
            var repoMock = new Mock<IRepository<Usuario>>(MockBehavior.Strict);
            Usuario_Logic logica = new Usuario_Logic(repoMock.Object);
            Assert.Throws<StringVacioException>(() => logica.ValidarString(nombre));
        }

        public void TestSetApellidoValido()
        {
            string apellido = "Hola don jose";
            var repoMock = new Mock<IRepository<Usuario>>(MockBehavior.Strict);
            Usuario_Logic logica = new Usuario_Logic(repoMock.Object);
            string apellidoResultado = logica.ValidarString(apellido);
            Assert.AreEqual(apellido, apellidoResultado);
        }
        [Test]
        [ExpectedException(typeof(StringVacioException))]
        public void TestSetApellidoVacio()
        {
            string apellido = "";
            var repoMock = new Mock<IRepository<Usuario>>(MockBehavior.Strict);
            Usuario_Logic logica = new Usuario_Logic(repoMock.Object);
            Assert.Throws<StringVacioException>(() => logica.ValidarString(apellido));
        }
        [Test]
        [ExpectedException(typeof(StringVacioException))]
        public void TestSetApellidoVacioConEspacio()
        {
            string apellido = " ";
            var repoMock = new Mock<IRepository<Usuario>>(MockBehavior.Strict);
            Usuario_Logic logica = new Usuario_Logic(repoMock.Object);
            Assert.Throws<StringVacioException>(() => logica.ValidarString(apellido));
        }
        [Test]
        [ExpectedException(typeof(StringVacioException))]
        public void TestSetApellidoNull()
        {
            string apellido = null;
            var repoMock = new Mock<IRepository<Usuario>>(MockBehavior.Strict);
            Usuario_Logic logica = new Usuario_Logic(repoMock.Object);
            Assert.Throws<StringVacioException>(() => logica.ValidarString(apellido));
        }

        [Test]
        public void TestMailValido()
        {
            string mail = "paso@usted.com";
            List<Usuario> usuarios = new List<Usuario>();
            var repoMock = new Mock<IRepository<Usuario>>(MockBehavior.Strict);
            Usuario_Logic logica = new Usuario_Logic(repoMock.Object);
            repoMock.Setup(x => x.GetAll()).Returns(usuarios);
            string mailResultado = logica.ValidarMail(mail);
            Assert.AreEqual(mail, mailResultado);
        }
        [Test]
        [ExpectedException(typeof(StringVacioException))]
        public void TestMailNull()
        {
            string mail = null;
            var repoMock = new Mock<IRepository<Usuario>>(MockBehavior.Strict);
            Usuario_Logic logica = new Usuario_Logic(repoMock.Object);
            Assert.Throws<StringVacioException>(()=>logica.ValidarMail(mail));
        }

        [Test]
        [ExpectedException(typeof(StringVacioException))]
        public void TestMailVacio()
        {
            string mail = "";
            var repoMock = new Mock<IRepository<Usuario>>(MockBehavior.Strict);
            Usuario_Logic logica = new Usuario_Logic(repoMock.Object);
            Assert.Throws<StringVacioException>(() => logica.ValidarMail(mail));
        }

        [Test]
        [ExpectedException(typeof(StringVacioException))]
        public void TestMailVacioConEspacio()
        {
            string mail = " ";
            var repoMock = new Mock<IRepository<Usuario>>(MockBehavior.Strict);
            Usuario_Logic logica = new Usuario_Logic(repoMock.Object);
            Assert.Throws<StringVacioException>(() => logica.ValidarMail(mail));
        }
        [Test]
        [ExpectedException(typeof(FormatoInvalidoException))]
        public void TestMailFormatoInValido()
        {
            string mail = "Ciudades";
            var repoMock = new Mock<IRepository<Usuario>>(MockBehavior.Strict);
            Usuario_Logic logica = new Usuario_Logic(repoMock.Object);
            Assert.Throws<FormatoInvalidoException>(() => logica.ValidarMail(mail));
        }
        [Test]
        [ExpectedException(typeof(MailNoUnicoException))]
        public void TestMailNoUnico()
        {
            string mail = "a@b.c";
            DatosUsuario datos = new DatosUsuario() { Mail = mail };
            Usuario usuario1 = new Usuario() { Datos = datos, };
            Usuario usuario2 = new Usuario() { Datos = datos };
            var repoMock = new Mock<IRepository<Usuario>>(MockBehavior.Strict);
            Usuario_Logic logica = new Usuario_Logic(repoMock.Object);
            List<Usuario> usuarios = new List<Usuario>();
            usuarios.Add(usuario1);
            usuarios.Add(usuario2);

            repoMock.Setup(x => x.GetAll()).Returns(usuarios);

            Assert.Throws<MailNoUnicoException>(() => logica.ValidarMail(mail));
        }

        [Test]
        public void TestSetContraseniaValido()
        {
            string nombre = "Hola don pepito";
            var repoMock = new Mock<IRepository<Usuario>>(MockBehavior.Strict);
            Usuario_Logic logica = new Usuario_Logic(repoMock.Object);
            string nombreResultado = logica.ValidarString(nombre);
            Assert.AreEqual(nombre, nombreResultado);
        }
        [Test]
        [ExpectedException(typeof(StringVacioException))]
        public void TestSetContraseniaVacio()
        {
            string nombre = "";
            var repoMock = new Mock<IRepository<Usuario>>(MockBehavior.Strict);
            Usuario_Logic logica = new Usuario_Logic(repoMock.Object);
            Assert.Throws<StringVacioException>(() => logica.ValidarString(nombre));
        }
        [Test]
        [ExpectedException(typeof(StringVacioException))]
        public void TestSetContraseniaVacioConEspacio()
        {
            string nombre = "";
            var repoMock = new Mock<IRepository<Usuario>>(MockBehavior.Strict);
            Usuario_Logic logica = new Usuario_Logic(repoMock.Object);
            Assert.Throws<StringVacioException>(() => logica.ValidarString(nombre));
        }
        [Test]
        [ExpectedException(typeof(StringVacioException))]
        public void TestSetContraseniaNull()
        {
            string nombre = null;
            var repoMock = new Mock<IRepository<Usuario>>(MockBehavior.Strict);
            Usuario_Logic logica = new Usuario_Logic(repoMock.Object);
            Assert.Throws<StringVacioException>(() => logica.ValidarString(nombre));
        }
        [Test]
        public void AgregarUsuario() 
        {
            var repoMock = new Mock<IRepository<Usuario>>(MockBehavior.Strict);
            Usuario_Logic logica = new Usuario_Logic(repoMock.Object);
            Usuario usuario = It.IsAny<Usuario>();
            repoMock.Setup(x => x.Create(usuario));
            repoMock.Setup(x => x.Save());
            logica.AgregarUsuario(usuario);
            repoMock.VerifyAll();
        }

        [Test]
        public void CrearUsuarioAdminNoControlaApellidoOk()
        {
            var repoMock = new Mock<IRepository<Usuario>>(MockBehavior.Strict);
            Usuario_Logic logica = new Usuario_Logic(repoMock.Object);
            Usuario retorno = new Usuario();
            DatosUsuario datos = new DatosUsuario()
            {
                Apellido = "",
                Nombre = "pepe",
                Mail = "a@b.c",
            };
            Usuario usuario = new Usuario()
            {
                Datos = datos,
                IsAdmin = true,
                Id = 0,
                Contrasenia = "Test",
            };
            repoMock.Setup(x => x.GetAll()).Returns(new List<Usuario>());
            retorno = logica.CrearUsuario(usuario.Id,usuario);
            Assert.AreEqual(usuario.Id,retorno.Id);
        }
        [Test]
        public void ActualizarUsuarioOk()
        {
            var repoMock = new Mock<IRepository<Usuario>>(MockBehavior.Strict);
            Usuario_Logic logica = new Usuario_Logic(repoMock.Object);
            Usuario retorno = new Usuario();
            string passVieja = "Test";
            string passNueva = "Pruebas";
            DatosUsuario datos = new DatosUsuario()
            {
                Apellido = "",
                Nombre = "pepe",
                Mail = "a@b.c",
            };
            Usuario usuario = new Usuario()
            {
                Datos = datos,
                IsAdmin = true,
                Id = 0,
                Contrasenia = passVieja,
            };
            Usuario usuario2 = new Usuario()
            {
                Datos = datos,
                IsAdmin = true,
                Id = 0,
                Contrasenia = passNueva,
            };
            repoMock.Setup(x => x.Get(usuario.Id)).Returns(usuario);
            repoMock.Setup(x => x.GetAll()).Returns(new List<Usuario>() { usuario });
            repoMock.Setup(x => x.Update(usuario));
            repoMock.Setup(x => x.Save());
            logica.ActualizarUsuario(usuario.Id, usuario2);
            Assert.AreEqual(usuario.Contrasenia, passNueva);
        }
        [Test]
        [ExpectedException(typeof(EntidadNoExisteExcepcion))]
        public void TestActualizarNoExiste()
        {
            var repoMock = new Mock<IRepository<Usuario>>(MockBehavior.Strict);
            Usuario_Logic logica = new Usuario_Logic(repoMock.Object);
            repoMock.Setup(x => x.Get(1)).Throws(new EntidadNoExisteExcepcion());
            Assert.Throws<EntidadNoExisteExcepcion>(() => logica.ActualizarUsuario(1,It.IsAny<Usuario>()));
        }
        [Test]
        public void BorrarUsuarioOk()
        {
            var repoMock = new Mock<IRepository<Usuario>>(MockBehavior.Strict);
            Usuario_Logic logica = new Usuario_Logic(repoMock.Object);
            Usuario retorno = new Usuario();
            DatosUsuario datos = new DatosUsuario()
            {
                Apellido = "",
                Nombre = "pepe",
                Mail = "a@b.c",
            };
            Usuario usuario = new Usuario()
            {
                Datos = datos,
                IsAdmin = true,
                Id = 0,
                Contrasenia ="Test",
            };

            repoMock.Setup(x => x.Get(usuario.Id)).Returns(usuario);
            repoMock.Setup(x => x.Delete(usuario));
            repoMock.Setup(x => x.Save());
            logica.BorrarUsuario(usuario.Id);
            repoMock.Setup(x => x.GetAll()).Returns(new List<Usuario>());
            List<Usuario> resultado = logica.ObtenerTodos();
            Assert.AreEqual(0, resultado.Count);
        }
        [Test]
        [ExpectedException(typeof(EntidadNoExisteExcepcion))]
        public void TestBorrarNoExiste()
        {
            var repoMock = new Mock<IRepository<Usuario>>(MockBehavior.Strict);
            Usuario_Logic logica = new Usuario_Logic(repoMock.Object);
            repoMock.Setup(x => x.Get(1)).Throws(new EntidadNoExisteExcepcion());
            Assert.Throws<EntidadNoExisteExcepcion>(() => logica.BorrarUsuario(1));
        }
        [Test]
        public void ObtenerPorCredencialesOk()
        {
            var repoMock = new Mock<IRepository<Usuario>>(MockBehavior.Strict);
            Usuario_Logic logica = new Usuario_Logic(repoMock.Object);
            Usuario resultado = new Usuario();
            DatosUsuario datos = new DatosUsuario()
            {
                Apellido = "",
                Nombre = "pepe",
                Mail = "a@b.c",
            };
            Usuario usuario = new Usuario()
            {
                Datos = datos,
                IsAdmin = false,
                Id = 0,
                Contrasenia = "Test",
            };
            repoMock.Setup(x => x.GetAll()).Returns(new List<Usuario>() { usuario});
            resultado = logica.ObtenerPorCredenciales(datos.Mail, usuario.Contrasenia);
            Assert.AreEqual(usuario.Id, resultado.Id);
        }
        [Test]
        [ExpectedException(typeof(StringVacioException))]
        public void ObtenerPorCredencialesMailVacio()
        {
            var repoMock = new Mock<IRepository<Usuario>>(MockBehavior.Strict);
            Usuario_Logic logica = new Usuario_Logic(repoMock.Object);
            string mail = "";
            string contrasenia = "123";
            repoMock.Setup(x => x.GetAll()).Returns(It.IsAny<List<Usuario>>());

            Assert.Throws<StringVacioException>(() => logica.ObtenerPorCredenciales(mail,contrasenia));
        }
        [Test]
        [ExpectedException(typeof(StringVacioException))]
        public void ObtenerPorCredencialesContraseniaVacio()
        {
            var repoMock = new Mock<IRepository<Usuario>>(MockBehavior.Strict);
            Usuario_Logic logica = new Usuario_Logic(repoMock.Object);
            string mail = "a@b.c";
            string contrasenia = " ";
            repoMock.Setup(x => x.GetAll()).Returns(It.IsAny<List<Usuario>>());

            Assert.Throws<StringVacioException>(() => logica.ObtenerPorCredenciales(mail, contrasenia));
        }
        [Test]
        [ExpectedException(typeof(FormatoInvalidoException))]
        public void ObtenerPorCredencialesMailFormatoInvalido()
        {
            var repoMock = new Mock<IRepository<Usuario>>(MockBehavior.Strict);
            Usuario_Logic logica = new Usuario_Logic(repoMock.Object);
            string mail = "asdf";
            string contrasenia = "123";
            repoMock.Setup(x => x.GetAll()).Returns(It.IsAny<List<Usuario>>());

            Assert.Throws<FormatoInvalidoException>(() => logica.ObtenerPorCredenciales(mail, contrasenia));
        }
        [Test]
        [ExpectedException(typeof(EntidadNoExisteExcepcion))]
        public void ObtenerPorCredencialesNoExiste()
        {
            var repoMock = new Mock<IRepository<Usuario>>(MockBehavior.Strict);
            Usuario_Logic logica = new Usuario_Logic(repoMock.Object);
            string mail = "a@b.c";
            string contrasenia = "123";
            Usuario usuario = new Usuario()
            {
                Contrasenia = "123",
                Datos = new DatosUsuario() { Mail = "b@c.a" }
            };
            repoMock.Setup(x => x.GetAll()).Returns(new List<Usuario>() { usuario});
            Assert.Throws<EntidadNoExisteExcepcion>(() => logica.ObtenerPorCredenciales(mail,contrasenia));
        }
    }
}
