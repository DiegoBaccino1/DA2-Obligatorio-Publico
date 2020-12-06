import { Component, OnInit } from '@angular/core';
import { ReservaService } from '../Services/reserva.service';
import { ActivatedRoute, Router } from '@angular/router';
import { Reserva } from 'src/app/Models/Reserva/reserva';
import { environment } from 'src/environments/environment';
import { Resenia } from '../../Models/Resenia/resenia';
import { DatosUsuario } from '../../Models/Datos/DatosUsuario/datos-usuario';

@Component({
  selector: 'app-agregar-resenia',
  templateUrl: './agregar-resenia.component.html',
  styleUrls: ['./agregar-resenia.component.css']
})
export class AgregarReseniaComponent implements OnInit {
  puntaje: number;
  resenia: string;
  reserva: Reserva;
  constructor(private services: ReservaService, private currentRoute: ActivatedRoute, private router: Router) { }

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
  ingresarResenia(): void {
    const datos = new DatosUsuario(this.reserva.nombreTurista, this.reserva.mailTurista, this.reserva.apellidoTurista);
    const resenia = new Resenia(0, this.puntaje, this.resenia, datos);
    this.services.agregarResenia(this.reserva.id, resenia).subscribe(
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
