using DataAccess;
using Domain;
using Microsoft.EntityFrameworkCore;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DataAccess_Test
{
    class UsuarioRepository_Test
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void CrearCategoriaOk()
        {
            var options = new DbContextOptionsBuilder<ObligatorioContext>()
            .UseInMemoryDatabase(databaseName: "TestDB")
            .Options;

            using (var context = new ObligatorioContext(options))
            {
                var repository = new Repository<Usuario>(context);
                Usuario usuario = new Usuario()
                {
                    Contrasenia = "Prueba",
                };
                repository.Create(usuario);
                repository.Save();
                Assert.AreEqual("Prueba", repository.GetAll().First().Contrasenia);
                context.Set<Usuario>().Remove(usuario);
                context.SaveChanges();
            }
        }
        [Test]
        public void BorrarCategoria()
        {
            var options = new DbContextOptionsBuilder<ObligatorioContext>()
            .UseInMemoryDatabase(databaseName: "TestDB")
            .Options;

            using (var context = new ObligatorioContext(options))
            {
                var repository = new Repository<Usuario>(context);
                Usuario usuario = new Usuario()
                {
                    Contrasenia = "Prueba",
                };
                repository.Create(usuario);
                repository.Save();
                repository.Delete(usuario);
                repository.Save();
                Assert.AreEqual(0, repository.GetAll().Count());
                context.SaveChanges();
            }
        }

        [Test]
        public void ActualizarCategoriaOk()
        {
            var options = new DbContextOptionsBuilder<ObligatorioContext>()
            .UseInMemoryDatabase(databaseName: "TestDB")
            .Options;

            using (var context = new ObligatorioContext(options))
            {
                var repository = new Repository<Usuario>(context);
                Usuario usuario = new Usuario()
                {
                    Contrasenia = "Prueba",
                };
                repository.Create(usuario);
                repository.Save();
                usuario.Contrasenia = "nueva contrasenia";
                repository.Update(usuario);
                repository.Save();
                Assert.AreEqual("nueva contrasenia", repository.GetAll().First().Contrasenia);
                context.Set<Usuario>().Remove(usuario);
                context.SaveChanges();
            }
        }

        [Test]
        public void GetByIdUsuarioOk()
        {
            var options = new DbContextOptionsBuilder<ObligatorioContext>()
            .UseInMemoryDatabase(databaseName: "TestDB")
            .Options;

            using (var context = new ObligatorioContext(options))
            {
                var repository = new Repository<Usuario>(context);
                Usuario usuario = new Usuario()
                {
                    Id = 1,
                    Contrasenia = "Prueba",
                };
                repository.Create(usuario);
                repository.Save();
                Assert.AreEqual("Prueba", repository.Get(usuario.Id).Contrasenia);
                context.Set<Usuario>().Remove(usuario);
                context.SaveChanges();
            }
        }
        [Test]
        public void TestGetAllUsuarioOk()
        {
            var options = new DbContextOptionsBuilder<ObligatorioContext>()
            .UseInMemoryDatabase(databaseName: "TestDB")
            .Options;

            using (var context = new ObligatorioContext(options))
            {
                var repository = new Repository<Usuario>(context);
                Usuario usuario = new Usuario()
                {
                    Contrasenia = "Prueba",
                };
                Usuario usuario2 = new Usuario()
                {
                    Contrasenia = "Prueba2",
                };
                repository.Create(usuario);
                repository.Save();
                repository.Create(usuario2);
                repository.Save();
                Assert.AreEqual(2, repository.GetAll().Count());
                context.Set<Usuario>().Remove(usuario);
                context.SaveChanges();
                context.Set<Usuario>().Remove(usuario2);
                context.SaveChanges();
            }
        }
    }
}
