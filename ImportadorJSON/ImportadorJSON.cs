using BuisnessLogic.Domain;
using BuissnesLogic_Interface;
using Domain;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text.Json.Serialization;

namespace Importador
{
    public class ImportadorJSON : IArchivoImportador
    {
        private string Name = "Importador JSON";
        public List<Hospedaje> ImportarHospedajes(string path)
        {
            List<Hospedaje> hospedajes;
            using (StreamReader reader = new StreamReader(path))
            {
                string json = reader.ReadToEnd();
                hospedajes = DeserializeJson(json);
            }
            return hospedajes;
        }

        public List<Hospedaje> DeserializeJson(string json)
        {
            return JsonConvert.DeserializeObject<List<Hospedaje>>(json);
        }

        public string GetName()
        {
            return Name;
        }
    }
}
