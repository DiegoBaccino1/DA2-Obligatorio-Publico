import { PuntoTuristicoCategoria } from '../PuntoTuristicoCategoria/punto-turistico-categoria';
export class Categoria {
    id: number;
    nombre: string;
    puntosTuristicosCategoria: PuntoTuristicoCategoria[];

    constructor(id: number, nombre: string, puntosCat: PuntoTuristicoCategoria[]) {
        this.id = id;
        this.nombre = nombre;
        this.puntosTuristicosCategoria = puntosCat;
    }
}
