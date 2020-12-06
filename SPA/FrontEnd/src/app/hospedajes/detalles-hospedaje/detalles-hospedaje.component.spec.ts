import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { DetallesHospedajeComponent } from './detalles-hospedaje.component';

describe('DetallesHospedajeComponent', () => {
  let component: DetallesHospedajeComponent;
  let fixture: ComponentFixture<DetallesHospedajeComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ DetallesHospedajeComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(DetallesHospedajeComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
