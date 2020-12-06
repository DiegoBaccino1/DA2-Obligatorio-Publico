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
    public class CategoriaRepository_Test
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
                var repository = new Repository<Categoria>(context);
                Categoria cat = new Categoria()
                {
                    Nombre = "Prueba",
                };
                repository.Create(cat);
                repository.Save();
                Assert.AreEqual("Prueba", repository.GetAll().First().Nombre);
                context.Set<Categoria>().Remove(cat);
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
                var repository = new Repository<Categoria>(context);
                Categoria cat = new Categoria()
                {
                    Nombre = "Prueba",
                };
                repository.Create(cat);
                repository.Save();
                repository.Delete(cat);
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
                var repository = new Repository<Categoria>(context);
                Categoria cat = new Categoria()
                {
                    Nombre = "Prueba",
                };
                repository.Create(cat);
                repository.Save();
                cat.Nombre = "nuevo Nombre";
                repository.Update(cat);
                repository.Save();
                Assert.AreEqual("nuevo Nombre", repository.GetAll().First().Nombre);
                context.Set<Categoria>().Remove(cat);
                context.SaveChanges();
            }
        }

        [Test]
        public void GetByIdCategoriaOk()
        {
            var options = new DbContextOptionsBuilder<ObligatorioContext>()
            .UseInMemoryDatabase(databaseName: "TestDB")
            .Options;

            using (var context = new ObligatorioContext(options))
            {
                var repository = new Repository<Categoria>(context);
                Categoria cat = new Categoria()
                {
                    Id = 1,
                    Nombre = "Prueba",
                };
                repository.Create(cat);
                repository.Save();
                Assert.AreEqual("Prueba", repository.Get(1).Nombre);
                context.Set<Categoria>().Remove(cat);
                context.SaveChanges();
            }
        }
        [Test]
        public void TestGetAllCategoriaOk()
        {
            var options = new DbContextOptionsBuilder<ObligatorioContext>()
            .UseInMemoryDatabase(databaseName: "TestDB")
            .Options;

            using (var context = new ObligatorioContext(options))
            {
                var repository = new Repository<Categoria>(context);
                Categoria cat = new Categoria()
                {
                    Nombre = "Prueba",
                };
                Categoria cat2 = new Categoria()
                {
                    Nombre = "Prueba2",
                };
                repository.Create(cat);
                repository.Save();
                repository.Create(cat2);
                repository.Save();
                Assert.AreEqual(2, repository.GetAll().Count());
                context.Set<Categoria>().Remove(cat);
                context.SaveChanges();
                context.Set<Categoria>().Remove(cat2);
                context.SaveChanges();
            }
        }
    }
}
