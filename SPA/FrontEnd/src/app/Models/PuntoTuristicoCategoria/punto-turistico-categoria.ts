import { Categoria } from '../Categoria/categoria';
import { PuntoTuristico } from '../Punto/punto';
export class PuntoTuristicoCategoria {
    puntoTuristicoId: number;
    puntoTuristico: PuntoTuristico;
    categoriaId: number;
    categoria: Categoria;
    constructor(puntoId: number, categoriaId: number, punto: PuntoTuristico, categoria: Categoria) {
        this.categoria = categoria;
        this.categoriaId = categoriaId;
        this.puntoTuristicoId = puntoId;
        this.puntoTuristico = punto;
    }
}
