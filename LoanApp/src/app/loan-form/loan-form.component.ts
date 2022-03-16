import { Component, EventEmitter, OnInit, Output } from "@angular/core";
import {
  FormBuilder,
  FormGroup,
  Validators,
  ReactiveFormsModule,
  FormControl,
} from "@angular/forms";
import { LoanCalculatorService } from "../loan-calculator.service";
import { LoanConfig, PaymentSchedule } from "../payment-schedule";

@Component({
  selector: "app-loan-form",
  templateUrl: "./loan-form.component.html",
  styleUrls: ["./loan-form.component.scss"],
})
export class LoanFormComponent implements OnInit {
  loanForm: FormGroup;

  @Output() paymentSchedule = new EventEmitter<PaymentSchedule>();
  constructor(
    private formBuilder: FormBuilder,
    private loanService: LoanCalculatorService
  ) {}
  amount = new FormControl("", [Validators.required, Validators.min(1)]);

  getAmountErrorMessage() {
    if (this.amount.hasError("required")) {
      return "Amount is required";
    }

    return this.amount.hasError("min") ? "Value must be greater than 0" : "";
  }
  years = new FormControl("", [Validators.required, Validators.min(1)]);

  getYearsErrorMessage() {
    if (this.years.hasError("required")) {
      return "Years is required";
    }

    return this.years.hasError("min") ? "Value must be greater than 0" : "";
  }
  ngOnInit(): void {}

  clearForm(): void {
    this.amount.reset();
    this.years.reset();
  }
  getSchedule(): void {
    if (
      !this.amount ||
      this.amount.invalid ||
      !this.years ||
      this.years.invalid
    ) {
      return;
    }
    const data = new LoanConfig();
    data.amount = this.amount.value;
    data.years = this.years.value;
    this.loanService.fetchSchedule(data).subscribe((response) => {
      this.paymentSchedule.emit(response);
    });
  }
}
