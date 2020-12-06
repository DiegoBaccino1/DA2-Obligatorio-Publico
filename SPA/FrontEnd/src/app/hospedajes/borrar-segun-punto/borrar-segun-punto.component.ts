import { Component, OnInit } from '@angular/core';
import { PuntoTuristico } from '../../Models/Punto/punto';
import { PuntosService } from '../../puntos/services/puntos.service';
import { HospedajeService } from '../services/hospedaje-service.service';
import { Router } from '@angular/router';
import { environment } from '../../../environments/environment';

@Component({
  selector: 'app-borrar-segun-punto',
  templateUrl: './borrar-segun-punto.component.html',
  styleUrls: ['./borrar-segun-punto.component.css']
})
export class BorrarSegunPuntoComponent implements OnInit {
  puntos;
  puntoId: number;
  constructor(private services: PuntosService, private hospedajeService: HospedajeService, private router: Router) {

  }

  ngOnInit(): void {
    this.services.getAllPuntos().subscribe(
      (res) => {
        this.puntos = res;
        this.puntoId = this.puntos[0].id;
      },
      (err) => {
        alert('Hubo un error');
        console.log(err);
      }
    );
  }

  borrarSegunPuntos(): void {
    this.hospedajeService.borrarPorPunto(this.puntoId).subscribe(
      (res) => {
        this.router.navigate(['/hospedajes']);
      },
      (err) => {
        alert(environment.mensajeDeError);
        console.log(err);
      }
    );
  }
  
  changePunto(puntoId): void {
    this.puntoId = puntoId;
  }
}
