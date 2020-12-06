import { Injectable } from '@angular/core';
import { environment } from 'src/environments/environment';
import { Hospedaje } from '../../Models/hospedaje/hospedaje';
import { HttpClient, HttpParams } from '@angular/common/http';
import { Observable, pipe } from 'rxjs';
import { HospedajeModel } from '../../Models/hospedaje/hospedaje-model';
import { HospedajeFiltro } from '../../Models/HospedajeFiltro/hospedaje-filtro';
import { JsonPipe } from '@angular/common';
import { FiltroJSONPipe } from '../../Pipes/Filtro/filtro-json.pipe';

@Injectable({
  providedIn: 'root'
})

export class HospedajeService {
  uri = `${environment.baseURL}hospedajes`;
  constructor(private http: HttpClient) {
  }

  getAllHospedaje(): Observable<Hospedaje> {
    return this.http.get<Hospedaje>(this.uri);
  }
  obtenerPorId(id: number): Observable<Hospedaje> {
    return this.http.get<Hospedaje>(`${this.uri}/${id}`);
  }
  borrar(id: number) {
    return this.http.delete<Hospedaje>(`${this.uri}/${id}`, { headers: environment.myheader });
  }
  borrarPorPunto(id: number) {
    return this.http.delete<Hospedaje>(`${this.uri}/puntos/${id}`, { headers: environment.myheader });
  }
  crear(modelo: HospedajeModel) {
    return this.http.post<Hospedaje>(this.uri, modelo, { headers: environment.myheader });
  }
  modificar(id: number, modelo: HospedajeModel) {
    return this.http.put(`${this.uri}/${id}`, modelo, { headers: environment.myheader });
  }
  cambiarCapacidad(id: number, nuevaCapacidad: number) {
    return this.http.put(`${this.uri}/${id}/capacidad?nuevaCapacidad=${nuevaCapacidad}`, null, { headers: environment.myheader });
  }
  asociarPunto(puntoId: number, hospedajeId: number) {
    return this.http.put<Hospedaje>(`${this.uri}/${hospedajeId}/puntos/${puntoId}`, null,
      { headers: environment.myheader });
  }
  filtrar(filtro: HospedajeFiltro, puntoId: number) {
    return this.http.post<Hospedaje>(`${this.uri}/puntos/${puntoId}`, filtro);
  }
}
