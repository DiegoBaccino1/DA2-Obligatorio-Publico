import { Component, OnInit } from '@angular/core';
import { Hospedaje } from '../../Models/hospedaje/hospedaje';
import { HospedajeService } from '../services/hospedaje-service.service';
import { ActivatedRoute } from '@angular/router';
import { PuntoTuristico } from '../../Models/Punto/punto';

@Component({
  selector: 'app-detalles-hospedaje',
  templateUrl: './detalles-hospedaje.component.html',
  styleUrls: ['./detalles-hospedaje.component.css']
})
export class DetallesHospedajeComponent implements OnInit {

  hospedaje;
  punto;
  constructor(private services: HospedajeService, private currentRoute: ActivatedRoute) {
  }

  ngOnInit(): void {
    const id = +this.currentRoute.snapshot.params['id'];
    this.services.obtenerPorId(id).subscribe(
      (res) => {
        this.hospedaje = res;
        this.punto = this.hospedaje.punto;
      },
      (err) => {
        alert('Hubo un error');
        console.log(err);
      }
    );
  }
}
