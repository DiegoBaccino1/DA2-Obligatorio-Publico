import { DatosUsuario } from '../Datos/DatosUsuario/datos-usuario';
export class Resenia {
    id: number;
    puntaje: number;
    texto: string;
    datos: DatosUsuario;

    constructor(id: number, puntaje: number, texto: string, datos: DatosUsuario) {
        this.id = id;
        this.puntaje = puntaje;
        this.texto = texto;
        this.datos = datos;
    }
}
