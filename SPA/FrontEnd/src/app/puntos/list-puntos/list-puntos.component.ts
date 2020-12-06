import { Component, OnInit } from '@angular/core';
import { PuntoTuristico } from '../../Models/Punto/punto';
import { PuntosService } from '../services/puntos.service';
import { Router } from '@angular/router';

@Component({
  selector: 'app-list-puntos',
  templateUrl: './list-puntos.component.html',
  styleUrls: ['./list-puntos.component.css']
})
export class ListPuntosComponent implements OnInit {
  puntos;
  constructor(private service: PuntosService, private router: Router) { }

  ngOnInit(): void {
    this.service.getAllPuntos().subscribe(
      (res) => {
        this.puntos = res;
      },
      (err) => {
        alert('Hubo un error');
        console.log(err);
      }
    );
  }
  crear(): void {
    this.router.navigate(['/new-punto']);
  }
  obtenerPorId(id: number): void {
    this.router.navigate(['/puntos', id]);
  }
  borrar(id: number): void {
    this.service.borrar(id).subscribe(
      (res)=>{
        this.ngOnInit();
      },
      (err)=>{
        alert('Algo salio mal');
        console.log(err);
      }
    );
  }
  modificar(id: number): void {
    this.router.navigate(['/modificarPunto', id]);
  }

  filtrar(): void {
    this.router.navigate(['/filtro']);
  }
}
