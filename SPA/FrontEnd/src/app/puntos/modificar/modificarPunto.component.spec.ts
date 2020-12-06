import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { ModificarPuntoComponent } from './modificarPunto.component';

describe('ModificarPuntoComponent', () => {
  let component: ModificarPuntoComponent;
  let fixture: ComponentFixture<ModificarPuntoComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ ModificarPuntoComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(ModificarPuntoComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
