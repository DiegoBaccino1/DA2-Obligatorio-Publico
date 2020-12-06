import { PuntoTuristico } from '../../Punto/punto';
export class RegionModel {
    nombre: string;
    puntos: PuntoTuristico[];

    constructor(nombre: string, nuevosPuntos: PuntoTuristico[]) {
        this.nombre = nombre;
        this.puntos = nuevosPuntos;
    }
}
