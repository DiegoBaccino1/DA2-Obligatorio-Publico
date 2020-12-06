import { Injectable } from '@angular/core';
import { PuntoTuristico } from '../../Models/Punto/punto';
import { Observable } from 'rxjs';
import { HttpClient, HttpParams } from '@angular/common/http';
import { environment } from '../../../environments/environment';
import { PuntoTuristicoModel } from '../../Models/Punto/PuntoTuristicoModel/punto-turistico-model';
import { Categoria } from 'src/app/Models/Categoria/categoria';

@Injectable({
  providedIn: 'root'
})
export class PuntosService {
  uri = `${environment.baseURL}puntos`;
  constructor(private http: HttpClient) {
  }

  getAllPuntos(): Observable<PuntoTuristico> {
    return this.http.get<PuntoTuristico>(this.uri);
  }

  borrar(id: number) {
    return this.http.delete<PuntoTuristico>(`${this.uri}/${id}`);
  }

  crear(nombre: string, desc: string) {
    let puntoModel = new PuntoTuristicoModel(nombre, desc, null, null);
    return this.http.post<PuntoTuristico>(this.uri, puntoModel);
  }

  obtenerPorId(id: number): Observable<PuntoTuristico> {
    return this.http.get<PuntoTuristico>(`${this.uri}/${id}`);
  }

  filtrar(regionId: number, categoriasId: number[]): Observable<PuntoTuristico> {
    let ids = 'Id= ' + categoriasId[0].toString();
    for (let index = 1; index < categoriasId.length; index++) {
      ids += '&Id= ' + categoriasId[index].toString();
    }
    return this.http.get<PuntoTuristico>(`${this.uri}/filtro?regionId=${regionId}&${ids}`);
  }
  agregarCategoria(puntoId: number, categoriaId: number) {
    return this.http.put<Categoria>(`${this.uri}/${puntoId}/categorias/${categoriaId}`, null);
  }
  modificar(punto: PuntoTuristico) {
    return this.http.put<PuntoTuristico>(`${this.uri}/${punto.id}`, punto);
  }
}
