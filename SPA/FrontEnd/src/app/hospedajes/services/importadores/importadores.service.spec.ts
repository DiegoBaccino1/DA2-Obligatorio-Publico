import { TestBed } from '@angular/core/testing';

import { ImportadoresService } from './importadores.service';

describe('ImportadoresService', () => {
  let service: ImportadoresService;

  beforeEach(() => {
    TestBed.configureTestingModule({});
    service = TestBed.inject(ImportadoresService);
  });

  it('should be created', () => {
    expect(service).toBeTruthy();
  });
});
