import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { ListHospedajesComponent } from './list-hospedajes.component';

describe('ListHospedajesComponent', () => {
  let component: ListHospedajesComponent;
  let fixture: ComponentFixture<ListHospedajesComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ ListHospedajesComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(ListHospedajesComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
