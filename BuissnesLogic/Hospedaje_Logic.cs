using System;
using System.Collections.Generic;
using System.Linq;
using BuisnessLogic.Domain;
using BuissnesLogic_Interface;
using DataAccessInterface;
using Domain;
using Exceptiones;

namespace BuissnesLogic
{
    public class Hospedaje_Logic : IHospedaje
    {
        private const int PUNTAJE_INICIAL = 0;
        private readonly IRepository<Hospedaje> repository;
        private readonly IPuntoTuristico logicaPunto;
        public Hospedaje_Logic(IRepository<Hospedaje> repository, IPuntoTuristico logica)
        {
            this.repository = repository;
            this.logicaPunto = logica;
        }

        public void AgregarHospedaje(Hospedaje hospedaje)
        {
                Hospedaje hospedajeABuscar=this.repository.GetAll().Where(x=>x.Id==hospedaje.Id ||
                                            x.NombreHospedaje.Equals(hospedaje.NombreHospedaje)).FirstOrDefault();
                if(hospedajeABuscar!=null)
                    throw new YaExisteLaEntidadExcepcion();

                hospedaje.NombreHospedaje = this.ValidaNombreHospedaje(hospedaje.NombreHospedaje);
                hospedaje.Ocupado = false;
                hospedaje.Puntaje = PUNTAJE_INICIAL;
                repository.Create(hospedaje);
                repository.Save();
        }

        public void BorrarHospedaje(int id)
        {
            Hospedaje hospedaje = this.repository.Get(id);
            repository.Delete(hospedaje);
            repository.Save();
        }

        public List<Hospedaje> ObtenerTodos()
        {
            return repository.GetAll().ToList();
        }

        public Hospedaje ObtenerPorId(int id)
        {
            Hospedaje hospedaje = repository.Get(id);
            return hospedaje;
        }

        public void ActualizarHospedaje(Hospedaje newHospedaje)
        {
            Hospedaje hospedaje = this.repository.Get(newHospedaje.Id);
            hospedaje.NombreHospedaje = newHospedaje.NombreHospedaje;
            hospedaje.Descripcion = newHospedaje.Descripcion;
            hospedaje.Direccion = newHospedaje.Direccion;
            hospedaje.Capacidad = newHospedaje.Capacidad;
            hospedaje.CantidadEstrellas = newHospedaje.CantidadEstrellas;
            hospedaje.Imagenes = newHospedaje.Imagenes;
            hospedaje.PrecioPorNoche = newHospedaje.PrecioPorNoche;
            hospedaje.PrecioTotalPeriodo = newHospedaje.PrecioTotalPeriodo;
            hospedaje.PuntoTuristico = newHospedaje.PuntoTuristico;
            hospedaje.Ocupado = newHospedaje.Ocupado;
            repository.Update(hospedaje);
            repository.Save();
        }

        public string ValidaNombreHospedaje(string nombre)
        {
            nombre = ValidadorString.ValidarStringVacio(nombre);
            return nombre;
        }

        public List<Hospedaje> BuscarHospedajePunto(int puntoId, HospedajeFiltro filtro)
        {
            List<Hospedaje> hospedajes = this.ObtenerHospedajesDePunto(puntoId);
            List<Hospedaje> retorno = new List<Hospedaje>();
            int capacidad = filtro.Huespedes.CapacidadTotal();
            int dias = ObtenerDias(filtro);

            foreach (Hospedaje hospedaje in hospedajes)
            {
                if (TieneCapacidad(capacidad, hospedaje))
                {
                    if (NoOcupado(hospedaje))
                    {
                        hospedaje.PrecioTotalPeriodo = CalcularPrecioTotal
                                                (filtro.Huespedes, hospedaje.PrecioPorNoche, dias);
                                
                        retorno.Add(hospedaje);
                    }
                }
            }
            return retorno;
        }

        private List<Hospedaje> ObtenerHospedajesDePunto(int puntoId)
        {
            List<Hospedaje> retorno = new List<Hospedaje>();
            List<Hospedaje> hospedajes = this.ObtenerTodos();
            foreach(Hospedaje hospedaje in hospedajes)
            {
                if (TienePunto(puntoId, hospedaje))
                    retorno.Add(hospedaje);                   
            }
            return retorno;
        }

