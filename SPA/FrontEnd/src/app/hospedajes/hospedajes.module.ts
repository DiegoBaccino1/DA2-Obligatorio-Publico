import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { ListHospedajesComponent } from './list-hospedajes/list-hospedajes.component';
import { NewHospedajesComponent } from './new-hospedajes/new-hospedajes.component';
import { ModificarHospedajeComponent } from './modificar-hospedaje/modificar-hospedaje.component';
import { FiltrarHospedajeComponent } from './filtrar-hospedaje/filtrar-hospedaje.component';
import { FormsModule } from '@angular/forms';
import { BorrarSegunPuntoComponent } from './borrar-segun-punto/borrar-segun-punto.component';
import { DetallesHospedajeComponent } from './detalles-hospedaje/detalles-hospedaje.component';
import { AsociarHospedajePuntoComponent } from './asociar-hospedaje-punto/asociar-hospedaje-punto.component';
import { CambiarCapacidadHospedajeComponent } from './cambiar-capacidad-hospedaje/cambiar-capacidad-hospedaje.component';
import { ImportarComponent } from './importar/importar/importar.component';



@NgModule({
  declarations: [ListHospedajesComponent, NewHospedajesComponent, ModificarHospedajeComponent,FiltrarHospedajeComponent, BorrarSegunPuntoComponent,
     DetallesHospedajeComponent, AsociarHospedajePuntoComponent, CambiarCapacidadHospedajeComponent, ImportarComponent],
  imports: [
    CommonModule,
    FormsModule
  ],
  exports: [ListHospedajesComponent, NewHospedajesComponent, ModificarHospedajeComponent,FiltrarHospedajeComponent, BorrarSegunPuntoComponent,
     DetallesHospedajeComponent, AsociarHospedajePuntoComponent, CambiarCapacidadHospedajeComponent, ImportarComponent]
})
export class HospedajesModule { }
