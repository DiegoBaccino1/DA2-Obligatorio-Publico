import { Injectable } from '@angular/core';
import { environment } from '../../environments/environment';
import { HttpClient, HttpHeaders, HttpParams } from '@angular/common/http';
import { Observable } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class LoginService {
  uri = `${environment.baseURL}login`;

  constructor(private http: HttpClient) { }

  login(email: string, contrasenia: string): Observable<string> {
    //params null
    /*let myParams = new HttpParams();
    myParams.set('mail', email);
    myParams.set('contrasenia', contrasenia);*/
    const myHeaders = new HttpHeaders();
    myHeaders.append('Accept', 'application/text');

    return this.http.get<string>(`${this.uri}?mail=${email}&contrasenia=${contrasenia}`, { headers: myHeaders, responseType: 'text' as 'json' });
  }
}