        private static int ObtenerDias(HospedajeFiltro filtro)
        {
            DateTime checkIn = filtro.CheckIn;
            DateTime checkOut = filtro.CheckOut;
            if (ValidadorFecha.FechaMenor(checkIn,checkOut))
                return (int)(checkOut - checkIn).TotalDays; 
            else
                throw new RevisarFechaExcepcion();
        }

        private int CalcularPrecioTotal(CantHuespedes cantHuespedes,int precio, int dias)
        {
            int costo = 0;
            ICosto calculador = new CostoAdulto();
            costo = calculador.Costo(dias, precio, cantHuespedes.CantAdultos);
            calculador = new CostoNinio();
            costo += calculador.Costo(dias, precio, cantHuespedes.CantNinios);
            calculador = new CostoBebe();
            costo += calculador.Costo(dias, precio, cantHuespedes.CantBebes);
            calculador = new CostoJubilado();
            costo += calculador.Costo(dias, precio, cantHuespedes.CantJubilados);
            return costo; 
        }

        private static bool NoOcupado(Hospedaje hospedaje)
        {
            return hospedaje.Ocupado == false;
        }

        private static bool TieneCapacidad(int capacidad, Hospedaje hospedaje)
        {
            return hospedaje.Capacidad >= capacidad;
        }

        private static bool TienePunto(int puntoId, Hospedaje hospedaje)
        {
            if (TieneUnPuntoAsociado(hospedaje))
                return puntoId == hospedaje.PuntoTuristico.Id;
            return false;
        }

        private static bool TieneUnPuntoAsociado(Hospedaje hospedaje)
        {
            return hospedaje.PuntoTuristico != null;
        }
        
        public void AgregarPunto(int hospedajeId, int puntoId)
        {
            Hospedaje hospedaje=this.ObtenerPorId(hospedajeId);
            PuntoTuristico punto=this.logicaPunto.ObtenerPuntoId(puntoId);
            hospedaje.PuntoTuristico = punto;
            this.ActualizarHospedaje(hospedaje);
        }

        public void BorrarHospedajeSegunPunto(int puntoId)
        {
            List<Hospedaje> hospedajes = this.ObtenerHospedajesDePunto(puntoId);
            foreach(Hospedaje hospedaje in hospedajes)
            {
                this.BorrarHospedaje(hospedaje.Id);
            }
        }

        public void CambiarCapacidad(int hospedajeId, int nuevaCapacidad)
        {
            Hospedaje hospedaje = this.ObtenerPorId(hospedajeId);
            if (nuevaCapacidad >= 0)
            {
                hospedaje.Capacidad = nuevaCapacidad;
                this.ActualizarHospedaje(hospedaje);
            }
            else
                throw new CapacidadNoValidaExcepcion();
        }

        public double CalcularPromedio(Hospedaje hospedaje)
        {
            double puntajeTotal = 0;
            int cantPuntajes = 0;
            double promedio = 0;
            List<Resenia> resenias = hospedaje.Resenias;
            NoHayResenias(resenias);
            foreach (Resenia resenia in resenias)
            {
                puntajeTotal += (double)resenia.Puntaje;
                cantPuntajes++;
            }
            promedio = puntajeTotal / cantPuntajes;
            promedio=Double.Parse(String.Format("{0:0.0}", promedio));
            return promedio;
        }

        private static void NoHayResenias(List<Resenia> resenias)
        {
            if (resenias.Count == 0)
            {
                throw new NoHayReseniaException();
            }
        }

        public void AgregarResenia(Hospedaje hospedajeNuevo, Resenia resenia)
        {
            Hospedaje hospedaje = this.repository.GetAll().Where(x=>x.Id==hospedajeNuevo.Id).FirstOrDefault();
            hospedaje.Resenias.Add(resenia);
            hospedaje.Puntaje=CalcularPromedio(hospedaje);
            this.repository.Update(hospedaje);
            this.repository.Save();
        }
    }
}
