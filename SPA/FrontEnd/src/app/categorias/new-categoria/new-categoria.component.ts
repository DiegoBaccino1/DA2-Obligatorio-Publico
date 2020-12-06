import { Component, OnInit } from '@angular/core';
import { CategoriaService } from '../Services/categoria.service';
import { Router } from '@angular/router';

@Component({
  selector: 'app-new-categoria',
  templateUrl: './new-categoria.component.html',
  styleUrls: ['./new-categoria.component.css']
})
export class NewCategoriaComponent implements OnInit {
  nombre: string;
  constructor(private services: CategoriaService, private router: Router) { }

  ngOnInit(): void {
  }
  crear(): void {
    this.services.crear(this.nombre).subscribe(
      (res) => {
        this.router.navigate(['/categorias']);
      },
      (err) => {
        alert("Algo salio mal....");
        console.log(err);
      }
    );
  }
}
