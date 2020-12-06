using BuissnesLogic_Interface;
using Domain;
using Domain.Enums;
using Exceptiones;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BuissnesLogic
{
    public class GenerarReporteConcretoA : IGenerarReporte
    {
        IReserva logicaReserva;
        public GenerarReporteConcretoA(IReserva reserva)
        {
            logicaReserva = reserva;
        }
        public List<CantReservasPorHospedaje> GenerarReporte(DatosReporte datos)
        {
            List<CantReservasPorHospedaje> retorno = new List<CantReservasPorHospedaje>();
            var reservas = logicaReserva.ObtenerTodos().Where(x => x.Hospedaje.PuntoTuristico.Id == datos.PuntoId).ToList();
            HayReservas(reservas);
            foreach (Reserva reserva in reservas)
            {
                if (EstaEnFecha(reserva, datos) && EstadoValido(reserva))
                {
                    AumentarContador(retorno, reserva);
                }
            }
            retorno = OrdenarLista(retorno);
            return retorno;
        }

        private static void HayReservas(List<Reserva> reservas)
        {
            if (reservas.Count == 0)
                throw new NoHayReservasException();
        }

        private static bool EstadoValido(Reserva reserva)
        {
            return ((reserva.Estado != EstadoReserva.Rechazada) && (reserva.Estado!=EstadoReserva.Expirada));
        }
        private static bool EstaEnFecha(Reserva reserva,DatosReporte datos)
        {
            return FechaMenorOIgual(reserva.CheckIn,datos.Inicio) && FechaMenorOIgual(datos.Fin, reserva.CheckOut);
        }
        private static bool FechaMenorOIgual(DateTime inicio,DateTime check)
        {
            return ValidadorFecha.FechaMenorOIgual(inicio,check);
        }
        private static void AumentarContador(List<CantReservasPorHospedaje> aux, Reserva reserva)
        {
            CantReservasPorHospedaje cantReservas = new CantReservasPorHospedaje();
            cantReservas.NombreHospedaje = reserva.Hospedaje.NombreHospedaje;
            int index = aux.IndexOf(cantReservas);
            if (index != -1)
            {
                aux[index].CantReservas++;
            }
            else
            {
                cantReservas.CantReservas++;
                aux.Add(cantReservas);
            }
        }
        private static List<CantReservasPorHospedaje> OrdenarLista(List<CantReservasPorHospedaje> aux)
        {
            List<CantReservasPorHospedaje> retorno = aux.OrderBy(x => x.CantReservas).ToList();
            retorno.Reverse();
            return retorno;
        }
    }
}
