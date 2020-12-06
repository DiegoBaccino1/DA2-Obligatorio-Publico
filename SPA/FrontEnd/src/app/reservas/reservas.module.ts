import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { NewReservaComponent } from './new-reserva/new-reserva.component';
import { ListReservaComponent } from './list-reserva/list-reserva.component';
import { ModificarReservaComponent } from './modificar-reserva/modificar-reserva.component';
import { AgregarReseniaComponent } from './agregar-resenia/agregar-resenia.component';
import { GenerarReporteComponent } from './generar-reporte/generar-reporte.component';
import { FormsModule } from '@angular/forms';
import { DetallesReservaComponent } from './detalles-reserva/detalles-reserva.component';



@NgModule({
  declarations: [NewReservaComponent, ListReservaComponent, ModificarReservaComponent,
     AgregarReseniaComponent, GenerarReporteComponent, DetallesReservaComponent],
  imports: [
    CommonModule,
    FormsModule
  ],
  exports: [NewReservaComponent, ListReservaComponent, ModificarReservaComponent,
     AgregarReseniaComponent, GenerarReporteComponent, DetallesReservaComponent],
})
export class ReservasModule { }
