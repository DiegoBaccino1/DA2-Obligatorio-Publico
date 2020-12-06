import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { FormsModule } from '@angular/forms';
import { RegionesModule } from './regiones/regiones.module';
import { LoginModule } from './login/login.module';
import { PuntosModule } from './puntos/puntos.module';
import { HospedajesModule } from './hospedajes/hospedajes.module';
import { CategoriaModule } from './categorias/categoria.module';
import { ReservasModule } from './reservas/reservas.module';
import {HttpClientModule} from '@angular/common/http';
import { FiltroJSONPipe } from './Pipes/Filtro/filtro-json.pipe';
import { JsonPipe } from '@angular/common';
import { ListUsuariosComponent } from './Usuarios/list-usuarios/list-usuarios.component';

@NgModule({
  declarations: [
    AppComponent,
    FiltroJSONPipe,
    ListUsuariosComponent,
  ],
  imports: [
    BrowserModule,
    FormsModule,
    AppRoutingModule,
    HttpClientModule,
    RegionesModule,
    PuntosModule,
    HospedajesModule,
    CategoriaModule,
    ReservasModule,
    LoginModule,
  ],
  providers: [JsonPipe],
  bootstrap: [AppComponent]
})
export class AppModule { }
