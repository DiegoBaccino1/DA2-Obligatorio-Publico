import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { NewPuntoComponent } from './new-punto.component';

describe('NewPuntoComponent', () => {
  let component: NewPuntoComponent;
  let fixture: ComponentFixture<NewPuntoComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ NewPuntoComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(NewPuntoComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
