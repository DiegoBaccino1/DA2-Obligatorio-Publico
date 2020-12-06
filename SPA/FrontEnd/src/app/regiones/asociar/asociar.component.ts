import { Component, OnInit } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { PuntoTuristico } from 'src/app/Models/Punto/punto';
import { Region } from 'src/app/Models/Region/region';
import { RegionService } from '../Services/region.service';
import { PuntosService } from '../../puntos/services/puntos.service';

@Component({
  selector: 'app-asociar',
  templateUrl: './asociar.component.html',
  styleUrls: ['./asociar.component.css']
})
export class AsociarComponent implements OnInit {

  region: Region;
  regionId: number;
  puntosRegion: PuntoTuristico[];
  todosPuntos;
  puntoId: number;
  constructor(private services: RegionService,
    private currentRoute: ActivatedRoute,
    private router: Router,
    private puntoService: PuntosService) {
  }

  ngOnInit(): void {
    this.regionId = +this.currentRoute.snapshot.params['id'];
    this.services.obtenerPorId(this.regionId).subscribe(
      (res) => {
        this.region = res;
        this.puntosRegion = this.region.puntos;
        console.log(res);
      },
      (err) => {
        alert('Hubo un error');
        console.log(err);
      }
    );
    
    this.puntoService.getAllPuntos().subscribe(
      (res) => {
        this.todosPuntos = res;
        this.puntoId = this.todosPuntos[0].id;
      },
      (err) => {
        alert('Hubo un error');
        console.log(err);
      }
    );
  }
  change(puntoId): void {
    this.puntoId = puntoId;
  }

  asociar(): void {
    this.services.asociar(this.regionId, this.puntoId).subscribe(
      (res) => {
        this.router.navigate(['/regiones']);
      },
      (err) => {
        alert('Hubo un error');
        console.log(err);
      }
    );
  }
}
