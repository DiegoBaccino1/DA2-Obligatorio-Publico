import { CantHuespedes } from '../CantHuespedes/cant-huespedes';
export class HospedajeFiltro {
    checkIn: Date;
    checkOut: Date;
    huespedes: CantHuespedes;

    constructor(huespedes: CantHuespedes, checkIn: Date, checkOut: Date) {
        this.checkIn = checkIn;
        this.checkOut = checkOut;
        this.huespedes = huespedes;
    }
}
