import { Injectable } from '@angular/core';
import { BehaviorSubject } from 'rxjs/internal/BehaviorSubject';
import { CantHuespedes } from '../Models/CantHuespedes/cant-huespedes';
import { HospedajeFiltro } from '../Models/HospedajeFiltro/hospedaje-filtro';


@Injectable({
  providedIn: 'root'
})
export class DataService {
  defaultFiltro = new HospedajeFiltro(new CantHuespedes(0, 0, 0, 0), new Date(), new Date());

  private filtroSource = new BehaviorSubject(this.defaultFiltro);
  currentFiltro = this.filtroSource.asObservable();

  constructor() { }

  changeFiltro(filtro: HospedajeFiltro) {
    this.filtroSource.next(filtro);
  }
}
