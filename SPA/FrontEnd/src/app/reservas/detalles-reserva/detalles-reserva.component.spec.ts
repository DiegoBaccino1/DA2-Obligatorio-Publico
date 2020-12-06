import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { DetallesReservaComponent } from './detalles-reserva.component';

describe('DetallesReservaComponent', () => {
  let component: DetallesReservaComponent;
  let fixture: ComponentFixture<DetallesReservaComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ DetallesReservaComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(DetallesReservaComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
