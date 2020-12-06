import { Component, OnInit } from '@angular/core';
import { Categoria } from '../../Models/Categoria/categoria';
import { CategoriaService } from '../Services/categoria.service';
import { ActivatedRoute } from '@angular/router';

@Component({
  selector: 'app-modificar-categorias',
  templateUrl: './modificar-categorias.component.html',
  styleUrls: ['./modificar-categorias.component.css']
})
export class ModificarCategoriasComponent implements OnInit {
  categoria: Categoria;
  nuevoNombre: string;
  constructor(private services: CategoriaService, private currentRoute: ActivatedRoute) { }

  ngOnInit(): void {
    let id = +this.currentRoute.snapshot.params['id'];
    this.services.obtenerPorId(id).subscribe(
      (res) => {
        console.log(res.id);
        console.log(res.nombre);
        console.log(res.puntosTuristicosCategoria);
        this.categoria = res;
        console.log(res);
      },
      (err) => {
        alert("algo salio mal");
        console.log(err);
      }
    );
  }
  modificar(): void {

  }
}
