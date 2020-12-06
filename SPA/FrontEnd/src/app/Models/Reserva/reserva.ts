import { Hospedaje } from '../hospedaje/hospedaje';
import { EstadoReserva } from '../EstadoReserva/estado-reserva.enum';
export class Reserva {
    id: number;
    nombreTurista: string;
    apellidoTurista: string;
    mailTurista: string;
    checkIn: Date;
    checkOut: Date;
    cantidadHuespedes: number;
    estado: EstadoReserva;
    hospedaje: Hospedaje;
    descripcion: string;
    constructor(id: number, desc: string, hospedaje: Hospedaje, estado: EstadoReserva,
        mailTurista: string, apellidoTurista: string, nombreTurista: string) {
            
        this.id = id;
        this.descripcion = desc;
        this.hospedaje = hospedaje;
        this.estado = estado;
        this.mailTurista = mailTurista;
        this.nombreTurista = nombreTurista;
        this.apellidoTurista = apellidoTurista;
    }
}