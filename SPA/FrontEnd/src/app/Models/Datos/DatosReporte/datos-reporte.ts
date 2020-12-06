export class DatosReporte {
    PuntoId: number;
    Inicio: Date;
    Fin: Date;

    constructor(PuntoId: number, Inicio: Date, Fin: Date) {
        this.PuntoId = PuntoId;
        this.Inicio = Inicio;
        this.Fin = Fin;
    }
}
