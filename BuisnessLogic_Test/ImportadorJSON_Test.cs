using BuissnesLogic;
using BuissnesLogic_Interface;
using Domain;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;

namespace BuisnessLogic_Test
{
    class ImportadorJSON_Test
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void TestImportarJSON_OK()
        {
            List<Hospedaje> list = new List<Hospedaje>();
            DllImportador dllImporter = new DllImportador();
            string path = "C:\\Users\\diego\\Desktop\\Obligatorio_DA2\\ImportadorJSON\\bin\\Debug\\netcoreapp3.1\\Importador.dll";
            Assembly assembly = dllImporter.CargarAssembly(path);
            List<IArchivoImportador> importadores = dllImporter.ObtenerImporters(assembly);
            IArchivoImportador importador = importadores.FirstOrDefault();
            string pathJSON = "C:\\Users\\diego\\Desktop\\Tests\\Importer\\Test.Json";
            list = importador.ImportarHospedajes(pathJSON);
            Assert.AreEqual(2, list.Count);
        }
    }
}
