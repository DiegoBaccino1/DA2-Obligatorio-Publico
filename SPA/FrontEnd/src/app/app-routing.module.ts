import { NgModule } from '@angular/core';
import { Routes, RouterModule, CanActivate } from '@angular/router';
import { LoginComponent } from './login/login.component';
import { ListRegionesComponent } from './regiones/list-regiones/list-regiones.component';
import { NewRegionComponent } from './regiones/new-region/new-region.component';
import { AppComponent } from './app.component';
import { DetallesComponent } from './regiones/detalles/detalles.component';
import { ModificarComponent } from './regiones/modificar/modificar.component';
import { AsociarComponent } from './regiones/asociar/asociar.component';
import { ListPuntosComponent } from './puntos/list-puntos/list-puntos.component';
import { DetallesPuntoComponent } from './puntos/detalles/detallesPunto.component';
import { NewPuntoComponent } from './puntos/new-punto/new-punto.component';
import { ModificarPuntoComponent } from './puntos/modificar/modificarPunto.component';
import { FiltradoComponent } from './puntos/filtrado/filtrado.component';
import { ListHospedajesComponent } from './hospedajes/list-hospedajes/list-hospedajes.component';
import { NewHospedajesComponent } from './hospedajes/new-hospedajes/new-hospedajes.component';
import { ModificarHospedajeComponent } from './hospedajes/modificar-hospedaje/modificar-hospedaje.component';
import { DetallesHospedajeComponent } from './hospedajes/detalles-hospedaje/detalles-hospedaje.component';
import { FiltrarHospedajeComponent } from './hospedajes/filtrar-hospedaje/filtrar-hospedaje.component';
import { BorrarSegunPuntoComponent } from './hospedajes/borrar-segun-punto/borrar-segun-punto.component';
import { ListCategoriasComponent } from './categorias/list-categorias/list-categorias.component';
import { DetallesCategoriaComponent } from './categorias/detalles-categoria/detalles-categoria.component';
import { ModificarCategoriasComponent } from './categorias/modificar-categorias/modificar-categorias.component';
import { NewCategoriaComponent } from './categorias/new-categoria/new-categoria.component';
import { ListReservaComponent } from './reservas/list-reserva/list-reserva.component';
import { ModificarReservaComponent } from './reservas/modificar-reserva/modificar-reserva.component';
import { GenerarReporteComponent } from './reservas/generar-reporte/generar-reporte.component';
import { NewReservaComponent } from './reservas/new-reserva/new-reserva.component';
import { DetallesReservaComponent } from './reservas/detalles-reserva/detalles-reserva.component';
import { AgregarReseniaComponent } from './reservas/agregar-resenia/agregar-resenia.component';
import { AsociarHospedajePuntoComponent } from './hospedajes/asociar-hospedaje-punto/asociar-hospedaje-punto.component';
import { CambiarCapacidadHospedajeComponent } from './hospedajes/cambiar-capacidad-hospedaje/cambiar-capacidad-hospedaje.component';
import { ImportarComponent } from './hospedajes/importar/importar/importar.component';
import { ListUsuariosComponent } from './Usuarios/list-usuarios/list-usuarios.component';
import { IsLoggedGuardGuard } from './Guards/is-logged-guard.guard';

const routes: Routes = [
  { path: 'usuarios', component: ListUsuariosComponent, canActivate: [IsLoggedGuardGuard] },
  { path: 'login', component: LoginComponent },
  { path: 'regiones', component: ListRegionesComponent },
  { path: 'new-region', component: NewRegionComponent },
  { path: 'detalles/:id', component: DetallesComponent },
  { path: 'modificar/:id', component: ModificarComponent },
  { path: 'asociar/:id', component: AsociarComponent },
  { path: 'puntos', component: ListPuntosComponent },
  { path: 'puntos/:id', component: DetallesPuntoComponent },
  { path: 'new-punto', component: NewPuntoComponent },
  { path: 'modificarPunto/:id', component: ModificarPuntoComponent },
  { path: 'filtro', component: FiltradoComponent },
  { path: 'hospedajes', component: ListHospedajesComponent },
  { path: 'new-hospedaje', component: NewHospedajesComponent },
  { path: 'modificarHospedaje/:id', component: ModificarHospedajeComponent },
  { path: 'hospedajes/:id', component: DetallesHospedajeComponent },
  { path: 'buscar-hospedajes', component: FiltrarHospedajeComponent },
  { path: 'borrar-segun-punto', component: BorrarSegunPuntoComponent },
  { path: 'HospedajePunto/:id', component: AsociarHospedajePuntoComponent },
  { path: 'cambiarCapacidad/:id', component: CambiarCapacidadHospedajeComponent },
  { path: 'importadores', component: ImportarComponent },
  { path: 'categorias', component: ListCategoriasComponent },
  { path: 'new-categoria', component: NewCategoriaComponent },
  { path: 'categorias/:id', component: DetallesCategoriaComponent },
  { path: 'modificarCategoria/:id', component: ModificarCategoriasComponent },
  { path: 'reservas', component: ListReservaComponent },
  { path: 'reservas/:id', component: DetallesReservaComponent },
  { path: 'modificar-reserva/:id', component: ModificarReservaComponent },
  { path: 'generar-reporte', component: GenerarReporteComponent },
  { path: 'new-reserva/:id', component: NewReservaComponent },
  { path: 'resenia/:id', component: AgregarReseniaComponent },
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
