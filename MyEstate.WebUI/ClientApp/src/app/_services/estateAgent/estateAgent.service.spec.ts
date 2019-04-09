/* tslint:disable:no-unused-variable */

import { TestBed, async, inject } from '@angular/core/testing';
import { EstateAgentService } from './estateAgent.service';

describe('Service: EstateAgent', () => {
  beforeEach(() => {
    TestBed.configureTestingModule({
      providers: [EstateAgentService]
    });
  });

  it('should ...', inject([EstateAgentService], (service: EstateAgentService) => {
    expect(service).toBeTruthy();
  }));
});
