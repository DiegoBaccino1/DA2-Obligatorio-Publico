import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { BorrarSegunPuntoComponent } from './borrar-segun-punto.component';

describe('BorrarSegunPuntoComponent', () => {
  let component: BorrarSegunPuntoComponent;
  let fixture: ComponentFixture<BorrarSegunPuntoComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ BorrarSegunPuntoComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(BorrarSegunPuntoComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
