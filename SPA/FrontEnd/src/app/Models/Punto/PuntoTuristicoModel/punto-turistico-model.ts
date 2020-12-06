import { Imagen } from '../../Imagen/imagen';

export class PuntoTuristicoModel {
    nombre: string;
    descripcion: string;
    imagen: Imagen;
    categorias: string[];

    constructor(name: string, desc: string, imagen: Imagen, categorias: string[]) {
        this.nombre = name;
        this.descripcion = desc;
        this.imagen = imagen;
        this.categorias = categorias;
    }
}
