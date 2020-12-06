using BuissnesLogic_Interface;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;

namespace BuissnesLogic
{
    public class DllImportador : IDllImportador
    {
        private IArchivoImportador CrearArchivoImportador(Type tipo)
        {
            IArchivoImportador importador = (IArchivoImportador)Activator.CreateInstance(tipo);
            return importador;
        }

        public List<IArchivoImportador> ObtenerImporters(Assembly assembly)
        {
            List<IArchivoImportador> importadores = new List<IArchivoImportador>();
            IEnumerable<Type> tipos = ObtenerTypesEnAssembly<IArchivoImportador>(assembly);
            foreach (Type tipo in tipos)
            {
                IArchivoImportador importador = CrearArchivoImportador(tipo);
                importadores.Add(importador);
            }
            return importadores;
        }
    }
}
