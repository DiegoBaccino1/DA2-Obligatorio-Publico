using DataAccess;
using Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Assert = NUnit.Framework.Assert;

namespace DataAccess_Test
{
    public class RegionRepository_Test
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void CrearRegionOk()
        {
            var options = new DbContextOptionsBuilder<ObligatorioContext>()
            .UseInMemoryDatabase(databaseName: "TestDB")
            .Options;

            using (var context = new ObligatorioContext(options))
            {
                var repository = new Repository<Region>(context);
                Region region = new Region()
                {
                    Nombre = "Prueba",
                };
                repository.Create(region);
                repository.Save();
                Assert.AreEqual("Prueba", repository.GetAll().First().Nombre);
                context.Set<Region>().Remove(region);
                context.SaveChanges();
            }
        }
        [Test]
        public void BorrarRegion()
        {
            var options = new DbContextOptionsBuilder<ObligatorioContext>()
            .UseInMemoryDatabase(databaseName: "TestDB")
            .Options;

            using (var context = new ObligatorioContext(options))
            {
                var repository = new Repository<Region>(context);
                Region region = new Region()
                {
                    Nombre = "Prueba",
                };
                repository.Create(region);
                repository.Save();
                repository.Delete(region);
                repository.Save();
                Assert.AreEqual(0, repository.GetAll().Count());
                context.SaveChanges();
            }
        }

        [Test]
        public void ActualizarRegionOk()
        {
            var options = new DbContextOptionsBuilder<ObligatorioContext>()
            .UseInMemoryDatabase(databaseName: "TestDB")
            .Options;

            using (var context = new ObligatorioContext(options))
            {
                var repository = new Repository<Region>(context);
                Region region = new Region()
                {
                    Nombre = "Prueba",
                };
                repository.Create(region);
                repository.Save();
                region.Nombre = "nuevo Nombre";
                repository.Update(region);
                repository.Save();
                Assert.AreEqual("nuevo Nombre", repository.GetAll().First().Nombre);
                context.Set<Region>().Remove(region);
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
                var repository = new Repository<Region>(context);
                Region region = new Region()
                {
                    Id = 1,
                    Nombre = "Prueba",
                };
                repository.Create(region);
                repository.Save();
                Assert.AreEqual("Prueba", repository.Get(1).Nombre);
                context.Set<Region>().Remove(region);
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
                var repository = new Repository<Region>(context);
                Region region = new Region()
                {
                    Nombre = "Prueba",
                };
                Region region2 = new Region()
                {
                    Nombre = "Prueba2",
                };
                repository.Create(region);
                repository.Save();
                repository.Create(region2);
                repository.Save();
                Assert.AreEqual(2, repository.GetAll().Count());
                context.Set<Region>().Remove(region);
                context.SaveChanges();
                context.Set<Region>().Remove(region2);
                context.SaveChanges();
            }
        }
    }
}
