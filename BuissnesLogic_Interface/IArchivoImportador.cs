using Domain;
using System;
using System.Collections.Generic;
using System.Text;

namespace BuissnesLogic_Interface
{
    public interface IArchivoImportador
    {
        List<Hospedaje> ImportarHospedajes(string path);
        string GetName();
    }
}
