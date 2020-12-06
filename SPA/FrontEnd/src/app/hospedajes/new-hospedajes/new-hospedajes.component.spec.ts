import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { NewHospedajesComponent } from './new-hospedajes.component';

describe('NewHospedajesComponent', () => {
  let component: NewHospedajesComponent;
  let fixture: ComponentFixture<NewHospedajesComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ NewHospedajesComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(NewHospedajesComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
