import { Injectable } from '@angular/core';
import { EstadoReserva } from 'src/app/Models/EstadoReserva/estado-reserva.enum';
import { Hospedaje } from 'src/app/Models/hospedaje/hospedaje';
import { environment } from 'src/environments/environment';
import { Reserva } from '../../Models/Reserva/reserva';
import { Observable } from 'rxjs';
import { HttpClient, HttpRequest, HttpHeaders } from '@angular/common/http';
import { ObjetoPostReserva } from '../../Models/ObetoPostReserva/objeto-post-reserva';
import { CantReservasPorHospedaje } from '../../Models/CantReservasPorHospedaje/cant-reservas-por-hospedaje';
import { Resenia } from '../../Models/Resenia/resenia';
import { DatosReporte } from '../../Models/Datos/DatosReporte/datos-reporte';
import { JsonPipe } from '@angular/common';

@Injectable({
  providedIn: 'root'
})
export class ReservaService {
  uri = `${environment.baseURL}reservas`;
  constructor(private http: HttpClient, private jsonPipe: JsonPipe) {
  }
  getAllReservas(): Observable<Reserva> {
    return this.http.get<Reserva>(this.uri);
  }
  obtenerPorId(id: number): Observable<Reserva> {
    return this.http.get<Reserva>(`${this.uri}/${id}`);
  }
  borrar(id: number) {
    return this.http.delete<Reserva>(`${this.uri}/${id}`);
  }
  agregarResenia(id: number, resenia: Resenia) {
    return this.http.put<Reserva>(`${this.uri}/${id}/resenia`, resenia);
  }
  cambiarEstado(id: number, nevoEstado: EstadoReserva, nuevaDescripcion: string) {
    return this.http.put<Reserva>(`${this.uri}/${id}?descripcion=${nuevaDescripcion}&estado=${nevoEstado}`,
      null, { headers: environment.myheader });
  }
  crear(objetoPostReserva: ObjetoPostReserva) {
    return this.http.post<Reserva>(this.uri, objetoPostReserva);
  }
  generarReporte(datos: DatosReporte) {
    /*const myheader = new HttpHeaders({ 'Content-Type': 'application/json' });
    const json = this.jsonPipe.transform(datos);
    const req = new HttpRequest('GET', `${this.uri}/reporte`, { body: datos }, { headers: myheader, responseType: 'json' });
    return this.http.request<CantReservasPorHospedaje>(req);*/
    return this.http.post<CantReservasPorHospedaje>(`${this.uri}/reporte`, datos);
  }
}
