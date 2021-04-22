import { TestBed } from '@angular/core/testing';

import { DtitleService } from './dtitle.service';

describe('DtitleService', () => {
  let service: DtitleService;

  beforeEach(() => {
    TestBed.configureTestingModule({});
    service = TestBed.inject(DtitleService);
  });

  it('should be created', () => {
    expect(service).toBeTruthy();
  });
});
