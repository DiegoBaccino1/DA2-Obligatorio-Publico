export class CantReservasPorHospedaje {
    nombreHospedaje: string;
    cantReservas: number;

    constructor(nombre: string, reservas: number) {
        this.nombreHospedaje = nombre;
        this.cantReservas = reservas;
    }
}
