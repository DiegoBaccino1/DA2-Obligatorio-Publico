import { Component, OnInit } from '@angular/core';
import { Hospedaje } from '../../Models/hospedaje/hospedaje';
import { HospedajeService } from '../services/hospedaje-service.service';
import { Router } from '@angular/router';

@Component({
  selector: 'app-list-hospedajes',
  templateUrl: './list-hospedajes.component.html',
  styleUrls: ['./list-hospedajes.component.css']
})
export class ListHospedajesComponent implements OnInit {
  hospedajes;
  constructor(private services: HospedajeService, private router: Router) {
  }

  ngOnInit(): void {
    this.services.getAllHospedaje().subscribe(
      (res) => {
        this.hospedajes = res;
      },
      (err) => {
        alert('Hubo un error');
        console.log(err);
      }
    );
  }

  crear(): void {
    this.router.navigate(['/new-hospedaje']);
  }
  obtenerPorId(id: number): void {
    this.router.navigate(['/hospedajes', id]);
  }

  borrar(id: number): void {
    this.services.borrar(id).subscribe(
      (res) => {
        this.ngOnInit();
      },
      (err) => {
        alert('Hubo un error');
        console.log(err);
      }
    );
  }
  cambiarCapacidad(id: number) {
    this.router.navigate(['/cambiarCapacidad', id]);
  }
  borrarSegunPunto(): void {
    this.router.navigate(['/borrar-segun-punto']);
  }
  modificar(id: number): void {
    this.router.navigate(['/modificarHospedaje', id]);
  }
  filtrar(): void {
    this.router.navigate(['/buscar-hospedajes']);
  }
  asociar(id: number): void {
    this.router.navigate(['/HospedajePunto', id]);
  }
  importadores(): void {
    this.router.navigate(['/importadores']);
  }
}
