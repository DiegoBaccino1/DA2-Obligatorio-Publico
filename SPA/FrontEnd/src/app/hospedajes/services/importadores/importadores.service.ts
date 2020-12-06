import { Injectable } from '@angular/core';
import { HttpClient} from '@angular/common/http';
import { environment } from 'src/environments/environment';
import { Observable } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class ImportadoresService {
  uri = `${environment.baseURL}importadores`;

  constructor(private http: HttpClient) { }

  getAllImportadores(): Observable<string> {
    return this.http.get<string>(this.uri);
  }
  importar(importador: string, path: string) {
    return this.http.get(`${this.uri}/${importador}?path=${path}`);
  }
}
