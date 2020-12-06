import { TestBed } from '@angular/core/testing';

import { IsLoggedGuardGuard } from './is-logged-guard.guard';

describe('IsLoggedGuardGuard', () => {
  let guard: IsLoggedGuardGuard;

  beforeEach(() => {
    TestBed.configureTestingModule({});
    guard = TestBed.inject(IsLoggedGuardGuard);
  });

  it('should be created', () => {
    expect(guard).toBeTruthy();
  });
});
