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
    public class HospedajeRepository_Test
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void CrearHospedajeOk()
        {
            var options = new DbContextOptionsBuilder<ObligatorioContext>()
            .UseInMemoryDatabase(databaseName: "TestDB")
            .Options;

            using (var context = new ObligatorioContext(options))
            {
                var repository = new Repository<Hospedaje>(context);
                Hospedaje hospedaje = new Hospedaje();
                repository.Create(hospedaje);
                repository.Save();
                Assert.AreEqual(1, repository.GetAll().Count());
                context.Set<Hospedaje>().Remove(hospedaje);
                context.SaveChanges();
            }
        }
        [Test]
        public void BorrarHospedaje()
        {
            var options = new DbContextOptionsBuilder<ObligatorioContext>()
            .UseInMemoryDatabase(databaseName: "TestDB")
            .Options;

            using (var context = new ObligatorioContext(options))
            {
                var repository = new Repository<Hospedaje>(context);
                Hospedaje hospedaje = new Hospedaje();
                repository.Create(hospedaje);
                repository.Save();
                repository.Delete(hospedaje);
                repository.Save();
                Assert.AreEqual(0, repository.GetAll().Count());
                context.SaveChanges();
            }
        }

        [Test]
        public void ActualizarHospedajeOk()
        {
            var options = new DbContextOptionsBuilder<ObligatorioContext>()
            .UseInMemoryDatabase(databaseName: "TestDB")
            .Options;

            using (var context = new ObligatorioContext(options))
            {
                var repository = new Repository<Hospedaje>(context);
                Hospedaje hospedaje = new Hospedaje();
                hospedaje.NombreHospedaje = "Prueba";
                repository.Create(hospedaje);
                repository.Save();
                hospedaje.NombreHospedaje = "Prueba";
                repository.Update(hospedaje);
                repository.Save();
                Assert.AreEqual("Prueba", repository.GetAll().First().NombreHospedaje);
                context.Set<Hospedaje>().Remove(hospedaje);
                context.SaveChanges();
            }
        }

        [Test]
        public void GetByIdHospedajeOk()
        {
            var options = new DbContextOptionsBuilder<ObligatorioContext>()
            .UseInMemoryDatabase(databaseName: "TestDB")
            .Options;

            using (var context = new ObligatorioContext(options))
            {
                var repository = new Repository<Hospedaje>(context);
                Hospedaje hospedaje = new Hospedaje() { Id = 1, NombreHospedaje = "Prueba" };
                repository.Create(hospedaje);
                repository.Save();
                Assert.AreEqual("Prueba", repository.Get(1).NombreHospedaje);
                context.Set<Hospedaje>().Remove(hospedaje);
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
                var repository = new Repository<Hospedaje>(context);
                Hospedaje hospedaje = new Hospedaje();

                repository.Create(hospedaje);
                repository.Save();

                Assert.AreEqual(1, repository.GetAll().Count());
                context.Set<Hospedaje>().Remove(hospedaje);
                context.SaveChanges();
            }
        }
    }
}
