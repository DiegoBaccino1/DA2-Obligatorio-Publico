using BuisnessLogic.Domain;
using DataAccess;
using Microsoft.EntityFrameworkCore;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using NUnit.Framework;
using System.Collections.Generic;
using System.Linq;
using Assert = NUnit.Framework.Assert;

namespace DataAccess_Test
{
    public class PuntoTuristicoRepository_Test
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void CrearPuntoTuristicoOk()
        {
            var options = new DbContextOptionsBuilder<ObligatorioContext>()
            .UseInMemoryDatabase(databaseName: "TestDB")
            .Options;

            using (var context = new ObligatorioContext(options))
            {
                var repository = new Repository<PuntoTuristico>(context);
                PuntoTuristico punto = new PuntoTuristico()
                {
                    Nombre = "Prueba",
                    Descripcion = "Prueba",
                };
                repository.Create(punto);
                repository.Save();
                Assert.AreEqual("Prueba", repository.GetAll().First().Nombre);
                context.Set<PuntoTuristico>().Remove(punto);
                context.SaveChanges();
            }
        }
        [Test]
        public void BorrarPuntoTuristico()
        {
            var options = new DbContextOptionsBuilder<ObligatorioContext>()
            .UseInMemoryDatabase(databaseName: "TestDB")
            .Options;

            using (var context = new ObligatorioContext(options))
            {
                var repository = new Repository<PuntoTuristico>(context);
                PuntoTuristico punto = new PuntoTuristico()
                {
                    Nombre = "Prueba",
                    Descripcion = "Prueba",
                };
                repository.Create(punto);
                repository.Save();
                repository.Delete(punto);
                repository.Save();
                Assert.AreEqual(0, repository.GetAll().Count());
                context.SaveChanges();
            }
        }
        
        [Test]
        public void ActualizarPuntoTuristicoOk()
        {
            var options = new DbContextOptionsBuilder<ObligatorioContext>()
            .UseInMemoryDatabase(databaseName: "TestDB")
            .Options;

            using (var context = new ObligatorioContext(options))
            {
                var repository = new Repository<PuntoTuristico>(context);
                PuntoTuristico punto = new PuntoTuristico()
                {
                    Nombre = "Prueba",
                    Descripcion = "Prueba",
                };
                repository.Create(punto);
                repository.Save();
                punto.Nombre = "nuevo Nombre";
                repository.Update(punto);
                repository.Save();
                Assert.AreEqual("nuevo Nombre", repository.GetAll().First().Nombre);
                context.Set<PuntoTuristico>().Remove(punto);
                context.SaveChanges();
            }
        }

        [Test]
        public void GetByIdPuntoTuristicoOk()
        {
            var options = new DbContextOptionsBuilder<ObligatorioContext>()
            .UseInMemoryDatabase(databaseName: "TestDB")
            .Options;

            using (var context = new ObligatorioContext(options))
            {
                var repository = new Repository<PuntoTuristico>(context);
                PuntoTuristico punto = new PuntoTuristico()
                {
                    Id = 1,
                    Nombre = "Prueba",
                    Descripcion = "Prueba",
                };
                repository.Create(punto);
                repository.Save();
                Assert.AreEqual("Prueba", repository.Get(1).Nombre);
                context.Set<PuntoTuristico>().Remove(punto);
                context.SaveChanges();
            }
        }
        [Test]
        public void TestGetAllPuntoTuristicoOk()
        {
            var options = new DbContextOptionsBuilder<ObligatorioContext>()
            .UseInMemoryDatabase(databaseName: "TestDB")
            .Options;

            using (var context = new ObligatorioContext(options))
            {
                var repository = new Repository<PuntoTuristico>(context);
                PuntoTuristico punto = new PuntoTuristico()
                {
                    Nombre = "Prueba",
                    Descripcion = "Prueba",
                };
                PuntoTuristico punto2 = new PuntoTuristico()
                {
                    Nombre = "Prueba2",
                    Descripcion = "Prueba2",
                };
                repository.Create(punto);
                repository.Save();
                repository.Create(punto2);
                repository.Save();
                Assert.AreEqual(2, repository.GetAll().Count());
                context.Set<PuntoTuristico>().Remove(punto);
                context.SaveChanges();
                context.Set<PuntoTuristico>().Remove(punto2);
                context.SaveChanges();
            }
        }
    }
}