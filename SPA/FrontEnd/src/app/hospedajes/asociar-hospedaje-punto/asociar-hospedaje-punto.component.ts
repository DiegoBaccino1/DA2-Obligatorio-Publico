import { Component, OnInit } from '@angular/core';
import { HospedajeService } from '../services/hospedaje-service.service';
import { environment } from '../../../environments/environment';
import { ActivatedRoute, Router } from '@angular/router';
import { Hospedaje } from 'src/app/Models/hospedaje/hospedaje';
import { PuntosService } from 'src/app/puntos/services/puntos.service';

@Component({
  selector: 'app-asociar-hospedaje-punto',
  templateUrl: './asociar-hospedaje-punto.component.html',
  styleUrls: ['./asociar-hospedaje-punto.component.css']
})
export class AsociarHospedajePuntoComponent implements OnInit {
  puntos;
  hospedajeId: number;
  puntoId: number;
  hospedaje: Hospedaje;
  constructor(private service: HospedajeService,
    private currentRoute: ActivatedRoute,
    private router: Router,
    private puntoService: PuntosService) { }

  ngOnInit(): void {
    this.hospedajeId = +this.currentRoute.snapshot.params['id'];
    this.service.obtenerPorId(this.hospedajeId).subscribe(
      (res) => {
        this.hospedaje = res;
      },
      (err) => {
        alert(environment.mensajeDeError);
        console.log(err);
      }
    );

    this.puntoService.getAllPuntos().subscribe(
      (res) => {
        this.puntos = res;
        this.puntoId = this.puntos[0].id;
      },
      (err) => {
        alert(environment.mensajeDeError);
        console.log(err);
      }
    );
  }

  change(puntoId): void {
    this.puntoId = puntoId;
  }

  asociar(): void {
    this.service.asociarPunto(this.puntoId, this.hospedajeId).subscribe(
      (res) => {
        this.ngOnInit();
      },
      (err) => {
        alert(environment.mensajeDeError);
        console.log(err);
      }
    );
  }

}
