import { Component, OnInit } from '@angular/core';
import { Hospedaje } from '../../Models/hospedaje/hospedaje';
import { HospedajeService } from '../services/hospedaje-service.service';
import { Observable, pipe } from 'rxjs';
import { HospedajeFiltro } from 'src/app/Models/HospedajeFiltro/hospedaje-filtro';
import { CantHuespedes } from '../../Models/CantHuespedes/cant-huespedes';
import { environment } from '../../../environments/environment';
import { PuntosService } from '../../puntos/services/puntos.service';
import { Router } from '@angular/router';
import { DataService } from '../../CommonService/data.service';

@Component({
  selector: 'app-filtrar-hospedaje',
  templateUrl: './filtrar-hospedaje.component.html',
  styleUrls: ['./filtrar-hospedaje.component.css']
})
export class FiltrarHospedajeComponent implements OnInit {
  hospedajes;
  puntos;
  fechaMax: string;
  checkIn: Date;
  checkOut: Date;
  cantAdultos: number;
  cantNinios: number;
  cantBebes: number;
  cantJubilados: number;
  puntoId: number;
  filtro: HospedajeFiltro;
  constructor(private services: HospedajeService, private puntoService: PuntosService,
    private router: Router, private dataService: DataService) {
    this.fechaMax = '2100-12-13';
  }

  ngOnInit(): void {
    this.dataService.currentFiltro.subscribe(filtro => this.filtro = filtro);
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

  changePunto(puntoId): void {
    this.puntoId = puntoId;
  }

  buscar(): void {
    const huespedes = new CantHuespedes(this.cantAdultos, this.cantNinios, this.cantBebes, this.cantJubilados);
    this.filtro = new HospedajeFiltro(huespedes, this.checkIn, this.checkOut);
    this.services.filtrar(this.filtro, this.puntoId).subscribe(
      (res) => {
        this.hospedajes = res;
      },
      (err) => {
        alert(environment.mensajeDeError);
        console.log(err);
      }
    );
  }

  reservar(id: number) {
    this.dataService.changeFiltro(this.filtro);
    this.router.navigate(['/new-reserva', id]);
  }
}
