using BuisnessLogic.Domain;
using BuissnesLogic_Interface;
using DataAccessInterface;
using Domain;
using Exceptiones;
using System;
using System.Collections.Generic;
using System.Linq;

namespace BuissnesLogic
{
    public class PuntoTuristico_Logic : IPuntoTuristico
    {
        private const int CANT_MAXIMA_DE_CARACTERES = 2000;
        private readonly IRepository<PuntoTuristico> repository;
        private readonly ICategoria logicaCategoria;
        public PuntoTuristico_Logic(IRepository<PuntoTuristico> repository,ICategoria categoria)
        {
            this.repository = repository;
            this.logicaCategoria = categoria;
        }
        
        public string ValidarNombre(string nombre)
        {
            nombre = ValidadorString.ValidarStringVacio(nombre);
            return nombre;
        }
        
        public string ValidarDescripcion(string descripcion)
        {
            if (MasDeMaximoDeCaracteres(descripcion))
                throw new MaxCantDeCaracteresException();
            return descripcion;
        }

        private static bool MasDeMaximoDeCaracteres(string descripcion)
        {
            return descripcion.Length > CANT_MAXIMA_DE_CARACTERES;
        }

        public PuntoTuristico PuntoTuristico(string nombre, string descripcion)
        {
            PuntoTuristico punto = new PuntoTuristico();
            nombre = ValidarNombre(nombre);
            descripcion = ValidarDescripcion(descripcion);
            punto.Descripcion = descripcion;
            punto.Nombre = nombre;
            punto.PuntosTuristicosCategoria = new List<PuntoTuristicoCategoria>();
            punto.Imagen = new Imagen() { Ruta=""};
            return punto;
        }

        public void CargarImagen(PuntoTuristico punto,Imagen imagen)
        {
            punto.Imagen=imagen;
        }

        public PuntoTuristico ObtenerPuntoId(int id)
        {
           return this.repository.Get(id);
        }

        public List<PuntoTuristico> PuntosPorCategoria(List<PuntoTuristico>puntos,int[] idCategorias)
        {
            List<PuntoTuristico> retorno = new List<PuntoTuristico>();
            foreach(PuntoTuristico punto in puntos)
            {
                if (Contiene(punto.PuntosTuristicosCategoria, idCategorias))
                    retorno.Add(punto);
            }
            return retorno;
        }
        
        private static bool Contiene(List<PuntoTuristicoCategoria> puntoTuristicoCategorias, int[] idCategoria)
        {
            foreach(PuntoTuristicoCategoria puntoCat in puntoTuristicoCategorias)
            {
                if (ContieneAux(puntoCat.CategoriaId,idCategoria))
                    return true;
            }
            return false;
        }
        
        private static bool ContieneAux(int puntoCat,int[] idCategoria)
        {
            for(int i = 0; i < idCategoria.Length; i++)
            {
                if (puntoCat == idCategoria[i])
                    return true;
            }
            return false;
        }

        public void AgregarPunto(PuntoTuristico punto)
        {
            try
            {
                this.ObtenerPuntoId(punto.Id);
                throw new YaExisteLaEntidadExcepcion();
            }
            catch (EntidadNoExisteExcepcion)
            {
                this.repository.Create(punto);
                this.repository.Save();
            }
        }

        public List<PuntoTuristico> ObtenerTodos()
        {
            return this.repository.GetAll().ToList();
        }

        public void ActualizarPunto(int id,PuntoTuristico punto)
        {
            PuntoTuristico nuevoPunto=this.ObtenerPuntoId(id);
            nuevoPunto.Nombre=punto.Nombre;
            nuevoPunto.Imagen = punto.Imagen;
            nuevoPunto.Descripcion = punto.Descripcion;
            this.repository.Update(nuevoPunto);
            this.repository.Save();
        }
        public void BorrarPuntoId(int id)
        {
            PuntoTuristico puntoABorrar=this.ObtenerPuntoId(id);
            this.repository.Delete(puntoABorrar);
            this.repository.Save();
        }

        public void AgregarPuntoCategoria(int puntoId, int categoriaId)
        {
            PuntoTuristico punto=this.ObtenerPuntoId(puntoId);
            Categoria categoria = this.logicaCategoria.ObtenerCategoriaId(categoriaId);
            PuntoTuristicoCategoria puntoCategoria = CrearPTC(punto, categoria);
            punto.PuntosTuristicosCategoria.Add(puntoCategoria);
            this.ActualizarPunto(puntoId, punto);
        }
        
        private static PuntoTuristicoCategoria CrearPTC(PuntoTuristico punto,Categoria categoria)
        {
            PuntoTuristicoCategoria puntoCategoria = new PuntoTuristicoCategoria();
            puntoCategoria.Categoria = categoria;
            puntoCategoria.CategoriaId = categoria.Id;
            puntoCategoria.PuntoTuristico = punto;
            puntoCategoria.PuntoTuristicoId = punto.Id;
            return puntoCategoria;
        }

        public List<string> ObtenerNombreCategorias(PuntoTuristico punto)
        {
            List<string>retorno = new List<string>();
            foreach(PuntoTuristicoCategoria ptc in punto.PuntosTuristicosCategoria)
            {
                retorno.Add(ptc.Categoria.Nombre);
            }
            return retorno;
        }
    }
}
