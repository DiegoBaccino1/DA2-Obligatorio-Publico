import { Component, OnInit } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { environment } from '../../../environments/environment';
import { HospedajeService } from '../services/hospedaje-service.service';

@Component({
  selector: 'app-cambiar-capacidad-hospedaje',
  templateUrl: './cambiar-capacidad-hospedaje.component.html',
  styleUrls: ['./cambiar-capacidad-hospedaje.component.css']
})
export class CambiarCapacidadHospedajeComponent implements OnInit {
  nuevaCapacidad: number;
  hospedaje;

  constructor(private services: HospedajeService, private currentRoute: ActivatedRoute,
    private router: Router) {
  }

  ngOnInit(): void {
    const id = +this.currentRoute.snapshot.params['id'];
    this.services.obtenerPorId(id).subscribe(
      (res) => {
        this.hospedaje = res;
      },
      (err) => {
        alert(environment.mensajeDeError);
        console.log(err);
      }
    );
  }
  cambiarCapacidad(): void {
    this.services.cambiarCapacidad(this.hospedaje.id, this.nuevaCapacidad).subscribe(
      (res) => {
        this.router.navigate(['/hospedajes']);
      },
      (err) => {
        alert(environment.mensajeDeError);
        console.log(err);
      }
    );
  }

}
