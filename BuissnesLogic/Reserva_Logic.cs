using BuissnesLogic_Interface;
using DataAccessInterface;
using Domain;
using Domain.Enums;
using Exceptiones;
using System;
using System.Collections.Generic;
using System.Linq;

namespace BuissnesLogic
{
    public class Reserva_Logic:IReserva
    {
        private readonly IRepository<Reserva> repository;
        private readonly IHospedaje logicaHospedaje;
        public Reserva_Logic(IRepository<Reserva> repo,IHospedaje logicaHospedaje)
        {
            repository = repo;
            this.logicaHospedaje = logicaHospedaje;
        }

        private void ActualizarReserva(Reserva reserva)
        {
            this.repository.Update(reserva);
            this.repository.Save();
        }

        public Reserva Reserva(HospedajeFiltro filtro, int hospedajeId,DatosUsuario datosTurista)
        {
            Reserva retorno = new Reserva();
            CargarDatosFiltro(filtro, retorno);
            CargarDatosTurista(datosTurista, retorno);
            SetearEstadoYDescripcion(retorno);
            SetearHospedaje(hospedajeId, retorno);
            return retorno;
        }

        private void SetearHospedaje(int hospedajeId, Reserva retorno)
        {
            Hospedaje hospedaje = this.logicaHospedaje.ObtenerPorId(hospedajeId);
            hospedaje.Ocupado = true;
            logicaHospedaje.ActualizarHospedaje(hospedaje);
            retorno.Hospedaje = hospedaje;
        }

        private static void SetearEstadoYDescripcion(Reserva retorno)
        {
            retorno.Estado = EstadoReserva.Creada;
            retorno.Descripcion = "Creada";
        }

        private static void CargarDatosTurista(DatosUsuario datosTurista, Reserva retorno)
        {
            retorno.ApellidoTurista = datosTurista.Apellido;
            retorno.MailTurista = datosTurista.Mail;
            retorno.NombreTurista = datosTurista.Nombre;
        }

        private static void CargarDatosFiltro(HospedajeFiltro filtro, Reserva retorno)
        {
            int cantidadHuespedes = filtro.Huespedes.CapacidadTotal();
            retorno.CantidadHuespedes = cantidadHuespedes;
            retorno.CheckIn = filtro.CheckIn;
            retorno.CheckOut = filtro.CheckOut;
        }

        public void AgregarReserva(Reserva reserva)
        {
            try
            {
                this.ObtenerPorId(reserva.Id);
                throw new YaExisteLaEntidadExcepcion();
            }catch (EntidadNoExisteExcepcion)
            {
                this.repository.Create(reserva);
                this.repository.Save();
            }
        }

        public void BorrarReserva(int id)
        {
            Reserva reserva=this.ObtenerPorId(id);
            this.repository.Delete(reserva);
            this.repository.Save();
        }

        public string ConsultarEstado(int id)
        {
            Reserva reserva=this.ObtenerPorId(id);
            string estado = reserva.Estado.ToString();
            string desc = reserva.Descripcion;
            return estado + " " + desc;
        }

        public void ModificarEstado(int id, string descripcion, EstadoReserva nuevoEstado)
        {
            Reserva reserva=this.ObtenerPorId(id);
            reserva.Descripcion = descripcion;
            reserva.Estado = nuevoEstado;
            this.ActualizarReserva(reserva);
        }

        public Reserva ObtenerPorId(int id)
        {
            return this.repository.Get(id);
        }

        public List<Reserva> ObtenerTodos()
        {
            return this.repository.GetAll().ToList();
        }
    }
}
