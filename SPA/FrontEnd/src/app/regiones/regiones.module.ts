import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { ListRegionesComponent } from './list-regiones/list-regiones.component';
import { ModificarComponent } from './modificar/modificar.component';
import { AsociarComponent } from './asociar/asociar.component';
import { DetallesComponent } from './detalles/detalles.component';
import { FormsModule } from '@angular/forms';
import { NewRegionComponent } from './new-region/new-region.component';



@NgModule({
  declarations: [ListRegionesComponent, ModificarComponent, AsociarComponent, DetallesComponent, NewRegionComponent],
  imports: [
    CommonModule,
    FormsModule
  ],
  exports: [ListRegionesComponent, ModificarComponent, AsociarComponent, DetallesComponent, NewRegionComponent]
})
export class RegionesModule { }
