import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { ListPuntosComponent } from './list-puntos/list-puntos.component';
import { NewPuntoComponent } from './new-punto/new-punto.component';
import { DetallesPuntoComponent } from './detalles/detallesPunto.component';
import { FiltradoComponent } from './filtrado/filtrado.component';
import { ModificarPuntoComponent } from './modificar/modificarPunto.component';
import { FormsModule } from '@angular/forms';


@NgModule({
  declarations: [ListPuntosComponent, NewPuntoComponent,
    ModificarPuntoComponent, DetallesPuntoComponent, FiltradoComponent],
  imports: [
    CommonModule,
    FormsModule
  ],
  exports: [ListPuntosComponent, NewPuntoComponent, ModificarPuntoComponent, DetallesPuntoComponent, FiltradoComponent]
})
export class PuntosModule { }
