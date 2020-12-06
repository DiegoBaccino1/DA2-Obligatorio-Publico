import { Component, OnInit } from '@angular/core';
import { RegionService } from '../Services/region.service';
import { Router } from '@angular/router';

@Component({
  selector: 'app-new-region',
  templateUrl: './new-region.component.html',
  styleUrls: ['./new-region.component.css']
})
export class NewRegionComponent implements OnInit {
  nombreRegion: string;

  constructor(private services: RegionService, private router: Router) {
    this.nombreRegion = '';
  }

  ngOnInit(): void {
  }
  crear(): void {
    this.services.crear(this.nombreRegion).subscribe(
      (res) => {
        alert('Creado con exito');
        this.router.navigate(['/regiones']);
      },
      (err) => {
        alert('Algo salio mal....');
        console.log(err);
      }
    );
  }
}
