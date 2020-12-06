import { Component, OnInit } from '@angular/core';
import { Hospedaje } from 'src/app/Models/hospedaje/hospedaje';
import { HospedajeService } from '../services/hospedaje-service.service';
import { ActivatedRoute, Router } from '@angular/router';
import { HospedajeModel } from '../../Models/hospedaje/hospedaje-model';

@Component({
  selector: 'app-modificar-hospedaje',
  templateUrl: './modificar-hospedaje.component.html',
  styleUrls: ['./modificar-hospedaje.component.css']
})
export class ModificarHospedajeComponent implements OnInit {
  hospedaje: Hospedaje;
  nuevoNombre: string;
  nuevaDesc: string;
  nuevaDir: string;
  nuevaCapacidad: number;
  nuevaCantEstrellas: number;
  nuevoPrecio: number;
  Id: number;
  constructor(private services: HospedajeService, private currentRoute: ActivatedRoute, private router: Router) { }

  ngOnInit(): void {
    this.Id = +this.currentRoute.snapshot.params["id"];
    this.services.obtenerPorId(this.Id).subscribe(
      (res) => {
        this.hospedaje = res;
      },
      (err) => {
        alert('Hubo un error');
        console.log(err);
      }
    );
  }
  modificar(): void {
    const modelo = new HospedajeModel(this.nuevoNombre, this.nuevaDesc, this.nuevaDir,
      this.nuevaCantEstrellas, this.nuevoPrecio, 0, this.nuevaCapacidad);
    this.services.modificar(this.Id, modelo).subscribe(
      (res) => {
        this.router.navigate(['/hospedajes']);
      },
      (err) => {
        alert('Hubo un error');
        console.log(err);
      }
    );
  }
}
