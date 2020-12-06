import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { AsociarHospedajePuntoComponent } from './asociar-hospedaje-punto.component';

describe('AsociarHospedajePuntoComponent', () => {
  let component: AsociarHospedajePuntoComponent;
  let fixture: ComponentFixture<AsociarHospedajePuntoComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ AsociarHospedajePuntoComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(AsociarHospedajePuntoComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
