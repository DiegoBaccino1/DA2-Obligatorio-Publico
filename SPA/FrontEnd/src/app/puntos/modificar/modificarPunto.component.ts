import { Component, OnInit } from '@angular/core';
import { PuntoTuristico } from '../../Models/Punto/punto';
import { PuntosService } from '../services/puntos.service';
import { ActivatedRoute, Router } from '@angular/router';
import { Categoria } from '../../Models/Categoria/categoria';
import { CategoriaService } from '../../categorias/Services/categoria.service';
import { HttpClient } from '@angular/common/http';

@Component({
  selector: 'app-modificar',
  templateUrl: './modificarPunto.component.html',
  styleUrls: ['./modificarPunto.component.css']
})
export class ModificarPuntoComponent implements OnInit {
  nuevoNombre: string;
  nuevaDescripcion: string;
  categoriaId: number;
  punto;
  puntoCategorias; //::PuntoTuristicoCategoria
  todasCategorias; //::Categoria

  constructor(private services: PuntosService,
    private currentRoute: ActivatedRoute,
    private categoriaService: CategoriaService,
    private router: Router) { }

  ngOnInit(): void {
    let id = +this.currentRoute.snapshot.params["id"];
    this.categoriaService.getAllCategorias().subscribe(
      (res) => {
        this.todasCategorias = res;
        this.categoriaId = this.todasCategorias[0].id;
      },
      (err) => {
        alert('Hubo un error al cargar todas las categorias');
        console.log(err);
      }
    );

    this.services.obtenerPorId(id).subscribe(
      (res) => {
        this.punto = res;
        this.puntoCategorias = this.punto.puntosTuristicosCategoria;
        this.nuevaDescripcion = this.punto.descripcion;
        this.nuevoNombre = this.punto.nombre;
        console.log(res);
      },
      (err) => {
        alert('Hubo un error');
        console.log(err);
      }
    );
  }

  modificar(): void {
    this.punto.nombre = this.nuevoNombre;
    this.punto.descripcion = this.nuevaDescripcion;
    this.services.modificar(this.punto).subscribe(
      (res) => {
        this.router.navigate(['/puntos']);
      },
      (err) => {
        alert('Hubo un error');
        console.log(err);
      }
    );
  }

  change(categoriaId): void {
    this.categoriaId = categoriaId;
  }

  agregarCategoria(id: number): void {
    this.services.agregarCategoria(id, this.categoriaId).subscribe(
      (res) => {
        this.ngOnInit();
        console.log(res);
      },
      (err) => {
        alert('Hubo un error');
        console.log(err);
      }
    );
  }

}
