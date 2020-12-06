import { Component, OnInit } from '@angular/core';
import { PuntosService } from '../services/puntos.service';
import { PuntoTuristico } from '../../Models/Punto/punto';
import { ActivatedRoute } from '@angular/router';
import { Categoria } from '../../Models/Categoria/categoria';
import { PuntoTuristicoCategoria } from '../../Models/PuntoTuristicoCategoria/punto-turistico-categoria';

@Component({
  selector: 'app-detalles',
  templateUrl: './detallesPunto.component.html',
  styleUrls: ['./detallesPunto.component.css']
})
export class DetallesPuntoComponent implements OnInit {
  punto;
  categorias;
  constructor(private services: PuntosService, private currentRoute: ActivatedRoute) {
  }

  ngOnInit(): void {
    const id = +this.currentRoute.snapshot.params['id'];
    this.services.obtenerPorId(id).subscribe(
      (res) => {
        this.punto = res;
        this.categorias = this.punto.puntosTuristicosCategoria;
        console.log(res);
      },
      (err) => {
        alert('Hubo un error');
        console.log(err);
      }
    );
  }

}
