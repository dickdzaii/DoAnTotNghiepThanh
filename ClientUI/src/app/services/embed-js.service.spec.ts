import { TestBed } from '@angular/core/testing';

import { EmbedJsService } from './embed-js.service';

describe('EmbedJsService', () => {
  let service: EmbedJsService;

  beforeEach(() => {
    TestBed.configureTestingModule({});
    service = TestBed.inject(EmbedJsService);
  });

  it('should be created', () => {
    expect(service).toBeTruthy();
  });
});
