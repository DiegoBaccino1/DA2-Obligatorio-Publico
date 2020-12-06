import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { CambiarCapacidadHospedajeComponent } from './cambiar-capacidad-hospedaje.component';

describe('CambiarCapacidadHospedajeComponent', () => {
  let component: CambiarCapacidadHospedajeComponent;
  let fixture: ComponentFixture<CambiarCapacidadHospedajeComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ CambiarCapacidadHospedajeComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(CambiarCapacidadHospedajeComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
