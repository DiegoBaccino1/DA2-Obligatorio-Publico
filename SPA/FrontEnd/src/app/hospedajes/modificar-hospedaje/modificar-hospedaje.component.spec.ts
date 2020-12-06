import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { ModificarHospedajeComponent } from './modificar-hospedaje.component';

describe('ModificarHospedajeComponent', () => {
  let component: ModificarHospedajeComponent;
  let fixture: ComponentFixture<ModificarHospedajeComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ ModificarHospedajeComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(ModificarHospedajeComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
