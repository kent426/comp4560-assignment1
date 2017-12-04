import { TestBed, inject } from '@angular/core/testing';

import { EventByWeekService } from './event-by-week.service';

describe('EventByWeekService', () => {
  beforeEach(() => {
    TestBed.configureTestingModule({
      providers: [EventByWeekService]
    });
  });

  it('should be created', inject([EventByWeekService], (service: EventByWeekService) => {
    expect(service).toBeTruthy();
  }));
});
