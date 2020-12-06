import { Component, OnInit } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { EstadoReserva } from 'src/app/Models/EstadoReserva/estado-reserva.enum';
import { Reserva } from 'src/app/Models/Reserva/reserva';
import { ReservaService } from '../Services/reserva.service';
import { environment } from '../../../environments/environment';

@Component({
  selector: 'app-modificar-reserva',
  templateUrl: './modificar-reserva.component.html',
  styleUrls: ['./modificar-reserva.component.css']
})
export class ModificarReservaComponent implements OnInit {
  reserva: Reserva;
  nuevoEstado: EstadoReserva;
  nuevaDescripcion: string;
  constructor(private services: ReservaService, private currentRoute: ActivatedRoute, private router: Router) {
    this.nuevaDescripcion = '';
  }

  ngOnInit(): void {
    const id = +this.currentRoute.snapshot.params['id'];
    this.services.obtenerPorId(id).subscribe(
      (res) => {
        this.reserva = res;
      },
      (err) => {
        alert(environment.mensajeDeError);
        console.log(err);
      }
    );
  }

  cambiarEstado(): void {
    this.services.cambiarEstado(this.reserva.id, this.nuevoEstado, this.nuevaDescripcion).subscribe(
      (res) => {
        this.router.navigate(['/reservas']);
      },
      (err) => {
        alert(environment.mensajeDeError);
        console.log(err);
      }
    );
  }
}
