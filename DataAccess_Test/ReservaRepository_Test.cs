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
    public class ReservaRepository_Test
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void CrearReservaOk()
        {
            var options = new DbContextOptionsBuilder<ObligatorioContext>()
            .UseInMemoryDatabase(databaseName: "TestDB")
            .Options;

            using (var context = new ObligatorioContext(options))
            {
                var repository = new Repository<Reserva>(context);
                Reserva reserva = new Reserva();
                repository.Create(reserva);
                repository.Save();
                Assert.AreEqual(1, repository.GetAll().Count());
                context.Set<Reserva>().Remove(reserva);
                context.SaveChanges();
            }
        }
        [Test]
        public void BorrarReserva()
        {
            var options = new DbContextOptionsBuilder<ObligatorioContext>()
            .UseInMemoryDatabase(databaseName: "TestDB")
            .Options;

            using (var context = new ObligatorioContext(options))
            {
                var repository = new Repository<Reserva>(context);
                Reserva reserva = new Reserva();
                repository.Create(reserva);
                repository.Save();
                repository.Delete(reserva);
                repository.Save();
                Assert.AreEqual(0, repository.GetAll().Count());
                context.SaveChanges();
            }
        }

        [Test]
        public void ActualizarReservaOk()
        {
            var options = new DbContextOptionsBuilder<ObligatorioContext>()
            .UseInMemoryDatabase(databaseName: "TestDB")
            .Options;

            using (var context = new ObligatorioContext(options))
            {
                var repository = new Repository<Reserva>(context);
                Reserva reserva = new Reserva();
                reserva.NombreTurista = "Test22";
                repository.Create(reserva);
                repository.Save();
                reserva.NombreTurista = "Prueba";
                repository.Update(reserva);
                repository.Save();
                Assert.AreEqual("Prueba", repository.GetAll().First().NombreTurista);
                context.Set<Reserva>().Remove(reserva);
                context.SaveChanges();
            }
        }

        [Test]
        public void GetByIdReservaOk()
        {
            var options = new DbContextOptionsBuilder<ObligatorioContext>()
            .UseInMemoryDatabase(databaseName: "TestDB")
            .Options;

            using (var context = new ObligatorioContext(options))
            {
                var repository = new Repository<Reserva>(context);
                Reserva reserva = new Reserva() { Id=1,NombreTurista="Prueba"};
                repository.Create(reserva);
                repository.Save();
                Assert.AreEqual("Prueba", repository.Get(1).NombreTurista);
                context.Set<Reserva>().Remove(reserva);
                context.SaveChanges();
            }
        }
        [Test]
        public void TestGetAllReservaOk()
        {
            var options = new DbContextOptionsBuilder<ObligatorioContext>()
            .UseInMemoryDatabase(databaseName: "TestDB")
            .Options;

            using (var context = new ObligatorioContext(options))
            {
                var repository = new Repository<Reserva>(context);
                Reserva reserva = new Reserva();

                repository.Create(reserva);
                repository.Save();

                Assert.AreEqual(1, repository.GetAll().Count());
                context.Set<Reserva>().Remove(reserva);
                context.SaveChanges();
            }
        }
    }
}
