import { TestBed } from '@angular/core/testing';

import { RomanCalculatorService } from './roman-calculator.service';

describe('RomanCalculatorService', () => {
  let service: RomanCalculatorService;

  beforeEach(() => {
    TestBed.configureTestingModule({});
    service = TestBed.inject(RomanCalculatorService);
  });

  it('should be created', () => {
    expect(service).toBeTruthy();
  });
});
