using System;
using System.Collections.Generic;
using Domain;
using Domain.Enums;

namespace BuissnesLogic_Interface
{
    public interface IReserva
    {
     public Reserva Reserva(HospedajeFiltro filtro, int hospedajeId, DatosUsuario datosTurista);
     List<Reserva> ObtenerTodos();
     void AgregarReserva(Reserva reserva);
     void BorrarReserva(int id);
     Reserva ObtenerPorId(int id);
     string ConsultarEstado(int id);
     void ModificarEstado(int id, string descripcion, EstadoReserva nuevoEstado);
    }
}
