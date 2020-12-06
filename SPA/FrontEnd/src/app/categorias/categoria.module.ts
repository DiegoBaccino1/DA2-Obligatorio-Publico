import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { ListCategoriasComponent } from './list-categorias/list-categorias.component';
import { ModificarCategoriasComponent } from './modificar-categorias/modificar-categorias.component';
import { DetallesCategoriaComponent } from './detalles-categoria/detalles-categoria.component';
import { FormsModule } from '@angular/forms';
import { NewCategoriaComponent } from './new-categoria/new-categoria.component';



@NgModule({
  declarations: [ListCategoriasComponent, ModificarCategoriasComponent, DetallesCategoriaComponent, NewCategoriaComponent],
  imports: [
    CommonModule,
    FormsModule
  ],
  exports: [ListCategoriasComponent, ModificarCategoriasComponent, DetallesCategoriaComponent]
})
export class CategoriaModule { }
