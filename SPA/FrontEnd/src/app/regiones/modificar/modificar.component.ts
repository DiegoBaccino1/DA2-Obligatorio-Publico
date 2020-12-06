import { Component, OnInit } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { RegionService } from '../Services/region.service';
import { Region } from '../../Models/Region/region';


@Component({
  selector: 'app-modificar',
  templateUrl: './modificar.component.html',
  styleUrls: ['./modificar.component.css']
})
export class ModificarComponent implements OnInit {
  nuevoNombre: string;
  region: Region;
  id: number;
  constructor(private services: RegionService, private currentRoute: ActivatedRoute, private router: Router) { }

  ngOnInit(): void {
    this.id = +this.currentRoute.snapshot.params["id"];
    this.services.obtenerPorId(this.id).subscribe(
      (res) => {
        this.region = res;
        console.log(res);
      },
      (err) => {
        alert('Hubo un error');
        console.log(err);
      }
    );
  }
  modificar(): void {
    this.services.modificar(this.id, this.nuevoNombre).subscribe(
      (res) => {
        console.log(res);
        this.router.navigate(['/regiones']);

      },
      (err) => {
        alert('Hubo un error');
        console.log(err);
      }
    );
  }
}
