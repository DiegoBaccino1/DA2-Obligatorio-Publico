import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { Observable } from 'rxjs';
import { Region } from '../../Models/Region/region';
import { RegionService } from '../Services/region.service';

@Component({
  selector: 'app-list-regiones',
  templateUrl: './list-regiones.component.html',
  styleUrls: ['./list-regiones.component.css']
})
export class ListRegionesComponent implements OnInit {
  regiones;
  constructor(private service: RegionService, private router: Router) {
  }

  ngOnInit(): void {
    this.service.getAllRegiones().subscribe(
      (res) => {
        this.regiones = res;
        console.log(res);
      },
      (err) => {
        alert('Hubo un error');
        console.log(err);
      }
    );
  }

  crear(): void {
    this.router.navigate(['/new-region']);
  }
  obtenerPorId(id: number): void {
    this.router.navigate(['/detalles', id]);
  }
  borrar(id: number): void {
    this.service.borrar(id).subscribe(
      (res) => {
        alert('Borrado con exito.');
        this.ngOnInit();
      },
      (err) => {
        console.log('Algo salio mal');
      });
  }
  modificar(id: number): void {
    this.router.navigate(['/modificar', id]);
  }
  asociarPunto(id: number): void {
    this.router.navigate(['/asociar', id]);
  }
}
