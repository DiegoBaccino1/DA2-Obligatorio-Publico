import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { HospedajeModel } from '../../Models/hospedaje/hospedaje-model';
import { HospedajeService } from '../services/hospedaje-service.service';

@Component({
  selector: 'app-new-hospedajes',
  templateUrl: './new-hospedajes.component.html',
  styleUrls: ['./new-hospedajes.component.css']
})
export class NewHospedajesComponent implements OnInit {
  nombre: string;
  desc: string;
  dir: string;
  capacidad: number;
  estrellas: number;
  precio: number;
  constructor(private service: HospedajeService, private router: Router) { }

  ngOnInit(): void {
  }
  crear(): void {
    let modelo = new HospedajeModel(this.nombre, this.desc, this.dir, this.estrellas, this.precio, 0, this.capacidad);
    this.service.crear(modelo).subscribe(
      (res)=>{
        this.router.navigate(['/hospedajes']);
      },
      (err)=>{
        alert('Hubo un error');
        console.log(err);
      }
    );
  }
}
