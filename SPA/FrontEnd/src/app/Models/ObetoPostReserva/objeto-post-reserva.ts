import { DatosUsuario } from '../Datos/DatosUsuario/datos-usuario';
import { HospedajeFiltro } from '../HospedajeFiltro/hospedaje-filtro';
export class ObjetoPostReserva {
    filtro: HospedajeFiltro;
    datos: DatosUsuario;
    hospedajeId: number;

    constructor(Filtro: HospedajeFiltro, Datos: DatosUsuario, HospedajeId: number) {
        this.datos = Datos;
        this.filtro = Filtro;
        this.hospedajeId = HospedajeId;
    }
}
