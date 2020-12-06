import { Component, OnInit } from '@angular/core';
import { PuntoTuristico } from '../../Models/Punto/punto';
import { PuntosService } from '../services/puntos.service';
import { RegionService } from '../../regiones/Services/region.service';
import { CategoriaService } from '../../categorias/Services/categoria.service';
import { environment } from '../../../environments/environment';

@Component({
  selector: 'app-filtrado',
  templateUrl: './filtrado.component.html',
  styleUrls: ['./filtrado.component.css']
})
export class FiltradoComponent implements OnInit {
  puntos;
  regionId: number;
  categoriasId: number[];
  regiones;
  categorias;
  constructor(private services: PuntosService,
    private regionService: RegionService,
    private categoriaService: CategoriaService) {
    this.categoriasId = new Array();
  }

  ngOnInit(): void {
    this.regionService.getAllRegiones().subscribe(
      (res) => {
        this.regiones = res;
        this.regionId = this.regiones[0].id;
      },
      (err) => {
        alert('Error al cargar Regiones');
        console.log(err);
      }
    );
    this.categoriaService.getAllCategorias().subscribe(
      (res) => {
        this.categorias = res;
      },
      (err) => {
        alert('Error al cargar Categorias');
        console.log(err);
      }
    );
  }

  filtrar(): void {
    this.services.filtrar(this.regionId, this.categoriasId).subscribe(
      (res) => {
        this.puntos = res;
        console.log(res);
        this.ngOnInit();
      },
      (err) => {
        alert(environment.mensajeDeError);
        console.log(err);
      }
    );
  }

  changeRegion(regionId): void {
    this.regionId = regionId;
  }
  changeCategoria(categoriaId): void {
    this.categoriasId.push(categoriaId);
  }
}
