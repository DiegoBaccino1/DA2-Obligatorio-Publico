import { PuntoTuristicoCategoria } from '../PuntoTuristicoCategoria/punto-turistico-categoria';
import { Imagen } from '../Imagen/imagen';
export class PuntoTuristico {
    nombre: string;
    descripcion: string;
    puntosTuristicosCategoria: PuntoTuristicoCategoria[];
    id: number;
    imagen: Imagen;

    constructor(name: string, desc: string, id: number, puntosCat: PuntoTuristicoCategoria[], imagen: Imagen) {
        this.nombre = name;
        this.descripcion = desc;
        this.id = id;
        this.imagen = imagen;
        this.puntosTuristicosCategoria = puntosCat;
    }
}
