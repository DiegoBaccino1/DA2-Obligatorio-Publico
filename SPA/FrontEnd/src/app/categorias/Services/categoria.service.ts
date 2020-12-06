import { Injectable } from '@angular/core';
import { Categoria } from '../../Models/Categoria/categoria';
import { environment } from '../../../environments/environment';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { CategoriaModel } from '../../Models/Categoria/CategoriaModel/categoria-model';

@Injectable({
  providedIn: 'root'
})
export class CategoriaService {

  categorias: Categoria[] = new Array();
  uri = `${environment.baseURL}categorias`;
  constructor(private http: HttpClient) {
  }

  getAllCategorias(): Observable<Categoria> {
    return this.http.get<Categoria>(this.uri);
  }
  obtenerPorId(id: number): Observable<Categoria> {
    return this.http.get<Categoria>(`${this.uri}/${id}`);
  }
  crear(nombre: string): Observable<Categoria> {
    let catModel = new CategoriaModel(nombre);
    return this.http.post<Categoria>(this.uri, catModel);
  }
  borrar(id: number) {
    let deleteURI = `${this.uri}/${id}`;
    return this.http.delete<Categoria>(deleteURI);
  }
}
