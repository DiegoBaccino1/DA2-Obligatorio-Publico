import { Imagen } from '../Imagen/imagen';
export class HospedajeModel {
    nombreHospedaje: string;
    descripcion: string;
    direccion: string;
    imagenes: Imagen[];
    cantidadEstrellas: number;
    precioPorNoche: number;
    precioTotalPeriodo: number;
    capacidad: number;

    constructor(nombreHospedaje: string, descripcion: string, direccion: string,
        cantidadEstrellas: number, precioPorNoche: number, precioTotalPeriodo: number,
        capacidad: number)
    {
        this.nombreHospedaje = nombreHospedaje;
        this.descripcion = descripcion;
        this.direccion = direccion;
        this.cantidadEstrellas = cantidadEstrellas;
        this.precioPorNoche = precioPorNoche;
        this.precioTotalPeriodo = precioTotalPeriodo;
        this.capacidad = capacidad;
    }
}
