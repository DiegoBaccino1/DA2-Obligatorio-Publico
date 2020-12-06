using System;
using System.Collections.Generic;
using System.IO;
using System.Reflection;
using System.Text;

namespace BuissnesLogic_Interface
{
    public abstract class IDllImportador
    {
        public Assembly CargarAssembly(string path)
        {
            var dll = new FileInfo(path);
            return Assembly.LoadFile(dll.FullName);
        }

        public virtual IEnumerable<Type> ObtenerTypesEnAssembly<Interface>(Assembly assembly)
        {
            List<Type> types = new List<Type>();
            foreach (var type in assembly.GetTypes())
            {
                if (typeof(Interface).IsAssignableFrom(type))
                    types.Add(type);
            }
            return types;
        }
    }
}
