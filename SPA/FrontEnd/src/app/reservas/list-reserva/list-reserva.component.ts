import { Component, OnInit } from '@angular/core';
import { Reserva } from '../../Models/Reserva/reserva';
import { ReservaService } from '../Services/reserva.service';
import { Router } from '@angular/router';

@Component({
  selector: 'app-list-reserva',
  templateUrl: './list-reserva.component.html',
  styleUrls: ['./list-reserva.component.css']
})
export class ListReservaComponent implements OnInit {
  reservas;
  constructor(private service: ReservaService, private router: Router) { }

  ngOnInit(): void {
    this.service.getAllReservas().subscribe(
      (res) => {
        this.reservas = res;
      },
      (err) => {
        alert('Hubo un error en la carga de reservas');
        console.log(err);
      }
    );
  }

  borrar(id: number): void {
    this.service.borrar(id).subscribe(
      (res) => {
        this.ngOnInit();
      },
      (err) => {
        alert('Hubo un error en borrar la reservas');
        console.log(err);
      }
    );
  }

  modificar(id: number): void {
    this.router.navigate(['/modificar-reserva', id]);
  }

  obtenerPorId(id: number): void {
    this.router.navigate(['/reservas', id]);
  }
  reporte(): void {
    this.router.navigate(['/generar-reporte']);
  }
  resenia(id: number): void {
    this.router.navigate(['/resenia', id]);
  }
}
