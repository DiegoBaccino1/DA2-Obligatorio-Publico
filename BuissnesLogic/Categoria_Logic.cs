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
    public class Categoria_Logic : ICategoria
    {
        private readonly IRepository<Categoria> repository;
        public Categoria_Logic(IRepository<Categoria> repository)
        {
            this.repository = repository;
        }

        public void ActualizarCategoria(int id, Categoria categoria)
        {
            Categoria nuevaCategoria=this.ObtenerCategoriaId(id);
            nuevaCategoria.Nombre = categoria.Nombre;
            nuevaCategoria.PuntosTuristicosCategoria = categoria.PuntosTuristicosCategoria;
            this.repository.Update(nuevaCategoria);
            this.repository.Save();
        }

        public void AgregarCategoria(Categoria categoria)
        {
            try
            {
                this.ObtenerCategoriaId(categoria.Id);
                throw new YaExisteLaEntidadExcepcion();
            }
            catch (EntidadNoExisteExcepcion)
            {
                this.repository.Create(categoria);
                this.repository.Save();
            }
        }

        public void BorrarCategoriaId(int id)
        {
            Categoria categoriaABorrar = this.ObtenerCategoriaId(id);
            this.repository.Delete(categoriaABorrar);
            this.repository.Save();
        }

        public Categoria Categoria(string nombre)
        {
            Categoria retorno = new Categoria();
            nombre=this.ValidarNombre(nombre);
            retorno.Nombre = nombre;
            return retorno;
        }

        public Categoria ObtenerCategoriaId(int id)
        {
            return this.repository.Get(id);
        }

        public List<Categoria> ObtenerTodas()
        {
            return this.repository.GetAll().ToList();
        }

        public string ValidarNombre(string nombre)
        {
            nombre = ValidadorString.ValidarStringVacio(nombre);
            return nombre;
        }
    }
}
