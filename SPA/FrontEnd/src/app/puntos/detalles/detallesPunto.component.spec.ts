import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { DetallesPuntoComponent } from './detallesPunto.component';

describe('DetallesComponent', () => {
  let component: DetallesPuntoComponent;
  let fixture: ComponentFixture<DetallesPuntoComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ DetallesPuntoComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(DetallesPuntoComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
