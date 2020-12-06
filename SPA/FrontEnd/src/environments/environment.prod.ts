import { HttpHeaders } from '@angular/common/http';
export const environment = {
  production: true,
  baseURL: 'http://localhost:12000/',
  mensajeDeError: 'Hubo un error',
  myHeaders: new HttpHeaders()
  .set('Content-Type', 'application/json')
  .append('Authorization', localStorage.token)
};
