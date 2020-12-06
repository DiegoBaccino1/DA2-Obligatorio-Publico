using System;
using Domain.Enums;

namespace Domain
{
    public class Reserva
    {
     public int Id { get; set; }
     public string NombreTurista { get; set; }
     public string ApellidoTurista { get; set; }
     public string MailTurista { get; set; }
     public DateTime CheckIn { get; set; }
     public DateTime CheckOut { get; set; }
     public int CantidadHuespedes { get; set; }
     public virtual EstadoReserva Estado { get; set; }
     public virtual Hospedaje Hospedaje { get; set; }
     public string Descripcion { get; set; }
    }
}
