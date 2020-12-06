import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { NewReservaComponent } from './new-reserva.component';

describe('NewReservaComponent', () => {
  let component: NewReservaComponent;
  let fixture: ComponentFixture<NewReservaComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ NewReservaComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(NewReservaComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
