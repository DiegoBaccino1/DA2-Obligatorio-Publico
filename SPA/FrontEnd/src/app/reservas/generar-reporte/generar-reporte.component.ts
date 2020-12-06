import { Component, OnInit } from '@angular/core';
import { PuntosService } from 'src/app/puntos/services/puntos.service';
import { ReservaService } from '../Services/reserva.service';
import { DatosReporte } from '../../Models/Datos/DatosReporte/datos-reporte';
import { PuntoTuristico } from '../../Models/Punto/punto';
import { environment } from 'src/environments/environment';
import { Observable } from 'rxjs';

@Component({
  selector: 'app-generar-reporte',
  templateUrl: './generar-reporte.component.html',
  styleUrls: ['./generar-reporte.component.css']
})
export class GenerarReporteComponent implements OnInit {
  reporte;
  puntos;
  puntoId: number;
  inicio: Date;
  fin: Date;
  constructor(private service: ReservaService, private puntoService: PuntosService) { }

  ngOnInit(): void {
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

  generarReporte(): void {
    const datos = new DatosReporte(this.puntoId, this.inicio, this.fin);
    this.service.generarReporte(datos).subscribe(
      (res) => {
        this.reporte = res;
      },
      (err) => {
        alert(environment.mensajeDeError + 'cargando el reporte');
        console.log(err);
      }
    );
  }
}
