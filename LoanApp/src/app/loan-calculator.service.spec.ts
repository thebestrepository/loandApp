import { TestBed } from "@angular/core/testing";

import { LoanCalculatorService } from "./loan-calculator.service";

describe("LoanCalculatorServiceService", () => {
  let service: LoanCalculatorService;

  beforeEach(() => {
    TestBed.configureTestingModule({});
    service = TestBed.inject(LoanCalculatorService);
  });

  it("should be created", () => {
    expect(service).toBeTruthy();
  });
});
