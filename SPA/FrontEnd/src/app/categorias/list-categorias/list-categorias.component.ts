import { Component, OnInit } from '@angular/core';
import { Categoria } from '../../Models/Categoria/categoria';
import { CategoriaService } from '../Services/categoria.service';
import { Router } from '@angular/router';

@Component({
  selector: 'app-list-categorias',
  templateUrl: './list-categorias.component.html',
  styleUrls: ['./list-categorias.component.css']
})
export class ListCategoriasComponent implements OnInit {
  categorias;
  constructor(private services: CategoriaService, private router: Router) {
    this.categorias = [];
  }

  ngOnInit(): void {
    this.services.getAllCategorias().subscribe(
      (res) => {
        console.log(res.id);
        console.log(res.nombre);
        console.log(res.puntosTuristicosCategoria);
        this.categorias = res;
        console.log(res);
      },
      (err) => {
        alert('algo salio mal');
        console.log(err);
      }
    );
  }

  borrar(id: number): void {
    this.services.borrar(id).subscribe(
      (res) => {
        alert('Borrado con exito.');
        this.ngOnInit();
      },
      (err) => {
        console.log('Algo salio mal');
      });
  }

  modificar(id: number): void {
    this.router.navigate(['/modificarCategoria', id]);
  }

  obtenerPorId(id: number): void {
    this.router.navigate(['/categorias', id]);
  }
  crear(): void {
    this.router.navigate(['/new-categoria']);
  }
}
