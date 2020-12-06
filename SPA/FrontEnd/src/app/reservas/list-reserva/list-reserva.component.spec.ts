import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { ListReservaComponent } from './list-reserva.component';

describe('ListReservaComponent', () => {
  let component: ListReservaComponent;
  let fixture: ComponentFixture<ListReservaComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ ListReservaComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(ListReservaComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
