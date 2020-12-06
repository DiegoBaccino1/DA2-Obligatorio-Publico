import { Component, OnInit } from '@angular/core';
import { PuntosService } from '../services/puntos.service';
import { Router } from '@angular/router';

@Component({
  selector: 'app-new-punto',
  templateUrl: './new-punto.component.html',
  styleUrls: ['./new-punto.component.css']
})
export class NewPuntoComponent implements OnInit {
  nombrePunto: string;
  descripcionPunto: string;
  constructor(private services: PuntosService, private router: Router) {
    this.descripcionPunto = '';
    this.nombrePunto = '';
  }

  ngOnInit(): void {
  }
  crear(): void {
    this.services.crear(this.nombrePunto, this.descripcionPunto).subscribe(
      (res) => {
        this.router.navigate(['/puntos']);
        console.log(res);
      },
      (err) => {
        alert('Hubo un error');
        console.log(err);
      }
    );
  }
}
