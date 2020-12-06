import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { FiltrarHospedajeComponent } from './filtrar-hospedaje.component';

describe('FiltrarHospedajeComponent', () => {
  let component: FiltrarHospedajeComponent;
  let fixture: ComponentFixture<FiltrarHospedajeComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ FiltrarHospedajeComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(FiltrarHospedajeComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
