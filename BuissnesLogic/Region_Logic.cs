using BuisnessLogic.Domain;
using BuissnesLogic_Interface;
using DataAccessInterface;
using Domain;
using Exceptiones;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BuissnesLogic
{
    public class Region_Logic : IRegion
    {
        private readonly IRepository<Region> repository;
        private readonly IPuntoTuristico logicaPunto;
        private static string[] _nombres = {"ESTE","METROPOLITANA","CENTRO SUR",
                                "LITORAL NORTE","CORREDOR PAJAROS PINTADOS"};
        public Region_Logic(IRepository<Region> repository,IPuntoTuristico logica)
        {
            this.repository = repository;
            this.logicaPunto = logica;
        }
        
        public string ValidarNombre(string nombre)
        {
            nombre = ValidadorString.ValidarStringVacio(nombre);
            if (NombreNoValido(nombre))
                throw new NombreNoValidoException();
            return nombre;
        }

        private static bool NombreNoValido(string nombre)
        {
            string nombreAux = nombre.ToUpper();
            return !(_nombres.Any(s => s.Contains(nombreAux)));
        }

        public Region Region(string nombre)
        {
            Region retorno = new Region();
            nombre=ValidarNombre(nombre);
            retorno.Nombre = nombre;
            retorno.Puntos = new List<PuntoTuristico>();
            return retorno;
        }

        public void AgregarRegion(Region region)
        {
            try
            {
                this.ObtenerRegionId(region.Id);
                throw new YaExisteLaEntidadExcepcion();
            }
            catch (EntidadNoExisteExcepcion)
            {
                repository.Create(region);
                repository.Save();
            }
        }

        public List<Region> ObtenerTodas()
        {
            return repository.GetAll().ToList();
        }

        public void AgregarPunto(int regionId,int puntoId)
        {
            Region region = this.ObtenerRegionId(regionId);
            PuntoTuristico punto = this.logicaPunto.ObtenerPuntoId(puntoId);
            region.Puntos.Add(punto);
            this.repository.Update(region);
            this.repository.Save();
        }

        public Region ObtenerRegionId(int id)
        {
            return this.repository.Get(id);
        }

        public List<PuntoTuristico> ObtenerPuntosTuristicos(int regionId)
        {
            return this.ObtenerRegionId(regionId).Puntos;
        }

        public void ActualizarRegion(Region region)
        {
            this.repository.Update(region);
            this.repository.Save();
        }

        public void BorrarRegionId(int id)
        {
            Region region = this.ObtenerRegionId(id);
            this.repository.Delete(region);
            this.repository.Save();
        }
    }
}
