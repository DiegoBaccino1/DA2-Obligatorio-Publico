import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { DetallesCategoriaComponent } from './detalles-categoria.component';

describe('DetallesCategoriaComponent', () => {
  let component: DetallesCategoriaComponent;
  let fixture: ComponentFixture<DetallesCategoriaComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ DetallesCategoriaComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(DetallesCategoriaComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
