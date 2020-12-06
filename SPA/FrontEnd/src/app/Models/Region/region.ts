import { PuntoTuristico } from '../Punto/punto';
export class Region {
    nombre: string;
    puntos: PuntoTuristico[];
    id: number;

    constructor(name: string, puntos: PuntoTuristico[], id: number) {
        this.nombre = name;
        this.id = id;
        this.puntos = puntos;
    }
}
