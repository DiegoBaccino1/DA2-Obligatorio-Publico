import { Injectable } from '@angular/core';
import { Region } from '../../Models/Region/region';
import { PuntoTuristico } from '../../Models/Punto/punto';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { environment } from '../../../environments/environment';
import { Observable } from 'rxjs';
import { RegionModel } from '../../Models/Region/RegionModel/region-model';

@Injectable({
  providedIn: 'root'
})
export class RegionService {
  uri = `${environment.baseURL}regiones`;
  constructor(private http: HttpClient) {
  }
  getAllRegiones(): Observable<Region> {
    return this.http.get<Region>(this.uri);
  }
  crear(nombre: string): Observable<Region> {
    let region = new Region(nombre, null, 0);
    return this.http.post<Region>(this.uri, region);
  }
  borrar(id: number) {
    return this.http.delete<Region>(`${this.uri}/${id}`);
  }
  modificar(id: number, name: string) {
    let regionModel = new RegionModel(name, null);
    return this.http.put<Region>(`${this.uri}/${id}`, regionModel);
  }
  asociar(regionId: number, puntoId: number) {
    return this.http.put<Region>(`${this.uri}/${regionId}/puntos/${puntoId}`, null,
    { headers: environment.myheader });
  }
  obtenerPorId(id: number): Observable<Region> {
    return this.http.get<Region>(`${this.uri}/${id}`);
  }
}
