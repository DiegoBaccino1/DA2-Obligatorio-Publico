import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { AgregarReseniaComponent } from './agregar-resenia.component';

describe('AgregarReseniaComponent', () => {
  let component: AgregarReseniaComponent;
  let fixture: ComponentFixture<AgregarReseniaComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ AgregarReseniaComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(AgregarReseniaComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
