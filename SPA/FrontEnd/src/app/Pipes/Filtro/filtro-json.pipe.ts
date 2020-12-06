import { Pipe, PipeTransform } from '@angular/core';
import { HospedajeFiltro } from '../../Models/HospedajeFiltro/hospedaje-filtro';

@Pipe({
  name: 'filtroJSON'
})

export class FiltroJSONPipe implements PipeTransform {

  transform(filtro: HospedajeFiltro): string {
    const jsonFiltro = `[
      {
        "cantHuespedes: [
          {
            "cantAdultos:" ${filtro.huespedes.cantAdultos},
            "cantNinios:" ${filtro.huespedes.cantNinios},
            "cantBebes:" ${filtro.huespedes.cantBebes},
            "cantJubilados:" ${filtro.huespedes.cantJubilados}
          }]",
        "checkIn:" ${filtro.checkIn.toString()},
        "checkout:" ${filtro.checkOut.toString()}
      }]`;
    return jsonFiltro;
  }

}
