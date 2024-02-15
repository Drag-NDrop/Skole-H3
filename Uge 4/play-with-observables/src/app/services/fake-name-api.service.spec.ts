import { TestBed } from '@angular/core/testing';

import { FakeNameApiService } from './fake-name-api.service';

describe('FakeNameApiService', () => {
  let service: FakeNameApiService;

  beforeEach(() => {
    TestBed.configureTestingModule({});
    service = TestBed.inject(FakeNameApiService);
  });

  it('should be created', () => {
    expect(service).toBeTruthy();
  });
});
