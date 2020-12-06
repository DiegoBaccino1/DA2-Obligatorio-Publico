import { Component, OnInit } from '@angular/core';
import { ReservaService } from '../Services/reserva.service';
import { ActivatedRoute } from '@angular/router';
import { Reserva } from '../../Models/Reserva/reserva';

@Component({
  selector: 'app-detalles-reserva',
  templateUrl: './detalles-reserva.component.html',
  styleUrls: ['./detalles-reserva.component.css']
})
export class DetallesReservaComponent implements OnInit {
  reserva;
  constructor(private services: ReservaService, private currentRoute: ActivatedRoute) { }

  ngOnInit(): void {
    let id = +this.currentRoute.snapshot.params['id'];
    this.services.obtenerPorId(id).subscribe(
      (res) => {
        this.reserva = res;
      },
      (err) => {
        alert('Hubo un error en la carga de la reserva');
        console.log(err);
      }
    );
  }
}
