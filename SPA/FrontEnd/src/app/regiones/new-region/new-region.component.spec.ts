import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { NewRegionComponent } from './new-region.component';

describe('NewRegionComponent', () => {
  let component: NewRegionComponent;
  let fixture: ComponentFixture<NewRegionComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ NewRegionComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(NewRegionComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
