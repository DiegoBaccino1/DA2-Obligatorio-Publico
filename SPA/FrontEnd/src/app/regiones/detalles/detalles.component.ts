import { Component, OnInit } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { RegionService } from '../Services/region.service';
import { Region } from '../../Models/Region/region';
import { PuntoTuristico } from '../../Models/Punto/punto';

@Component({
  selector: 'app-detalles',
  templateUrl: './detalles.component.html',
  styleUrls: ['./detalles.component.css']
})
export class DetallesComponent implements OnInit {

  region: Region;
  puntos: PuntoTuristico[];
  constructor(private services: RegionService, private currentRoute: ActivatedRoute) { }

  ngOnInit(): void {
    let id = +this.currentRoute.snapshot.params['id'];
    this.services.obtenerPorId(id).subscribe(
      (res) => {
        this.region = res;
        console.log(res);
      },
      (err) => {
        alert('Hubo un error');
        console.log(err);
      }
    );
    this.puntos = this.region.puntos;
  }
}
