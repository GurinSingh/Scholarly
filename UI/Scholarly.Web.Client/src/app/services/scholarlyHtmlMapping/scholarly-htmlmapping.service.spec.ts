import { TestBed } from '@angular/core/testing';

import { ScholarlyHTMLMappingService } from './scholarly-htmlmapping.service';

describe('ScholarlyHTMLMappingService', () => {
  let service: ScholarlyHTMLMappingService;

  beforeEach(() => {
    TestBed.configureTestingModule({});
    service = TestBed.inject(ScholarlyHTMLMappingService);
  });

  it('should be created', () => {
    expect(service).toBeTruthy();
  });
});
