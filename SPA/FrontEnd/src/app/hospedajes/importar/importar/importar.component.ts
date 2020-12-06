import { Component, OnInit } from '@angular/core';
import { ImportadoresService } from '../../services/importadores/importadores.service';
import { environment } from 'src/environments/environment';
import { ConstantPool } from '@angular/compiler';
import { Router } from '@angular/router';

@Component({
  selector: 'app-importar',
  templateUrl: './importar.component.html',
  styleUrls: ['./importar.component.css']
})
export class ImportarComponent implements OnInit {
  importadores;
  path: string;
  importador: string;
  constructor(private service: ImportadoresService, private router: Router) { }

  ngOnInit(): void {
    this.service.getAllImportadores().subscribe(
      (res) => {
        this.importadores = res;
        this.importador = this.importadores[0];
      },
      (err) => {
        alert(environment.mensajeDeError);
        console.log(err);
      }
    );
  }

  change(importador): void {
    this.importador = importador;
  }

  importar(): void {
    alert(this.path + ' || ' + this.importador);
    this.service.importar(this.importador, this.path).subscribe(
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
