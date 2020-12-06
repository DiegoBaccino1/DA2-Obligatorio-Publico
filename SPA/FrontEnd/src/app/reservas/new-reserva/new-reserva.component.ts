import { Component, OnInit } from '@angular/core';
import { HospedajeFiltro } from '../../Models/HospedajeFiltro/hospedaje-filtro';
import { DataService } from '../../CommonService/data.service';
import { ActivatedRoute, Router } from '@angular/router';
import { ObjetoPostReserva } from '../../Models/ObetoPostReserva/objeto-post-reserva';
import { DatosUsuario } from 'src/app/Models/Datos/DatosUsuario/datos-usuario';
import { ReservaService } from '../Services/reserva.service';
import { environment } from 'src/environments/environment';

@Component({
  selector: 'app-new-reserva',
  templateUrl: './new-reserva.component.html',
  styleUrls: ['./new-reserva.component.css']
})
export class NewReservaComponent implements OnInit {
  filtro: HospedajeFiltro;
  nombreTurista: string;
  mailTurista: string;
  apellidoTurista: string;
  hospedajeId: number;

  constructor(private service: ReservaService, private dataService: DataService,
    private currentRoute: ActivatedRoute, private router: Router) { }

  ngOnInit(): void {
    this.dataService.currentFiltro.subscribe(filtro => this.filtro = filtro);
    this.hospedajeId = +this.currentRoute.snapshot.params['id'];
  }
  reservar() {
    const datos = new DatosUsuario(this.nombreTurista, this.mailTurista, this.apellidoTurista);
    const objeto = new ObjetoPostReserva(this.filtro, datos, this.hospedajeId);
    this.service.crear(objeto).subscribe(
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
