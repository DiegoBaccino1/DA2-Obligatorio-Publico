import { PuntoTuristico } from '../Punto/punto';
import { Imagen } from '../Imagen/imagen';
import { Resenia } from '../Resenia/resenia';
export class Hospedaje {
    id: number;
    nombreHospedaje: string;
    punto: PuntoTuristico;
    cantidadEstrellas: number;
    direccion: string;
    imagenes: Imagen[];
    precioPorNoche: number;
    precioTotalPeriodo: number;
    descripcion: string;
    ocupado: boolean;
    capacidad: number;
    resenias: Resenia[];
    puntaje: number;

    constructor(id: number, punto: PuntoTuristico, nombre: string, direccion: string,
        cantidadEstrellas: number, ocupado: boolean, resenias: Resenia[],
        imagenes: Imagen[], precioPorNoche: number, precioTotalPeriodo: number, descripcion: string,
        capacidad: number, puntaje: number)
        {
            this.precioTotalPeriodo = precioTotalPeriodo;
            this.descripcion = descripcion;
            this.capacidad = capacidad;
            this.puntaje = puntaje;
            this.imagenes = imagenes;
            this.cantidadEstrellas = cantidadEstrellas;
            this.punto = punto;
            this.direccion = direccion;
            this.precioPorNoche = precioPorNoche;
            this.resenias = resenias;
            this.nombreHospedaje = nombre;
            this.ocupado = ocupado;
            this.id = id;
        }
}
