export class CantHuespedes {
    cantAdultos: number;
    cantNinios: number;
    cantBebes: number;
    cantJubilados: number;

    constructor
        (CantAdultos: number, CantNinios: number,
            CantBebes: number, CantJubilados: number) {
        this.cantAdultos = CantAdultos;
        this.cantNinios = CantNinios;
        this.cantBebes = CantBebes;
        this.cantJubilados = CantJubilados;
    }
}
